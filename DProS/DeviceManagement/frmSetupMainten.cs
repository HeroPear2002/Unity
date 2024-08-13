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

namespace DProS.DeviceManagement
{
	public partial class frmSetupMainten : DevExpress.XtraEditors.XtraForm
	{
		List<DeviceDTO> listdevice = new List<DeviceDTO>();
		List<CateTestMachineDTO> listcate = new List<CateTestMachineDTO>();
		List<MachineDTO> listMachine = new List<MachineDTO>();
		bool change = false;
		public frmSetupMainten()
		{
			InitializeComponent();
		}
		private void frmSetupMainten_Load(object sender, EventArgs e)
		{
			if (Common.CommonConstant.checkSetupDevice == 0) this.Text = "THIẾT LẬP KT HÀNG NGÀY";
			listdevice = DeviceDAO.Instance.GetList();
			cbDeviceType.DataSource = listdevice;
			cbDeviceType.DisplayMember = "Name";
			cbDeviceType.ValueMember = "Id";
			change = true;
			cbDeviceType.SelectedValue = listdevice[0].Id;
			cbDeviceType_SelectedIndexChanged(sender, e);
		}
		private void LoadData()
		{
			if (Common.CommonConstant.checkSetupDevice == 0)
			{
				int idDevice = 0;
				if (cbDeviceType.Text.Length > 0) idDevice = int.Parse(cbDeviceType.SelectedValue.ToString());
				listcate = CateTestMachineDAO.Instance.GetList(idDevice).Where(x => x.Timer == 24).ToList();
				listMachine = MachineDAO.Instance.GetList(idDevice);
			}
			else
			{
				int idDevice = 0;
				if (cbDeviceType.Text.Length > 0) idDevice = int.Parse(cbDeviceType.SelectedValue.ToString());
				listcate = CateTestMachineDAO.Instance.GetList(idDevice).Where(x => x.Timer != 24).ToList();
				listMachine = MachineDAO.Instance.GetList(idDevice);
			}
			gcListMachine.DataSource = listMachine;
			gcListCategory.DataSource = listcate;
		}

		private void cbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(change) LoadData();
		}

		private void btnEditInfor_Click(object sender, EventArgs e)
		{
			frmSetupMaintenEditInfor EditInfor = new frmSetupMaintenEditInfor();
			EditInfor.ShowDialog();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("BẠN MUỐN LƯU BẢN GHI NÀY?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int idDevice = int.Parse(cbDeviceType.SelectedValue.ToString());
				int countInsert = 0;
				foreach (var item in gvListMachine.GetSelectedRows())
				{
					string machineCode = gvListMachine.GetRowCellValue(item, "MachineCode").ToString();
					int idMachine = int.Parse(gvListMachine.GetRowCellValue(item, "Id").ToString());
					foreach (var item2 in gvListCategory.GetSelectedRows())
					{
						string nameCategory = gvListCategory.GetRowCellValue(item2, "NameCategory").ToString();
						int idCategory = int.Parse(gvListCategory.GetRowCellValue(item2, "Id").ToString());
						RelationMachineCateDTO dto = RelationMachineCateDAO.Instance.GetItem(machineCode, nameCategory);
						if (dto == null)
						{
							bool insertRelation = RelationMachineCateDAO.Instance.Insert(idMachine, idCategory);
							if (insertRelation) countInsert++;
						}
						else if(dto.StatusRe == 0)
						{
							bool updateRelation = RelationMachineCateDAO.Instance.Update(dto.Id);
							if (updateRelation) countInsert++;
						}
					}
				}
				if (countInsert > 0) MessageBox.Show("THÊM THÀNH CÔNG.");
				else MessageBox.Show("BẠN CẦN CHỌN LẠI MÁY VÀ HẠNG MỤC BẢO DƯỠNG.");
			}
			LoadData();
		}
	}
}