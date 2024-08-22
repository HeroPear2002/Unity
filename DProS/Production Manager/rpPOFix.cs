using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DTO;
using DAO;

namespace DProS.Production_Manager
{
	public partial class rpPOFix : DevExpress.XtraReports.UI.XtraReport
	{
		public rpPOFix()
		{
			InitializeComponent();
			BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.rpMachineQRCodeLarge_BeforePrint);
		}

		private void rpMachineQRCodeLarge_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (this.DataSource != null)
			{
				var currentRow = this.GetCurrentRow() as POFixDTO;

				if (currentRow != null)
				{
					txtPartCode.Text = currentRow.PartCode;
					txtPartName.Text = PartDAO.Instance.GetItem(currentRow.PartCode).PartName;

					string barCode = "KUN" + currentRow.POCode + " " + currentRow.Quantity;
					txtBarCodePO.Text = barCode;
					txtQrcode.Text = barCode;
				}
			}
		}
	}
}
