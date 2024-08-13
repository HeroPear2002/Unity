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
using DTO;
using DAO;
using DevExpress.XtraReports.UI;

namespace DProS.DeviceManagement
{
	public partial class frmListDevice : DevExpress.XtraEditors.XtraForm
	{
		List<DeviceDTO> listdevice = new List<DeviceDTO>();
		List<MachineDTO> listMachine = new List<MachineDTO>();
		bool insert = true;
		public frmListDevice()
		{
			InitializeComponent();
			loadDevice();
			LoadControl();
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}
		private void loadDevice()
		{
			listdevice = DeviceDAO.Instance.GetList();
			cbDeviceType.DataSource = listdevice;
			cbDeviceType.DisplayMember = "Name";
			cbDeviceType.ValueMember = "Id";
		}
		private void LoadData()
		{
			listMachine = MachineDAO.Instance.GetList();
			gridControl1.DataSource = listMachine;
		}

		private void CleanText()
		{
			cbDeviceType.Text = string.Empty;
		}

		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				cbDeviceType.Enabled = false;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				cbDeviceType.Enabled = true;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			int idDevice = 0;
			if (cbDeviceType.Text.Length > 0) idDevice = int.Parse(cbDeviceType.SelectedValue.ToString());
			if (!insert)
			{
				int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
				bool updateMachine = MachineDAO.Instance.Update(id, idDevice);
				if (updateMachine)
				{
					MessageBox.Show("Bạn đã sửa thành công.".ToUpper());
					return;
				}
				MessageBox.Show("Bạn sửa bị thất bại.".ToUpper());

			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
			insert = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0 ;
				foreach (var item in gridView1.GetSelectedRows())
				{
					int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
					bool delete = MachineDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper());
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA"); 
			}
			LoadControl();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Save();
			LoadControl();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void btnCodeLarge_Click(object sender, EventArgs e)
		{
			List<MachineDTO> listQr = new List<MachineDTO>();
			foreach (var item in gridView1.GetSelectedRows())
			{
				MachineDTO machineDTO = null;
				int idMachine = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
				machineDTO = MachineDAO.Instance.GetItem(idMachine);
				listQr.Add(machineDTO);
			}
			rpMachineQRCodeLarge rp = new rpMachineQRCodeLarge();
			rp.DataSource = listQr;
			rp.PrintDialog();
		}

		private void btnCodeSmall_Click(object sender, EventArgs e)
		{
			List<MachineDTO> listQr = new List<MachineDTO>();
			foreach (var item in gridView1.GetSelectedRows())
			{
				MachineDTO machineDTO = null;
				int idMachine = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
				machineDTO = MachineDAO.Instance.GetItem(idMachine);
				listQr.Add(machineDTO);
			}
			rpMachineQRCodeSmall rp = new rpMachineQRCodeSmall();
			rp.DataSource = listQr;	
			rp.PrintDialog();
		}

		private void btnCodeMedium_Click(object sender, EventArgs e)
		{
			List<MachineDTO> listQr = new List<MachineDTO>();
			foreach (var item in gridView1.GetSelectedRows())
			{
				MachineDTO machineDTO = null;
				int idMachine = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
				machineDTO = MachineDAO.Instance.GetItem(idMachine);
				listQr.Add(machineDTO);
			}
			rpMachineQRCodeMedium rp = new rpMachineQRCodeMedium();
			rp.DataSource = listQr;
			rp.PrintDialog();
		}

		private void btnEditCodeMachine_Click(object sender, EventArgs e)
		{
			frmListDeviceEditMachineCode form = new frmListDeviceEditMachineCode();
			form.ShowDialog();
		}
	}
}