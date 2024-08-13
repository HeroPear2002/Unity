using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DTO;
using DAO;

namespace DProS.DeviceManagement
{
	public partial class rpMachineQRCodeLarge : DevExpress.XtraReports.UI.XtraReport
	{
		public rpMachineQRCodeLarge()
		{
			InitializeComponent();
			BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.rpMachineQRCodeLarge_BeforePrint);
		}

		private void rpMachineQRCodeLarge_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (this.DataSource != null)
			{
				var currentRow = this.GetCurrentRow() as MachineDTO;

				if (currentRow != null)
				{
					string machineCode = currentRow.MachineCode;
					string machineName = currentRow.MachineName;
					string codeAsset = currentRow.CodeAsset;
					string serialNumber = currentRow.SerialNumber;
					int idDevice = currentRow.IdDevice;
					DeviceDTO DTO = DeviceDAO.Instance.GetItem(idDevice);
					string name = "";
					if (DTO != null) name = DTO.Name;
					// Thay đổi giá trị của các điều khiển
					txtDeviceType.Text = name;
					txtMachineCode.Text = machineCode;
					txtMachineName.Text = machineName;
					txtCodeAsset.Text = codeAsset;
					string qrcode = machineCode + "&" + codeAsset + "&" + serialNumber;
					txtQRCode.Text = qrcode;
				}
				else
				{
					txtMachineCode.Text = "N/A";
					txtMachineName.Text = "N/A";
					txtCodeAsset.Text = "N/A";
					txtQRCode.Text = "N/A";
				}
			}
			else
			{
				txtMachineCode.Text = "N/A";
				txtMachineName.Text = "N/A";
				txtCodeAsset.Text = "N/A";
				txtQRCode.Text = "N/A";
			}
		}
	}
}
