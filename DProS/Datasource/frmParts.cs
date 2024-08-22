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
using System.Data;
using System.IO;

namespace DProS.Datasource
{
    public partial class frmParts : DevExpress.XtraEditors.XtraForm
    {
        public frmParts()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            LockControl(true);
            Loadgl();
            Clentext();
        }

        private void Loadgl()
        {
            glMaterialCode.Properties.DataSource = MaterialDAO.Instance.Getlist();
            glMaterialCode.Properties.DisplayMember = "MatName";
            glMaterialCode.Properties.ValueMember = "MatCode";

            glSpCode.Properties.DataSource = CustomerDAO.Instance.Getlist();
            glSpCode.Properties.DisplayMember = "CusCode";
            glSpCode.Properties.ValueMember = "Id";
        }

        private void Clentext()
        {
            txtCycleTime.Text = string.Empty;
            txtNamePartsVi.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtPartsCode.Text = string.Empty;

            txtPartsName.Text = string.Empty;
            txtPartsWeight.Text = string.Empty;
            txtRunnerWeight.Text = string.Empty;

            nudBoxPallet.Text = string.Empty;
            nudNumCavi.Text = string.Empty;
            nudPartsBox.Text = string.Empty;
            nudPalletHeight.Text = string.Empty;

            glMaterialCode.Text = string.Empty;
            glSpCode.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtCycleTime.Enabled = false;
                txtNamePartsVi.Enabled = false;
                txtNote.Enabled = false;
                txtPartsCode.Enabled = false;

                txtPartsName.Enabled = false;
                txtPartsWeight.Enabled = false;
                txtRunnerWeight.Enabled = false;

                nudBoxPallet.Enabled = false;
                nudNumCavi.Enabled = false;
                nudPartsBox.Enabled = false;
                nudPalletHeight.Enabled = false;

                glMaterialCode.Enabled = false;
                glSpCode.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;

                btnImpExcel.Enabled = true;
                btnExpExcel.Enabled = true;
                btnFormExcel.Enabled = true;
                
            }
            else
            {
                txtCycleTime.Enabled = true;
                txtNamePartsVi.Enabled = true;
                txtNote.Enabled = true;
                txtPartsCode.Enabled = true;

                txtPartsName.Enabled = true;
                txtPartsWeight.Enabled = true;
                txtRunnerWeight.Enabled = true;

                nudBoxPallet.Enabled = true;
                nudNumCavi.Enabled = true;
                nudPartsBox.Enabled = true;
                nudPalletHeight.Enabled = true;
              
                glMaterialCode.Enabled = true;
                glSpCode.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;

                btnImpExcel.Enabled = false;
                btnExpExcel.Enabled = false;
                btnFormExcel.Enabled = false;
            }
        }
        void Save()
        {
            if (IsInsert)
            {
                string partCode = txtPartsCode.Text;
                PartDTO part = PartDAO.Instance.GetItem(partCode);
                if(part != null)
                {
                    MessageBox.Show("Trùng mã nhân viên", "THÔNG Báo", MessageBoxButtons.OK);
                    return;
                }
              float  cyleTime=float.Parse( txtCycleTime.Text) ;
              string nameVN=  txtNamePartsVi.Text ;
              string note=  txtNote.Text ;
              
              string partName=  txtPartsName.Text ;
              float weightPart=float.Parse(txtPartsWeight.Text);
              float  weightRunner=float.Parse(txtRunnerWeight.Text) ;

              int countBox=int.Parse(nudBoxPallet.Text) ;
              int cav=int.Parse(nudNumCavi.Text);
              int countPart=int.Parse(nudPartsBox.Text);
              int height = int.Parse( nudPalletHeight.Text) ;

               string matCode= glMaterialCode.EditValue.ToString() ;
               int idCus=int.Parse( glSpCode.EditValue.ToString());
               int insert = PartDAO.Instance.Insert(partCode, partName, matCode, idCus, countPart, countBox, weightPart, weightRunner, cyleTime, cav, nameVN, height, note);

            }
            else
            {
                try
                {
                    int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                    float cyleTime = float.Parse(txtCycleTime.Text);
                    string nameVN = txtNamePartsVi.Text;
                    string note = txtNote.Text;
                    string partCode = txtPartsCode.Text;
                    string partName = txtPartsName.Text;
                    float weightPart = float.Parse(txtPartsWeight.Text);
                    float weightRunner = float.Parse(txtRunnerWeight.Text);

                    int countBox = int.Parse(nudBoxPallet.Text);
                    int cav = int.Parse(nudNumCavi.Text);
                    int countPart = int.Parse(nudPartsBox.Text);
                    int height = int.Parse(nudPalletHeight.Text);

                    string matCode = glMaterialCode.EditValue.ToString();
                    int idCus = int.Parse(glSpCode.EditValue.ToString());
                    int Update = PartDAO.Instance.Update(id, partCode, partName, matCode, idCus, countPart, countBox, weightPart, weightRunner, cyleTime, cav, nameVN, height, note);
                }
                catch (Exception)
                {

                    
                }
               
            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = PartDAO.Instance.Getlist();
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
            txtPartsCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("Bạn chắc chắn xóa linh kiện này","THÔNG BÁO",MessageBoxButtons.YesNo)==DialogResult.Yes)
            foreach (var item in gridView1.GetSelectedRows())
            {
                try
                {
                        int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        int Del = PartDAO.Instance.Delete(id);

                }
                catch (Exception)
                {

                   
                }
            }
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
                            gridColumn5.Visible = false;
                            gridControl1.ExportToXlsx(exportFilePath);
                            gridColumn5.Visible = true;
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

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            frmImpExcelPart f = new frmImpExcelPart();
            f.ShowDialog();
            LoadControl();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void txtPartsWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }

        private void txtRunnerWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }

        private void txtCycleTime_KeyPress(object sender, KeyPressEventArgs e)
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
                txtCycleTime.Text = gridView1.GetFocusedRowCellValue("CycleTime").ToString();
                txtNamePartsVi.Text = gridView1.GetFocusedRowCellValue("NameVN").ToString();
                txtNote.Text = gridView1.GetFocusedRowCellValue("Note").ToString();
                txtPartsCode.Text = gridView1.GetFocusedRowCellValue("PartCode").ToString();

                txtPartsName.Text = gridView1.GetFocusedRowCellValue("Partname").ToString();
                txtPartsWeight.Text = gridView1.GetFocusedRowCellValue("WeightPart").ToString();
                txtRunnerWeight.Text = gridView1.GetFocusedRowCellValue("WeightRunner").ToString();

                nudBoxPallet.Text = gridView1.GetFocusedRowCellValue("CountBox").ToString();
                nudNumCavi.Text = gridView1.GetFocusedRowCellValue("Cav").ToString();
                nudPartsBox.Text = gridView1.GetFocusedRowCellValue("CountPart").ToString();
                nudPalletHeight.Text = gridView1.GetFocusedRowCellValue("Height").ToString();

                glMaterialCode.Text = gridView1.GetFocusedRowCellValue("MatCode").ToString();
                glSpCode.Text = gridView1.GetFocusedRowCellValue("CusCode").ToString();
            }
            catch (Exception)
            {

                
            }
        }
    }
}