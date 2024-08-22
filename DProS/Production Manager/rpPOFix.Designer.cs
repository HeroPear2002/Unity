namespace DProS.Production_Manager
{
	partial class rpPOFix
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
			DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
			DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtPartCode = new DevExpress.XtraReports.UI.XRLabel();
			this.txtPartName = new DevExpress.XtraReports.UI.XRLabel();
			this.txtBarCodePO = new DevExpress.XtraReports.UI.XRBarCode();
			this.txtQrcode = new DevExpress.XtraReports.UI.XRBarCode();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// TopMargin
			// 
			this.TopMargin.Dpi = 254F;
			this.TopMargin.HeightF = 80F;
			this.TopMargin.Name = "TopMargin";
			// 
			// BottomMargin
			// 
			this.BottomMargin.Dpi = 254F;
			this.BottomMargin.HeightF = 50F;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.txtPartCode,
            this.txtPartName,
            this.txtBarCodePO,
            this.txtQrcode});
			this.Detail.Dpi = 254F;
			this.Detail.HeightF = 415.0624F;
			this.Detail.HierarchyPrintOptions.Indent = 50.8F;
			this.Detail.MultiColumn.ColumnWidth = 1400F;
			this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
			this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
			this.Detail.Name = "Detail";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel1.Dpi = 254F;
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(186.3956F, 402.3749F);
			this.xrLabel1.StylePriority.UseBorders = false;
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "PO Xuất Hàng";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtPartCode
			// 
			this.txtPartCode.Borders = DevExpress.XtraPrinting.BorderSide.Top;
			this.txtPartCode.Dpi = 254F;
			this.txtPartCode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPartCode.LocationFloat = new DevExpress.Utils.PointFloat(186.3956F, 0F);
			this.txtPartCode.Name = "txtPartCode";
			this.txtPartCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtPartCode.SizeF = new System.Drawing.SizeF(954.6595F, 106.5741F);
			this.txtPartCode.StylePriority.UseBorders = false;
			this.txtPartCode.StylePriority.UseFont = false;
			this.txtPartCode.StylePriority.UseTextAlignment = false;
			this.txtPartCode.Text = "MaterialName";
			this.txtPartCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtPartName
			// 
			this.txtPartName.Borders = DevExpress.XtraPrinting.BorderSide.None;
			this.txtPartName.Dpi = 254F;
			this.txtPartName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPartName.LocationFloat = new DevExpress.Utils.PointFloat(186.3956F, 106.5741F);
			this.txtPartName.Name = "txtPartName";
			this.txtPartName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtPartName.SizeF = new System.Drawing.SizeF(954.6596F, 143.6158F);
			this.txtPartName.StylePriority.UseBorders = false;
			this.txtPartName.StylePriority.UseFont = false;
			this.txtPartName.StylePriority.UseTextAlignment = false;
			this.txtPartName.Text = "MaterialName";
			this.txtPartName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtBarCodePO
			// 
			this.txtBarCodePO.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.txtBarCodePO.AutoModule = true;
			this.txtBarCodePO.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
			this.txtBarCodePO.Dpi = 254F;
			this.txtBarCodePO.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBarCodePO.LocationFloat = new DevExpress.Utils.PointFloat(186.3956F, 250.19F);
			this.txtBarCodePO.Name = "txtBarCodePO";
			this.txtBarCodePO.Padding = new DevExpress.XtraPrinting.PaddingInfo(38, 38, 5, 5, 254F);
			this.txtBarCodePO.SizeF = new System.Drawing.SizeF(954.6595F, 152.1851F);
			this.txtBarCodePO.StylePriority.UseBorders = false;
			this.txtBarCodePO.StylePriority.UseFont = false;
			this.txtBarCodePO.StylePriority.UsePadding = false;
			this.txtBarCodePO.StylePriority.UseTextAlignment = false;
			this.txtBarCodePO.Symbology = code128Generator1;
			this.txtBarCodePO.Text = "KUN123456 123456";
			this.txtBarCodePO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtQrcode
			// 
			this.txtQrcode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.txtQrcode.AutoModule = true;
			this.txtQrcode.BarCodeOrientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.RotateRight;
			this.txtQrcode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.txtQrcode.Dpi = 254F;
			this.txtQrcode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQrcode.LocationFloat = new DevExpress.Utils.PointFloat(1141.055F, 196.5325F);
			this.txtQrcode.Module = 4.572F;
			this.txtQrcode.Name = "txtQrcode";
			this.txtQrcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 254F);
			this.txtQrcode.ShowText = false;
			this.txtQrcode.SizeF = new System.Drawing.SizeF(214.842F, 205.8426F);
			this.txtQrcode.StylePriority.UseBorders = false;
			this.txtQrcode.StylePriority.UseFont = false;
			this.txtQrcode.StylePriority.UsePadding = false;
			this.txtQrcode.StylePriority.UseTextAlignment = false;
			qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
			qrCodeGenerator1.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.QRCodeErrorCorrectionLevel.Q;
			qrCodeGenerator1.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.Version5;
			this.txtQrcode.Symbology = qrCodeGenerator1;
			this.txtQrcode.Text = "&0121&&LY8099001&DONGDUONGPLA&201809070930251234&20180907-0011&24&VS1-2&A2&DongDu" +
    "ong&&";
			this.txtQrcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel2
			// 
			this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel2.Dpi = 254F;
			this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1141.055F, 0F);
			this.xrLabel2.Multiline = true;
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(214.842F, 196.5325F);
			this.xrLabel2.StylePriority.UseBorders = false;
			// 
			// rpPOFix
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
			this.Dpi = 254F;
			this.Font = new System.Drawing.Font("Arial", 9.75F);
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(104, 60, 80, 50);
			this.PageHeight = 2100;
			this.PageWidth = 2970;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.ReportPrintOptions.DetailCountOnEmptyDataSource = 6;
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
		private DevExpress.XtraReports.UI.XRLabel txtPartCode;
		private DevExpress.XtraReports.UI.XRLabel txtPartName;
		private DevExpress.XtraReports.UI.XRBarCode txtBarCodePO;
		private DevExpress.XtraReports.UI.XRBarCode txtQrcode;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
	}
}
