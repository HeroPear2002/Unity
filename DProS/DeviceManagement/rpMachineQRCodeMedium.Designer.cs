namespace DProS.DeviceManagement
{
	partial class rpMachineQRCodeMedium
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

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtMachineCode = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtMachineName = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtCodeAsset = new DevExpress.XtraReports.UI.XRLabel();
			this.txtQRCode = new DevExpress.XtraReports.UI.XRBarCode();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// TopMargin
			// 
			this.TopMargin.Dpi = 254F;
			this.TopMargin.HeightF = 74F;
			this.TopMargin.Name = "TopMargin";
			// 
			// BottomMargin
			// 
			this.BottomMargin.Dpi = 254F;
			this.BottomMargin.HeightF = 82F;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtQRCode,
            this.xrLabel1,
            this.txtMachineCode,
            this.xrLabel3,
            this.txtMachineName,
            this.xrLabel5,
            this.txtCodeAsset});
			this.Detail.Dpi = 254F;
			this.Detail.HeightF = 297.0877F;
			this.Detail.HierarchyPrintOptions.Indent = 50.8F;
			this.Detail.KeepTogether = true;
			this.Detail.MultiColumn.ColumnWidth = 950F;
			this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
			this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
			this.Detail.Name = "Detail";
			// 
			// xrLabel1
			// 
			this.xrLabel1.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel1.BorderColor = System.Drawing.Color.Black;
			this.xrLabel1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel1.BorderWidth = 1F;
			this.xrLabel1.Dpi = 254F;
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel1.ForeColor = System.Drawing.Color.Black;
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(21.16667F, 0F);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(144.9916F, 92.60421F);
			this.xrLabel1.StylePriority.UseBackColor = false;
			this.xrLabel1.StylePriority.UseBorderColor = false;
			this.xrLabel1.StylePriority.UseBorderDashStyle = false;
			this.xrLabel1.StylePriority.UseBorders = false;
			this.xrLabel1.StylePriority.UseBorderWidth = false;
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.StylePriority.UsePadding = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "Mã TB: ";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtMachineCode
			// 
			this.txtMachineCode.BackColor = System.Drawing.Color.Transparent;
			this.txtMachineCode.BorderColor = System.Drawing.Color.Black;
			this.txtMachineCode.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.txtMachineCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.txtMachineCode.BorderWidth = 1F;
			this.txtMachineCode.Dpi = 254F;
			this.txtMachineCode.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMachineCode.ForeColor = System.Drawing.Color.Black;
			this.txtMachineCode.LocationFloat = new DevExpress.Utils.PointFloat(166.1583F, 4.037221E-05F);
			this.txtMachineCode.Multiline = true;
			this.txtMachineCode.Name = "txtMachineCode";
			this.txtMachineCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtMachineCode.SizeF = new System.Drawing.SizeF(510.4251F, 92.60421F);
			this.txtMachineCode.StylePriority.UseBackColor = false;
			this.txtMachineCode.StylePriority.UseBorderColor = false;
			this.txtMachineCode.StylePriority.UseBorderDashStyle = false;
			this.txtMachineCode.StylePriority.UseBorders = false;
			this.txtMachineCode.StylePriority.UseBorderWidth = false;
			this.txtMachineCode.StylePriority.UseFont = false;
			this.txtMachineCode.StylePriority.UseForeColor = false;
			this.txtMachineCode.StylePriority.UsePadding = false;
			this.txtMachineCode.StylePriority.UseTextAlignment = false;
			this.txtMachineCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel3
			// 
			this.xrLabel3.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel3.BorderColor = System.Drawing.Color.Black;
			this.xrLabel3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel3.BorderWidth = 1F;
			this.xrLabel3.Dpi = 254F;
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel3.ForeColor = System.Drawing.Color.Black;
			this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(21.16667F, 92.60425F);
			this.xrLabel3.Multiline = true;
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(144.9916F, 92.08757F);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseBorderColor = false;
			this.xrLabel3.StylePriority.UseBorderDashStyle = false;
			this.xrLabel3.StylePriority.UseBorders = false;
			this.xrLabel3.StylePriority.UseBorderWidth = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "Tên TB: ";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtMachineName
			// 
			this.txtMachineName.BackColor = System.Drawing.Color.Transparent;
			this.txtMachineName.BorderColor = System.Drawing.Color.Black;
			this.txtMachineName.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.txtMachineName.Borders = DevExpress.XtraPrinting.BorderSide.None;
			this.txtMachineName.BorderWidth = 1F;
			this.txtMachineName.Dpi = 254F;
			this.txtMachineName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMachineName.ForeColor = System.Drawing.Color.Black;
			this.txtMachineName.LocationFloat = new DevExpress.Utils.PointFloat(166.1583F, 92.60425F);
			this.txtMachineName.Multiline = true;
			this.txtMachineName.Name = "txtMachineName";
			this.txtMachineName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtMachineName.SizeF = new System.Drawing.SizeF(510.4251F, 92.08757F);
			this.txtMachineName.StylePriority.UseBackColor = false;
			this.txtMachineName.StylePriority.UseBorderColor = false;
			this.txtMachineName.StylePriority.UseBorderDashStyle = false;
			this.txtMachineName.StylePriority.UseBorders = false;
			this.txtMachineName.StylePriority.UseBorderWidth = false;
			this.txtMachineName.StylePriority.UseFont = false;
			this.txtMachineName.StylePriority.UseForeColor = false;
			this.txtMachineName.StylePriority.UsePadding = false;
			this.txtMachineName.StylePriority.UseTextAlignment = false;
			this.txtMachineName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel5
			// 
			this.xrLabel5.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel5.BorderColor = System.Drawing.Color.Black;
			this.xrLabel5.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel5.BorderWidth = 1F;
			this.xrLabel5.Dpi = 254F;
			this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel5.ForeColor = System.Drawing.Color.Black;
			this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(21.16667F, 184.6918F);
			this.xrLabel5.Multiline = true;
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(144.9916F, 92.6042F);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseBorderColor = false;
			this.xrLabel5.StylePriority.UseBorderDashStyle = false;
			this.xrLabel5.StylePriority.UseBorders = false;
			this.xrLabel5.StylePriority.UseBorderWidth = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "MTSCĐ: ";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtCodeAsset
			// 
			this.txtCodeAsset.BackColor = System.Drawing.Color.Transparent;
			this.txtCodeAsset.BorderColor = System.Drawing.Color.Black;
			this.txtCodeAsset.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.txtCodeAsset.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.txtCodeAsset.BorderWidth = 1F;
			this.txtCodeAsset.Dpi = 254F;
			this.txtCodeAsset.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCodeAsset.ForeColor = System.Drawing.Color.Black;
			this.txtCodeAsset.LocationFloat = new DevExpress.Utils.PointFloat(166.1583F, 184.6918F);
			this.txtCodeAsset.Multiline = true;
			this.txtCodeAsset.Name = "txtCodeAsset";
			this.txtCodeAsset.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtCodeAsset.SizeF = new System.Drawing.SizeF(510.4251F, 92.6042F);
			this.txtCodeAsset.StylePriority.UseBackColor = false;
			this.txtCodeAsset.StylePriority.UseBorderColor = false;
			this.txtCodeAsset.StylePriority.UseBorderDashStyle = false;
			this.txtCodeAsset.StylePriority.UseBorders = false;
			this.txtCodeAsset.StylePriority.UseBorderWidth = false;
			this.txtCodeAsset.StylePriority.UseFont = false;
			this.txtCodeAsset.StylePriority.UseForeColor = false;
			this.txtCodeAsset.StylePriority.UsePadding = false;
			this.txtCodeAsset.StylePriority.UseTextAlignment = false;
			this.txtCodeAsset.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtQRCode
			// 
			this.txtQRCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.txtQRCode.AutoModule = true;
			this.txtQRCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.txtQRCode.Dpi = 254F;
			this.txtQRCode.LocationFloat = new DevExpress.Utils.PointFloat(676.5834F, 2.129311F);
			this.txtQRCode.Module = 5.08F;
			this.txtQRCode.Name = "txtQRCode";
			this.txtQRCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
			this.txtQRCode.ShowText = false;
			this.txtQRCode.SizeF = new System.Drawing.SizeF(273.4166F, 275.1667F);
			this.txtQRCode.StylePriority.UseBorders = false;
			this.txtQRCode.StylePriority.UsePadding = false;
			qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
			this.txtQRCode.Symbology = qrCodeGenerator1;
			this.txtQRCode.Text = "BĐ&123456";
			// 
			// rpMachineQRCodeMedium
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
			this.Dpi = 254F;
			this.Font = new System.Drawing.Font("Arial", 9.75F);
			this.Margins = new System.Drawing.Printing.Margins(90, 87, 74, 82);
			this.PageHeight = 2970;
			this.PageWidth = 2100;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.ReportPrintOptions.DetailCountOnEmptyDataSource = 12;
			this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
			this.SnapGridSize = 25F;
			this.Version = "19.2";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel txtMachineCode;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel txtMachineName;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel txtCodeAsset;
		private DevExpress.XtraReports.UI.XRBarCode txtQRCode;
	}
}
