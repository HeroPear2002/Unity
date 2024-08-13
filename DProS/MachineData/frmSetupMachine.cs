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
	public partial class frmSetupMachine : DevExpress.XtraEditors.XtraForm
	{
		List<MoldDTO> listmold = new List<MoldDTO>();
		List<CateDataDefaultDTO> listcate = new List<CateDataDefaultDTO>();
		List<MachineDTO> listMachine = new List<MachineDTO>();
		List<SetupDefaultDTO> listSetupDefault = new List<SetupDefaultDTO>();
		public frmSetupMachine()
		{
			InitializeComponent();
			LoadControl();
		}

		private void LoadControl()
		{
			LoadData();
			ClearText();
			LockControl(0);
		}

		private void ClearText()
		{
			txtValue.Text = string.Empty;
		}

		private void LockControl(int lockcontrol)
		{
			if(lockcontrol == 0)
			{
				btnDelete.Enabled = false;
				btnEdit.Enabled = false;
				btnSave.Enabled = false;
			}
			else if(lockcontrol == 1)
			{
				btnDelete.Enabled = true;
				btnEdit.Enabled = true;
				btnSave.Enabled = false;
			}
			else if (lockcontrol == 2)
			{
				btnDelete.Enabled = false;
				btnEdit.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		private void LoadData()
		{
			listmold = MoldDAO.Instance.GetListMold();
			int idDevice = DeviceDAO.Instance.GetItem("Máy Đúc").Id;
			listMachine = MachineDAO.Instance.GetList(idDevice);
			listcate = CateDataDefaultDAO.Instance.GetList();
			listSetupDefault = SetupDefaultDAO.Instance.GetList();
			gcMold.DataSource = listmold;
			gcMachine.DataSource = listMachine;
			gcCateDataDefault.DataSource = listcate;
			gcSetupDefault.DataSource = listSetupDefault;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvSetupDefault.GetSelectedRows())
				{
					long id = long.Parse(gvSetupDefault.GetRowCellValue(item, "Id").ToString());
					bool delete = SetupDefaultDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper());
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA");
			}
			LoadControl();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvSetupDefault.GetSelectedRows())
				{
					long id = long.Parse(gvSetupDefault.GetRowCellValue(item, "Id").ToString());
					string name = gvSetupDefault.GetRowCellValue(item, "Name").ToString();
					string machineCode = gvSetupDefault.GetRowCellValue(item, "MachineCode").ToString();
					string moldCode = gvSetupDefault.GetRowCellValue(item, "MoldCode").ToString();
					string valueDefault = gvSetupDefault.GetRowCellValue(item,"ValueDefault").ToString();
					int idcate = 0;
					int idmachine = 0;
					int idmold = 0;
					if(name == "" || machineCode == "" || moldCode == "")
					{
						MessageBox.Show("BẠN PHẢI NHẬP ĐỦ MÃ KHUÔN, MÃ MÁY, TÊN HẠNG MỤC KIỂM TRA.");
						return;
					}
					else
					{
						idcate = CateDataDefaultDAO.Instance.GetItem(name).Id;
						idmachine = MachineDAO.Instance.GetItem(machineCode).Id;
						idmold = MoldDAO.Instance.GetMoldDTO1(moldCode).Id;
					}
					float value = 0;
					if (valueDefault == "")
					{
						MessageBox.Show("BẠN PHẢI NHẬP GIÁ TRỊ ĐÃ.");
						return;
					}
					else value = float.Parse(valueDefault);
					bool update = SetupDefaultDAO.Instance.Update(id,idcate,idmold,idmachine,value);
					if (update) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã sửa thành công.".ToUpper());
				else MessageBox.Show("SỬA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI SỬA");
			}
			LoadControl();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn lưu?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int idmold = 0;
				int idmachine = 0;
				int idcate = 0;
				
				int[] selectedRowsMold = gvMold.GetSelectedRows();
				int[] selectedRowsMachine = gvMachine.GetSelectedRows();
				int[] selectedRowsCate = gvCateDataDefault.GetSelectedRows();
				if (selectedRowsMold.Length == 1 && selectedRowsMachine.Length == 1 && selectedRowsCate.Length == 1)
				{
					idmold = int.Parse(gvMold.GetRowCellValue(selectedRowsMold[0], "Id").ToString());
					idmachine = int.Parse(gvMachine.GetRowCellValue(selectedRowsMachine[0], "Id").ToString());
					idcate = int.Parse(gvCateDataDefault.GetRowCellValue(selectedRowsCate[0], "Id").ToString());
					CateDataDefaultDTO CateDTO = CateDataDefaultDAO.Instance.GetItem(idcate);
					float value = 0;
					if (txtValue.Text == "")
					{
						MessageBox.Show("BẠN PHẢI NHẬP GIÁ TRỊ ĐÃ.");
						return;
					}
					else if (float.Parse(txtValue.Text) < CateDTO.LowerLimit || CateDTO.UpperLimit < float.Parse(txtValue.Text))
					{
						MessageBox.Show("Giá trị của bạn phải nằm trong khoảng giới hạn trên và giới hạn dưới".ToUpper());
						return;
					}
					else value = float.Parse(txtValue.Text);
					if (!SetupDefaultDAO.Instance.GetItem(idcate, idmold, idmachine))
					{
						bool insert = SetupDefaultDAO.Instance.Insert(idcate, idmold, idmachine, value);
						if (insert) MessageBox.Show("Bạn đã lưu thành công.".ToUpper());
						else MessageBox.Show("LƯU KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI LƯU");
					}
					else MessageBox.Show("HẠNG MỤC KIỂM TRA MÁY VÀ KHUÔN NÀY ĐÃ ĐƯỢC THIẾT LẬP.");
				}
				else MessageBox.Show("MỖI BẢNG BẠN PHẢI CHỌN 1 HÀNG");
			}
			LoadControl();
		}

		private void gvSetupDefault_Click(object sender, EventArgs e)
		{
			LockControl(1);
		}

		private void gvCateDataDefault_Click(object sender, EventArgs e)
		{
			LockControl(2);
		}

		private void gvMachine_Click(object sender, EventArgs e)
		{
			LockControl(2);
		}

		private void gvMold_Click(object sender, EventArgs e)
		{
			LockControl(2);
		}
	}
}