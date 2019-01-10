using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Nodes;
using ICSharpCode.TextEditor;
using Newtonsoft.Json;
using QY.DBtools.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QY.DBtools
{
    public partial class FormMain : Form
    {
        private const int COLUMN_HEADER_CHECKBOX_WIDTH = 12;

        private const string HostsFileFilter = "主机列表 (*.hosts)|*.hosts";

        private static string ResultPageTitle = "执行信息({0})";

        private TextEditorControlEx _sourceControl;

        private ConcurrentQueue<Host> _hostsQueue;

        private WorkArguments _defaultWorkArguments;

        private BatchHandler _batchHandler;

        private ResultPage _statusPage;

        private List<ResultPage> _dataPages;

        private int _checkedNodes;

        private DXMenuItem _rdpDXMenuItem;

        #region 构造器及创建编辑控件及主机列表数据源
        public FormMain()
        {
            InitializeComponent();
            CreateSourceControl();
            AppearanceObject.DefaultFont = this.Font;//解决XtraGrid导出PDF时中文乱码问题
            AppearanceObject.DefaultMenuFont = this.Font;
        }

        private void CreateSourceControl()
        {
            _sourceControl = new TextEditorControlEx
            {
                FoldingStrategy = "CSharp",
                Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                HideVScrollBarIfPossible = false,
                ShowVRuler = false,
                Dock = DockStyle.Fill,
                SyntaxHighlighting = "SQL",
                TabIndex = 0,
                VRulerRow = 999
            };
            gbSource.Controls.Add(_sourceControl);
        }

        private BindingList<Host> GetHostsDataSource()
        {
            var ds = tlHosts.DataSource;
            if (ds == null)
            {
                var lst = new BindingList<Host>();
                tlHosts.DataSource = lst;
                return lst;
            }
            return (BindingList<Host>)ds;
        }
        #endregion

        #region 工具栏-加载主机
        private void tsbHosts_ButtonClick(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = HostsFileFilter;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadHosts(ofd.FileName);
                }
            }
        }

        private void miHostsExcel_Click(object sender, EventArgs e)
        {
            string tip = "请在EXCEL中按如下列格式编辑服务器信息并复制:\n 连接名 | IP地址 | 端口号 | 登录用户名 | 登陆密码\n按 确定 后导入到列表中";
            if (MessageBox.Show(tip, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }
            if (Clipboard.ContainsText())
            {
                string s = Clipboard.GetText();
                var lst = GetHostsDataSource();
                using (var sr = new StringReader(s))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var args = line.Split('\t');
                        int port;
                        if (args != null && args.Length >= 5 && int.TryParse(args[2], out port) && port > 0)
                        {
                            var h = new Host()
                            {
                                Name = args[0],
                                Address = args[1],
                                Port = port,
                                User = args[3],
                                Password = args[4],
                            };
                            lst.Add(h);
                        }
                    }
                }
            }
            //MessageBox.Show("系统剪贴板中无有效数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void miHostsSave_Click(object sender, EventArgs e)
        {
            SaveHosts();
        }

        private void SaveHosts()
        {
            var lst = GetHostsDataSource();
            if (lst.Count == 0)
            {
                ShowInformation("列表中没有可保存的项目");
                return;
            }
            using (var fsd = new SaveFileDialog())
            {
                fsd.Filter = HostsFileFilter;
                if (fsd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string json = JsonConvert.SerializeObject(lst);
                File.WriteAllText(fsd.FileName, json);
            }
        }

        private void LoadHosts(string fileName)
        {
            string json = File.ReadAllText(fileName);
            var lst = JsonConvert.DeserializeObject<BindingList<Host>>(json);
            tlHosts.DataSource = lst;
            CheckedAll();
            SelectMainPage();
            tlHosts.Focus();
        }
        #endregion

        #region 工具栏-加载程序
        private void tsbFile_ButtonClick(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "SQL文件 (*.sql)|*.sql|C#源代码 (*.cs)|*.cs";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadFile(ofd.FileName);
                }
            }
        }

        private void miFileNewSql_Click(object sender, EventArgs e)
        {
            LoadTemplet("templet.sql");
        }

        private void miFileNewCSharp_Click(object sender, EventArgs e)
        {
            LoadTemplet("templet.cs");
        }

        private void miFileSave_Click(object sender, EventArgs e)
        {

        }

        private void LoadFile(string filePath)
        {
            _sourceControl.LoadFile(filePath);
            gbSource.Text = filePath;
            SelectMainPage();
            _sourceControl.Focus();
        }

        private void SelectMainPage()
        {
            tabMain.SelectedTabPageIndex = 0;
        }

        private void LoadTemplet(string fileName)
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Templets", fileName);
            if (!File.Exists(file))
            {
                ShowInformation("模板文件不存在:\n" + file);
                return;
            }
            LoadFile(file);
        }
        #endregion

        #region 执行过程
        private void tsbRun_Click(object sender, EventArgs e)
        {
            if (!IsWorkerIdle())
            {
                ShowInformation("上一次执行还未结束,请稍等...");
                return;
            }
            Execute();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            if (!IsWorkerIdle() && DialogResult.OK ==
                MessageBox.Show("正在执行任务,确定要尝试取消吗?", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                _batchHandler.CancelAll();
                tsbStop.Enabled = false;
                tsbStop.ToolTipText = "正在停止...";
            }
        }

        private bool IsWorkerIdle()
        {
            return _batchHandler == null || !_batchHandler.IsBusy;
        }

        private void Execute()
        {
            if (_checkedNodes <= 0)
            {
                tlHosts.Focus();
                ShowInformation("没有需要执行的主机");
                return;
            }
            string src = _sourceControl.Text;
            if (string.IsNullOrWhiteSpace(src))
            {
                _sourceControl.Focus();
                ShowInformation("没有可以执行的指令");
                return;
            }
            using (var fwa = new FormWorkArguments())
            {
                if (_defaultWorkArguments == null)
                {//TODO:从本地历史记录加载
                    _defaultWorkArguments = WorkArguments.CreateDefault();
                }
                fwa.Arguments = _defaultWorkArguments;
                if (fwa.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                if (_hostsQueue == null)
                {
                    _hostsQueue = new ConcurrentQueue<Host>();
                }
                else if (!_hostsQueue.IsEmpty)
                {//线程被取消后此集合可能不为空
                    while (_hostsQueue.TryDequeue(out Host r))
                    {
                    }
                }
                SuspendLayout();
                foreach (TreeListNode item in tlHosts.Nodes)
                {
                    var h = (Host)tlHosts.GetDataRecordByNode(item);
                    if (h.IsStatusChanged)
                    {
                        h.ResetStatus();
                        h.NotifyStatusChanged();
                    }
                    if (item.Visible && item.Checked)
                    {
                        _hostsQueue.Enqueue(h);
                    }
                }
                _defaultWorkArguments.Source = src;
                _defaultWorkArguments.Hosts = _hostsQueue;
                if (_batchHandler == null)
                {
                    _batchHandler = new BatchHandler
                    {
                        OnHostStatusChanged = OnHostStatusChanged,
                        OnHostMessage = OnHostMessage,
                        OnWorkersCompleted = OnWorkersCompleted
                    };
                }
                if (_statusPage == null)
                {
                    _statusPage = CreateResultPage(ResultPageTitle);
                    _statusPage.DataSource = BatchHandler.CreateResultTable();
                    _statusPage.Grid.CustomColumnDisplayText += Grid_CustomColumnDisplayText;
                    _statusPage.Grid.CustomDrawCell += Grid_CustomDrawCell;
                }
                else
                {
                    _statusPage.ClearData();
                }
                if (_dataPages != null)
                {
                    var pgs = tabMain.TabPages;
                    for (int i = pgs.Count - 1; i > 0; i--)
                    {
                        var pg = pgs[i];
                        if (pg.Controls[0] is ResultPage r && r != _statusPage)
                        {
                            pgs.RemoveAt(i);
                        }
                    }
                    _dataPages.Clear();
                }
                tlHosts.FocusedNode = tlHosts.Nodes.FirstNode;
                SetRunButtonStatus(false);
                ResumeLayout();
                _batchHandler.Execute(_defaultWorkArguments);
            }
        }

        private void Grid_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == nameof(HostMessage.Status))
            {
                switch ((MessageStatus)e.CellValue)
                {
                    case MessageStatus.None:
                    case MessageStatus.Info:
                        break;
                    case MessageStatus.Warning:
                    case MessageStatus.Error:
                    case MessageStatus.Stop:
                        e.Appearance.BackColor = Color.OrangeRed;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetRunButtonStatus(bool runEnabled)
        {
            tsbRun.Enabled = runEnabled;
            tsbStop.Enabled = !runEnabled;
        }

        private void Grid_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            var fn = e.Column.FieldName;
            if ((fn == nameof(HostMessage.AffectedRows) ||
                fn == nameof(HostMessage.ResultSet)) &&
                HostMessage.INVISIBLE_ROWS.Equals(e.Value))
            {
                e.DisplayText = string.Empty;
            }
        }
        #endregion

        #region 线程消息处理
        private void OnHostStatusChanged(Host obj)
        {
            obj.NotifyStatusChanged();
        }

        private void OnHostMessage(HostMessage obj)
        {
            var tb = obj.Table;
            if (tb == null)
            {
                _statusPage.AppendMessage(obj.Name, obj.Status, obj.Time, obj.Message, obj.AffectedRows, HostMessage.INVISIBLE_ROWS);
                return;
            }
            var rc = tb.Rows.Count;
            string msg;
            if (rc == obj.AffectedRows)
            {
                msg = "执行成功,返回数据行数:" + rc;
            }
            else
            {
                msg = "执行成功,返回数据最大行数:" + rc;
            }
            _statusPage.AppendMessage(obj.Name, obj.Status, obj.Time, msg, HostMessage.INVISIBLE_ROWS, rc);
            if (_dataPages == null)
            {
                _dataPages = new List<ResultPage>();
            }
            foreach (var item in _dataPages)
            {
                if (item.IsMatchTable(tb, obj.ResultSet))
                {
                    item.MergeDataSource(tb);
                    return;
                }
            }
            var pg = CreateResultPage("结果" + (obj.ResultSet + 1) + "({0})");
            _dataPages.Add(pg);
            pg.DataSource = tb;
            pg.ResultSetIndex = obj.ResultSet;
        }

        private void OnWorkersCompleted(TimeSpan span)
        {
            SetRunButtonStatus(true);
            tsbStop.ToolTipText = null;
            ShowInformation(string.Format("执行结束,耗时: {0}分{1}秒", (int)span.TotalMinutes, span.Seconds));
        }
        #endregion

        #region 公共方法
        private ResultPage CreateResultPage(string title)
        {
            var result = new ResultPage
            {
                Dock = DockStyle.Fill,
                TitleFormat = title
            };
            var pg = new XtraTabPage
            {
                Text = title,
                ShowCloseButton = DefaultBoolean.True
            };
            pg.Controls.Add(result);
            tabMain.TabPages.Add(pg);
            return result;
        }

        private void ShowInformation(string msg)
        {
            MessageBox.Show(this, msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region TreeList行指示器及选择状态
        private void tlHosts_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            DevExpress.Utils.Drawing.IndicatorObjectInfoArgs args = e.ObjectArgs as DevExpress.Utils.Drawing.IndicatorObjectInfoArgs;
            if (args != null && args.IsRowIndicator && !e.Node.Focused)
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                args.DisplayText = (tlHosts.Nodes.IndexOf(e.Node) + 1).ToString();
            }
        }

        private void tlHosts_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.Checked)
            {
                _checkedNodes++;
            }
            else
            {
                _checkedNodes--;
            }
        }

        private void gbHosts_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var idx = e.Button.Properties.VisibleIndex;
            if (idx == 0)
            {
                CheckedAll();
            }
            else if (idx == 1)
            {
                UncheckedAll();
            }
            else if (idx == 2)
            {
                CheckedErrorHosts();
            }
            else
            {
                SaveHosts();
            }
        }

        private void CheckedAll()
        {
            _checkedNodes = tlHosts.AllNodesCount;
            tlHosts.CheckAll();
        }

        /// <summary>
        /// 选中有错误的主机
        /// </summary>
        private void CheckedErrorHosts()
        {
            int checkCount = 0;
            foreach (TreeListNode node in tlHosts.Nodes)
            {
                var h = tlHosts.GetDataRecordByNode(node) as Host;
                if (h.HasError)
                {
                    node.Checked = true;
                    checkCount++;
                }
                else
                {
                    node.Checked = false;
                }
            }
            _checkedNodes = checkCount;
        }

        private void UncheckedAll()
        {
            _checkedNodes = 0;
            tlHosts.UncheckAll();
        }

        private bool IsAllChecked()
        {
            return _checkedNodes > 0 && _checkedNodes == tlHosts.AllNodesCount;
        }

        private void tlHosts_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (tlHosts.GetDataRecordByNode(e.Node) is Host h)
            {
                if (h.IsBusy)
                {
                    e.NodeImageIndex = 0;
                }
                else if (h.HasError)
                {
                    e.NodeImageIndex = 1;
                }
            }
        }
        #endregion

        #region 右键菜单处理
        private void tlHosts_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            if (tlHosts.GetDataRecordByNode(tlHosts.FocusedNode) is Host h)
            {
                if (_rdpDXMenuItem == null)
                {
                    _rdpDXMenuItem = RdpHelper.GetRdpMenuItem();
                }
                _rdpDXMenuItem.Tag = h.Address;
                e.Menu.Items.Add(_rdpDXMenuItem);
            }
        }
        #endregion

        #region 关闭窗体处理
        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (_batchHandler != null)
            {
                if (_batchHandler.IsBusy)
                {
                    if (MessageBox.Show("正在执行任务,是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        == DialogResult.Cancel)
                        e.Cancel = true;
                }
                _batchHandler.Dispose();
            }
        }
        #endregion
    }
}
