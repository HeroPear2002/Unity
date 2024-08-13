
namespace DProS.MachineData
{
	partial class frmTableCheckData
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableCheckData));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.cbMachineCode = new System.Windows.Forms.ComboBox();
			this.cbMoldCode = new System.Windows.Forms.ComboBox();
			this.gcDataCheck = new DevExpress.XtraGrid.GridControl();
			this.gvDataCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gvcId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcLowerLimit = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcValueDefault = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcUpperLimit = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gvcValueReal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtpCheck = new System.Windows.Forms.DateTimePicker();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcDataCheck)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDataCheck)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.cbMachineCode);
			this.layoutControl1.Controls.Add(this.cbMoldCode);
			this.layoutControl1.Controls.Add(this.gcDataCheck);
			this.layoutControl1.Controls.Add(this.dtpCheck);
			this.layoutControl1.Controls.Add(this.btnSave);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1102, 321, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1152, 704);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// cbMachineCode
			// 
			this.cbMachineCode.FormattingEnabled = true;
			this.cbMachineCode.Location = new System.Drawing.Point(387, 12);
			this.cbMachineCode.Name = "cbMachineCode";
			this.cbMachineCode.Size = new System.Drawing.Size(211, 23);
			this.cbMachineCode.TabIndex = 11;
			this.cbMachineCode.SelectedIndexChanged += new System.EventHandler(this.cbMachineCode_SelectedIndexChanged);
			// 
			// cbMoldCode
			// 
			this.cbMoldCode.FormattingEnabled = true;
			this.cbMoldCode.Location = new System.Drawing.Point(76, 12);
			this.cbMoldCode.Name = "cbMoldCode";
			this.cbMoldCode.Size = new System.Drawing.Size(233, 23);
			this.cbMoldCode.TabIndex = 10;
			this.cbMoldCode.SelectedIndexChanged += new System.EventHandler(this.cbMoldCode_SelectedIndexChanged);
			// 
			// gcDataCheck
			// 
			this.gcDataCheck.Location = new System.Drawing.Point(12, 38);
			this.gcDataCheck.MainView = this.gvDataCheck;
			this.gcDataCheck.Name = "gcDataCheck";
			this.gcDataCheck.Size = new System.Drawing.Size(1128, 654);
			this.gcDataCheck.TabIndex = 9;
			this.gcDataCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDataCheck});
			// 
			// gvDataCheck
			// 
			this.gvDataCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvcId,
            this.gvcName,
            this.gvcLowerLimit,
            this.gvcValueDefault,
            this.gvcUpperLimit,
            this.gvcValueReal});
			this.gvDataCheck.DetailHeight = 404;
			this.gvDataCheck.GridControl = this.gcDataCheck;
			this.gvDataCheck.Name = "gvDataCheck";
			this.gvDataCheck.OptionsCustomization.AllowGroup = false;
			this.gvDataCheck.OptionsSelection.MultiSelect = true;
			this.gvDataCheck.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gvDataCheck.OptionsView.ShowAutoFilterRow = true;
			this.gvDataCheck.OptionsView.ShowGroupPanel = false;
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
			this.gvcId.OptionsColumn.AllowEdit = false;
			this.gvcId.Width = 87;
			// 
			// gvcName
			// 
			this.gvcName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcName.AppearanceCell.Options.UseFont = true;
			this.gvcName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcName.AppearanceHeader.Options.UseFont = true;
			this.gvcName.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcName.Caption = "Tên hạng mục";
			this.gvcName.FieldName = "Name";
			this.gvcName.Name = "gvcName";
			this.gvcName.OptionsColumn.AllowEdit = false;
			this.gvcName.Visible = true;
			this.gvcName.VisibleIndex = 1;
			this.gvcName.Width = 354;
			// 
			// gvcLowerLimit
			// 
			this.gvcLowerLimit.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcLowerLimit.AppearanceCell.Options.UseFont = true;
			this.gvcLowerLimit.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcLowerLimit.AppearanceHeader.Options.UseFont = true;
			this.gvcLowerLimit.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcLowerLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcLowerLimit.Caption = "Giới hạn dưới";
			this.gvcLowerLimit.FieldName = "LowerLimit";
			this.gvcLowerLimit.Name = "gvcLowerLimit";
			this.gvcLowerLimit.OptionsColumn.AllowEdit = false;
			this.gvcLowerLimit.Visible = true;
			this.gvcLowerLimit.VisibleIndex = 2;
			this.gvcLowerLimit.Width = 251;
			// 
			// gvcValueDefault
			// 
			this.gvcValueDefault.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcValueDefault.AppearanceCell.Options.UseFont = true;
			this.gvcValueDefault.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcValueDefault.AppearanceHeader.Options.UseFont = true;
			this.gvcValueDefault.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcValueDefault.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcValueDefault.Caption = "Giá trị tiêu chuẩn";
			this.gvcValueDefault.FieldName = "ValueDefault";
			this.gvcValueDefault.Name = "gvcValueDefault";
			this.gvcValueDefault.OptionsColumn.AllowEdit = false;
			this.gvcValueDefault.Visible = true;
			this.gvcValueDefault.VisibleIndex = 3;
			this.gvcValueDefault.Width = 232;
			// 
			// gvcUpperLimit
			// 
			this.gvcUpperLimit.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcUpperLimit.AppearanceCell.Options.UseFont = true;
			this.gvcUpperLimit.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcUpperLimit.AppearanceHeader.Options.UseFont = true;
			this.gvcUpperLimit.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcUpperLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcUpperLimit.Caption = "Giới hạn trên";
			this.gvcUpperLimit.FieldName = "UpperLimit";
			this.gvcUpperLimit.Name = "gvcUpperLimit";
			this.gvcUpperLimit.OptionsColumn.AllowEdit = false;
			this.gvcUpperLimit.Visible = true;
			this.gvcUpperLimit.VisibleIndex = 4;
			this.gvcUpperLimit.Width = 220;
			// 
			// gvcValueReal
			// 
			this.gvcValueReal.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcValueReal.AppearanceCell.Options.UseFont = true;
			this.gvcValueReal.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gvcValueReal.AppearanceHeader.Options.UseFont = true;
			this.gvcValueReal.AppearanceHeader.Options.UseTextOptions = true;
			this.gvcValueReal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gvcValueReal.Caption = "Giá trị";
			this.gvcValueReal.FieldName = "ValueReal";
			this.gvcValueReal.Name = "gvcValueReal";
			this.gvcValueReal.Visible = true;
			this.gvcValueReal.VisibleIndex = 5;
			this.gvcValueReal.Width = 187;
			// 
			// dtpCheck
			// 
			this.dtpCheck.CustomFormat = "dd/MM/yyyy hh:mm";
			this.dtpCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpCheck.Location = new System.Drawing.Point(718, 12);
			this.dtpCheck.Name = "dtpCheck";
			this.dtpCheck.Size = new System.Drawing.Size(148, 22);
			this.dtpCheck.TabIndex = 8;
			// 
			// btnSave
			// 
			this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
			this.btnSave.Location = new System.Drawing.Point(1064, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(76, 22);
			this.btnSave.StyleController = this.layoutControl1;
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Lưu";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1152, 704);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnSave;
			this.layoutControlItem2.Location = new System.Drawing.Point(1052, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.dtpCheck;
			this.layoutControlItem5.Location = new System.Drawing.Point(600, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(258, 26);
			this.layoutControlItem5.Text = "Ngày, giờ kiểm tra: ";
			this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem5.TextSize = new System.Drawing.Size(101, 15);
			this.layoutControlItem5.TextToControlDistance = 5;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.gcDataCheck;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(1132, 658);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(301, 0);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(590, 0);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(10, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(858, 0);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(194, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.cbMoldCode;
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(301, 26);
			this.layoutControlItem6.Text = "Mã khuôn: ";
			this.layoutControlItem6.TextSize = new System.Drawing.Size(61, 15);
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.cbMachineCode;
			this.layoutControlItem7.Location = new System.Drawing.Point(311, 0);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(279, 26);
			this.layoutControlItem7.Text = "Mã máy: ";
			this.layoutControlItem7.TextSize = new System.Drawing.Size(61, 15);
			// 
			// frmTableCheckData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 704);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmTableCheckData";
			this.Text = "BẢNG KIỂM TRA";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcDataCheck)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDataCheck)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraGrid.GridControl gcDataCheck;
		private DevExpress.XtraGrid.Views.Grid.GridView gvDataCheck;
		private System.Windows.Forms.DateTimePicker dtpCheck;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraGrid.Columns.GridColumn gvcId;
		private DevExpress.XtraGrid.Columns.GridColumn gvcName;
		private DevExpress.XtraGrid.Columns.GridColumn gvcLowerLimit;
		private DevExpress.XtraGrid.Columns.GridColumn gvcValueDefault;
		private DevExpress.XtraGrid.Columns.GridColumn gvcUpperLimit;
		private DevExpress.XtraGrid.Columns.GridColumn gvcValueReal;
		private System.Windows.Forms.ComboBox cbMachineCode;
		private System.Windows.Forms.ComboBox cbMoldCode;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
	}
}
