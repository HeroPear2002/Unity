
namespace DProS.DeviceManagement
{
	partial class frmSetupMainten
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupMainten));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gcListCategory = new DevExpress.XtraGrid.GridControl();
			this.gvListCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcNameCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcTimer = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDetail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcListMachine = new DevExpress.XtraGrid.GridControl();
			this.gvListMachine = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnEditInfor = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.cbDeviceType = new System.Windows.Forms.ComboBox();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcListCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvListCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcListMachine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvListMachine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gcListCategory);
			this.layoutControl1.Controls.Add(this.gcListMachine);
			this.layoutControl1.Controls.Add(this.btnEditInfor);
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Controls.Add(this.cbDeviceType);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1102, 321, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// gcListCategory
			// 
			this.gcListCategory.Location = new System.Drawing.Point(423, 38);
			this.gcListCategory.MainView = this.gvListCategory;
			this.gcListCategory.Name = "gcListCategory";
			this.gcListCategory.Size = new System.Drawing.Size(717, 654);
			this.gcListCategory.TabIndex = 9;
			this.gcListCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListCategory});
			// 
			// gvListCategory
			// 
			this.gvListCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcNameCategory,
            this.gvcMethod,
            this.gvcTimer,
            this.gvcDetail});
			this.gvListCategory.DetailHeight = 404;
			this.gvListCategory.GridControl = this.gcListCategory;
			this.gvListCategory.Name = "gvListCategory";
			this.gvListCategory.OptionsCustomization.AllowGroup = false;
			this.gvListCategory.OptionsSelection.MultiSelect = true;
			this.gvListCategory.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvListCategory.OptionsView.RowAutoHeight = true;
			this.gvListCategory.OptionsView.ShowAutoFilterRow = true;
			this.gvListCategory.OptionsView.ShowGroupPanel = false;
			this.gvListCategory.OptionsView.ShowViewCaption = true;
			this.gvListCategory.ViewCaption = "Danh Sách Hạng Mục Bảo Dưỡng Định Kỳ";
			// 
			// gvcNameCategory
			// 
			this.gvcNameCategory.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNameCategory.AppearanceCell.Options.UseFont = true;
			this.gvcNameCategory.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNameCategory.AppearanceHeader.Options.UseFont = true;
			this.gvcNameCategory.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcNameCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcNameCategory.Caption = "Tên hạng mục";
			this.gvcNameCategory.FieldName = "NameCategory";
			this.gvcNameCategory.Name = "gvcNameCategory";
			this.gvcNameCategory.Visible = true;
			this.gvcNameCategory.VisibleIndex = 1;
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
			this.gvcMethod.VisibleIndex = 2;
			// 
			// gvcTimer
			// 
			this.gvcTimer.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTimer.AppearanceCell.Options.UseFont = true;
			this.gvcTimer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTimer.AppearanceHeader.Options.UseFont = true;
			this.gvcTimer.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcTimer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcTimer.Caption = "Thời gian ( h )";
			this.gvcTimer.FieldName = "Timer";
			this.gvcTimer.Name = "gvcTimer";
			this.gvcTimer.Visible = true;
			this.gvcTimer.VisibleIndex = 3;
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
			// gcListMachine
			// 
			this.gcListMachine.Location = new System.Drawing.Point(12, 38);
			this.gcListMachine.MainView = this.gvListMachine;
			this.gcListMachine.Name = "gcListMachine";
			this.gcListMachine.Size = new System.Drawing.Size(407, 654);
			this.gcListMachine.TabIndex = 8;
			this.gcListMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListMachine});
			// 
			// gvListMachine
			// 
			this.gvListMachine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcMachineCode,
            this.gvcMachineName});
			this.gvListMachine.DetailHeight = 404;
			this.gvListMachine.GridControl = this.gcListMachine;
			this.gvListMachine.Name = "gvListMachine";
			this.gvListMachine.OptionsCustomization.AllowGroup = false;
			this.gvListMachine.OptionsSelection.MultiSelect = true;
			this.gvListMachine.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvListMachine.OptionsView.ShowAutoFilterRow = true;
			this.gvListMachine.OptionsView.ShowGroupPanel = false;
			this.gvListMachine.OptionsView.ShowViewCaption = true;
			this.gvListMachine.ViewCaption = "Danh Sách Thiết Bị";
			// 
			// gvcMachineCode
			// 
			this.gvcMachineCode.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineCode.AppearanceCell.Options.UseFont = true;
			this.gvcMachineCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineCode.AppearanceHeader.Options.UseFont = true;
			this.gvcMachineCode.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcMachineCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcMachineCode.Caption = "Mã thiết bị";
			this.gvcMachineCode.FieldName = "MachineCode";
			this.gvcMachineCode.Name = "gvcMachineCode";
			this.gvcMachineCode.Visible = true;
			this.gvcMachineCode.VisibleIndex = 1;
			// 
			// gvcMachineName
			// 
			this.gvcMachineName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineName.AppearanceCell.Options.UseFont = true;
			this.gvcMachineName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcMachineName.AppearanceHeader.Options.UseFont = true;
			this.gvcMachineName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcMachineName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcMachineName.Caption = "Tên thiết bị";
			this.gvcMachineName.FieldName = "MachineName";
			this.gvcMachineName.Name = "gvcMachineName";
			this.gvcMachineName.Visible = true;
			this.gvcMachineName.VisibleIndex = 2;
			// 
			// btnEditInfor
			// 
			this.btnEditInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditInfor.ImageOptions.Image")));
			this.btnEditInfor.Location = new System.Drawing.Point(542, 12);
			this.btnEditInfor.Name = "btnEditInfor";
			this.btnEditInfor.Size = new System.Drawing.Size(99, 22);
			this.btnEditInfor.StyleController = this.layoutControl1;
			this.btnEditInfor.TabIndex = 7;
			this.btnEditInfor.Text = "Sửa thông tin";
			this.btnEditInfor.Click += new System.EventHandler(this.btnEditInfor_Click);
			// 
			// btnSave
			// 
			this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
			this.btnSave.Location = new System.Drawing.Point(434, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(69, 22);
			this.btnSave.StyleController = this.layoutControl1;
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Lưu";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// cbDeviceType
			// 
			this.cbDeviceType.FormattingEnabled = true;
			this.cbDeviceType.Location = new System.Drawing.Point(86, 12);
			this.cbDeviceType.Name = "cbDeviceType";
			this.cbDeviceType.Size = new System.Drawing.Size(334, 23);
			this.cbDeviceType.TabIndex = 4;
			this.cbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cbDeviceType_SelectedIndexChanged);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbDeviceType;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(412, 26);
			this.layoutControlItem1.Text = "Loại thiết bị: ";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 15);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.btnSave;
			this.layoutControlItem3.Location = new System.Drawing.Point(422, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(73, 26);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnEditInfor;
			this.layoutControlItem4.Location = new System.Drawing.Point(530, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(103, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.gcListMachine;
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(411, 658);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.gcListCategory;
			this.layoutControlItem6.Location = new System.Drawing.Point(411, 26);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(721, 658);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(412, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(495, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(35, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(633, 0);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(499, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmSetupMainten
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmSetupMainten";
			this.Text = "THIẾT LẬP KT ĐỊNH KỲ";
			this.Load += new System.EventHandler(this.frmSetupMainten_Load);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcListCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvListCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcListMachine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvListMachine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.ComboBox cbDeviceType;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraGrid.GridControl gcListCategory;
		private DevExpress.XtraGrid.Views.Grid.GridView gvListCategory;
		private DevExpress.XtraGrid.GridControl gcListMachine;
		private DevExpress.XtraGrid.Views.Grid.GridView gvListMachine;
		private DevExpress.XtraEditors.SimpleButton btnEditInfor;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraGrid.Columns.GridColumn gvcNameCategory;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMethod;
		private DevExpress.XtraGrid.Columns.GridColumn gvcTimer;
		private DevExpress.XtraGrid.Columns.GridColumn gvcDetail;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMachineCode;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMachineName;
	}
}
