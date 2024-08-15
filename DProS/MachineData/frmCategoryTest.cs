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
	public partial class frmCategoryTest : DevExpress.XtraEditors.XtraForm
	{
		List<CateDataDefaultDTO> listCateData = new List<CateDataDefaultDTO>();
		bool insert = true;
		public frmCategoryTest()
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
			listCateData = CateDataDefaultDAO.Instance.GetList();
			gcCateDataDefault.DataSource = listCateData;
		}

		private void CleanText()
		{
			txtNameCategory.Text = string.Empty;
			txtUpperLimit.Text = string.Empty;
			txtLowerLimit.Text = string.Empty;
		}
		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtNameCategory.Enabled = false;
				txtUpperLimit.Enabled = false;
				txtLowerLimit.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtNameCategory.Enabled = true;
				txtUpperLimit.Enabled = true;
				txtLowerLimit.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			string name = txtNameCategory.Text;
			if (name.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập tên hạng mục cần kiểm tra.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			float upperLimit = 0;
			float lowerLimit = 0;
			if (txtUpperLimit.Text == "" || txtLowerLimit.Text == "")
			{
				MessageBox.Show("Bạn không được để trống giới hạn trên và giới hạn dưới.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if(float.Parse(txtUpperLimit.Text)< float.Parse(txtLowerLimit.Text))
			{
				MessageBox.Show("Giới hạn trên phải lớn hơn hoặc bằng giới hạn dưới.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else
			{
				upperLimit = float.Parse(txtUpperLimit.Text);
				lowerLimit = float.Parse(txtLowerLimit.Text);
			}
			if (insert)
			{
				if (CateDataDefaultDAO.Instance.GetItem(name) == null)
				{
					bool insertCateData = CateDataDefaultDAO.Instance.Insert(name , upperLimit, lowerLimit);
					if (insertCateData)
					{
						MessageBox.Show("Bạn đã thêm thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Tên hạng mục này đã tồn tại hãy nhập tên hạng mục khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}
			else
			{
				int id = int.Parse(gvCateDataDefault.GetFocusedRowCellValue("Id").ToString());
				if (CateDataDefaultDAO.Instance.GetItem(name) == null || CateDataDefaultDAO.Instance.GetItem(name).Id == id)
				{
					bool updateCateData = CateDataDefaultDAO.Instance.Update(id, name, upperLimit, lowerLimit);
					if (updateCateData)
					{
						MessageBox.Show("Bạn đã sửa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Tên hạng mục này đã tồn tại hãy nhập tên hạng mục khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				int countid = 0;
				foreach (var item in gvCateDataDefault.GetSelectedRows())
				{
					int id = int.Parse(gvCateDataDefault.GetRowCellValue(item, "Id").ToString());
					bool delete = CateDataDefaultDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void gvCateDataDefault_Click(object sender, EventArgs e)
		{
			try
			{
				txtNameCategory.Text = gvCateDataDefault.GetFocusedRowCellValue("Name").ToString();
				txtUpperLimit.Text = gvCateDataDefault.GetFocusedRowCellValue("UpperLimit").ToString();
				txtLowerLimit.Text = gvCateDataDefault.GetFocusedRowCellValue("LowerLimit").ToString();
				
			}
			catch (Exception)
			{


			}
		}
	}
}