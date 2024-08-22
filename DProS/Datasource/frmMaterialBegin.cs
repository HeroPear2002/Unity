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
    public partial class frmMaterialBegin : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialBegin()
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
            LoadGrcid();
        }

        private void LoadGrcid()
        {
            glMaterialCode.Properties.DataSource = MaterialDAO.Instance.Getlist();
            glMaterialCode.Properties.DisplayMember = "MatCode";
            glMaterialCode.Properties.ValueMember = "Id";
        }

        private void Clentext()
        {
            glMaterialCode.Text = string.Empty;
            txtMinDate.Text = string.Empty;
            txtMinWeight.Text = string.Empty;
           

        }

        private void LockControl(bool v)
        {
            if (v)
            {
               glMaterialCode.Enabled = false;
                txtMinWeight.Enabled = false;
                txtMinDate.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;                
                btnSave.Enabled = false;
                btnUpadte.Enabled = true;
                btnExpExcel.Enabled = true;
                btnFormExcel.Enabled = true;
                btnImpExcel.Enabled = true;
            }
            else
            {
                glMaterialCode.Enabled = true;
                txtMinWeight.Enabled = true;
                txtMinDate.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnUpadte.Enabled = true;
                btnExpExcel.Enabled = false;
                btnFormExcel.Enabled =false;
                btnImpExcel.Enabled = false;
            }
        }
        void Save()
        {
            if (IsInsert)
            {                  
                    int idmat = int.Parse(glMaterialCode.EditValue.ToString());
                    string mintime = txtMinDate.Text.ToString();
                    string minweight = txtMinWeight.Text;
                    int insert = MaterialBeginDAO.Instance.Insert(idmat, minweight, mintime);              
            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                int idmat = int.Parse(glMaterialCode.EditValue.ToString());
                string mintime = txtMinDate.Text.ToString();
                string minweight = txtMinWeight.Text;
                int update = MaterialBeginDAO.Instance.Update(id, idmat, minweight,mintime);
            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = MaterialBeginDAO.Instance.Getlist();
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
            if(MessageBox.Show("Bạn có chắc chắn sẽ xóa.","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int del = MaterialBeginDAO.Instance.Delete(id);
                }
            }
        }

        private void btnUpadte_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            frmImpExMaterialBegin f = new frmImpExMaterialBegin();
            f.ShowDialog();
            LoadControl();
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
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
        }

        private void btnFormExcel_Click(object sender, EventArgs e)
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
                            gridColumn3.Visible = false;
                            gridControl1.ExportToXlsx(exportFilePath);
                            gridColumn3.Visible = true;
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
    }
}