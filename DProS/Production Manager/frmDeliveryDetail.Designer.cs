namespace DProS.Production_Manager
{
	partial class frmDeliveryDetail
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliveryDetail));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gcDeliveryDetail = new DevExpress.XtraGrid.GridControl();
			this.gvDeliveryDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcPOCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDateDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcPartCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcFactoryCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcCarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcQuantityOut = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
			this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
			this.btnExportPOInfor = new DevExpress.XtraEditors.SimpleButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.txtArrayPOCode = new System.Windows.Forms.TextBox();
			this.glPOFix = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcDeliveryDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDeliveryDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.glPOFix.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gcDeliveryDetail);
			this.layoutControl1.Controls.Add(this.btnUpdate);
			this.layoutControl1.Controls.Add(this.btnDelete);
			this.layoutControl1.Controls.Add(this.btnExportExcel);
			this.layoutControl1.Controls.Add(this.btnInsert);
			this.layoutControl1.Controls.Add(this.btnExportPOInfor);
			this.layoutControl1.Controls.Add(this.checkBox1);
			this.layoutControl1.Controls.Add(this.txtArrayPOCode);
			this.layoutControl1.Controls.Add(this.glPOFix);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(967, 488, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1364, 736);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// gcDeliveryDetail
			// 
			this.gcDeliveryDetail.Location = new System.Drawing.Point(12, 88);
			this.gcDeliveryDetail.MainView = this.gvDeliveryDetail;
			this.gcDeliveryDetail.Name = "gcDeliveryDetail";
			this.gcDeliveryDetail.Size = new System.Drawing.Size(1340, 636);
			this.gcDeliveryDetail.TabIndex = 12;
			this.gcDeliveryDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeliveryDetail});
			// 
			// gvDeliveryDetail
			// 
			this.gvDeliveryDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcPOCode,
            this.gvcQuantity,
            this.gvcDateDelivery,
            this.gvcPartCode,
            this.gvcFactoryCustomer,
            this.gvcCarNumber,
            this.gvcQuantityOut,
            this.gvcId,
            this.gvcStatus});
			this.gvDeliveryDetail.GridControl = this.gcDeliveryDetail;
			this.gvDeliveryDetail.Name = "gvDeliveryDetail";
			this.gvDeliveryDetail.OptionsCustomization.AllowGroup = false;
			this.gvDeliveryDetail.OptionsSelection.MultiSelect = true;
			this.gvDeliveryDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvDeliveryDetail.OptionsView.ShowAutoFilterRow = true;
			this.gvDeliveryDetail.OptionsView.ShowGroupPanel = false;
			this.gvDeliveryDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvDeliveryDetail_RowStyle);
			// 
			// gvcPOCode
			// 
			this.gvcPOCode.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcPOCode.AppearanceCell.Options.UseFont = true;
			this.gvcPOCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcPOCode.AppearanceHeader.Options.UseFont = true;
			this.gvcPOCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcPOCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcPOCode.Caption = "Mã PO";
			this.gvcPOCode.FieldName = "POCode";
			this.gvcPOCode.Name = "gvcPOCode";
			this.gvcPOCode.Visible = true;
			this.gvcPOCode.VisibleIndex = 1;
			// 
			// gvcQuantity
			// 
			this.gvcQuantity.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcQuantity.AppearanceCell.Options.UseFont = true;
			this.gvcQuantity.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcQuantity.AppearanceHeader.Options.UseFont = true;
			this.gvcQuantity.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcQuantity.Caption = "Số lượng";
			this.gvcQuantity.FieldName = "Quantity";
			this.gvcQuantity.Name = "gvcQuantity";
			this.gvcQuantity.Visible = true;
			this.gvcQuantity.VisibleIndex = 2;
			// 
			// gvcDateDelivery
			// 
			this.gvcDateDelivery.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDateDelivery.AppearanceCell.Options.UseFont = true;
			this.gvcDateDelivery.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDateDelivery.AppearanceHeader.Options.UseFont = true;
			this.gvcDateDelivery.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDateDelivery.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDateDelivery.Caption = "Ngày giao";
			this.gvcDateDelivery.FieldName = "DateDelivery";
			this.gvcDateDelivery.Name = "gvcDateDelivery";
			this.gvcDateDelivery.Visible = true;
			this.gvcDateDelivery.VisibleIndex = 3;
			// 
			// gvcPartCode
			// 
			this.gvcPartCode.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcPartCode.AppearanceCell.Options.UseFont = true;
			this.gvcPartCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcPartCode.AppearanceHeader.Options.UseFont = true;
			this.gvcPartCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcPartCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcPartCode.Caption = "Mã linh liện";
			this.gvcPartCode.FieldName = "PartCode";
			this.gvcPartCode.Name = "gvcPartCode";
			this.gvcPartCode.Visible = true;
			this.gvcPartCode.VisibleIndex = 4;
			// 
			// gvcFactoryCustomer
			// 
			this.gvcFactoryCustomer.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcFactoryCustomer.AppearanceCell.Options.UseFont = true;
			this.gvcFactoryCustomer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcFactoryCustomer.AppearanceHeader.Options.UseFont = true;
			this.gvcFactoryCustomer.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcFactoryCustomer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcFactoryCustomer.Caption = "Nhà máy";
			this.gvcFactoryCustomer.FieldName = "FactoryCustomer";
			this.gvcFactoryCustomer.Name = "gvcFactoryCustomer";
			this.gvcFactoryCustomer.Visible = true;
			this.gvcFactoryCustomer.VisibleIndex = 5;
			// 
			// gvcCarNumber
			// 
			this.gvcCarNumber.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcCarNumber.AppearanceCell.Options.UseFont = true;
			this.gvcCarNumber.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcCarNumber.AppearanceHeader.Options.UseFont = true;
			this.gvcCarNumber.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcCarNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcCarNumber.Caption = "Số xe";
			this.gvcCarNumber.FieldName = "CarNumber";
			this.gvcCarNumber.Name = "gvcCarNumber";
			this.gvcCarNumber.Visible = true;
			this.gvcCarNumber.VisibleIndex = 6;
			// 
			// gvcQuantityOut
			// 
			this.gvcQuantityOut.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcQuantityOut.AppearanceCell.Options.UseFont = true;
			this.gvcQuantityOut.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcQuantityOut.AppearanceHeader.Options.UseFont = true;
			this.gvcQuantityOut.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcQuantityOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcQuantityOut.Caption = "Số lượng xuất";
			this.gvcQuantityOut.FieldName = "QuantityOut";
			this.gvcQuantityOut.Name = "gvcQuantityOut";
			this.gvcQuantityOut.Visible = true;
			this.gvcQuantityOut.VisibleIndex = 7;
			// 
			// gvcId
			// 
			this.gvcId.Caption = "IdPOFix";
			this.gvcId.FieldName = "Id";
			this.gvcId.Name = "gvcId";
			// 
			// gvcStatus
			// 
			this.gvcStatus.Caption = "Trạng thái";
			this.gvcStatus.FieldName = "Status";
			this.gvcStatus.Name = "gvcStatus";
			// 
			// btnUpdate
			// 
			this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
			this.btnUpdate.Location = new System.Drawing.Point(197, 62);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(113, 22);
			this.btnUpdate.StyleController = this.layoutControl1;
			this.btnUpdate.TabIndex = 11;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
			this.btnDelete.Location = new System.Drawing.Point(103, 62);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(90, 22);
			this.btnDelete.StyleController = this.layoutControl1;
			this.btnDelete.TabIndex = 10;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnExportExcel
			// 
			this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
			this.btnExportExcel.Location = new System.Drawing.Point(314, 62);
			this.btnExportExcel.Name = "btnExportExcel";
			this.btnExportExcel.Size = new System.Drawing.Size(119, 22);
			this.btnExportExcel.StyleController = this.layoutControl1;
			this.btnExportExcel.TabIndex = 9;
			this.btnExportExcel.Text = "Xuất Excel";
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.ImageOptions.Image")));
			this.btnInsert.Location = new System.Drawing.Point(12, 62);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(87, 22);
			this.btnInsert.StyleController = this.layoutControl1;
			this.btnInsert.TabIndex = 8;
			this.btnInsert.Text = "Thêm";
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// btnExportPOInfor
			// 
			this.btnExportPOInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPOInfor.ImageOptions.Image")));
			this.btnExportPOInfor.Location = new System.Drawing.Point(437, 62);
			this.btnExportPOInfor.Name = "btnExportPOInfor";
			this.btnExportPOInfor.Size = new System.Drawing.Size(153, 22);
			this.btnExportPOInfor.StyleController = this.layoutControl1;
			this.btnExportPOInfor.TabIndex = 7;
			this.btnExportPOInfor.Text = "Xuất thông tin PO";
			this.btnExportPOInfor.Click += new System.EventHandler(this.btnExportPOInfor_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.BackColor = System.Drawing.Color.Yellow;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(1139, 62);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(213, 20);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "PO chưa xuất";
			this.checkBox1.UseVisualStyleBackColor = false;
			// 
			// txtArrayPOCode
			// 
			this.txtArrayPOCode.Location = new System.Drawing.Point(12, 38);
			this.txtArrayPOCode.Name = "txtArrayPOCode";
			this.txtArrayPOCode.Size = new System.Drawing.Size(1340, 20);
			this.txtArrayPOCode.TabIndex = 5;
			// 
			// glPOFix
			// 
			this.glPOFix.Location = new System.Drawing.Point(86, 12);
			this.glPOFix.Name = "glPOFix";
			this.glPOFix.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.glPOFix.Properties.PopupView = this.gridLookUpEdit1View;
			this.glPOFix.Size = new System.Drawing.Size(1266, 22);
			this.glPOFix.StyleController = this.layoutControl1;
			this.glPOFix.TabIndex = 4;
			this.glPOFix.EditValueChanged += new System.EventHandler(this.glPOFix_EditValueChanged);
			// 
			// gridLookUpEdit1View
			// 
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
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1364, 736);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.glPOFix;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1344, 26);
			this.layoutControlItem1.Text = "Chọn POFix: ";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 15);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.txtArrayPOCode;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(1344, 24);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.checkBox1;
			this.layoutControlItem3.Location = new System.Drawing.Point(1127, 50);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(217, 26);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnExportPOInfor;
			this.layoutControlItem4.Location = new System.Drawing.Point(425, 50);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(157, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnInsert;
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(91, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnExportExcel;
			this.layoutControlItem6.Location = new System.Drawing.Point(302, 50);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(123, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.btnDelete;
			this.layoutControlItem7.Location = new System.Drawing.Point(91, 50);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(94, 26);
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextVisible = false;
			// 
			// layoutControlItem8
			// 
			this.layoutControlItem8.Control = this.btnUpdate;
			this.layoutControlItem8.Location = new System.Drawing.Point(185, 50);
			this.layoutControlItem8.Name = "layoutControlItem8";
			this.layoutControlItem8.Size = new System.Drawing.Size(117, 26);
			this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem8.TextVisible = false;
			// 
			// layoutControlItem9
			// 
			this.layoutControlItem9.Control = this.gcDeliveryDetail;
			this.layoutControlItem9.Location = new System.Drawing.Point(0, 76);
			this.layoutControlItem9.Name = "layoutControlItem9";
			this.layoutControlItem9.Size = new System.Drawing.Size(1344, 640);
			this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem9.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(582, 50);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(545, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmDeliveryDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1364, 736);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmDeliveryDetail";
			this.Text = "Chi Tiết BBGH";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcDeliveryDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDeliveryDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.glPOFix.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.GridControl gcDeliveryDetail;
		private DevExpress.XtraGrid.Views.Grid.GridView gvDeliveryDetail;
		private DevExpress.XtraGrid.Columns.GridColumn gvcPOCode;
		private DevExpress.XtraGrid.Columns.GridColumn gvcQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn gvcDateDelivery;
		private DevExpress.XtraGrid.Columns.GridColumn gvcPartCode;
		private DevExpress.XtraGrid.Columns.GridColumn gvcFactoryCustomer;
		private DevExpress.XtraGrid.Columns.GridColumn gvcCarNumber;
		private DevExpress.XtraGrid.Columns.GridColumn gvcQuantityOut;
		private DevExpress.XtraEditors.SimpleButton btnUpdate;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraEditors.SimpleButton btnExportExcel;
		private DevExpress.XtraEditors.SimpleButton btnInsert;
		private DevExpress.XtraEditors.SimpleButton btnExportPOInfor;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox txtArrayPOCode;
		private DevExpress.XtraEditors.GridLookUpEdit glPOFix;
		private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraGrid.Columns.GridColumn gvcId;
		private DevExpress.XtraGrid.Columns.GridColumn gvcStatus;
	}
}