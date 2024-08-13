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

namespace DProS.MachineData
{
	public partial class frmTableCheckData : DevExpress.XtraEditors.XtraForm
	{
		List<MoldDTO> listMold = new List<MoldDTO>();
		List<DataCheckDTO> listDataCheck = new List<DataCheckDTO>();
		List<CateDataDefaultDTO> listCate = new List<CateDataDefaultDTO>();
		List<SetupDefaultDTO> listSetup = new List<SetupDefaultDTO>();
		public frmTableCheckData()
		{
			InitializeComponent();
			LoadComboBox();

		}
		private void LoadComboBox()
		{
			listMold = MoldDAO.Instance.GetListMold();
			cbMoldCode.DataSource = listMold;
			cbMoldCode.DisplayMember = "MoldCode";
			cbMoldCode.ValueMember = "Id";
		}
		private void LoadData()
		{
			listDataCheck = new List<DataCheckDTO>();
			string moldcode = cbMoldCode.Text;
			string machinecode = cbMachineCode.Text;
			listSetup = SetupDefaultDAO.Instance.GetItem(moldcode, machinecode);
			foreach (var item in listSetup)
			{
				CateDataDefaultDTO CateDTO = CateDataDefaultDAO.Instance.GetItem(item.Name);
				DataCheckDTO DTO = new DataCheckDTO(item.Id, item.Id, item.Name, CateDTO.UpperLimit, item.ValueDefault, CateDTO.LowerLimit, "DD");
				listDataCheck.Add(DTO);
			}
			gcDataCheck.DataSource = listDataCheck;
		}

		private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			string moldcode = cbMoldCode.Text;
			listSetup = SetupDefaultDAO.Instance.GetItem(moldcode);
			cbMachineCode.DataSource = listSetup;
			cbMachineCode.DisplayMember = "MachineCode";
		}

		private void cbMachineCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn lưu?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int count = 0;
				foreach (var item in gvDataCheck.GetSelectedRows())
				{
					long idSetup = long.Parse(gvDataCheck.GetRowCellValue(item,"Id").ToString());
					float valueReal = float.Parse(gvDataCheck.GetRowCellValue(item,"ValueReal").ToString());
					DateTime dateCheck = dtpCheck.Value;
					if(dateCheck > DateTime.Now)
					{
						MessageBox.Show("BẠN CHỌN NGÀY KIỂM TRA KHÔNG HỢP LÝ.");
						return;
					}
					bool insert = DataCheckDAO.Instance.Insert(idSetup, dateCheck, valueReal, 1);
					if (insert) count++;
				}
				if (count > 0) MessageBox.Show("Bạn đã lưu thành công.".ToUpper());
				else MessageBox.Show("LƯU KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI LƯU");
			}
			LoadData();
		}
	}
}