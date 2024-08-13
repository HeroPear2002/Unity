namespace DProS.DeviceManagement
{
	partial class frmSetupMaintenEditInfor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupMaintenEditInfor));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gcRelationMachineCate = new DevExpress.XtraGrid.GridControl();
			this.gvRelationMachineCate = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcNameCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDetail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcStatusRe = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.cbDeviceType = new System.Windows.Forms.ComboBox();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.gvcTimeReality = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcRelationMachineCate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRelationMachineCate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gcRelationMachineCate);
			this.layoutControl1.Controls.Add(this.btnDelete);
			this.layoutControl1.Controls.Add(this.cbDeviceType);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 356, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1144, 604);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// gcRelationMachineCate
			// 
			this.gcRelationMachineCate.Location = new System.Drawing.Point(12, 38);
			this.gcRelationMachineCate.MainView = this.gvRelationMachineCate;
			this.gcRelationMachineCate.Name = "gcRelationMachineCate";
			this.gcRelationMachineCate.Size = new System.Drawing.Size(1120, 554);
			this.gcRelationMachineCate.TabIndex = 6;
			this.gcRelationMachineCate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRelationMachineCate});
			// 
			// gvRelationMachineCate
			// 
			this.gvRelationMachineCate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcId,
            this.gvcMachineCode,
            this.gvcNameCategory,
            this.gvcMethod,
            this.gvcDetail,
            this.gvcTimeReality,
            this.gvcStatusRe});
			this.gvRelationMachineCate.GridControl = this.gcRelationMachineCate;
			this.gvRelationMachineCate.Name = "gvRelationMachineCate";
			this.gvRelationMachineCate.OptionsCustomization.AllowGroup = false;
			this.gvRelationMachineCate.OptionsSelection.MultiSelect = true;
			this.gvRelationMachineCate.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvRelationMachineCate.OptionsView.ShowAutoFilterRow = true;
			this.gvRelationMachineCate.OptionsView.ShowGroupPanel = false;
			// 
			// gvcId
			// 
			this.gvcId.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcId.AppearanceCell.Options.UseFont = true;
			this.gvcId.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcId.AppearanceHeader.Options.UseFont = true;
			this.gvcId.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcId.Caption = "ID";
			this.gvcId.FieldName = "Id";
			this.gvcId.Name = "gvcId";
			// 
			// gvcMachineCode
			// 
			this.gvcMachineCode.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineCode.AppearanceCell.Options.UseFont = true;
			this.gvcMachineCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineCode.AppearanceHeader.Options.UseFont = true;
			this.gvcMachineCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcMachineCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcMachineCode.Caption = "Mã máy";
			this.gvcMachineCode.FieldName = "MachineCode";
			this.gvcMachineCode.Name = "gvcMachineCode";
			this.gvcMachineCode.Visible = true;
			this.gvcMachineCode.VisibleIndex = 1;
			// 
			// gvcNameCategory
			// 
			this.gvcNameCategory.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNameCategory.AppearanceCell.Options.UseFont = true;
			this.gvcNameCategory.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNameCategory.AppearanceHeader.Options.UseFont = true;
			this.gvcNameCategory.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcNameCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcNameCategory.Caption = "Tên hạng mục kiểm tra";
			this.gvcNameCategory.FieldName = "NameCategory";
			this.gvcNameCategory.Name = "gvcNameCategory";
			this.gvcNameCategory.Visible = true;
			this.gvcNameCategory.VisibleIndex = 2;
			// 
			// gvcMethod
			// 
			this.gvcMethod.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMethod.AppearanceCell.Options.UseFont = true;
			this.gvcMethod.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMethod.AppearanceHeader.Options.UseFont = true;
			this.gvcMethod.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcMethod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcMethod.Caption = "Phương pháp thực hiện";
			this.gvcMethod.FieldName = "Method";
			this.gvcMethod.Name = "gvcMethod";
			this.gvcMethod.Visible = true;
			this.gvcMethod.VisibleIndex = 3;
			// 
			// gvcDetail
			// 
			this.gvcDetail.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDetail.AppearanceCell.Options.UseFont = true;
			this.gvcDetail.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDetail.AppearanceHeader.Options.UseFont = true;
			this.gvcDetail.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDetail.Caption = "Tiêu chuẩn phán định";
			this.gvcDetail.FieldName = "Detail";
			this.gvcDetail.Name = "gvcDetail";
			this.gvcDetail.Visible = true;
			this.gvcDetail.VisibleIndex = 4;
			// 
			// gvcStatusRe
			// 
			this.gvcStatusRe.Caption = "Trạng thái liên kết";
			this.gvcStatusRe.FieldName = "StatusRe";
			this.gvcStatusRe.Name = "gvcStatusRe";
			// 
			// btnDelete
			// 
			this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
			this.btnDelete.Location = new System.Drawing.Point(583, 12);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(104, 22);
			this.btnDelete.StyleController = this.layoutControl1;
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// cbDeviceType
			// 
			this.cbDeviceType.FormattingEnabled = true;
			this.cbDeviceType.Location = new System.Drawing.Point(84, 12);
			this.cbDeviceType.Name = "cbDeviceType";
			this.cbDeviceType.Size = new System.Drawing.Size(485, 23);
			this.cbDeviceType.TabIndex = 4;
			this.cbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cbDeviceType_SelectedIndexChanged);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1144, 604);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbDeviceType;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(561, 26);
			this.layoutControlItem1.Text = "Loại thiết bị: ";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 15);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnDelete;
			this.layoutControlItem2.Location = new System.Drawing.Point(571, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(108, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gcRelationMachineCate;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(1124, 558);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(561, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(679, 0);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(445, 26);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// gvcTimeReality
			// 
			this.gvcTimeReality.Caption = "Thời gian chạy thực tế";
			this.gvcTimeReality.FieldName = "TimeReality";
			this.gvcTimeReality.Name = "gvcTimeReality";
			// 
			// frmSetupMaintenEditInfor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1144, 604);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmSetupMaintenEditInfor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sửa Thông Tin";
			this.Load += new System.EventHandler(this.frmSetupMaintenEditInfor_Load);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcRelationMachineCate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRelationMachineCate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.GridControl gcRelationMachineCate;
		private DevExpress.XtraGrid.Views.Grid.GridView gvRelationMachineCate;
		private DevExpress.XtraGrid.Columns.GridColumn gvcId;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMachineCode;
		private DevExpress.XtraGrid.Columns.GridColumn gvcNameCategory;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMethod;
		private DevExpress.XtraGrid.Columns.GridColumn gvcDetail;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private System.Windows.Forms.ComboBox cbDeviceType;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraGrid.Columns.GridColumn gvcStatusRe;
		private DevExpress.XtraGrid.Columns.GridColumn gvcTimeReality;
	}
}