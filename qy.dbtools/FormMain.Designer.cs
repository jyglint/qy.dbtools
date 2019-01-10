namespace QY.DBtools
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbHosts = new System.Windows.Forms.ToolStripSplitButton();
            this.miHostsExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.miHostsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFile = new System.Windows.Forms.ToolStripSplitButton();
            this.miFileNewSql = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileNewCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbHosts = new DevExpress.XtraEditors.GroupControl();
            this.tlHosts = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsBusy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasError = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAddress = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gbSource = new DevExpress.XtraEditors.GroupControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.pgMain = new DevExpress.XtraTab.XtraTabPage();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbHosts)).BeginInit();
            this.gbHosts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlHosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pgMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHosts,
            this.toolStripSeparator1,
            this.tsbFile,
            this.toolStripSeparator2,
            this.tsbRun,
            this.tsbStop,
            this.toolStripSeparator3,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(666, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "ToolBar";
            // 
            // tsbHosts
            // 
            this.tsbHosts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHostsExcel,
            this.miHostsSave});
            this.tsbHosts.Image = ((System.Drawing.Image)(resources.GetObject("tsbHosts.Image")));
            this.tsbHosts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHosts.Name = "tsbHosts";
            this.tsbHosts.Size = new System.Drawing.Size(104, 36);
            this.tsbHosts.Text = "加载主机";
            this.tsbHosts.ButtonClick += new System.EventHandler(this.tsbHosts_ButtonClick);
            // 
            // miHostsExcel
            // 
            this.miHostsExcel.Name = "miHostsExcel";
            this.miHostsExcel.Size = new System.Drawing.Size(148, 22);
            this.miHostsExcel.Text = "从EXCEL粘贴";
            this.miHostsExcel.Click += new System.EventHandler(this.miHostsExcel_Click);
            // 
            // miHostsSave
            // 
            this.miHostsSave.Name = "miHostsSave";
            this.miHostsSave.Size = new System.Drawing.Size(148, 22);
            this.miHostsSave.Text = "保存当前列表";
            this.miHostsSave.Click += new System.EventHandler(this.miHostsSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbFile
            // 
            this.tsbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileNewSql,
            this.miFileNewCSharp,
            this.miFileSave});
            this.tsbFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbFile.Image")));
            this.tsbFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFile.Name = "tsbFile";
            this.tsbFile.Size = new System.Drawing.Size(104, 36);
            this.tsbFile.Text = "加载程序";
            this.tsbFile.ButtonClick += new System.EventHandler(this.tsbFile_ButtonClick);
            // 
            // miFileNewSql
            // 
            this.miFileNewSql.Name = "miFileNewSql";
            this.miFileNewSql.Size = new System.Drawing.Size(136, 22);
            this.miFileNewSql.Text = "新建SQL";
            this.miFileNewSql.Click += new System.EventHandler(this.miFileNewSql_Click);
            // 
            // miFileNewCSharp
            // 
            this.miFileNewCSharp.Name = "miFileNewCSharp";
            this.miFileNewCSharp.Size = new System.Drawing.Size(136, 22);
            this.miFileNewCSharp.Text = "新建C#";
            this.miFileNewCSharp.Click += new System.EventHandler(this.miFileNewCSharp_Click);
            // 
            // miFileSave
            // 
            this.miFileSave.Name = "miFileSave";
            this.miFileSave.Size = new System.Drawing.Size(136, 22);
            this.miFileSave.Text = "保存到文件";
            this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbRun
            // 
            this.tsbRun.Image = ((System.Drawing.Image)(resources.GetObject("tsbRun.Image")));
            this.tsbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Size = new System.Drawing.Size(68, 36);
            this.tsbRun.Text = "执行";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(68, 36);
            this.tsbStop.Text = "停止";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(68, 36);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbHosts);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbSource);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(660, 348);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbHosts
            // 
            this.gbHosts.Controls.Add(this.tlHosts);
            this.gbHosts.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("全选", "", DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "选中全部主机", true, 0, true, null, true, false, true, null, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("全不选", "", DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "取消选择全部主机", true, 1, true, null, true, false, true, null, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Button", "DeleteDataSource;Size16x16;GrayScaled", DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "仅选中有错误的主机", false, 2, true, null, true, false, true, null, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", "Save;Size16x16;GrayScaled", DevExpress.XtraEditors.ButtonPanel.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "将主机列表保存到文件", false, 3, true, null, true, false, true, null, null, -1)});
            this.gbHosts.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gbHosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHosts.Location = new System.Drawing.Point(0, 0);
            this.gbHosts.Name = "gbHosts";
            this.gbHosts.Size = new System.Drawing.Size(250, 348);
            this.gbHosts.TabIndex = 0;
            this.gbHosts.Text = "主机";
            this.gbHosts.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.gbHosts_CustomButtonClick);
            // 
            // tlHosts
            // 
            this.tlHosts.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colIsBusy,
            this.colHasError,
            this.colAddress,
            this.colPort});
            this.tlHosts.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlHosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlHosts.IndicatorWidth = 36;
            this.tlHosts.Location = new System.Drawing.Point(2, 29);
            this.tlHosts.Name = "tlHosts";
            this.tlHosts.OptionsBehavior.Editable = false;
            this.tlHosts.OptionsBehavior.EnableFiltering = true;
            this.tlHosts.OptionsView.ShowCheckBoxes = true;
            this.tlHosts.OptionsView.ShowColumns = false;
            this.tlHosts.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
            this.tlHosts.Size = new System.Drawing.Size(246, 317);
            this.tlHosts.StateImageList = this.imageCollection1;
            this.tlHosts.TabIndex = 0;
            this.tlHosts.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.tlHosts_GetStateImage);
            this.tlHosts.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlHosts_AfterCheckNode);
            this.tlHosts.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.tlHosts_CustomDrawNodeIndicator);
            this.tlHosts.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.tlHosts_PopupMenuShowing);
            // 
            // colName
            // 
            this.colName.Caption = "主机";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 70;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 88;
            // 
            // colIsBusy
            // 
            this.colIsBusy.Caption = "正在执行";
            this.colIsBusy.FieldName = "IsBusy";
            this.colIsBusy.Name = "colIsBusy";
            // 
            // colHasError
            // 
            this.colHasError.Caption = "发生错误";
            this.colHasError.FieldName = "HasError";
            this.colHasError.Name = "colHasError";
            // 
            // colAddress
            // 
            this.colAddress.Caption = "地址";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            // 
            // colPort
            // 
            this.colPort.Caption = "端口";
            this.colPort.FieldName = "Port";
            this.colPort.Name = "colPort";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("editdatasource_16x16.png", "office2013/data/editdatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/editdatasource_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "editdatasource_16x16.png");
            this.imageCollection1.InsertGalleryImage("deletedatasource_16x16.png", "office2013/data/deletedatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/deletedatasource_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "deletedatasource_16x16.png");
            this.imageCollection1.InsertGalleryImage("database_16x16.png", "office2013/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/database_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "database_16x16.png");
            this.imageCollection1.InsertGalleryImage("addnewdatasource_16x16.png", "office2013/data/addnewdatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/addnewdatasource_16x16.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "addnewdatasource_16x16.png");
            // 
            // gbSource
            // 
            this.gbSource.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", null, "Save;Size16x16;GrayScaled", false, true, "将程序保存到文件")});
            this.gbSource.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSource.Location = new System.Drawing.Point(0, 0);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(406, 348);
            this.gbSource.TabIndex = 0;
            this.gbSource.Text = "文件";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 39);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.pgMain;
            this.tabMain.Size = new System.Drawing.Size(666, 377);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pgMain});
            // 
            // pgMain
            // 
            this.pgMain.Controls.Add(this.splitContainer1);
            this.pgMain.Name = "pgMain";
            this.pgMain.Size = new System.Drawing.Size(660, 348);
            this.pgMain.Text = "主界面";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 416);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "QY.DBtools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbHosts)).EndInit();
            this.gbHosts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlHosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pgMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSplitButton tsbFile;
        private System.Windows.Forms.ToolStripMenuItem miFileNewSql;
        private System.Windows.Forms.ToolStripMenuItem miFileNewCSharp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton tsbHosts;
        private System.Windows.Forms.ToolStripMenuItem miHostsExcel;
        private System.Windows.Forms.ToolStripMenuItem miHostsSave;
        private System.Windows.Forms.ToolStripMenuItem miFileSave;
        private DevExpress.XtraTreeList.TreeList tlHosts;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsBusy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasError;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAddress;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPort;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage pgMain;
        private DevExpress.XtraEditors.GroupControl gbHosts;
        private DevExpress.XtraEditors.GroupControl gbSource;
        private System.Windows.Forms.ToolStripButton tsbStop;
    }
}

