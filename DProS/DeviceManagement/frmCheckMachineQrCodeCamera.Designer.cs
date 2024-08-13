namespace DProS.DeviceManagement
{
	partial class frmCheckMachineQrCodeCamera
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckMachineQrCodeCamera));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.cbCamera = new System.Windows.Forms.ComboBox();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.btnCamera = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.picbQrCode = new System.Windows.Forms.PictureBox();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lblNote = new System.Windows.Forms.Label();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picbQrCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.lblNote);
			this.layoutControl1.Controls.Add(this.picbQrCode);
			this.layoutControl1.Controls.Add(this.btnCamera);
			this.layoutControl1.Controls.Add(this.cbCamera);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(620, 365);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(620, 365);
			this.Root.TextVisible = false;
			// 
			// cbCamera
			// 
			this.cbCamera.FormattingEnabled = true;
			this.cbCamera.Location = new System.Drawing.Point(61, 12);
			this.cbCamera.Name = "cbCamera";
			this.cbCamera.Size = new System.Drawing.Size(446, 23);
			this.cbCamera.TabIndex = 4;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbCamera;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(499, 26);
			this.layoutControlItem1.Text = "Camera: ";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(45, 15);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(300, 26);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(300, 68);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// btnCamera
			// 
			this.btnCamera.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCamera.ImageOptions.Image")));
			this.btnCamera.Location = new System.Drawing.Point(511, 12);
			this.btnCamera.Name = "btnCamera";
			this.btnCamera.Size = new System.Drawing.Size(97, 22);
			this.btnCamera.StyleController = this.layoutControl1;
			this.btnCamera.TabIndex = 5;
			this.btnCamera.Text = "Chọn Camera";
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnCamera;
			this.layoutControlItem2.Location = new System.Drawing.Point(499, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(101, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// picbQrCode
			// 
			this.picbQrCode.Location = new System.Drawing.Point(12, 38);
			this.picbQrCode.Name = "picbQrCode";
			this.picbQrCode.Size = new System.Drawing.Size(296, 315);
			this.picbQrCode.TabIndex = 6;
			this.picbQrCode.TabStop = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.picbQrCode;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(300, 319);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// lblNote
			// 
			this.lblNote.Location = new System.Drawing.Point(312, 106);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(296, 247);
			this.lblNote.TabIndex = 7;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.lblNote;
			this.layoutControlItem4.Location = new System.Drawing.Point(300, 94);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(300, 251);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// frmCheckMachineQrCodeCamera
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(620, 365);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmCheckMachineQrCodeCamera";
			this.Text = "frmCheckMachineQrCodeCamera";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picbQrCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private System.Windows.Forms.Label lblNote;
		private System.Windows.Forms.PictureBox picbQrCode;
		private DevExpress.XtraEditors.SimpleButton btnCamera;
		private System.Windows.Forms.ComboBox cbCamera;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private System.Windows.Forms.Timer timer1;
	}
}