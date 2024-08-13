namespace DProS.MachineData
{
	partial class frmCharCheckData
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharCheckData));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
			this.btnWatchInMonth = new DevExpress.XtraEditors.SimpleButton();
			this.btnWatchInDay = new DevExpress.XtraEditors.SimpleButton();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.cbMachineCode = new System.Windows.Forms.ComboBox();
			this.cbMoldCode = new System.Windows.Forms.ComboBox();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.chartControl1);
			this.layoutControl1.Controls.Add(this.btnWatchInMonth);
			this.layoutControl1.Controls.Add(this.btnWatchInDay);
			this.layoutControl1.Controls.Add(this.dtpDate);
			this.layoutControl1.Controls.Add(this.cbMachineCode);
			this.layoutControl1.Controls.Add(this.cbMoldCode);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1102, 316, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// chartControl1
			// 
			this.chartControl1.Legend.Name = "Default Legend";
			this.chartControl1.Location = new System.Drawing.Point(12, 38);
			this.chartControl1.Name = "chartControl1";
			this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
			this.chartControl1.Size = new System.Drawing.Size(1128, 654);
			this.chartControl1.TabIndex = 19;
			// 
			// btnWatchInMonth
			// 
			this.btnWatchInMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWatchInMonth.ImageOptions.Image")));
			this.btnWatchInMonth.Location = new System.Drawing.Point(1021, 12);
			this.btnWatchInMonth.Name = "btnWatchInMonth";
			this.btnWatchInMonth.Size = new System.Drawing.Size(119, 22);
			this.btnWatchInMonth.StyleController = this.layoutControl1;
			this.btnWatchInMonth.TabIndex = 18;
			this.btnWatchInMonth.Text = "Xem trong tháng";
			// 
			// btnWatchInDay
			// 
			this.btnWatchInDay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWatchInDay.ImageOptions.Image")));
			this.btnWatchInDay.Location = new System.Drawing.Point(888, 12);
			this.btnWatchInDay.Name = "btnWatchInDay";
			this.btnWatchInDay.Size = new System.Drawing.Size(119, 22);
			this.btnWatchInDay.StyleController = this.layoutControl1;
			this.btnWatchInDay.TabIndex = 17;
			this.btnWatchInDay.Text = "Xem trong ngày";
			// 
			// dtpDate
			// 
			this.dtpDate.CustomFormat = "dd/MM/yyyy";
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDate.Location = new System.Drawing.Point(749, 12);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(125, 22);
			this.dtpDate.TabIndex = 16;
			// 
			// cbMachineCode
			// 
			this.cbMachineCode.FormattingEnabled = true;
			this.cbMachineCode.Location = new System.Drawing.Point(414, 12);
			this.cbMachineCode.Name = "cbMachineCode";
			this.cbMachineCode.Size = new System.Drawing.Size(224, 23);
			this.cbMachineCode.TabIndex = 15;
			// 
			// cbMoldCode
			// 
			this.cbMoldCode.FormattingEnabled = true;
			this.cbMoldCode.Location = new System.Drawing.Point(78, 12);
			this.cbMoldCode.Name = "cbMoldCode";
			this.cbMoldCode.Size = new System.Drawing.Size(268, 23);
			this.cbMoldCode.TabIndex = 14;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbMoldCode;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(338, 26);
			this.layoutControlItem1.Text = "Mã khuôn: ";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 15);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.cbMachineCode;
			this.layoutControlItem2.Location = new System.Drawing.Point(348, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(282, 26);
			this.layoutControlItem2.Text = "Mã máy: ";
			this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(49, 15);
			this.layoutControlItem2.TextToControlDistance = 5;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.dtpDate;
			this.layoutControlItem3.Location = new System.Drawing.Point(640, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(226, 26);
			this.layoutControlItem3.Text = "Ngày tháng năm: ";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 15);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnWatchInDay;
			this.layoutControlItem4.Location = new System.Drawing.Point(876, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(123, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnWatchInMonth;
			this.layoutControlItem5.Location = new System.Drawing.Point(1009, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(123, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.chartControl1;
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(1132, 658);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(338, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(630, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(866, 0);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.Location = new System.Drawing.Point(999, 0);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmCharCheckData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmCharCheckData";
			this.Text = "BIỂU ĐỒ";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private System.Windows.Forms.ComboBox cbMoldCode;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraCharts.ChartControl chartControl1;
		private DevExpress.XtraEditors.SimpleButton btnWatchInMonth;
		private DevExpress.XtraEditors.SimpleButton btnWatchInDay;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.ComboBox cbMachineCode;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
	}
}
