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
using DAO;
using DTO;

namespace DProS.Datasource
{
    public partial class frmFactory : DevExpress.XtraEditors.XtraForm
    {
		List<FactoryDTO> listFactory = new List<FactoryDTO>();
		List<CustomerDTO> listCustomer = new List<CustomerDTO>();
		bool insert = true;
		public frmFactory()
        {
            InitializeComponent();
			LoadControl();
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
			LoadGridLookUpEdit();
		}

		private void LoadData()
		{
			listFactory = FactoryDAO.Instance.GetList();
			gcFactoryList.DataSource = listFactory;
		}
		private void LoadGridLookUpEdit()
		{
			listCustomer = CustomerDAO.Instance.Getlist();
			glCusCode.Properties.DataSource = listCustomer;
			glCusCode.Properties.DisplayMember = "CusCode";
			glCusCode.Properties.ValueMember = "Id";
			glCusCode.EditValue = listCustomer[0].Id;
		}
		private void CleanText()
		{
			txtFacCode.Text = string.Empty;
			txtNamFac.Text = string.Empty;
			txtAddress.Text = string.Empty;
			txtCodeofCus.Text = string.Empty;
			txtFacNameEn.Text = string.Empty;
			txtFacNameVi.Text = string.Empty;
			txtPhone.Text = string.Empty;
			txtFax.Text = string.Empty;
			txtTaxCode.Text = string.Empty;
		}
		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtFacCode.Enabled = false;
				txtNamFac.Enabled = false;
				txtAddress.Enabled = false;
				txtCodeofCus.Enabled = false;
				txtFacNameEn.Enabled = false;
				txtFacNameVi.Enabled = false;
				txtPhone.Enabled = false;
				txtFax.Enabled = false;
				txtTaxCode.Enabled = false;
				glCusCode.Enabled = false;
				btnAdd.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtFacCode.Enabled = true;
				txtNamFac.Enabled = true;
				txtAddress.Enabled = true;
				txtCodeofCus.Enabled = true;
				txtFacNameEn.Enabled = true;
				txtFacNameVi.Enabled = true;
				txtPhone.Enabled = true;
				txtFax.Enabled = true;
				txtTaxCode.Enabled = true;
				glCusCode.Enabled = true;
				btnAdd.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			string faccode = txtFacCode.Text;
			if (faccode.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập mã nhà máy.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string facname = txtNamFac.Text;
			string address = txtAddress.Text;
			string codecus = txtCodeofCus.Text;
			string facnameen = txtFacNameEn.Text;
			string facnamevn = txtFacNameVi.Text;
			string fax = txtFax.Text;
			string phone = txtPhone.Text;
			string taxcode = txtTaxCode.Text;
			int idcus = int.Parse(glCusCode.EditValue.ToString());
			string cusCode = CustomerDAO.Instance.GetItemById(idcus).CusCode;
			if (insert)
			{
				if (FactoryDAO.Instance.GetItem(faccode, cusCode) != null)
					MessageBox.Show("Mã nhà máy này đã tồn tại hãy nhập mã nhà máy khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				else if(FactoryDAO.Instance.GetItem(codecus) != null)
					MessageBox.Show("Mã nhà máy của khách hàng này đã tồn tại hãy nhập mã nhà máy của khách hàng khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				else
				{
					int insertFactory = FactoryDAO.Instance.Insert(faccode, facname, codecus, idcus, facnamevn, facnameen, address, phone, fax, taxcode);
					if (insertFactory > 0) MessageBox.Show("Bạn đã thêm thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else MessageBox.Show("Bạn thêm bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				int id = int.Parse(gvFactoryList.GetFocusedRowCellValue("Id").ToString());
				if (FactoryDAO.Instance.GetItem(codecus) != null)
					MessageBox.Show("Mã nhà máy của khách hàng này đã tồn tại hãy nhập mã nhà máy của khách hàng khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				else if (FactoryDAO.Instance.GetItem(faccode, cusCode) == null || FactoryDAO.Instance.GetItem(faccode, cusCode).Id == id )
				{
					int updateFactory = FactoryDAO.Instance.Update(id, faccode,facname,codecus,idcus,facnamevn,facnameen,address,phone,fax,taxcode);
					if (updateFactory>0) MessageBox.Show("Bạn đã sửa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else MessageBox.Show("Bạn sửa bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Mã nhà máy này đã tồn tại hãy nhập mã nhà máy khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
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
				foreach (var item in gvFactoryList.GetSelectedRows())
				{
					int id = int.Parse(gvFactoryList.GetRowCellValue(item, "Id").ToString());
					int delete = FactoryDAO.Instance.Delete(id);
					if (delete>0) countid++;
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

		private void gvFactoryList_Click(object sender, EventArgs e)
		{
			try
			{
				txtAddress.Text = gvFactoryList.GetFocusedRowCellValue("Address").ToString();
				txtCodeofCus.Text = gvFactoryList.GetFocusedRowCellValue("CodeCus").ToString();
				txtFacCode.Text = gvFactoryList.GetFocusedRowCellValue("FacCode").ToString();
				txtFacNameEn.Text = gvFactoryList.GetFocusedRowCellValue("NameBillVN").ToString();
				txtFacNameVi.Text = gvFactoryList.GetFocusedRowCellValue("NameBillEN").ToString();
				txtFax.Text = gvFactoryList.GetFocusedRowCellValue("Fax").ToString();
				txtNamFac.Text = gvFactoryList.GetFocusedRowCellValue("FacName").ToString();
				txtPhone.Text = gvFactoryList.GetFocusedRowCellValue("Phone").ToString();
				txtTaxCode.Text = gvFactoryList.GetFocusedRowCellValue("TaxCode").ToString();
				glCusCode.EditValue = int.Parse(gvFactoryList.GetFocusedRowCellValue("IdCus").ToString());
			}
			catch (Exception)
			{


			}
		}
	}
}