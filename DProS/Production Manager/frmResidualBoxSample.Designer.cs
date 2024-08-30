namespace DProS.Production_Manager
{
	partial class frmResidualBoxSample
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResidualBoxSample));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnGetFormSample = new DevExpress.XtraEditors.SimpleButton();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Controls.Add(this.btnGetFormSample);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1059, 396, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1129, 576);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// gridControl1
			// 
			this.gridControl1.Location = new System.Drawing.Point(12, 38);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(1105, 526);
			this.gridControl1.TabIndex = 5;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridColumn1.AppearanceHeader.Options.UseFont = true;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.Caption = "Part Code";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 151;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridColumn2.AppearanceHeader.Options.UseFont = true;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "Date Month";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 187;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Quantity Part";
			this.gridColumn3.FieldName = "Quantity Part";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 180;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Quantity Box";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 180;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Date Works";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 180;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Date Iventory";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 202;
			// 
			// btnGetFormSample
			// 
			this.btnGetFormSample.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetFormSample.ImageOptions.Image")));
			this.btnGetFormSample.Location = new System.Drawing.Point(12, 12);
			this.btnGetFormSample.Name = "btnGetFormSample";
			this.btnGetFormSample.Size = new System.Drawing.Size(104, 22);
			this.btnGetFormSample.StyleController = this.layoutControl1;
			this.btnGetFormSample.TabIndex = 4;
			this.btnGetFormSample.Text = "Lấy Form Mẫu";
			this.btnGetFormSample.Click += new System.EventHandler(this.btnGetFormSample_Click);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1129, 576);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.btnGetFormSample;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(108, 26);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.gridControl1;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(1109, 530);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(108, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(1001, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// xtraSaveFileDialog1
			// 
			this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
			// 
			// frmResidualBoxSample
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1129, 576);
			this.Controls.Add(this.layoutControl1);
			this.Name = "frmResidualBoxSample";
			this.Text = "Form Mẫu";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.SimpleButton btnGetFormSample;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
	}
}