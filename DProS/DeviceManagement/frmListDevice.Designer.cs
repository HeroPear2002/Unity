
namespace DProS.DeviceManagement
{
	partial class frmListDevice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListDevice));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gcDevice = new DevExpress.XtraGrid.GridControl();
			this.gvDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnCodeSmall = new DevExpress.XtraEditors.SimpleButton();
			this.btnCodeMedium = new DevExpress.XtraEditors.SimpleButton();
			this.btnCodeLarge = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnEditCodeMachine = new DevExpress.XtraEditors.SimpleButton();
			this.cbDeviceType = new System.Windows.Forms.ComboBox();
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
			this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.gvcIdDevice = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcDevice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDevice)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gcDevice);
			this.layoutControl1.Controls.Add(this.btnCodeSmall);
			this.layoutControl1.Controls.Add(this.btnCodeMedium);
			this.layoutControl1.Controls.Add(this.btnCodeLarge);
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Controls.Add(this.btnEdit);
			this.layoutControl1.Controls.Add(this.btnUpdate);
			this.layoutControl1.Controls.Add(this.btnDelete);
			this.layoutControl1.Controls.Add(this.btnEditCodeMachine);
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
			// gcDevice
			// 
			this.gcDevice.Location = new System.Drawing.Point(12, 63);
			this.gcDevice.MainView = this.gvDevice;
			this.gcDevice.Name = "gcDevice";
			this.gcDevice.Size = new System.Drawing.Size(1128, 629);
			this.gcDevice.TabIndex = 13;
			this.gcDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDevice});
			// 
			// gvDevice
			// 
			this.gvDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcMachineCode,
            this.gvcMachineName,
            this.gvcId,
            this.gvcIdDevice});
			this.gvDevice.DetailHeight = 404;
			this.gvDevice.GridControl = this.gcDevice;
			this.gvDevice.Name = "gvDevice";
			this.gvDevice.OptionsCustomization.AllowGroup = false;
			this.gvDevice.OptionsSelection.MultiSelect = true;
			this.gvDevice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvDevice.OptionsView.ShowAutoFilterRow = true;
			this.gvDevice.OptionsView.ShowGroupPanel = false;
			this.gvDevice.Click += new System.EventHandler(this.gvDevice_Click);
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
			// gvcId
			// 
			this.gvcId.Caption = "ID thiết bị";
			this.gvcId.FieldName = "Id";
			this.gvcId.Name = "gvcId";
			// 
			// btnCodeSmall
			// 
			this.btnCodeSmall.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCodeSmall.ImageOptions.Image")));
			this.btnCodeSmall.Location = new System.Drawing.Point(729, 37);
			this.btnCodeSmall.Name = "btnCodeSmall";
			this.btnCodeSmall.Size = new System.Drawing.Size(106, 22);
			this.btnCodeSmall.StyleController = this.layoutControl1;
			this.btnCodeSmall.TabIndex = 12;
			this.btnCodeSmall.Text = "QR Code Small";
			this.btnCodeSmall.Click += new System.EventHandler(this.btnCodeSmall_Click);
			// 
			// btnCodeMedium
			// 
			this.btnCodeMedium.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCodeMedium.ImageOptions.Image")));
			this.btnCodeMedium.Location = new System.Drawing.Point(593, 37);
			this.btnCodeMedium.Name = "btnCodeMedium";
			this.btnCodeMedium.Size = new System.Drawing.Size(122, 22);
			this.btnCodeMedium.StyleController = this.layoutControl1;
			this.btnCodeMedium.TabIndex = 11;
			this.btnCodeMedium.Text = "QR Code Medium";
			this.btnCodeMedium.Click += new System.EventHandler(this.btnCodeMedium_Click);
			// 
			// btnCodeLarge
			// 
			this.btnCodeLarge.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCodeLarge.ImageOptions.Image")));
			this.btnCodeLarge.Location = new System.Drawing.Point(472, 37);
			this.btnCodeLarge.Name = "btnCodeLarge";
			this.btnCodeLarge.Size = new System.Drawing.Size(107, 22);
			this.btnCodeLarge.StyleController = this.layoutControl1;
			this.btnCodeLarge.TabIndex = 10;
			this.btnCodeLarge.Text = "QR Code Large";
			this.btnCodeLarge.Click += new System.EventHandler(this.btnCodeLarge_Click);
			// 
			// btnSave
			// 
			this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
			this.btnSave.Location = new System.Drawing.Point(237, 37);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(107, 22);
			this.btnSave.StyleController = this.layoutControl1;
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Lưu";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
			this.btnEdit.Location = new System.Drawing.Point(123, 37);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(100, 22);
			this.btnEdit.StyleController = this.layoutControl1;
			this.btnEdit.TabIndex = 8;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
			this.btnUpdate.Location = new System.Drawing.Point(358, 37);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(100, 22);
			this.btnUpdate.StyleController = this.layoutControl1;
			this.btnUpdate.TabIndex = 7;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
			this.btnDelete.Location = new System.Drawing.Point(12, 37);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(97, 22);
			this.btnDelete.StyleController = this.layoutControl1;
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEditCodeMachine
			// 
			this.btnEditCodeMachine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCodeMachine.ImageOptions.Image")));
			this.btnEditCodeMachine.Location = new System.Drawing.Point(849, 37);
			this.btnEditCodeMachine.Name = "btnEditCodeMachine";
			this.btnEditCodeMachine.Size = new System.Drawing.Size(89, 22);
			this.btnEditCodeMachine.StyleController = this.layoutControl1;
			this.btnEditCodeMachine.TabIndex = 5;
			this.btnEditCodeMachine.Text = "Sửa mã máy";
			this.btnEditCodeMachine.Click += new System.EventHandler(this.btnEditCodeMachine_Click);
			// 
			// cbDeviceType
			// 
			this.cbDeviceType.FormattingEnabled = true;
			this.cbDeviceType.Location = new System.Drawing.Point(86, 12);
			this.cbDeviceType.Name = "cbDeviceType";
			this.cbDeviceType.Size = new System.Drawing.Size(1054, 23);
			this.cbDeviceType.TabIndex = 4;
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
            this.layoutControlItem10,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7,
            this.emptySpaceItem8,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.emptySpaceItem12});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbDeviceType;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1132, 25);
			this.layoutControlItem1.Text = "Loại thiết bị: ";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 15);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnEditCodeMachine;
			this.layoutControlItem2.Location = new System.Drawing.Point(837, 25);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(93, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.btnDelete;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(101, 26);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnUpdate;
			this.layoutControlItem4.Location = new System.Drawing.Point(346, 25);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(104, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnEdit;
			this.layoutControlItem5.Location = new System.Drawing.Point(111, 25);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(104, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnSave;
			this.layoutControlItem6.Location = new System.Drawing.Point(225, 25);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(111, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.btnCodeLarge;
			this.layoutControlItem7.Location = new System.Drawing.Point(460, 25);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(111, 26);
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextVisible = false;
			// 
			// layoutControlItem8
			// 
			this.layoutControlItem8.Control = this.btnCodeMedium;
			this.layoutControlItem8.Location = new System.Drawing.Point(581, 25);
			this.layoutControlItem8.Name = "layoutControlItem8";
			this.layoutControlItem8.Size = new System.Drawing.Size(126, 26);
			this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem8.TextVisible = false;
			// 
			// layoutControlItem9
			// 
			this.layoutControlItem9.Control = this.btnCodeSmall;
			this.layoutControlItem9.Location = new System.Drawing.Point(717, 25);
			this.layoutControlItem9.Name = "layoutControlItem9";
			this.layoutControlItem9.Size = new System.Drawing.Size(110, 26);
			this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem9.TextVisible = false;
			// 
			// layoutControlItem10
			// 
			this.layoutControlItem10.Control = this.gcDevice;
			this.layoutControlItem10.Location = new System.Drawing.Point(0, 51);
			this.layoutControlItem10.Name = "layoutControlItem10";
			this.layoutControlItem10.Size = new System.Drawing.Size(1132, 633);
			this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem10.TextVisible = false;
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(101, 25);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.Location = new System.Drawing.Point(215, 25);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem7
			// 
			this.emptySpaceItem7.AllowHotTrack = false;
			this.emptySpaceItem7.Location = new System.Drawing.Point(336, 25);
			this.emptySpaceItem7.Name = "emptySpaceItem7";
			this.emptySpaceItem7.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem8
			// 
			this.emptySpaceItem8.AllowHotTrack = false;
			this.emptySpaceItem8.Location = new System.Drawing.Point(450, 25);
			this.emptySpaceItem8.Name = "emptySpaceItem8";
			this.emptySpaceItem8.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem9
			// 
			this.emptySpaceItem9.AllowHotTrack = false;
			this.emptySpaceItem9.Location = new System.Drawing.Point(571, 25);
			this.emptySpaceItem9.Name = "emptySpaceItem9";
			this.emptySpaceItem9.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem10
			// 
			this.emptySpaceItem10.AllowHotTrack = false;
			this.emptySpaceItem10.Location = new System.Drawing.Point(707, 25);
			this.emptySpaceItem10.Name = "emptySpaceItem10";
			this.emptySpaceItem10.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem11
			// 
			this.emptySpaceItem11.AllowHotTrack = false;
			this.emptySpaceItem11.Location = new System.Drawing.Point(827, 25);
			this.emptySpaceItem11.Name = "emptySpaceItem11";
			this.emptySpaceItem11.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem12
			// 
			this.emptySpaceItem12.AllowHotTrack = false;
			this.emptySpaceItem12.Location = new System.Drawing.Point(930, 25);
			this.emptySpaceItem12.Name = "emptySpaceItem12";
			this.emptySpaceItem12.Size = new System.Drawing.Size(202, 26);
			this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
			// 
			// gvcIdDevice
			// 
			this.gvcIdDevice.Caption = "IdDevice";
			this.gvcIdDevice.FieldName = "IdDevice";
			this.gvcIdDevice.Name = "gvcIdDevice";
			// 
			// frmListDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmListDevice";
			this.Text = "DANH SÁCH THIẾT BỊ";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcDevice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDevice)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.GridControl gcDevice;
		private DevExpress.XtraGrid.Views.Grid.GridView gvDevice;
		private DevExpress.XtraEditors.SimpleButton btnCodeSmall;
		private DevExpress.XtraEditors.SimpleButton btnCodeMedium;
		private DevExpress.XtraEditors.SimpleButton btnCodeLarge;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnEdit;
		private DevExpress.XtraEditors.SimpleButton btnUpdate;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraEditors.SimpleButton btnEditCodeMachine;
		private System.Windows.Forms.ComboBox cbDeviceType;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMachineCode;
		private DevExpress.XtraGrid.Columns.GridColumn gvcMachineName;
		private DevExpress.XtraGrid.Columns.GridColumn gvcId;
		private DevExpress.XtraGrid.Columns.GridColumn gvcIdDevice;
	}
}
