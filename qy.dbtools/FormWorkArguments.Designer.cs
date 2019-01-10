namespace QY.DBtools
{
    partial class FormWorkArguments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        ///
        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.teDataBase = new DevExpress.XtraEditors.TextEdit();
            this.meConnectionString = new DevExpress.XtraEditors.MemoEdit();
            this.cbMaxThreads = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teLimitRows = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bpActions = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meConnectionString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaxThreads.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLimitRows.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomization = false;
            this.layoutControl.Controls.Add(this.teDataBase);
            this.layoutControl.Controls.Add(this.meConnectionString);
            this.layoutControl.Controls.Add(this.cbMaxThreads);
            this.layoutControl.Controls.Add(this.teLimitRows);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(475, 210, 738, 496);
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(420, 187);
            this.layoutControl.TabIndex = 1;
            // 
            // teDataBase
            // 
            this.teDataBase.EditValue = "";
            this.teDataBase.Location = new System.Drawing.Point(141, 117);
            this.teDataBase.Name = "teDataBase";
            this.teDataBase.Properties.NullValuePromptShowForEmptyValue = true;
            this.teDataBase.Size = new System.Drawing.Size(237, 20);
            this.teDataBase.StyleController = this.layoutControl;
            this.teDataBase.TabIndex = 0;
            // 
            // meConnectionString
            // 
            this.meConnectionString.Location = new System.Drawing.Point(42, 19);
            this.meConnectionString.Name = "meConnectionString";
            this.meConnectionString.Size = new System.Drawing.Size(336, 94);
            this.meConnectionString.StyleController = this.layoutControl;
            this.meConnectionString.TabIndex = 1;
            // 
            // cbMaxThreads
            // 
            this.cbMaxThreads.EditValue = "16";
            this.cbMaxThreads.Location = new System.Drawing.Point(141, 165);
            this.cbMaxThreads.Name = "cbMaxThreads";
            this.cbMaxThreads.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMaxThreads.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256"});
            this.cbMaxThreads.Size = new System.Drawing.Size(237, 20);
            this.cbMaxThreads.StyleController = this.layoutControl;
            this.cbMaxThreads.TabIndex = 3;
            // 
            // teLimitRows
            // 
            this.teLimitRows.EditValue = "10";
            this.teLimitRows.Location = new System.Drawing.Point(141, 141);
            this.teLimitRows.Name = "teLimitRows";
            this.teLimitRows.Size = new System.Drawing.Size(237, 20);
            this.teLimitRows.StyleController = this.layoutControl;
            this.teLimitRows.TabIndex = 2;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 0);
            this.layoutControlGroup.Size = new System.Drawing.Size(420, 187);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.meConnectionString;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(340, 115);
            this.layoutControlItem2.Text = "数据库连接字符串";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teDataBase;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(340, 24);
            this.layoutControlItem1.Text = "默认使用数据库";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cbMaxThreads;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 163);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(340, 24);
            this.layoutControlItem3.Text = "最大使用线程数";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teLimitRows;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 139);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(340, 24);
            this.layoutControlItem4.Text = "记录集最大行数";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 14);
            // 
            // bpActions
            // 
            this.bpActions.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.bpActions.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.bpActions.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.bpActions.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.bpActions.AppearanceButton.Hovered.Options.UseFont = true;
            this.bpActions.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.bpActions.AppearanceButton.Normal.FontSizeDelta = -1;
            this.bpActions.AppearanceButton.Normal.Options.UseFont = true;
            this.bpActions.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.bpActions.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.bpActions.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.bpActions.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.bpActions.AppearanceButton.Pressed.Options.UseFont = true;
            this.bpActions.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.bpActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.bpActions.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("确定", "Apply;Size32x32;GrayScaled", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, 0, true, null, true, false, true, null, null, -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(null, true, 1),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("取消", "Cancel;Size32x32;GrayScaled", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, 2, true, null, true, false, true, null, null, -1, false, false)});
            this.bpActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bpActions.EnableImageTransparency = true;
            this.bpActions.ForeColor = System.Drawing.Color.White;
            this.bpActions.Location = new System.Drawing.Point(0, 187);
            this.bpActions.Margin = new System.Windows.Forms.Padding(5);
            this.bpActions.MaximumSize = new System.Drawing.Size(0, 65);
            this.bpActions.MinimumSize = new System.Drawing.Size(70, 65);
            this.bpActions.Name = "bpActions";
            this.bpActions.Size = new System.Drawing.Size(420, 65);
            this.bpActions.TabIndex = 0;
            this.bpActions.Text = "windowsUIButtonPanel";
            this.bpActions.UseButtonBackgroundImages = false;
            this.bpActions.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.bpActions_ButtonClick);
            // 
            // FormWorkArguments
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 252);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.bpActions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWorkArguments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "执行参数";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meConnectionString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaxThreads.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLimitRows.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel bpActions;
        private DevExpress.XtraEditors.TextEdit teDataBase;
        private DevExpress.XtraEditors.MemoEdit meConnectionString;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cbMaxThreads;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit teLimitRows;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}