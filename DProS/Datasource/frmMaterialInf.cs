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
using DProS.Datasource.Report;
using DevExpress.XtraReports.UI;

namespace DProS.Datasource
{
    public partial class frmMaterialInf : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialInf()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            LoadCb();
            LockControl(true);
            Clentext();
        }

        private void LoadCb()
        {
            cbSuplier.DataSource = SupplierDAO.Instance.Getlist();
            cbSuplier.DisplayMember = "SupName";
            cbSuplier.ValueMember = "Id";
        }

        private void Clentext()
        {
            txtColorCode.Text = string.Empty;
            txtMaterialName.Text = string.Empty;
            txtMaterialCode.Text = string.Empty;
            txtNature.Text = string.Empty;
            txtRoHS.Text = string.Empty;
            nudWarnQ.Text = string.Empty;
            nudWarnY.Text = string.Empty;
            cbSuplier.Text = string.Empty;
        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtColorCode.Enabled = false;
                txtMaterialName.Enabled = false;
                txtMaterialCode.Enabled = false;
                txtNature.Enabled = false;
                txtRoHS.Enabled = false;
                nudWarnQ.Enabled = false;
                nudWarnY.Enabled = false;
                cbSuplier.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnExcelForm.Enabled = true;
                btnExExcel.Enabled = true;
                btnImExcel.Enabled = true;
                btnNoNeed.Enabled = true;
                btnPrinQrRe.Enabled = true;
                btnPrintKanban.Enabled = true;
                btnPrintQr.Enabled = true;
                btnPrintQrMix.Enabled = true;
                btnBrrower.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                txtColorCode.Enabled = true;
                txtMaterialName.Enabled = true;
                txtMaterialCode.Enabled = true;
                txtNature.Enabled = true;
                txtRoHS.Enabled = false;
                nudWarnQ.Enabled = true;
                nudWarnY.Enabled = true;
                cbSuplier.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnExcelForm.Enabled = false;
                btnExExcel.Enabled = false;
                btnImExcel.Enabled = false;
                btnNoNeed.Enabled = false;
                btnPrinQrRe.Enabled = false;
                btnPrintKanban.Enabled = false;
                btnPrintQr.Enabled = false;
                btnPrintQrMix.Enabled =false;
                btnBrrower.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        void Save()
        {
            if (IsInsert)
            {
                string colorcode = txtColorCode.Text;
                string matname = txtMaterialName.Text;
                string matcode = txtMaterialCode.Text;
                string nature = txtNature.Text;
                string rohsfile = txtRoHS.Text;
                int warnyllow = int.Parse(nudWarnQ.Value.ToString());
                int warncount = int.Parse(nudWarnY.Value.ToString());
                int idsup = int.Parse(cbSuplier.SelectedValue.ToString());
                string note = "";
                int Insert = MaterialDAO.Instance.Insert(matcode, matname, warnyllow, warncount, idsup, nature, rohsfile, colorcode, note);

            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string colorcode = txtColorCode.Text;
                string matname = txtMaterialName.Text;
                string matcode = txtMaterialCode.Text;
                string nature = txtNature.Text;
                string rohsfile = txtRoHS.Text;
                int warnyllow = int.Parse(nudWarnQ.Value.ToString());
                int warncount = int.Parse(nudWarnY.Value.ToString());
                int idsup = int.Parse(cbSuplier.SelectedValue.ToString());
                string note = "";
                int Update = MaterialDAO.Instance.Update(id, matcode, matname, warnyllow, warncount, idsup, nature, rohsfile, colorcode, note);                
            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = MaterialDAO.Instance.Getlist();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn xóa nguyên liệu này.","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int del = MaterialDAO.Instance.Delete(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }
        #region Chưa xử lý các nut in
        private void btnPrintQr_Click(object sender, EventArgs e)
        {
            frmCreateBarCodeMat f = new frmCreateBarCodeMat();
            f.ShowDialog();
        }

        private void btnPrinQrRe_Click(object sender, EventArgs e)
        {
            List<BarcodeMaterialDTO> lsvcode = new List<BarcodeMaterialDTO>();
            string MaterialCode= gridView1.GetFocusedRowCellValue("MatCode").ToString();
            string MaterialName= gridView1.GetFocusedRowCellValue("MatName").ToString();
            string DateInput=DateTime.Now.ToString("yyyyMMddHHss")+DateTime.Now.Millisecond.ToString();
            string Employess = "";
            string Nature="";
            for (int i = 1; i < 81; i++)
            {
                float Count=i;
                string Name = MaterialCode + "&" + DateInput + "&" + Count + "&" + "rec_";
                lsvcode.Add(new BarcodeMaterialDTO(MaterialCode, MaterialName, Count, Name, DateInput, "", ""));
            }
            rpCreateMatRecCode f = new rpCreateMatRecCode();
            f.DataSource = lsvcode;
            f.ShowPreview();
            LoadControl();
        }

        private void btnPrintQrMix_Click(object sender, EventArgs e)
        {
            List<BarcodeMaterialDTO> lsvcode = new List<BarcodeMaterialDTO>();
            string MaterialCode = gridView1.GetFocusedRowCellValue("MatCode").ToString();
            string MaterialName = gridView1.GetFocusedRowCellValue("MatName").ToString();
            string DateInput = DateTime.Now.ToString("yyyyMMddHHss") + DateTime.Now.Millisecond.ToString();
            string Employess = "";
            string Nature = "";
            for (int i = 1; i < 81; i++)
            {
                float Count = i;
                string Name = MaterialCode + "&" + DateInput + "&" + Count + "&" + "mix_";
                lsvcode.Add(new BarcodeMaterialDTO(MaterialCode, MaterialName, Count, Name, DateInput, "", ""));
            }
            rpCreateMatMix f = new rpCreateMatMix();
            f.DataSource = lsvcode;
            f.ShowPreview();
            LoadControl();
        }

        private void btnNoNeed_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintKanban_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void btnExcelForm_Click(object sender, EventArgs e)
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

        private void btnExExcel_Click(object sender, EventArgs e)
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

        private void btnImExcel_Click(object sender, EventArgs e)
        {
            frmImpExcelMaterial f = new frmImpExcelMaterial();
            f.ShowDialog();
            LoadControl();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtRoHS.Text = gridView1.GetFocusedRowCellValue("RohsFile").ToString();
                txtNature.Text= gridView1.GetFocusedRowCellValue("Nature").ToString();
                txtMaterialName.Text= gridView1.GetFocusedRowCellValue("MatName").ToString();
                txtMaterialCode.Text= gridView1.GetFocusedRowCellValue("MatCode").ToString();
                txtColorCode.Text= gridView1.GetFocusedRowCellValue("ColorCode").ToString();
                nudWarnY.Value= int .Parse(gridView1.GetFocusedRowCellValue("WarnYllow").ToString());
                nudWarnQ.Value= int.Parse(gridView1.GetFocusedRowCellValue("WarnCount").ToString());                
            }
            catch (Exception)
            {               
            }
        }

        private void btnBrrower_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRoHS.Text = ofd.FileName;
                }
            }
        }
    }
}