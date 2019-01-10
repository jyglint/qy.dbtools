using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QY.DBtools.Models;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace QY.DBtools
{
    public partial class ResultPage : UserControl
    {
        public int ResultSetIndex { get; set; } = -1;

        public string TitleFormat { get; set; }

        private DataTable _dataSource;

        public DataTable DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                SetTitle();
                gridControl1.DataSource = value;
            }
        }

        public GridView Grid
        {
            get
            {
                return gridView1;
            }
        }

        public int RowCount
        {
            get
            {
                return _dataSource == null ? 0 : _dataSource.Rows.Count;
            }
        }

        private DXMenuItem _copyDXMenuItem;

        private DXMenuItem _rdpDXMenuItem;

        public ResultPage()
        {
            InitializeComponent();
            _copyDXMenuItem = new DXMenuItem("复制", CellCopy);
        }

        internal void AppendMessage(params object[] values)
        {
            _dataSource.Rows.Add(values);
            SetTitle();
        }

        internal void ClearData()
        {
            _dataSource?.Clear();
            SetTitle();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is DateTime)
            {
                e.DisplayText = ((DateTime)e.Value).ToString();
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && gridView1.FocusedRowHandle != e.RowHandle)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Export")
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Enum.GetNames(typeof(ExportTarget)))
                {
                    sb.AppendFormat("{0}|*.{0}|", item);
                }
                sb.Length--;
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = sb.ToString();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var et = (ExportTarget)(sfd.FilterIndex - 1);//FilterIndex从1开始
                        gridView1.Export(et, sfd.FileName);
                    }
                }
            }
        }

        private void CellCopy(object sender, EventArgs e)
        {
            var hi = ((DXMenuItem)sender).Tag as GridHitInfo;
            var cv = gridView1.GetRowCellDisplayText(hi.RowHandle, hi.Column);
            if (!string.IsNullOrEmpty(cv))
            {
                Clipboard.SetText(cv);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var hi = e.HitInfo;
            if (e.MenuType == GridMenuType.Row && hi.InRowCell)
            {
                var items = e.Menu.Items;
                _copyDXMenuItem.Tag = e.HitInfo;
                items.Add(_copyDXMenuItem);
                var cv = gridView1.GetRowCellDisplayText(hi.RowHandle, hi.Column);
                if (!string.IsNullOrEmpty(cv) && RdpHelper.IsValidIp(cv))
                {
                    if (_rdpDXMenuItem == null)
                    {
                        _rdpDXMenuItem = RdpHelper.GetRdpMenuItem();
                    }
                    _rdpDXMenuItem.Tag = cv;
                    items.Add(_rdpDXMenuItem);
                }
            }
        }

        internal bool IsMatchTable(DataTable table, int resultSetIndex)
        {
            if (ResultSetIndex >= 0)
            {
                return ResultSetIndex == resultSetIndex;
            }
            //以下通常不会执行，因为_resultSetIndex在创建PAGE页后总是>=0
            if (_dataSource == null)
            {
                return false;
            }
            var srcCols = _dataSource.Columns;
            var destCols = table.Columns;
            if (srcCols.Count != destCols.Count)
            {
                return false;
            }
            for (int i = 0; i < srcCols.Count; i++)
            {
                var src = srcCols[i];
                var dest = destCols[i];
                if (src.ColumnName != dest.ColumnName ||
                    src.DataType != dest.DataType)
                {
                    return false;
                }
            }
            return true;
        }

        internal void MergeDataSource(DataTable source)
        {
            _dataSource.Merge(source);
            SetTitle();
        }

        private void SetTitle()
        {
            if (TitleFormat != null)
            {//TODO: ResultPage改为直接从XtraTabPage继承
                var p = Parent;
                if (p != null)
                {
                    p.Text = string.Format(TitleFormat, RowCount);
                }
            }
        }
    }
}
