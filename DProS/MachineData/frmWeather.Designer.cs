
namespace DProS.MachineData
{
	partial class frmWeather
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeather));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gcWeather = new DevExpress.XtraGrid.GridControl();
			this.gvWeather = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcDateWeather = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcTemperature = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcHumidity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
			this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.txtTemperature = new System.Windows.Forms.TextBox();
			this.txtHumidity = new System.Windows.Forms.TextBox();
			this.cbLocation = new System.Windows.Forms.ComboBox();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcWeather)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvWeather)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gcWeather);
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Controls.Add(this.btnEdit);
			this.layoutControl1.Controls.Add(this.btnDelete);
			this.layoutControl1.Controls.Add(this.btnInsert);
			this.layoutControl1.Controls.Add(this.btnUpdate);
			this.layoutControl1.Controls.Add(this.txtTemperature);
			this.layoutControl1.Controls.Add(this.txtHumidity);
			this.layoutControl1.Controls.Add(this.cbLocation);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 453, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// gcWeather
			// 
			this.gcWeather.Location = new System.Drawing.Point(12, 63);
			this.gcWeather.MainView = this.gvWeather;
			this.gcWeather.Name = "gcWeather";
			this.gcWeather.Size = new System.Drawing.Size(1128, 629);
			this.gcWeather.TabIndex = 14;
			this.gcWeather.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeather});
			// 
			// gvWeather
			// 
			this.gvWeather.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcDateWeather,
            this.gvcName,
            this.gvcTemperature,
            this.gvcHumidity,
            this.gvcUserName,
            this.gvcId});
			this.gvWeather.DetailHeight = 404;
			this.gvWeather.GridControl = this.gcWeather;
			this.gvWeather.Name = "gvWeather";
			this.gvWeather.OptionsCustomization.AllowGroup = false;
			this.gvWeather.OptionsSelection.MultiSelect = true;
			this.gvWeather.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvWeather.OptionsView.ShowAutoFilterRow = true;
			this.gvWeather.OptionsView.ShowGroupPanel = false;
			this.gvWeather.Click += new System.EventHandler(this.gvWeather_Click);
			// 
			// gvcDateWeather
			// 
			this.gvcDateWeather.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDateWeather.AppearanceCell.Options.UseFont = true;
			this.gvcDateWeather.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcDateWeather.AppearanceHeader.Options.UseFont = true;
			this.gvcDateWeather.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcDateWeather.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcDateWeather.Caption = "Ngày / Giờ";
			this.gvcDateWeather.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
			this.gvcDateWeather.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gvcDateWeather.FieldName = "DateWeather";
			this.gvcDateWeather.Name = "gvcDateWeather";
			this.gvcDateWeather.Visible = true;
			this.gvcDateWeather.VisibleIndex = 1;
			this.gvcDateWeather.Width = 248;
			// 
			// gvcName
			// 
			this.gvcName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcName.AppearanceCell.Options.UseFont = true;
			this.gvcName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcName.AppearanceHeader.Options.UseFont = true;
			this.gvcName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcName.Caption = "Vị trí đo";
			this.gvcName.FieldName = "Name";
			this.gvcName.Name = "gvcName";
			this.gvcName.Visible = true;
			this.gvcName.VisibleIndex = 2;
			this.gvcName.Width = 314;
			// 
			// gvcTemperature
			// 
			this.gvcTemperature.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTemperature.AppearanceCell.Options.UseFont = true;
			this.gvcTemperature.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcTemperature.AppearanceHeader.Options.UseFont = true;
			this.gvcTemperature.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcTemperature.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcTemperature.Caption = "Nhiệt đọ ( °C )";
			this.gvcTemperature.FieldName = "Temperature";
			this.gvcTemperature.Name = "gvcTemperature";
			this.gvcTemperature.Visible = true;
			this.gvcTemperature.VisibleIndex = 3;
			this.gvcTemperature.Width = 197;
			// 
			// gvcHumidity
			// 
			this.gvcHumidity.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcHumidity.AppearanceCell.Options.UseFont = true;
			this.gvcHumidity.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcHumidity.AppearanceHeader.Options.UseFont = true;
			this.gvcHumidity.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcHumidity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcHumidity.Caption = "Độ ẩm ( % )";
			this.gvcHumidity.FieldName = "Humidity";
			this.gvcHumidity.Name = "gvcHumidity";
			this.gvcHumidity.Visible = true;
			this.gvcHumidity.VisibleIndex = 4;
			this.gvcHumidity.Width = 166;
			// 
			// gvcUserName
			// 
			this.gvcUserName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcUserName.AppearanceCell.Options.UseFont = true;
			this.gvcUserName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcUserName.AppearanceHeader.Options.UseFont = true;
			this.gvcUserName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcUserName.Caption = "Người check";
			this.gvcUserName.FieldName = "UserName";
			this.gvcUserName.Name = "gvcUserName";
			this.gvcUserName.Visible = true;
			this.gvcUserName.VisibleIndex = 5;
			this.gvcUserName.Width = 319;
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
			this.btnSave.Location = new System.Drawing.Point(310, 37);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(87, 22);
			this.btnSave.StyleController = this.layoutControl1;
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Lưu";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
			this.btnEdit.Location = new System.Drawing.Point(112, 37);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(82, 22);
			this.btnEdit.StyleController = this.layoutControl1;
			this.btnEdit.TabIndex = 12;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
			this.btnDelete.Location = new System.Drawing.Point(208, 37);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(88, 22);
			this.btnDelete.StyleController = this.layoutControl1;
			this.btnDelete.TabIndex = 10;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.ImageOptions.Image")));
			this.btnInsert.Location = new System.Drawing.Point(12, 37);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(86, 22);
			this.btnInsert.StyleController = this.layoutControl1;
			this.btnInsert.TabIndex = 9;
			this.btnInsert.Text = "Thêm";
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
			this.btnUpdate.Location = new System.Drawing.Point(411, 37);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(97, 22);
			this.btnUpdate.StyleController = this.layoutControl1;
			this.btnUpdate.TabIndex = 8;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtTemperature
			// 
			this.txtTemperature.Location = new System.Drawing.Point(539, 12);
			this.txtTemperature.Name = "txtTemperature";
			this.txtTemperature.Size = new System.Drawing.Size(293, 20);
			this.txtTemperature.TabIndex = 6;
			// 
			// txtHumidity
			// 
			this.txtHumidity.Location = new System.Drawing.Point(891, 12);
			this.txtHumidity.Name = "txtHumidity";
			this.txtHumidity.Size = new System.Drawing.Size(249, 20);
			this.txtHumidity.TabIndex = 5;
			// 
			// cbLocation
			// 
			this.cbLocation.FormattingEnabled = true;
			this.cbLocation.Location = new System.Drawing.Point(65, 12);
			this.cbLocation.Name = "cbLocation";
			this.cbLocation.Size = new System.Drawing.Size(403, 23);
			this.cbLocation.TabIndex = 4;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem8,
            this.emptySpaceItem10,
            this.emptySpaceItem11});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cbLocation;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(460, 25);
			this.layoutControlItem1.Text = "Vị trí đo: ";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 15);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.txtHumidity;
			this.layoutControlItem2.Location = new System.Drawing.Point(834, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(298, 25);
			this.layoutControlItem2.Text = "Độ ẩm: ";
			this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 15);
			this.layoutControlItem2.TextToControlDistance = 5;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.txtTemperature;
			this.layoutControlItem3.Location = new System.Drawing.Point(470, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(354, 25);
			this.layoutControlItem3.Text = "Nhiệt độ: ";
			this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 15);
			this.layoutControlItem3.TextToControlDistance = 5;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnUpdate;
			this.layoutControlItem5.Location = new System.Drawing.Point(399, 25);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(101, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnInsert;
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 25);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(90, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.btnDelete;
			this.layoutControlItem7.Location = new System.Drawing.Point(196, 25);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(92, 26);
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextVisible = false;
			// 
			// layoutControlItem9
			// 
			this.layoutControlItem9.Control = this.btnEdit;
			this.layoutControlItem9.Location = new System.Drawing.Point(100, 25);
			this.layoutControlItem9.Name = "layoutControlItem9";
			this.layoutControlItem9.Size = new System.Drawing.Size(86, 26);
			this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem9.TextVisible = false;
			// 
			// layoutControlItem10
			// 
			this.layoutControlItem10.Control = this.btnSave;
			this.layoutControlItem10.Location = new System.Drawing.Point(298, 25);
			this.layoutControlItem10.Name = "layoutControlItem10";
			this.layoutControlItem10.Size = new System.Drawing.Size(91, 26);
			this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem10.TextVisible = false;
			// 
			// layoutControlItem11
			// 
			this.layoutControlItem11.Control = this.gcWeather;
			this.layoutControlItem11.Location = new System.Drawing.Point(0, 51);
			this.layoutControlItem11.Name = "layoutControlItem11";
			this.layoutControlItem11.Size = new System.Drawing.Size(1132, 633);
			this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem11.TextVisible = false;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(90, 25);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(186, 25);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(288, 25);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.Location = new System.Drawing.Point(389, 25);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem8
			// 
			this.emptySpaceItem8.AllowHotTrack = false;
			this.emptySpaceItem8.Location = new System.Drawing.Point(500, 25);
			this.emptySpaceItem8.Name = "emptySpaceItem8";
			this.emptySpaceItem8.Size = new System.Drawing.Size(632, 26);
			this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem10
			// 
			this.emptySpaceItem10.AllowHotTrack = false;
			this.emptySpaceItem10.Location = new System.Drawing.Point(824, 0);
			this.emptySpaceItem10.Name = "emptySpaceItem10";
			this.emptySpaceItem10.Size = new System.Drawing.Size(10, 25);
			this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem11
			// 
			this.emptySpaceItem11.AllowHotTrack = false;
			this.emptySpaceItem11.Location = new System.Drawing.Point(460, 0);
			this.emptySpaceItem11.Name = "emptySpaceItem11";
			this.emptySpaceItem11.Size = new System.Drawing.Size(10, 25);
			this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmWeather
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmWeather";
			this.Text = "NHIỆT ĐỘ/ ĐỘ ẨM";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcWeather)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvWeather)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.GridControl gcWeather;
		private DevExpress.XtraGrid.Views.Grid.GridView gvWeather;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnEdit;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraEditors.SimpleButton btnInsert;
		private DevExpress.XtraEditors.SimpleButton btnUpdate;
		private System.Windows.Forms.TextBox txtTemperature;
		private System.Windows.Forms.TextBox txtHumidity;
		private System.Windows.Forms.ComboBox cbLocation;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
		private DevExpress.XtraGrid.Columns.GridColumn gvcDateWeather;
		private DevExpress.XtraGrid.Columns.GridColumn gvcName;
		private DevExpress.XtraGrid.Columns.GridColumn gvcTemperature;
		private DevExpress.XtraGrid.Columns.GridColumn gvcHumidity;
		private DevExpress.XtraGrid.Columns.GridColumn gvcUserName;
		private DevExpress.XtraGrid.Columns.GridColumn gvcId;
	}
}
