using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAO;
using DTO;

namespace DProS.DeviceManagement
{
	public partial class frmCheckMachineQrCode : DevExpress.XtraEditors.XtraForm
	{
		bool mainten = true;
		public EventHandler LamMoi;
		public frmCheckMachineQrCode()
		{
			InitializeComponent();
			LoadControl();
		}
		public frmCheckMachineQrCode(bool ismainten)
		{
			InitializeComponent();
			mainten = ismainten;
			LoadControl();
		}
		void LoadControl()
		{
			this.AcceptButton = btnScan;
			this.CancelButton = btnExit;
			if (!mainten)
			{
				lbTile.Text = "bạn đang chọn kiểm tra hàng ngày!".ToUpper();
			}
			else
			{
				lbTile.Text = "bạn đang chọn kiểm tra định kỳ!".ToUpper();
			}
		}
		private void btnScan_Click(object sender, EventArgs e)
		{
			try
			{
				string qrCode = txtMachineCode.Text;
				string[] array = qrCode.Split('&');
				string machineCode = array[0];
				MachineDTO test = MachineDAO.Instance.GetItem(machineCode);
				if (test != null)
				{
					Common.CommonConstant.idMachine = test.Id;
					frmCheckMaintenDevice f = new frmCheckMaintenDevice(mainten, test.Id);
					f.ShowDialog();
					txtMachineCode.Text = string.Empty;
				}
				else
				{
					MessageBox.Show("mã vạch không đúng hoặc mã máy không tồn tại!".ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			catch
			{
				MessageBox.Show("mã vạch không đúng!".ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCamera_Click(object sender, EventArgs e)
		{
			frmCheckMachineQrCodeCamera f = new frmCheckMachineQrCodeCamera();
			f.ShowDialog();
			txtMachineCode.Text = string.Empty;
		}

		private void frmCheckMachineQrCode_FormClosing(object sender, FormClosingEventArgs e)
		{
			LamMoi?.Invoke(sender, e);
		}
	}
}