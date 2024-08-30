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

namespace DProS.Datasource
{
    public partial class frmBoxPart : DevExpress.XtraEditors.XtraForm
    {
        public frmBoxPart()
        {
            InitializeComponent();
			LoadControl();
		}
		public bool IsInsert = false;
		void LoadControl()
		{
			LockControl(true);
			LoadData();
			LoadPartCode();
		}
		void LoadData()
		{
			gcBoxPart.DataSource = BoxNatureDAO.Instance.GetList();
		}
		void LockControl(bool lockcontrol)
		{
			if(lockcontrol)
			{
				txtBoxName.Enabled = false;
				nudQuantity.Enabled = false;
				txtNote.Enabled = false;

				btnAdd.Enabled = true;
				btnDelete.Enabled = true;
				btnEdit.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtBoxName.Enabled = true;
				nudQuantity.Enabled = true;
				txtNote.Enabled = true;
				btnAdd.Enabled = false;
				btnDelete.Enabled = false;
				btnEdit.Enabled = false;
				btnSave.Enabled = true;
			}
			

		}
		void DeleteText()
		{
			txtBoxName.Text = String.Empty;
			txtNote.Text = String.Empty;
			nudQuantity.Text = String.Empty;
		}
		void AddText()
		{
			try
			{
				txtNote.Text = gvBoxPart.GetRowCellValue(gvBoxPart.FocusedRowHandle, gvBoxPart.Columns["Note"]).ToString();
				txtBoxName.Text = gvBoxPart.GetRowCellValue(gvBoxPart.FocusedRowHandle, gvBoxPart.Columns["BoxName"]).ToString();
				nudQuantity.Text = gvBoxPart.GetRowCellValue(gvBoxPart.FocusedRowHandle, gvBoxPart.Columns["Quantity"]).ToString();
			}
			catch
			{
			}
		}
		void LoadPartCode()
		{
			txtNote.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtNote.AutoCompleteSource = AutoCompleteSource.CustomSource;
			AutoCompleteStringCollection data = new AutoCompleteStringCollection();
			AddItem(data);
			txtNote.AutoCompleteCustomSource = data;
		}
		void AddItem(AutoCompleteStringCollection col)
		{
			List<PartDTO> listP = PartDAO.Instance.Getlist();
			foreach (PartDTO item in listP)
			{
				col.Add(item.PartCode);
			}
		}
		void Save()
		{
			int quantity = int.Parse(nudQuantity.Value.ToString());
			string boxName = txtBoxName.Text;
			if(txtBoxName.Text.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập tên thùng.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string note = txtNote.Text;
			if (IsInsert)
			{
				int insert = BoxNatureDAO.Instance.Insert(boxName, quantity, note);
				if (insert > 0)
				{
					MessageBox.Show("Bạn đã thêm thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				MessageBox.Show("Bạn thêm bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
			else
			{
				int id = int.Parse(gvBoxPart.GetFocusedRowCellValue("Id").ToString());
				int update = BoxNatureDAO.Instance.Update(id, boxName, quantity, note);
				if (update > 0)
				{
					MessageBox.Show("Bạn đã sửa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				MessageBox.Show("Bạn sửa bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void btnAdd_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = true;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = false;
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

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvBoxPart.GetSelectedRows())
				{
					int id = int.Parse(gvBoxPart.GetRowCellValue(item, "Id").ToString());
					int delete = BoxNatureDAO.Instance.Delete(id);
					if (delete > 0) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void gvBoxPart_Click(object sender, EventArgs e)
		{
			AddText();
		}
	}
}