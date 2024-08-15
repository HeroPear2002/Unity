namespace DProS.DeviceManagement
{
	partial class frmCheckMaintenDevice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckMaintenDevice));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gcCheckDevice = new DevExpress.XtraGrid.GridControl();
			this.gvCheckDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcIdRelationShip = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcNameCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDetail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcTimeReality = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcTimer = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcDataCount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcResult = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cbResult = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.gvcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcNote = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcStatusCate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnWatchWork = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcCheckDevice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvCheckDevice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gcCheckDevice);
			this.layoutControl1.Controls.Add(this.btnWatchWork);
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(981, 488, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1364, 736);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// gcCheckDevice
			// 
			this.gcCheckDevice.Location = new System.Drawing.Point(12, 52);
			this.gcCheckDevice.MainView = this.gvCheckDevice;
			this.gcCheckDevice.Name = "gcCheckDevice";
			this.gcCheckDevice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbResult});
			this.gcCheckDevice.Size = new System.Drawing.Size(1340, 672);
			this.gcCheckDevice.TabIndex = 6;
			this.gcCheckDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCheckDevice});
			// 
			// gvCheckDevice
			// 
			this.gvCheckDevice.Appearance.ViewCaption.BackColor = System.Drawing.Color.Black;
			this.gvCheckDevice.Appearance.ViewCaption.Options.UseBackColor = true;
			this.gvCheckDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcIdRelationShip,
            this.gvcNameCategory,
            this.gvcMethod,
            this.gvcDetail,
            this.gvcTimeReality,
            this.gvcTimer,
            this.gvcDataCount,
            this.gvcResult,
            this.gvcUserName,
            this.gvcNote,
            this.gvcStatusCate});
			this.gvCheckDevice.GridControl = this.gcCheckDevice;
			this.gvCheckDevice.Name = "gvCheckDevice";
			this.gvCheckDevice.OptionsCustomization.AllowGroup = false;
			this.gvCheckDevice.OptionsSelection.MultiSelect = true;
			this.gvCheckDevice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvCheckDevice.OptionsView.ShowAutoFilterRow = true;
			this.gvCheckDevice.OptionsView.ShowGroupPanel = false;
			this.gvCheckDevice.OptionsView.ShowViewCaption = true;
			this.gvCheckDevice.ViewCaption = "Danh Sách Hạng Mục Cần Kiểm Tra: ";
			this.gvCheckDevice.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvCheckDevice_RowCellStyle);
			this.gvCheckDevice.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvCheckDevice_RowStyle);
			this.gvCheckDevice.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvCheckDevice_CellValueChanged);
			// 
			// gvcIdRelationShip
			// 
			this.gvcIdRelationShip.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcIdRelationShip.AppearanceCell.Options.UseFont = true;
			this.gvcIdRelationShip.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcIdRelationShip.AppearanceHeader.Options.UseFont = true;
			this.gvcIdRelationShip.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcIdRelationShip.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcIdRelationShip.Caption = "ID thiết lập";
			this.gvcIdRelationShip.FieldName = "IdRelationShip";
			this.gvcIdRelationShip.Name = "gvcIdRelationShip";
			this.gvcIdRelationShip.OptionsColumn.AllowEdit = false;
			// 
			// gvcNameCategory
			// 
			this.gvcNameCategory.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNameCategory.AppearanceCell.Options.UseFont = true;
			this.gvcNameCategory.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNameCategory.AppearanceHeader.Options.UseFont = true;
			this.gvcNameCategory.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcNameCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcNameCategory.Caption = "Tên hạng mục BD";
			this.gvcNameCategory.FieldName = "NameCategory";
			this.gvcNameCategory.Name = "gvcNameCategory";
			this.gvcNameCategory.OptionsColumn.AllowEdit = false;
			this.gvcNameCategory.Visible = true;
			this.gvcNameCategory.VisibleIndex = 1;
			this.gvcNameCategory.Width = 207;
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
			this.gvcMethod.OptionsColumn.AllowEdit = false;
			this.gvcMethod.Visible = true;
			this.gvcMethod.VisibleIndex = 2;
			this.gvcMethod.Width = 231;
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
			this.gvcDetail.OptionsColumn.AllowEdit = false;
			this.gvcDetail.Visible = true;
			this.gvcDetail.VisibleIndex = 3;
			this.gvcDetail.Width = 187;
			// 
			// gvcTimeReality
			// 
			this.gvcTimeReality.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTimeReality.AppearanceCell.Options.UseFont = true;
			this.gvcTimeReality.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTimeReality.AppearanceHeader.Options.UseFont = true;
			this.gvcTimeReality.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcTimeReality.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcTimeReality.Caption = "TG chạy ( h )";
			this.gvcTimeReality.FieldName = "TimeReality";
			this.gvcTimeReality.Name = "gvcTimeReality";
			this.gvcTimeReality.OptionsColumn.AllowEdit = false;
			this.gvcTimeReality.Visible = true;
			this.gvcTimeReality.VisibleIndex = 4;
			this.gvcTimeReality.Width = 118;
			// 
			// gvcTimer
			// 
			this.gvcTimer.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTimer.AppearanceCell.Options.UseFont = true;
			this.gvcTimer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTimer.AppearanceHeader.Options.UseFont = true;
			this.gvcTimer.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcTimer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcTimer.Caption = "TG tiêu chuẩn ( h )";
			this.gvcTimer.FieldName = "Timer";
			this.gvcTimer.Name = "gvcTimer";
			this.gvcTimer.OptionsColumn.AllowEdit = false;
			this.gvcTimer.Visible = true;
			this.gvcTimer.VisibleIndex = 5;
			this.gvcTimer.Width = 118;
			// 
			// gvcDataCount
			// 
			this.gvcDataCount.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDataCount.AppearanceCell.Options.UseFont = true;
			this.gvcDataCount.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDataCount.AppearanceHeader.Options.UseFont = true;
			this.gvcDataCount.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDataCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDataCount.Caption = "Thực tế";
			this.gvcDataCount.FieldName = "DataCount";
			this.gvcDataCount.Name = "gvcDataCount";
			this.gvcDataCount.Visible = true;
			this.gvcDataCount.VisibleIndex = 6;
			this.gvcDataCount.Width = 118;
			// 
			// gvcResult
			// 
			this.gvcResult.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcResult.AppearanceCell.Options.UseFont = true;
			this.gvcResult.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcResult.AppearanceHeader.Options.UseFont = true;
			this.gvcResult.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcResult.Caption = "Kết quả";
			this.gvcResult.ColumnEdit = this.cbResult;
			this.gvcResult.FieldName = "Result";
			this.gvcResult.Name = "gvcResult";
			this.gvcResult.Visible = true;
			this.gvcResult.VisibleIndex = 7;
			this.gvcResult.Width = 86;
			// 
			// cbResult
			// 
			this.cbResult.AutoHeight = false;
			this.cbResult.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbResult.Name = "cbResult";
			// 
			// gvcUserName
			// 
			this.gvcUserName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcUserName.AppearanceCell.Options.UseFont = true;
			this.gvcUserName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcUserName.AppearanceHeader.Options.UseFont = true;
			this.gvcUserName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcUserName.Caption = "Người KT";
			this.gvcUserName.FieldName = "UserName";
			this.gvcUserName.Name = "gvcUserName";
			this.gvcUserName.OptionsColumn.AllowEdit = false;
			this.gvcUserName.Visible = true;
			this.gvcUserName.VisibleIndex = 8;
			// 
			// gvcNote
			// 
			this.gvcNote.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNote.AppearanceCell.Options.UseFont = true;
			this.gvcNote.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcNote.AppearanceHeader.Options.UseFont = true;
			this.gvcNote.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcNote.Caption = "Ghi chú";
			this.gvcNote.FieldName = "Note";
			this.gvcNote.Name = "gvcNote";
			this.gvcNote.Visible = true;
			this.gvcNote.VisibleIndex = 9;
			this.gvcNote.Width = 175;
			// 
			// gvcStatusCate
			// 
			this.gvcStatusCate.Caption = "Có thông số đo hay không";
			this.gvcStatusCate.FieldName = "StatusCate";
			this.gvcStatusCate.Name = "gvcStatusCate";
			// 
			// btnWatchWork
			// 
			this.btnWatchWork.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWatchWork.ImageOptions.Image")));
			this.btnWatchWork.Location = new System.Drawing.Point(693, 12);
			this.btnWatchWork.Name = "btnWatchWork";
			this.btnWatchWork.Size = new System.Drawing.Size(249, 36);
			this.btnWatchWork.StyleController = this.layoutControl1;
			this.btnWatchWork.TabIndex = 5;
			this.btnWatchWork.Text = "Xem phương pháp thực hiện";
			// 
			// btnSave
			// 
			this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
			this.btnSave.Location = new System.Drawing.Point(442, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(237, 36);
			this.btnSave.StyleController = this.layoutControl1;
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Lưu";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1364, 736);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.btnSave;
			this.layoutControlItem1.Location = new System.Drawing.Point(430, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(241, 40);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnWatchWork;
			this.layoutControlItem2.Location = new System.Drawing.Point(681, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(253, 40);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gcCheckDevice;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 40);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(1344, 676);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(430, 40);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(671, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(10, 40);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(934, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(410, 40);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmCheckMaintenDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1364, 736);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmCheckMaintenDevice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kiểm Tra Định Kỳ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckMaintenDevice_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcCheckDevice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvCheckDevice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbResult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.Views.Grid.GridView gvCheckDevice;
		private DevExpress.XtraEditors.SimpleButton btnWatchWork;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraGrid.GridControl gcCheckDevice;
		public DevExpress.XtraGrid.Columns.GridColumn gvcDataCount;
		public DevExpress.XtraGrid.Columns.GridColumn gvcResult;
		public DevExpress.XtraGrid.Columns.GridColumn gvcNote;
		public DevExpress.XtraGrid.Columns.GridColumn gvcNameCategory;
		public DevExpress.XtraGrid.Columns.GridColumn gvcMethod;
		public DevExpress.XtraGrid.Columns.GridColumn gvcDetail;
		public DevExpress.XtraGrid.Columns.GridColumn gvcTimeReality;
		public DevExpress.XtraGrid.Columns.GridColumn gvcTimer;
		public DevExpress.XtraGrid.Columns.GridColumn gvcIdRelationShip;
		public DevExpress.XtraGrid.Columns.GridColumn gvcUserName;
		private DevExpress.XtraGrid.Columns.GridColumn gvcStatusCate;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbResult;
	}
}