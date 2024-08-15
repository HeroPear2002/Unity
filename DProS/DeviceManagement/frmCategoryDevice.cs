using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;

namespace DProS.DeviceManagement
{
	public partial class frmCategoryDevice : DevExpress.XtraEditors.XtraForm
	{
		List<DeviceDTO> listDevice = new List<DeviceDTO>();
		bool insert;
		public frmCategoryDevice()
		{
			InitializeComponent();
			LoadControl();
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}

		private void LoadData()
		{
			List<DeviceDTO> listDevice = DeviceDAO.Instance.GetList();
			gcDeviceList.DataSource = listDevice;
		}

		private void CleanText()
		{
			txtDeviceName.Text = string.Empty;
			txtMethodEveryday.Text = string.Empty;
			txtMethodMainten.Text = string.Empty;
		}

		private void LockControl(bool isLock)
		{
			txtMethodEveryday.Enabled = false;
			txtMethodMainten.Enabled = false;
			if (isLock)
			{
				txtDeviceName.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
				btnChooseFileEveryday.Enabled = false;
				btnChooseFileMainten.Enabled = false;
			}
			else
			{
				txtDeviceName.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
				btnChooseFileEveryday.Enabled = true;
				btnChooseFileMainten.Enabled = true;
			}
		}
		void Save()
		{
			string name = txtDeviceName.Text;
			if (name.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập loại thiết bị.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string urlEveryday = txtMethodEveryday.Text;
			string urlMainten = txtMethodMainten.Text;
			if (insert)
			{
				if (DeviceDAO.Instance.GetItem(name) == null)
				{
					bool inserted = DeviceDAO.Instance.Insert(name, urlEveryday, urlMainten);
					if (inserted)
					{
						MessageBox.Show("Bạn đã thêm thành công".ToUpper(),"THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Tên thiết bị này đã tồn tại hãy nhập tên thiết bị khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				int id = int.Parse(tvDeviceList.GetFocusedRowCellValue("Id").ToString());
				if (DeviceDAO.Instance.GetItem(name) == null || DeviceDAO.Instance.GetItem(name).Id == id)
				{
					bool updated = DeviceDAO.Instance.Update(id, name, urlEveryday, urlMainten);
					if (updated)
					{
						MessageBox.Show("Bạn đã sửa thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Tên thiết bị này đã tồn tại hãy nhập tên thiết bị khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}
		}

		private void TileView1_DoubleClick(object sender, EventArgs e)
		{
			int rowHandle = tvDeviceList.FocusedRowHandle;
			DeviceDTO data = (DeviceDTO)tvDeviceList.GetRow(rowHandle);
			if (data != null)
			{
				int id = data.Id;
				frmMachineList machineList = new frmMachineList(id);
				machineList.Text = "Danh sách "+ data.Name;
				machineList.Show();
			}
		}
		private void tileView1_Click(object sender, EventArgs e)
		{
			int rowHandle = tvDeviceList.FocusedRowHandle;
			DeviceDTO data = (DeviceDTO)tvDeviceList.GetRow(rowHandle);
			if (data != null)
			{
				txtDeviceName.Text = data.Name;
				txtMethodEveryday.Text = data.UrlEveryday;
				txtMethodMainten.Text = data.UrlMainten;
			}
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			LockControl(false);
			insert = true;
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
				int id = int.Parse(tvDeviceList.GetFocusedRowCellValue("Id").ToString());
				bool delete = DeviceDAO.Instance.Delete(id);
				if (delete)  MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("BẠN MUỐN LƯU BẢN GHI NÀY?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				Save();
				LoadControl();
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void btnChooseFileMainten_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "C:\\";
				openFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt|Image files (*.png;*.jpg)|*.png;*.jpg";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					txtMethodMainten.Text = openFileDialog.FileName;
				}
			}
		}

		private void btnChooseFileEveryday_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "C:\\";
				openFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt|Image files (*.png;*.jpg)|*.png;*.jpg";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					txtMethodEveryday.Text = openFileDialog.FileName;
				}
			}
		}
	}
}