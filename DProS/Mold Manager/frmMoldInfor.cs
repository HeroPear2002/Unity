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

namespace DProS.Mold_Manager
{
    public partial class frmMoldInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmMoldInfor()
        {
            InitializeComponent();
            LoadControl();
        }

        bool Insert;


        private void LoadControl()
        {
            Insert = false;
            LoadData();          
            LockControl(true);
            CleanText();
        }

      


        private void LockControl(bool kt)
        {

            if (kt)
            {
                txtMoldCode.Enabled = false;
                txtMoldName.Enabled = false;
                txtNumberMold.Enabled = false;
                txtModel.Enabled = false;
                txtMaker.Enabled = false;
                txtWhere.Enabled = false;
                txtNote.Enabled = false;
                txtEmCode.Enabled = false;
                txtDateInput.Enabled = false;
                dtpDateProduct.Enabled = false;
                nudShotCount.Enabled = false;
                
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
               
            }
            else
            {
                txtMoldCode.Enabled = true;
                txtMoldName.Enabled = true;
                txtNumberMold.Enabled = true;
                txtModel.Enabled = true;
                txtMaker.Enabled = true;
                txtWhere.Enabled = true;
                txtNote.Enabled = true;
                txtEmCode.Enabled = true;
                txtDateInput.Enabled = true;
                dtpDateProduct.Enabled = true;
                nudShotCount.Enabled = true;


                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnUpdate.Enabled = true;
             
            }

        }

        private void LoadData()
        {
            gridControl1.DataSource = MoldDAO.Instance.GetListMold();          
        }

       


        private void CleanText()
        {
            txtMoldCode.Clear();
            txtMoldName.Clear();
            txtNumberMold.Clear();
            txtModel.Clear();
            txtMaker.Clear();
            txtWhere.Clear();
            txtNote.Clear();
            txtEmCode.Clear();           
        }


        void Save()
        {
            string MoldCode = txtMoldCode.Text.Trim();
            string MoldName = txtMoldName.Text.Trim();
            string Model = txtModel.Text.Trim();
            string Maker = txtMaker.Text.Trim();
            DateTime DateInput = txtDateInput.Value;
            string Where = txtWhere.Text.Trim();
            string DateProduct = dtpDateProduct.Value.ToString("dd/MM/yyyyy");
            string EmCode = txtEmCode.Text;
            int ShotCount = int.Parse(nudShotCount.Value.ToString());
            string NumberMold = txtNumberMold.Text;
            string Note = txtNote.Text;
            if (Insert)
            {                                                 
                        bool CheckKhuonExist = MoldDAO.Instance.CheckMoldExist(MoldCode);
                        if (CheckKhuonExist)
                        {
                            MessageBox.Show(" Mã khuôn đã tồn tại!", "LỖI:",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            MoldDAO.Instance.InsertMold(MoldCode,MoldName,Model,Maker,DateInput,Where,DateProduct,EmCode,ShotCount,NumberMold,Note);
                            MessageBox.Show($"Đã thêm mã khuôn:  {MoldName}.", "THÀNH CÔNG:",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        Insert = false;                                    
            }
            else
            {                             
                MoldDAO.Instance.UpdateMold(MoldCode, MoldName, Model, Maker, DateInput, Where, DateProduct, EmCode, ShotCount, NumberMold, Note);
                MessageBox.Show($"Đã sửa thông tin mã khuôn:  {MoldName}.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }
      



        void XuatExCel()
        {
            using (System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xlsx":

                            gridView1.OptionsSelection.MultiSelect = false; 
                            gridControl1.ExportToXlsx(exportFilePath);
                            gridView1.OptionsSelection.MultiSelect = true;
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

        void TaiForm()
        {
            using (System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    string taikhoan = "";

                    gridControl1.DataSource = null;

                    switch (fileExtenstion)
                    {
                        case ".xlsx":

                            //  gridColumn1.Visible = false; // Bỏ cột đầu tiên đi.
                            gridView1.OptionsSelection.MultiSelect = false; // Bỏ cột lựa chọn khi xuất file Excell.
                            gridControl1.ExportToXlsx(exportFilePath);

                            //gridColumn1.Visible = true;
                            //gridColumn1.VisibleIndex = 1;
                            gridView1.OptionsSelection.MultiSelect = true;
                            // lỗi ở đoạn này
                            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                            LoadControl();


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

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            Insert = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadControl();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            LockControl(false);         
            
            int Count = 0;

            List<string> LsMoldSelected = new List<string>();

            foreach (var item in gridView1.GetSelectedRows())
            {
                string MaMT = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                LsMoldSelected.Add(MaMT);
                Count++;
            }

            if (Count > 0)
            {
                int CountDeleted = 0;
                DialogResult kq = MessageBox.Show($"Bạn muốn xóa {Count} mã khuôn được chọn?", "THÔNG BÁO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    foreach (string item in LsMoldSelected)
                    {
                        try
                        {
                            MoldDAO.Instance.DeleteMoldCode(item);
                            CountDeleted++;
                        }
                        catch 
                        {
                        }                     
                    }
                    if(CountDeleted==Count)
                    {
                        MessageBox.Show($"Đã xóa {Count} mã khuôn được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Đã xóa {CountDeleted} mã khuôn, có {Count-CountDeleted} khuôn đang tồn tại thông tin ở bảng khác.", "CẢNH BÁO:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                  
                }
                LoadControl();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã khuôn để xóa.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int dem = 0;

            List<string> LsMaKhuonDcChon = new List<string>();

            foreach (var item in gridView1.GetSelectedRows())
            {
                string MaMT = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                LsMaKhuonDcChon.Add(MaMT);
                dem++;
            }
            if (dem == 1)
            {
                LockControl(false);
                txtMoldCode.Enabled = false;
            }
            else
            {
                MessageBox.Show("Chưa chọn khuôn để sửa hoặc chọn quá 1 khuôn.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
              //  Mold(MoldCode, MoldName, Model, Maker, DateInput,[Where], DateProduct, EmCode, ShotCount, NumberMold, Note)" 

                txtMoldCode.Text = gridView1.GetFocusedRowCellValue("MoldCode").ToString();
                txtMoldName.Text = gridView1.GetFocusedRowCellValue("MoldName").ToString();
                txtNumberMold.Text = gridView1.GetFocusedRowCellValue("NumberMold").ToString();
                txtModel.Text = gridView1.GetFocusedRowCellValue("Model").ToString();
                txtMaker.Text = gridView1.GetFocusedRowCellValue("Maker").ToString();
             
                txtNote.Text = gridView1.GetFocusedRowCellValue("Note").ToString();
                txtEmCode.Text = gridView1.GetFocusedRowCellValue("EmCode").ToString();
                txtDateInput.Text = gridView1.GetFocusedRowCellValue("DateInput").ToString();
                dtpDateProduct.Text = gridView1.GetFocusedRowCellValue("DateProduct").ToString();
                nudShotCount.Value=int.Parse( gridView1.GetFocusedRowCellValue("ShotCount").ToString());

                txtWhere.Text = gridView1.GetFocusedRowCellValue("Where").ToString();
            }
            catch
            {


            }

        }

        private void btnFormMau_Click(object sender, EventArgs e)
        {          
              TaiForm();
              LoadControl();
        }

        private void btnNhaptuExcell_Click(object sender, EventArgs e)
        {
            LockControl(false);
            frmExCellMoldInfor f = new frmExCellMoldInfor();
            f.ShowDialog();
            LoadControl();
        }

        private void btnXuatExCell_Click(object sender, EventArgs e)
        {         
            XuatExCel();           
            LoadControl();  
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           
        }
    }
}