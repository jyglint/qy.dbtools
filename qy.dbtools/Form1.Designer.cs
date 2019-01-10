namespace QY.DBtools
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", null, 0, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", true, -1, true, null, true, false, true, null, null, -1, false, true),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", null, 1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", null, 2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1)});
            this.windowsUIButtonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowsUIButtonPanel1.Images = this.imageCollection1;
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(0, 0);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(545, 60);
            this.windowsUIButtonPanel1.TabIndex = 0;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.UseButtonBackgroundImages = false;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("play_32x32.png", "images/arrows/play_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/play_32x32.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "play_32x32.png");
            this.imageCollection1.InsertGalleryImage("pause_32x32.png", "images/arrows/pause_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/pause_32x32.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "pause_32x32.png");
            this.imageCollection1.InsertGalleryImage("stop_32x32.png", "images/arrows/stop_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/stop_32x32.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "stop_32x32.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 258);
            this.Controls.Add(this.windowsUIButtonPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}