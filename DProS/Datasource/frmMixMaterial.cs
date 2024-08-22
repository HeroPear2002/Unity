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
    public partial class frmMixMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmMixMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            Loadgrid();
            LockControl(true);
            Clentext();
        }

        private void Loadgrid()
        {
            List<MaterialDTO> lsvtotal = MaterialDAO.Instance.Getlist();
            List<MaterialMixDTO> lsvmix = MaterialMixDAO.Instance.Getlist();
            foreach (MaterialMixDTO item in lsvmix)
            {
                lsvtotal.RemoveAll(x => x.MatCode == item.MatMix);
            }
            glSupMatMix.Properties.DataSource = lsvtotal;
            glSupMatMix.Properties.DisplayMember = "MatCode";
            glSupMatMix.Properties.ValueMember = "MatCode";
        }

        private void Clentext()
        {
            txtMixMaterialCode.Text = string.Empty;
            
            txtWeight.Text = string.Empty;
           

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtMixMaterialCode.Enabled = false;
                glSupMatMix.Enabled = false;
                txtWeight.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                btnPrintQr.Enabled = true;
            }
            else
            {
                txtMixMaterialCode.Enabled = true;
                glSupMatMix.Enabled = true;
                txtWeight.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
                btnPrintQr.Enabled = false;
            }
        }
        void Save()
        {
            if (IsInsert)
            {
                string matmix = txtMixMaterialCode.Text;
                string matsup = glSupMatMix.EditValue.ToString();
                float weight = float.Parse(txtWeight.Text);
                string note = "";
                int insert = MaterialMixDAO.Instance.Insert(matmix, matsup, weight, note);

            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string matmix = txtMixMaterialCode.Text;
                string matsup = glSupMatMix.Text.ToString();
                float weight = float.Parse(txtWeight.Text);
                string note = "";
                int update = MaterialMixDAO.Instance.Update(id,matmix, matsup, weight, note);

            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = MaterialMixDAO.Instance.Getlist();
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
            if( MessageBox.Show("Bạn có chắc chắn muốn xóa","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    try
                    {
                        int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        int del = MaterialMixDAO.Instance.Delete(id);
                    }
                    catch (Exception)
                    {

                      
                    }
                }
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnPrintQr_Click(object sender, EventArgs e)
        {
            //Phan mem goc chua có tinh năng này
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMixMaterialCode.Text = gridView1.GetFocusedRowCellValue("MatMix").ToString();

                txtWeight.Text = gridView1.GetFocusedRowCellValue("Quantity").ToString();
                glSupMatMix.Text= gridView1.GetFocusedRowCellValue("MatCode").ToString();
            }
            catch (Exception)
            {

               
            }
        }
    }
}