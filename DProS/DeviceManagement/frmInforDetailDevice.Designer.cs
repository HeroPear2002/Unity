namespace DProS.DeviceManagement
{
	partial class frmInforDetailDevice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInforDetailDevice));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.gcInforDetailMachine = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcDetailName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDetailInfor = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnGetMachineData = new DevExpress.XtraEditors.SimpleButton();
			this.btnInsertLine = new DevExpress.XtraEditors.SimpleButton();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcInforDetailMachine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.btnDelete);
			this.layoutControl1.Controls.Add(this.gcInforDetailMachine);
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Controls.Add(this.btnGetMachineData);
			this.layoutControl1.Controls.Add(this.btnInsertLine);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(981, 488, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1364, 736);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// btnDelete
			// 
			this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
			this.btnDelete.Location = new System.Drawing.Point(1031, 12);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(198, 36);
			this.btnDelete.StyleController = this.layoutControl1;
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// gcInforDetailMachine
			// 
			this.gcInforDetailMachine.Location = new System.Drawing.Point(12, 52);
			this.gcInforDetailMachine.MainView = this.gridView1;
			this.gcInforDetailMachine.Name = "gcInforDetailMachine";
			this.gcInforDetailMachine.Size = new System.Drawing.Size(1340, 672);
			this.gcInforDetailMachine.TabIndex = 7;
			this.gcInforDetailMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcDetailName,
            this.gvcDetailInfor,
            this.gvcId});
			this.gridView1.GridControl = this.gcInforDetailMachine;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsSelection.MultiSelect = true;
			this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gridView1.OptionsView.ShowAutoFilterRow = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.OptionsView.ShowViewCaption = true;
			this.gridView1.ViewCaption = "Thông Tin Chi Tiết Máy";
			// 
			// gvcDetailName
			// 
			this.gvcDetailName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDetailName.AppearanceCell.Options.UseFont = true;
			this.gvcDetailName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDetailName.AppearanceHeader.Options.UseFont = true;
			this.gvcDetailName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDetailName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDetailName.Caption = "Hạng mục";
			this.gvcDetailName.FieldName = "DetailName";
			this.gvcDetailName.Name = "gvcDetailName";
			this.gvcDetailName.Visible = true;
			this.gvcDetailName.VisibleIndex = 1;
			// 
			// gvcDetailInfor
			// 
			this.gvcDetailInfor.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDetailInfor.AppearanceCell.Options.UseFont = true;
			this.gvcDetailInfor.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDetailInfor.AppearanceHeader.Options.UseFont = true;
			this.gvcDetailInfor.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDetailInfor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDetailInfor.Caption = "Thông tin";
			this.gvcDetailInfor.FieldName = "DetailInfor";
			this.gvcDetailInfor.Name = "gvcDetailInfor";
			this.gvcDetailInfor.Visible = true;
			this.gvcDetailInfor.VisibleIndex = 2;
			// 
			// gvcId
			// 
			this.gvcId.Caption = "Id";
			this.gvcId.FieldName = "Id";
			this.gvcId.Name = "gvcId";
			// 
			// btnSave
			// 
			this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
			this.btnSave.Location = new System.Drawing.Point(462, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(211, 36);
			this.btnSave.StyleController = this.layoutControl1;
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "Lưu";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnGetMachineData
			// 
			this.btnGetMachineData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetMachineData.ImageOptions.Image")));
			this.btnGetMachineData.Location = new System.Drawing.Point(176, 12);
			this.btnGetMachineData.Name = "btnGetMachineData";
			this.btnGetMachineData.Size = new System.Drawing.Size(217, 36);
			this.btnGetMachineData.StyleController = this.layoutControl1;
			this.btnGetMachineData.TabIndex = 5;
			this.btnGetMachineData.Text = "Lấy dữ liệu máy";
			this.btnGetMachineData.Click += new System.EventHandler(this.btnGetMachineData_Click);
			// 
			// btnInsertLine
			// 
			this.btnInsertLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertLine.ImageOptions.Image")));
			this.btnInsertLine.Location = new System.Drawing.Point(742, 12);
			this.btnInsertLine.Name = "btnInsertLine";
			this.btnInsertLine.Size = new System.Drawing.Size(225, 36);
			this.btnInsertLine.StyleController = this.layoutControl1;
			this.btnInsertLine.TabIndex = 4;
			this.btnInsertLine.Text = "Thêm dòng";
			this.btnInsertLine.Click += new System.EventHandler(this.btnInsertLine_Click);
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
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem5,
            this.emptySpaceItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1364, 736);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.btnInsertLine;
			this.layoutControlItem1.Location = new System.Drawing.Point(730, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(229, 40);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnGetMachineData;
			this.layoutControlItem2.Location = new System.Drawing.Point(164, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(221, 40);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.btnSave;
			this.layoutControlItem3.Location = new System.Drawing.Point(450, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(215, 40);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.gcInforDetailMachine;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 40);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(1344, 676);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(164, 40);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(385, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(65, 40);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(665, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(65, 40);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(959, 0);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(60, 40);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnDelete;
			this.layoutControlItem5.Location = new System.Drawing.Point(1019, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(202, 40);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(1221, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(123, 40);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmInforDetailDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1364, 736);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmInforDetailDevice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông Tin Chi Tiết Máy";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInforDetailDevice_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcInforDetailMachine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.GridControl gcInforDetailMachine;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gvcDetailName;
		private DevExpress.XtraGrid.Columns.GridColumn gvcDetailInfor;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnGetMachineData;
		private DevExpress.XtraEditors.SimpleButton btnInsertLine;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraGrid.Columns.GridColumn gvcId;
	}
}