
namespace DProS.DeviceManagement
{
	partial class frmCharMachine
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharMachine));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.btnHMChartMainten = new DevExpress.XtraEditors.SimpleButton();
			this.btnHMChartEveryday = new DevExpress.XtraEditors.SimpleButton();
			this.dtpMonthYear = new System.Windows.Forms.DateTimePicker();
			this.cbMachineCode = new System.Windows.Forms.ComboBox();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.flpMain);
			this.layoutControl1.Controls.Add(this.btnHMChartMainten);
			this.layoutControl1.Controls.Add(this.btnHMChartEveryday);
			this.layoutControl1.Controls.Add(this.dtpMonthYear);
			this.layoutControl1.Controls.Add(this.cbMachineCode);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 453, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// flpMain
			// 
			this.flpMain.Location = new System.Drawing.Point(12, 38);
			this.flpMain.Name = "flpMain";
			this.flpMain.Size = new System.Drawing.Size(1128, 654);
			this.flpMain.TabIndex = 8;
			// 
			// btnHMChartMainten
			// 
			this.btnHMChartMainten.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHMChartMainten.ImageOptions.Image")));
			this.btnHMChartMainten.Location = new System.Drawing.Point(947, 12);
			this.btnHMChartMainten.Name = "btnHMChartMainten";
			this.btnHMChartMainten.Size = new System.Drawing.Size(193, 22);
			this.btnHMChartMainten.StyleController = this.layoutControl1;
			this.btnHMChartMainten.TabIndex = 7;
			this.btnHMChartMainten.Text = "Biểu đồ HM định kỳ";
			this.btnHMChartMainten.Click += new System.EventHandler(this.btnHMChartMainten_Click);
			// 
			// btnHMChartEveryday
			// 
			this.btnHMChartEveryday.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHMChartEveryday.ImageOptions.Image")));
			this.btnHMChartEveryday.Location = new System.Drawing.Point(745, 12);
			this.btnHMChartEveryday.Name = "btnHMChartEveryday";
			this.btnHMChartEveryday.Size = new System.Drawing.Size(188, 22);
			this.btnHMChartEveryday.StyleController = this.layoutControl1;
			this.btnHMChartEveryday.TabIndex = 6;
			this.btnHMChartEveryday.Text = "Biểu đồ HM hàng ngày";
			this.btnHMChartEveryday.Click += new System.EventHandler(this.btnHMChartEveryday_Click);
			// 
			// dtpMonthYear
			// 
			this.dtpMonthYear.CustomFormat = "MM/yyyy";
			this.dtpMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpMonthYear.Location = new System.Drawing.Point(443, 12);
			this.dtpMonthYear.Name = "dtpMonthYear";
			this.dtpMonthYear.Size = new System.Drawing.Size(162, 22);
			this.dtpMonthYear.TabIndex = 5;
			// 
			// cbMachineCode
			// 
			this.cbMachineCode.FormattingEnabled = true;
			this.cbMachineCode.Location = new System.Drawing.Point(81, 12);
			this.cbMachineCode.Name = "cbMachineCode";
			this.cbMachineCode.Size = new System.Drawing.Size(277, 23);
			this.cbMachineCode.TabIndex = 4;
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
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem5});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbMachineCode;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(350, 26);
			this.layoutControlItem1.Text = "Mã thiết bị: ";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 15);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.dtpMonthYear;
			this.layoutControlItem2.Location = new System.Drawing.Point(360, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(237, 26);
			this.layoutControlItem2.Text = "Tháng năm: ";
			this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 15);
			this.layoutControlItem2.TextToControlDistance = 5;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.btnHMChartEveryday;
			this.layoutControlItem3.Location = new System.Drawing.Point(733, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(192, 26);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnHMChartMainten;
			this.layoutControlItem4.Location = new System.Drawing.Point(935, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(197, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(925, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(597, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(136, 26);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(350, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.flpMain;
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(1132, 658);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// frmCharMachine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmCharMachine";
			this.Text = "BIỂU ĐỒ";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraEditors.SimpleButton btnHMChartMainten;
		private DevExpress.XtraEditors.SimpleButton btnHMChartEveryday;
		private System.Windows.Forms.DateTimePicker dtpMonthYear;
		private System.Windows.Forms.ComboBox cbMachineCode;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private System.Windows.Forms.FlowLayoutPanel flpMain;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
	}
}
