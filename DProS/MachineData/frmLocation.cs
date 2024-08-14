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
	public partial class frmLocation : DevExpress.XtraEditors.XtraForm
	{
		List<LocationDTO> listLocation = new List<LocationDTO>();
		bool Insert = true;
		public frmLocation()
		{
			InitializeComponent();
			LoadControl();
		}

		private void LoadControl()
		{
			LoadData();
			LockControl(true);
			CleanText();
		}

		private void CleanText()
		{
			txtNameLocation.Text = string.Empty;
		}

		private void LockControl(bool lockcontrol)
		{
			if(lockcontrol)
			{
				txtNameLocation.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtNameLocation.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}

		private void LoadData()
		{
			listLocation = LocationDAO.Instance.GetList();
			gcLocation.DataSource = listLocation;
		}
		private void Save()
		{
			string name = txtNameLocation.Text;
			if(name.Trim() == "")
			{
				MessageBox.Show("KHÔNG ĐƯỢC ĐỂ TRỐNG VỊ TRÍ.");
				return;
			}
			if (Insert)
			{
				if (LocationDAO.Instance.GetItem(name) == null)
				{
					bool insert = LocationDAO.Instance.Insert(name);
					if (insert)
					{
						MessageBox.Show("Bạn đã thêm thành công.".ToUpper());
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại.".ToUpper());
				}
				else MessageBox.Show("Vị trí này đã tồn tại hãy nhập Vị trí khác khác.".ToUpper());

			}
			else
			{
				int id = int.Parse(gvLocation.GetFocusedRowCellValue("Id").ToString());
				if (LocationDAO.Instance.GetItem(name) == null || LocationDAO.Instance.GetItem(name).Id == id)
				{
					bool update = LocationDAO.Instance.Update(id, name);
					if (update)
					{
						MessageBox.Show("Bạn đã sửa thành công.".ToUpper());
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại.".ToUpper());
				}
				else MessageBox.Show("Vị trí này đã tồn tại hãy nhập vị trí khác.".ToUpper());
			}
		}
		private void btnInsert_Click(object sender, EventArgs e)
		{
			Insert = true;
			LockControl(false);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Insert = false;
			LockControl(false);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvLocation.GetSelectedRows())
				{
					int id = int.Parse(gvLocation.GetRowCellValue(item, "Id").ToString());
					bool delete = LocationDAO.Instance.Delete(id);
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

		private void gvLocation_Click(object sender, EventArgs e)
		{
			try
			{
				txtNameLocation.Text = gvLocation.GetFocusedRowCellValue("Name").ToString();
			}
			catch (Exception)
			{


			}
		}
	}
}