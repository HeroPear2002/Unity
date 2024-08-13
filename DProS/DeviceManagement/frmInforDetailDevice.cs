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
	public partial class frmInforDetailDevice : DevExpress.XtraEditors.XtraForm
	{
		int idMachine;
		List<MachineDetailDTO> listMachineDetail = new List<MachineDetailDTO>();
		MachineDTO machine = null;
		public frmInforDetailDevice()
		{
			InitializeComponent();
			LoadData();
		}
		public frmInforDetailDevice(int idmachine)
		{
			InitializeComponent();
			idMachine = idmachine;
			LoadData();
		}
		private void LoadData()
		{
			listMachineDetail = MachineDetailDAO.Instance.GetListMachineDetail(idMachine);
			machine = MachineDAO.Instance.GetItem(idMachine);
			gcInforDetailMachine.DataSource = listMachineDetail;
		}

		private void btnGetMachineData_Click(object sender, EventArgs e)
		{
			List<MachineDetailDTO> listM = MachineDetailDAO.Instance.GetListMachineDetail(idMachine);
			if (listM.Count > 0)
			{

			}
			else
			{
				string DetailName = "";
				string DetailInfor = "";
				string Note = "";
				machine = MachineDAO.Instance.GetItem(idMachine);
				for (int i = 1; i <= 19; i++)
				{
					switch (i)
					{
						case 1:
							{
								DetailName = "Tên máy";
								DetailInfor = machine.MachineName;
							}
							break;
						case 2:
							{
								DetailName = "Mã máy";
								DetailInfor = machine.MachineCode;
							}
							break;
						case 3:
							{
								DetailName = "Nhà sản xuất";
								DetailInfor = machine.Manufacturer;
							}
							break;
						case 4:
							{
								DetailName = "Ngày sản xuất";
								DetailInfor = machine.DateMaker;
							}
							break;
						case 5:
							{
								DetailName = "Số seri";
								DetailInfor = machine.SerialNumber;
							}
							break;
						case 6:
							{
								DetailName = "Ngày nhập";
								DetailInfor = machine.DateInput;
							}
							break;
						case 7:
							{
								DetailName = "Nhà cung cấp";
								DetailInfor = machine.Vender;
							}
							break;
						case 8:
							{
								DetailName = "Ngày sử dụng";
								DetailInfor = machine.DateProduct;
							}
							break;
						case 9:
							{
								DetailName = "Điện áp sử dụng";
								DetailInfor = "";
							}
							break;
						case 10:
							{ 
								DetailName = "Mã tài sản cố định";
								DetailInfor = machine.CodeAsset;
							}
							break;
						case 11:
							{
								DetailName = "Thời gian sử dụng";
								DetailInfor = "";
							}
							break;
						default:
							{
								DetailName = "";
								DetailInfor = "";
							}
							break;
					}
					MachineDetailDAO.Instance.InsertMachineDetail(idMachine, DetailName, DetailInfor, Note);
				}
				LoadData();
			}
			}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn lưu thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					long Id = long.Parse(gridView1.GetRowCellValue(i, "Id").ToString());
					string DetailName = gridView1.GetRowCellValue(i, "DetailName").ToString();
					string DetailInfor = gridView1.GetRowCellValue(i, "DetailInfor").ToString();
					MachineDetailDAO.Instance.UpdateMachineDetail(Id, idMachine, DetailName, DetailInfor, "");
				}
				LoadData();
			}
		}

		private void btnInsertLine_Click(object sender, EventArgs e)
		{
			MachineDetailDAO.Instance.InsertMachineDetail(idMachine, "", "", "");
			LoadData();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gridView1.GetSelectedRows())
				{
					int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
					bool delete = MachineDetailDAO.Instance.DeleteMachineDetail(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper());
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA");
			}
			LoadData();
		}
	}
}