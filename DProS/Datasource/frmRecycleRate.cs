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
    public partial class frmRecycleRate : DevExpress.XtraEditors.XtraForm
    {
        public frmRecycleRate()
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
            LoadGrid();
        }

        private void LoadGrid()
        {
            glMaterial.Properties.DataSource = MaterialDAO.Instance.Getlist();
            glMaterial.Properties.DisplayMember = "MatCode";
            glMaterial.Properties.ValueMember = "Id";
        }

        private void Clentext()
        {
            txtNote.Text = string.Empty;
            glMaterial.Text = string.Empty;
            nudMaxImpRate.Text = string.Empty;
           nudMaxUseRate.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtNote.Enabled = false;
                glMaterial.Enabled = false;
                nudMaxImpRate.Enabled = false;
                nudMaxUseRate.Enabled = false;


                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnEditSomeValue.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtNote.Enabled = true;
                glMaterial.Enabled = true;
                nudMaxImpRate.Enabled = true;
                nudMaxUseRate.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnEditSomeValue.Enabled = false;
                btnSave.Enabled = true;
            }
        }
        void Save()
        {
            if (IsInsert)
            {
                try
                {
                    string note = txtNote.Text;
                    int idmat = int.Parse(glMaterial.EditValue.ToString());
                    int ratiouse = int.Parse(nudMaxUseRate.Value.ToString());
                    int ratioinput = int.Parse(nudMaxImpRate.Value.ToString());
                    int insert = RatioMaterialDAO.Instance.Insert(idmat,ratiouse,ratioinput, note);
                }
                catch (Exception)
                {                   
                }               
            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string note = txtNote.Text;
                int idmat = int.Parse(glMaterial.EditValue.ToString());
                int ratiouse = int.Parse(nudMaxUseRate.Value.ToString());
                int ratioinput = int.Parse(nudMaxImpRate.Value.ToString());
                int update = RatioMaterialDAO.Instance.Update(id,idmat, ratiouse, ratioinput, note);
            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = RatioMaterialDAO.Instance.Getlist();
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
            if(MessageBox.Show("Bạn chắc chắn xóa.","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int del = RatioMaterialDAO.Instance.Delete(id);
                }
            }
        }

        private void btnEditSomeValue_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn sửa những mã nguyên liệu này,","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    try
                    {
                        int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        int ratioUse = int.Parse(gridView1.GetRowCellValue(item, "RatioUsing").ToString());
                        int ratioInput = int.Parse(gridView1.GetRowCellValue(item, "RatioInput").ToString());
                        string note = gridView1.GetRowCellValue(item, "Note").ToString();
                        int Update = RatioMaterialDAO.Instance.Update(id, ratioUse, ratioInput, note);
                    }
                    catch (Exception)
                    {
                   
                    }                  
                }
                LoadControl();
            }

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtNote.Text = gridView1.GetFocusedRowCellValue("Note").ToString();
                glMaterial.Text= gridView1.GetFocusedRowCellValue("MatCode").ToString();
                nudMaxImpRate.Value = int.Parse(gridView1.GetFocusedRowCellValue("RatioInput").ToString());
                nudMaxUseRate.Value = int.Parse(gridView1.GetFocusedRowCellValue("RatioUsing").ToString());
            }
            catch (Exception)
            {

               
            }
        }
    }
}