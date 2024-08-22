namespace DProS.Production_Manager.PO_Manager
{
   
    partial class frmPOOutput
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOOutput));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnSee = new DevExpress.XtraEditors.SimpleButton();
			this.dtpkDateTo = new System.Windows.Forms.DateTimePicker();
			this.dtpkDateFrom = new System.Windows.Forms.DateTimePicker();
			this.gcPOOutput = new DevExpress.XtraGrid.GridControl();
			this.gvPOOutput = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcPartCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcPOCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDateManufacturi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDateOutput = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcNumberMold = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcQuantityOut = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcIdDe = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcLot = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcPOOutput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPOOutput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.btnExportExcel);
			this.layoutControl1.Controls.Add(this.btnUpdate);
			this.layoutControl1.Controls.Add(this.btnSee);
			this.layoutControl1.Controls.Add(this.dtpkDateTo);
			this.layoutControl1.Controls.Add(this.dtpkDateFrom);
			this.layoutControl1.Controls.Add(this.gcPOOutput);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(994, 347, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// btnExportExcel
			// 
			this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
			this.btnExportExcel.Location = new System.Drawing.Point(973, 14);
			this.btnExportExcel.Name = "btnExportExcel";
			this.btnExportExcel.Size = new System.Drawing.Size(85, 22);
			this.btnExportExcel.StyleController = this.layoutControl1;
			this.btnExportExcel.TabIndex = 9;
			this.btnExportExcel.Text = "Xuất Excel";
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
			this.btnUpdate.Location = new System.Drawing.Point(1062, 14);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(76, 22);
			this.btnUpdate.StyleController = this.layoutControl1;
			this.btnUpdate.TabIndex = 8;
			this.btnUpdate.Text = "Cập Nhật";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnSee
			// 
			this.btnSee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
			this.btnSee.Location = new System.Drawing.Point(491, 14);
			this.btnSee.Name = "btnSee";
			this.btnSee.Size = new System.Drawing.Size(65, 22);
			this.btnSee.StyleController = this.layoutControl1;
			this.btnSee.TabIndex = 7;
			this.btnSee.Text = "Xem";
			this.btnSee.Click += new System.EventHandler(this.btnSee_Click);
			// 
			// dtpkDateTo
			// 
			this.dtpkDateTo.CustomFormat = "dd/MM/yyyy";
			this.dtpkDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkDateTo.Location = new System.Drawing.Point(310, 14);
			this.dtpkDateTo.Name = "dtpkDateTo";
			this.dtpkDateTo.Size = new System.Drawing.Size(177, 22);
			this.dtpkDateTo.TabIndex = 6;
			// 
			// dtpkDateFrom
			// 
			this.dtpkDateFrom.CustomFormat = "dd/MM/yyyy";
			this.dtpkDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkDateFrom.Location = new System.Drawing.Point(72, 14);
			this.dtpkDateFrom.Name = "dtpkDateFrom";
			this.dtpkDateFrom.Size = new System.Drawing.Size(176, 22);
			this.dtpkDateFrom.TabIndex = 5;
			// 
			// gcPOOutput
			// 
			this.gcPOOutput.Location = new System.Drawing.Point(14, 40);
			this.gcPOOutput.MainView = this.gvPOOutput;
			this.gcPOOutput.Name = "gcPOOutput";
			this.gcPOOutput.Size = new System.Drawing.Size(1124, 650);
			this.gcPOOutput.TabIndex = 4;
			this.gcPOOutput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPOOutput});
			// 
			// gvPOOutput
			// 
			this.gvPOOutput.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcPartCode,
            this.gvcPOCode,
            this.gvcDateManufacturi,
            this.gvcDateOutput,
            this.gvcMachineCode,
            this.gvcNumberMold,
            this.gvcName,
            this.gvcQuantityOut,
            this.gvcIdDe,
            this.gvcLot});
			this.gvPOOutput.DetailHeight = 404;
			this.gvPOOutput.GridControl = this.gcPOOutput;
			this.gvPOOutput.IndicatorWidth = 41;
			this.gvPOOutput.Name = "gvPOOutput";
			this.gvPOOutput.OptionsCustomization.AllowGroup = false;
			this.gvPOOutput.OptionsSelection.MultiSelect = true;
			this.gvPOOutput.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvPOOutput.OptionsView.ShowAutoFilterRow = true;
			this.gvPOOutput.OptionsView.ShowGroupPanel = false;
			// 
			// gvcPartCode
			// 
			this.gvcPartCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcPartCode.AppearanceHeader.Options.UseFont = true;
			this.gvcPartCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcPartCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcPartCode.Caption = "Mã Linh Kiện";
			this.gvcPartCode.FieldName = "PartCode";
			this.gvcPartCode.MinWidth = 23;
			this.gvcPartCode.Name = "gvcPartCode";
			this.gvcPartCode.Visible = true;
			this.gvcPartCode.VisibleIndex = 1;
			this.gvcPartCode.Width = 87;
			// 
			// gvcPOCode
			// 
			this.gvcPOCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcPOCode.AppearanceHeader.Options.UseFont = true;
			this.gvcPOCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcPOCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcPOCode.Caption = "Mã PO";
			this.gvcPOCode.FieldName = "POCode";
			this.gvcPOCode.MinWidth = 23;
			this.gvcPOCode.Name = "gvcPOCode";
			this.gvcPOCode.Visible = true;
			this.gvcPOCode.VisibleIndex = 2;
			this.gvcPOCode.Width = 87;
			// 
			// gvcDateManufacturi
			// 
			this.gvcDateManufacturi.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDateManufacturi.AppearanceHeader.Options.UseFont = true;
			this.gvcDateManufacturi.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDateManufacturi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDateManufacturi.Caption = "Ngày Sản Xuất";
			this.gvcDateManufacturi.FieldName = "DateManufacturi";
			this.gvcDateManufacturi.MinWidth = 23;
			this.gvcDateManufacturi.Name = "gvcDateManufacturi";
			this.gvcDateManufacturi.Visible = true;
			this.gvcDateManufacturi.VisibleIndex = 3;
			this.gvcDateManufacturi.Width = 87;
			// 
			// gvcDateOutput
			// 
			this.gvcDateOutput.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDateOutput.AppearanceHeader.Options.UseFont = true;
			this.gvcDateOutput.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDateOutput.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDateOutput.Caption = "Ngày Giao";
			this.gvcDateOutput.FieldName = "DateOutput";
			this.gvcDateOutput.MinWidth = 23;
			this.gvcDateOutput.Name = "gvcDateOutput";
			this.gvcDateOutput.Visible = true;
			this.gvcDateOutput.VisibleIndex = 4;
			this.gvcDateOutput.Width = 87;
			// 
			// gvcMachineCode
			// 
			this.gvcMachineCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineCode.AppearanceHeader.Options.UseFont = true;
			this.gvcMachineCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcMachineCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcMachineCode.Caption = "Mã Máy";
			this.gvcMachineCode.FieldName = "MachineCode";
			this.gvcMachineCode.MinWidth = 23;
			this.gvcMachineCode.Name = "gvcMachineCode";
			this.gvcMachineCode.Visible = true;
			this.gvcMachineCode.VisibleIndex = 5;
			this.gvcMachineCode.Width = 87;
			// 
			// gvcNumberMold
			// 
			this.gvcNumberMold.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNumberMold.AppearanceHeader.Options.UseFont = true;
			this.gvcNumberMold.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcNumberMold.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcNumberMold.Caption = "Số Khuôn";
			this.gvcNumberMold.FieldName = "NumberMold";
			this.gvcNumberMold.MinWidth = 23;
			this.gvcNumberMold.Name = "gvcNumberMold";
			this.gvcNumberMold.Visible = true;
			this.gvcNumberMold.VisibleIndex = 6;
			this.gvcNumberMold.Width = 87;
			// 
			// gvcName
			// 
			this.gvcName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcName.AppearanceHeader.Options.UseFont = true;
			this.gvcName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcName.Caption = "Vị Trí";
			this.gvcName.FieldName = "Name";
			this.gvcName.MinWidth = 23;
			this.gvcName.Name = "gvcName";
			this.gvcName.Visible = true;
			this.gvcName.VisibleIndex = 7;
			this.gvcName.Width = 87;
			// 
			// gvcQuantityOut
			// 
			this.gvcQuantityOut.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcQuantityOut.AppearanceHeader.Options.UseFont = true;
			this.gvcQuantityOut.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcQuantityOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcQuantityOut.Caption = "Số Lượng Giao";
			this.gvcQuantityOut.FieldName = "QuantityOut";
			this.gvcQuantityOut.MinWidth = 23;
			this.gvcQuantityOut.Name = "gvcQuantityOut";
			this.gvcQuantityOut.Visible = true;
			this.gvcQuantityOut.VisibleIndex = 8;
			this.gvcQuantityOut.Width = 87;
			// 
			// gvcIdDe
			// 
			this.gvcIdDe.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcIdDe.AppearanceHeader.Options.UseFont = true;
			this.gvcIdDe.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcIdDe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcIdDe.Caption = "Số BBGH";
			this.gvcIdDe.FieldName = "IdDe";
			this.gvcIdDe.MinWidth = 23;
			this.gvcIdDe.Name = "gvcIdDe";
			this.gvcIdDe.Visible = true;
			this.gvcIdDe.VisibleIndex = 9;
			this.gvcIdDe.Width = 87;
			// 
			// gvcLot
			// 
			this.gvcLot.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcLot.AppearanceHeader.Options.UseFont = true;
			this.gvcLot.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcLot.Caption = "Lot";
			this.gvcLot.FieldName = "Lot";
			this.gvcLot.MinWidth = 23;
			this.gvcLot.Name = "gvcLot";
			this.gvcLot.Visible = true;
			this.gvcLot.VisibleIndex = 10;
			this.gvcLot.Width = 87;
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
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.Text = "Danh Sách PO Giao";
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gcPOOutput;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1128, 654);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(546, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(413, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.dtpkDateFrom;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(238, 26);
			this.layoutControlItem2.Text = "Từ ngày:";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 15);
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.dtpkDateTo;
			this.layoutControlItem3.Location = new System.Drawing.Point(238, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(239, 26);
			this.layoutControlItem3.Text = "Đến ngày:";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 15);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnSee;
			this.layoutControlItem4.Location = new System.Drawing.Point(477, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(69, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnUpdate;
			this.layoutControlItem5.Location = new System.Drawing.Point(1048, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(80, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnExportExcel;
			this.layoutControlItem6.Location = new System.Drawing.Point(959, 0);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(89, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// frmPOOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmPOOutput";
			this.Text = "Danh Sách PO Giao";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcPOOutput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPOOutput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gcPOOutput;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPOOutput;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnSee;
        private System.Windows.Forms.DateTimePicker dtpkDateTo;
        private System.Windows.Forms.DateTimePicker dtpkDateFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gvcPartCode;
        private DevExpress.XtraGrid.Columns.GridColumn gvcPOCode;
        private DevExpress.XtraGrid.Columns.GridColumn gvcDateManufacturi;
        private DevExpress.XtraGrid.Columns.GridColumn gvcDateOutput;
        private DevExpress.XtraGrid.Columns.GridColumn gvcMachineCode;
        private DevExpress.XtraGrid.Columns.GridColumn gvcNumberMold;
        private DevExpress.XtraGrid.Columns.GridColumn gvcName;
        private DevExpress.XtraGrid.Columns.GridColumn gvcQuantityOut;
        private DevExpress.XtraGrid.Columns.GridColumn gvcIdDe;
        private DevExpress.XtraGrid.Columns.GridColumn gvcLot;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }


}