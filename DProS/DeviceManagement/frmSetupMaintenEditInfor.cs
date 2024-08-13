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
	public partial class frmSetupMaintenEditInfor : DevExpress.XtraEditors.XtraForm
	{
		List<DeviceDTO> listdevice = new List<DeviceDTO>();
		List<RelationMachineCateDTO> listRelationShip = new List<RelationMachineCateDTO>();
		bool change = false;
		public frmSetupMaintenEditInfor()
		{
			InitializeComponent();
		}

		private void frmSetupMaintenEditInfor_Load(object sender, EventArgs e)
		{
			listdevice = DeviceDAO.Instance.GetList();
			cbDeviceType.DataSource = listdevice;
			cbDeviceType.DisplayMember = "Name";
			cbDeviceType.ValueMember = "Id";
			cbDeviceType.Text = listdevice[0].Name;
			change = true;
			cbDeviceType_SelectedIndexChanged(sender, e);
		}
		private void LoadData()
		{
			int idDevice = 0;
			if (cbDeviceType.Text.Length > 0) idDevice = int.Parse(cbDeviceType.SelectedValue.ToString());
			if (Common.CommonConstant.checkSetupDevice == 0)
			{
				listRelationShip = RelationMachineCateDAO.Instance.GetList(idDevice).Where(x => x.Timer == 24).ToList();
				gcRelationMachineCate.DataSource = listRelationShip;
			}
			else
			{
				listRelationShip = RelationMachineCateDAO.Instance.GetList(idDevice).Where(x => x.Timer != 24).ToList();
				gcRelationMachineCate.DataSource = listRelationShip;
			}
		}
		private void cbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (change) LoadData();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvRelationMachineCate.GetSelectedRows())
				{
					long id = long.Parse(gvRelationMachineCate.GetRowCellValue(item, "Id").ToString());
					bool delete = RelationMachineCateDAO.Instance.Delete(id);
					if(delete) countid++;
				}
				if (countid > 0)
				{
					LoadData();
					MessageBox.Show("Bạn đã xóa thành công.".ToUpper());
				}
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA");
			}
			this.Close();
		}
	}
}