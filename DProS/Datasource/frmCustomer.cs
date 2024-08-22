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
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frmCustomer()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            LockControl(true);
            Clentext();
        }

        private void Clentext()
        {
            txtAddress.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtPhone.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if(v)
            {
                txtAddress.Enabled = false;
                txtCustomerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtPhone.Enabled = false;
                nudDiff.Enabled = false;
                nudPOFix.Enabled = false;
                nudPOIn.Enabled = false;
                txtEmail.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false; 
            }
            else
            {
                txtAddress.Enabled = true;
                txtCustomerCode.Enabled = true;
                txtCustomerName.Enabled = true;
                txtPhone.Enabled = true;
                nudDiff.Enabled = true;
                nudPOFix.Enabled = true;
                nudPOIn.Enabled = true;
                txtEmail.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        void Save()
        {
            if(IsInsert)
            {
                string addr = txtAddress.Text;
                string cusco = txtCustomerCode.Text;
                string cusna = txtCustomerName.Text;
                string phone = txtPhone.Text;
                int dif = int.Parse(nudDiff.Value.ToString());
                int pofix= int.Parse(nudPOFix.Value.ToString());
                int point = int.Parse(nudPOIn.Value.ToString());
                string email = txtEmail.Text;
                int insert = CustomerDAO.Instance.Insert(cusco, cusna, addr, phone, email, "", point, pofix, dif);

            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string addr = txtAddress.Text;
                string cusco = txtCustomerCode.Text;
                string cusna = txtCustomerName.Text;
                string phone = txtPhone.Text;
                int dif = int.Parse(nudDiff.Value.ToString());
                int pofix = int.Parse(nudPOFix.Value.ToString());
                int point = int.Parse(nudPOIn.Value.ToString());
                string email = txtEmail.Text;
                int Update = CustomerDAO.Instance.Update(id,cusco, cusna, addr, phone, email, "", point, pofix, dif);
            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = CustomerDAO.Instance.Getlist();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsInsert = true;
            LockControl(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            LockControl(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    foreach (var item in gridView1.GetSelectedRows())
                    {
                        int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        int del = CustomerDAO.Instance.Delete(id);
                    }
                    LoadControl();
                    
                }
            }
            catch (Exception)
            {

               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
    }
}