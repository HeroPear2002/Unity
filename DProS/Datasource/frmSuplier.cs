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
using System.IO;

namespace DProS.Datasource
{
    public partial class frmSuplier : DevExpress.XtraEditors.XtraForm
    {
        public frmSuplier()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert = false;
        private void LoadControl()
        {
            LockCotrol(true);
            LoadData();
            CleanText();
        }

        private void CleanText()
        {
            txtAddress.Enabled = false;
            txtContact.Enabled = false;
            txtFax.Enabled = false;
            txtPhone.Enabled = false;
            txtSuplierCode.Enabled = false;
            txtSuplierName.Enabled = false;
        }

        private void LoadData()
        {
            gridControl1.DataSource = SupplierDAO.Instance.Getlist();
        }

        private void LockCotrol(bool v)
        {
            if(v)
            {
                txtAddress.Enabled = false;
                txtContact.Enabled = false;
                txtFax.Enabled = false;
                txtPhone.Enabled = false;
                txtSuplierCode.Enabled = false;
                txtSuplierName.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnExcelInPut.Enabled = true;
                btnDelete.Enabled = true;
                btnForm.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtAddress.Enabled = true;
                txtContact.Enabled = true;
                txtFax.Enabled = true;
                txtPhone.Enabled = true;
                txtSuplierCode.Enabled = true;
                txtSuplierName.Enabled = true;
                

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnExcelInPut.Enabled = false;
                btnDelete.Enabled = false;
                btnForm.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        void Save()
        {
            if(IsInsert)
            {
                string code = txtSuplierCode.Text;
                string name = txtSuplierName.Text;
                string phone = txtPhone.Text;
                string fax = txtFax.Text;
                string contact = txtContact.Text;
                string address = txtAddress.Text;
                int insert = SupplierDAO.Instance.Insert(code, name, address, phone, contact, fax);
            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string code = txtSuplierCode.Text;
                string name = txtSuplierName.Text;
                string phone = txtPhone.Text;
                string fax = txtFax.Text;
                string contact = txtContact.Text;
                string address = txtAddress.Text;

                int Update = SupplierDAO.Instance.Update(id,code, name, address, phone, contact, fax);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsInsert = true;
            LockCotrol(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            LockCotrol(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn xóa khách hàng này","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "ID").ToString());
                    int del = SupplierDAO.Instance.Delete(id);
                }
                LoadControl();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtAddress.Text = gridView1.GetFocusedRowCellValue("Address").ToString();
                txtContact.Text= gridView1.GetFocusedRowCellValue("Contact").ToString();
                txtFax.Text= gridView1.GetFocusedRowCellValue("Fax").ToString();
                txtPhone.Text= gridView1.GetFocusedRowCellValue("Phone").ToString();
                txtSuplierCode.Text= gridView1.GetFocusedRowCellValue("SuplierCode").ToString();
                txtSuplierName.Text = gridView1.GetFocusedRowCellValue("SuplierName").ToString();
            }
            catch (Exception)
            {

               
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    switch (fileExtenstion)
                    {
                        case ".xlsx":
                            gridControl1.DataSource = null;                           
                            gridControl1.ExportToXlsx(exportFilePath);    
                            break;
                        default:
                            break;
                    }
                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadControl();
        }

        private void btnExcelInPut_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
    }
}