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

namespace DProS.Production_Manager.Box_Manager
{
    public partial class frmBoxInf : DevExpress.XtraEditors.XtraForm
    {
		List<BoxInforDTO> listBox = new List<BoxInforDTO>();
        public frmBoxInf()
        {
            InitializeComponent();
			LoadControl();
			LoadComboBox();
		}
		public bool IsInsert = false;
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}
		void LoadComboBox()
		{
			cbBoxCode.DataSource = BoxListDAO.Instance.GetList();
			cbBoxCode.DisplayMember = "BoxCode";
			cbBoxCode.ValueMember = "Id";
			cbPartCode.DataSource = PartDAO.Instance.Getlist();
			cbPartCode.DisplayMember = "PartCode";
			cbPartCode.ValueMember = "Id";
		}
		void LoadData()
		{
			listBox = BoxInforDAO.Instance.GetList();
			gcBoxInfor.DataSource = listBox;
		}
		private void CleanText()
		{
			cbBoxCode.Text = string.Empty;
			cbPartCode.Text = string.Empty;
		}

		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				cbBoxCode.Enabled = false;
				cbPartCode.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				cbBoxCode.Enabled = true;
				cbPartCode.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			if (cbBoxCode.Text == "")
			{
				MessageBox.Show("Bạn phải chọn mã hộp trước.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if (cbPartCode.Text == "")
			{
				MessageBox.Show("Bạn phải chọn mã linh kiện trước.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			int idBox = int.Parse(cbBoxCode.SelectedValue.ToString());
			int idPart = int.Parse(cbPartCode.SelectedValue.ToString());
			if (IsInsert)
			{
				if (BoxInforDAO.Instance.GetItem(idBox, idPart) == null)
				{
					bool insert = BoxInforDAO.Instance.Insert(idBox, idPart);
					if (insert)
					{
						MessageBox.Show("Bạn đã thêm thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Mã hộp với Mã linh kiện này đã có hãy nhập lại.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				int id = int.Parse(gvBoxInfor.GetFocusedRowCellValue("Id").ToString());
				if (BoxInforDAO.Instance.GetItem(idBox, idPart) == null || BoxInforDAO.Instance.GetItem(idBox, idPart).Id == id)
				{
					bool update = BoxInforDAO.Instance.Update(id, idBox, idPart);
					if (update)
					{
						MessageBox.Show("Bạn đã sửa thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Mã hộp với Mã linh kiện này đã có hãy nhập lại.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = true;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvBoxInfor.GetSelectedRows())
				{
					int id = int.Parse(gvBoxInfor.GetRowCellValue(item, "Id").ToString());
					bool delete = BoxInforDAO.Instance.Delete(id);
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

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmBoxInforSample form = new frmBoxInforSample();
			form.ShowDialog();
			LoadControl();
		}

		private void btnImportExcel_Click(object sender, EventArgs e)
		{
			frmBoxInforImport form = new frmBoxInforImport();
			form.ShowDialog();
			LoadControl();
		}

		private void gvBoxInfor_Click(object sender, EventArgs e)
		{
			try
			{
				cbBoxCode.Text = gvBoxInfor.GetFocusedRowCellValue("BoxCode").ToString();
				cbPartCode.Text = gvBoxInfor.GetFocusedRowCellValue("PartCode").ToString();
			}
			catch (Exception)
			{
			}
		}
	}
}