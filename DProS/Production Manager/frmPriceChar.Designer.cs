namespace DProS.Production_Manager.Oder_Manager
{
   


    partial class frmPriceChar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPriceChar));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.btnView = new DevExpress.XtraEditors.SimpleButton();
			this.dtpkTo = new System.Windows.Forms.DateTimePicker();
			this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
			this.glMaterialCode = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ccVND = new DevExpress.XtraCharts.ChartControl();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ccUSD = new DevExpress.XtraCharts.ChartControl();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.glMaterialCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ccVND)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ccUSD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.ccUSD);
			this.layoutControl1.Controls.Add(this.ccVND);
			this.layoutControl1.Controls.Add(this.btnView);
			this.layoutControl1.Controls.Add(this.dtpkTo);
			this.layoutControl1.Controls.Add(this.dtpkFrom);
			this.layoutControl1.Controls.Add(this.glMaterialCode);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(966, 390, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// btnView
			// 
			this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
			this.btnView.Location = new System.Drawing.Point(1060, 14);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(78, 22);
			this.btnView.StyleController = this.layoutControl1;
			this.btnView.TabIndex = 9;
			this.btnView.Text = "Xem";
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// dtpkTo
			// 
			this.dtpkTo.CustomFormat = "dd/MM/yyyy";
			this.dtpkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkTo.Location = new System.Drawing.Point(978, 14);
			this.dtpkTo.Name = "dtpkTo";
			this.dtpkTo.Size = new System.Drawing.Size(78, 22);
			this.dtpkTo.TabIndex = 8;
			// 
			// dtpkFrom
			// 
			this.dtpkFrom.CustomFormat = "dd/MM/yyyy";
			this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkFrom.Location = new System.Drawing.Point(799, 14);
			this.dtpkFrom.Name = "dtpkFrom";
			this.dtpkFrom.Size = new System.Drawing.Size(85, 22);
			this.dtpkFrom.TabIndex = 7;
			// 
			// glMaterialCode
			// 
			this.glMaterialCode.Location = new System.Drawing.Point(104, 14);
			this.glMaterialCode.Name = "glMaterialCode";
			this.glMaterialCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.glMaterialCode.Properties.PopupView = this.gridLookUpEdit1View;
			this.glMaterialCode.Size = new System.Drawing.Size(601, 22);
			this.glMaterialCode.StyleController = this.layoutControl1;
			this.glMaterialCode.TabIndex = 6;
			// 
			// gridLookUpEdit1View
			// 
			this.gridLookUpEdit1View.DetailHeight = 404;
			this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
			this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem2});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.glMaterialCode;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(695, 26);
			this.layoutControlItem3.Text = "Mã nguyên liệu:";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 15);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.dtpkFrom;
			this.layoutControlItem4.Location = new System.Drawing.Point(695, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(179, 26);
			this.layoutControlItem4.Text = "Từ tháng:";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 15);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.dtpkTo;
			this.layoutControlItem5.Location = new System.Drawing.Point(874, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(172, 26);
			this.layoutControlItem5.Text = "Đến tháng:";
			this.layoutControlItem5.TextSize = new System.Drawing.Size(87, 15);
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnView;
			this.layoutControlItem6.Location = new System.Drawing.Point(1046, 0);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(82, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// ccVND
			// 
			this.ccVND.Legend.Name = "Default Legend";
			this.ccVND.Location = new System.Drawing.Point(14, 40);
			this.ccVND.Name = "ccVND";
			this.ccVND.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
			this.ccVND.Size = new System.Drawing.Size(1124, 323);
			this.ccVND.TabIndex = 10;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.ccVND;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1128, 327);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// ccUSD
			// 
			this.ccUSD.Legend.Name = "Default Legend";
			this.ccUSD.Location = new System.Drawing.Point(14, 367);
			this.ccUSD.Name = "ccUSD";
			this.ccUSD.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
			this.ccUSD.Size = new System.Drawing.Size(1124, 323);
			this.ccUSD.TabIndex = 11;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.ccUSD;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 353);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(1128, 327);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// frmPriceChar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmPriceChar";
			this.Text = "BIỂU ĐỒ GIÁ NGUYÊN LIỆU.";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.glMaterialCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ccVND)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ccUSD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private System.Windows.Forms.DateTimePicker dtpkTo;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private DevExpress.XtraEditors.GridLookUpEdit glMaterialCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraCharts.ChartControl ccUSD;
		private DevExpress.XtraCharts.ChartControl ccVND;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
	}
}