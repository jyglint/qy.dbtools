using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;
using QY.DBtools.Models;

namespace QY.DBtools
{
    public partial class FormWorkArguments : XtraForm
    {
        private const int LIMIT_ROWS = 1000;
        private const int MAX_THREADS = 256;

        public WorkArguments Arguments { get; set; }

        public FormWorkArguments()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Arguments != null)
            {
                meConnectionString.Text = Arguments.ConnectionString;
                teDataBase.Text = Arguments.DataBase;
                teLimitRows.Text = Arguments.LimitRows.ToString();
                cbMaxThreads.Text = Arguments.MaxThreads.ToString();
            }
        }

        private void ShowInformation(string msg)
        {
            MessageBox.Show(this, msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bpActions_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.VisibleIndex == 2)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
            string connstr = meConnectionString.Text.Trim();
            if (string.IsNullOrEmpty(connstr))
            {
                meConnectionString.Focus();
                ShowInformation("数据库连接字符串不能为空!");
                return;
            }
            var db = teDataBase.Text.Trim();
            if (string.IsNullOrEmpty(db))
            {
                teDataBase.Focus();
                ShowInformation("默认使用的数据库不能为空!");
                return;
            }
            try
            {
                WorkArguments.CreateConnectionString(connstr, "host", 3306, "user", "password", db);
            }
            catch (Exception ex)
            {
                meConnectionString.Focus();
                ShowInformation("数据库连接字符串有错误:\n" + ex.Message);
                return;
            }
            if (!CheckInputNumber(teLimitRows, out int limitRows, 0, LIMIT_ROWS,
                "记录集最大行数必须是{0}-{1}之间的有效数字!"))
            {
                return;
            }
            if (!CheckInputNumber(cbMaxThreads, out int maxThreads, 1, MAX_THREADS,
                "最大使用线程数必须是{0}-{1}之间的有效数字!"))
            {
                return;
            }
            Arguments.ConnectionString = connstr;
            Arguments.DataBase = db;
            Arguments.LimitRows = limitRows;
            Arguments.MaxThreads = maxThreads;
            DialogResult = DialogResult.OK;
        }

        private bool CheckInputNumber(Control c, out int val, int min, int max, string invalidFormat)
        {
            if (int.TryParse(c.Text, out val) && val >= min && val <= max)
            {
                return true;
            }
            c.Focus();
            ShowInformation(string.Format(invalidFormat, min, max));
            return false;
        }
    }
}
