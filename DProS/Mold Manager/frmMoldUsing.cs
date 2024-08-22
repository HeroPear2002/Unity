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
using DevExpress.XtraGrid.Views.Grid;

namespace DProS.Mold_Manager
{
    public partial class frmMoldUsing : DevExpress.XtraEditors.XtraForm
    {
        public frmMoldUsing()
        {
            InitializeComponent();
            LoadControl();
        }

        public EventHandler LamMoi;
        public bool Insert;

        public class MoldUsing
        {
            static public int IdMold;
            static public string moldCode;
            static public int shotTC;
            static public int shotTT;
          
            static public int totalShot;
        }



        #region Control
        void LoadControl()
        {
            //  LoadCate();
            // AsyncLoad();
            
            LockControl(true);
            LoadData();
            CleanText();
            LoadMoldCode(); 
        }

        #region    Lập trình bất đồng bộ

        //async void LoadCate() 
        //{
        //    await LoadCategory(); 
        //}



        //public static async Task LoadCategory()
        //{
        //    await Task.Run(() =>
        //    {
        //        List<MoldDTO> listK = MoldDAO.Instance.GetListMold();
        //        foreach (MoldDTO item in listK)
        //        {
        //            string MoldeCode = item.MoldCode;
        //            int kTest = MoldDAO.Instance.MaxId(MoldeCode);
        //            if (kTest > 0)
        //            {
        //                string Category = MoldDAO.Instance.CategoryById(kTest);
        //                MoldDAO.Instance.UpdateCategoryMold(MoldeCode, Category);
        //            }
        //        }
        //    });
        //}



        //async void AsyncLoad()
        //{
        //    await LoadMoldInfor();
        //    await SendMail();
        //}

        //public static async Task LoadMoldInfor()
        //{
        //    await Task.Run(() =>
        //    {
        //        DateTime today = DateTime.Now;
        //        DateTime dateCheck = today;
        //        List<MoldInforDTO> listM = MoldDAO.Instance.GetListMoldInfor();
        //        foreach (MoldInforDTO item in listM)
        //        {
        //            int ShotTT = item.ShotTT;
        //            int ShotTC = item.ShotTC;
        //            string MoldeCode = item.MoldCode;
        //            int test = MoldDAO.Instance.TestConfirm(MoldeCode);
        //            float total = (float)ShotTT / (float)ShotTC;
        //            int a = 0;
        //            int b = MoldDAO.Instance.ConfirmMold(MoldeCode);
        //            if (test == 1)
        //            {
        //                MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, 4);
        //            }
        //            else
        //            {
        //                if (total > 0.9)
        //                {
        //                    a = 3;
        //                    MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
        //                }
        //                else if (total <= 0.9 && total > 0.8)
        //                {
        //                    a = 2;
        //                    MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
        //                }
        //                else
        //                {
        //                    a = 0;
        //                    MoldDAO.Instance.UpdateConfirmMoldInfor(MoldeCode, a);
        //                    MoldDAO.Instance.UpdateNoteMoldInfor(item.MoldCode, "");
        //                    if ((today - item.DateCheck).TotalDays >= 140)
        //                    {
        //                        MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 1);
        //                    }
        //                    else if ((today - item.DateCheck).TotalDays <= 150 && (today - item.DateCheck).TotalDays > 140)
        //                    {
        //                        MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 2);
        //                    }
        //                    else if ((today - item.DateCheck).TotalDays >= 160)
        //                    {
        //                        MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 3);
        //                    }
        //                    else
        //                    {
        //                        if (item.Warn != 0)
        //                            MoldDAO.Instance.UpdateWainMoldInfor(MoldeCode, 0);
        //                    }
        //                }
        //            }
        //        }
        //    });
        //}


        //public static async Task SendMail()
        //{
        //    await Task.Run(() =>
        //    {
        //        string message1 = "";
        //        string message2 = "";
        //        List<MoldInforDTO> listM2 = new List<MoldInforDTO>();
        //        List<MoldInforDTO> listM = MoldDAO.Instance.GetListMoldInfor();
        //        List<MoldInforDTO> listM1 = listM.Where(x => x.Confirm == 3 || x.Confirm == 2).ToList();
        //        List<MoldInforDTO> listMM = listM.Where(x => x.Warn >= 0).ToList();
        //        int dk = 0;

        //        if (listM1.Count > 0)
        //        {
        //            dk = 1;
        //            foreach (MoldInforDTO item in listM1)
        //            {
        //                if (item.PlanMold.Length <= 0)
        //                {
        //                    message1 += item.MoldCode + " ;";
        //                }
        //            }
        //        }
        //        if (listMM.Count > 0)
        //        {
        //            dk = 2;
        //            foreach (MoldInforDTO item in listM)
        //            {
        //                message2 += item.MoldCode + " ;";
        //            }
        //        }
        //        List<AccountDTO> Email = AccountDAO.Instance.GetAccountEmail(5);
        //        List<AccountDTO> EmailAll = AccountDAO.Instance.GetAccount().Where(x => x.EMail.Length > 5).ToList();
        //        if (dk == 1 && Email.Count > 0)
        //        {
        //            string to = "";
        //            foreach (AccountDTO item in Email)
        //            {
        //                to += item.EMail + ",";
        //            }
        //            string subject = "Cảnh báo khuôn chưa bảo dưỡng";
        //            SendEMail.SendGMail(to, subject, message1);
        //        }
        //        else if (dk == 2 && EmailAll.Count > 0)
        //        {
        //            string to = "";
        //            foreach (AccountDTO item in Email)
        //            {
        //                to += item.EMail + ",";
        //            }
        //            string subject = "Cảnh báo khuôn cần cấp FA";
        //            SendEMail.SendGMail(to, subject, message2);
        //        }
        //    });
        //}

        #endregion


        void LoadMoldCode()
        {
            sglMoldCode.Properties.DataSource = MoldDAO.Instance.GetListMold();
            sglMoldCode.Properties.DisplayMember = "MoldCode";
            sglMoldCode.Properties.ValueMember = "Id";
        }

        void LoadData()
        {
            GCData.DataSource = MoldDAO.Instance.GetTableMoldUsing();
        }
        void LockControl(bool kt)
        {
            if(kt)
            {
                sglMoldCode.Enabled = false;
                nudShotTC.Enabled = false;
                nudShotTT.Enabled = false;
                nudTotalShot.Enabled = false;
                cbCategory.Enabled = false;
                txtNote.Enabled = false;
                txtStatusMold.Enabled = false;
                txtPlan.Enabled = false;
                nudCav.Enabled = false;
                nudCavNG.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                sglMoldCode.Enabled = true;
                nudShotTC.Enabled = true;
                nudShotTT.Enabled = true;
                nudTotalShot.Enabled = true;
                cbCategory.Enabled = true;
                txtNote.Enabled = true;
                txtStatusMold.Enabled = true;
                txtPlan.Enabled = true;
                nudCav.Enabled = true;
                nudCavNG.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }          
        }
       

        void CleanText()
        {
            sglMoldCode.Text = String.Empty;
            nudShotTC.Text = String.Empty;
            nudShotTT.Text = String.Empty;
            nudTotalShot.Text = String.Empty;
            cbCategory.Text = String.Empty;
            txtNote.Text = String.Empty;
            txtStatusMold.Text = String.Empty;
            txtPlan.Text = String.Empty;
            nudCav.Text = String.Empty;
            nudCavNG.Text = String.Empty;
        }

        void AddText()
        {
            try
            {
                sglMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                nudShotTC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ShotTC"]).ToString();
                nudShotTT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ShotTT"]).ToString();
                nudTotalShot.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TotalShot"]).ToString();
                cbCategory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Category"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtStatusMold.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["StatusMold"]).ToString();
                txtPlan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PlanMold"]).ToString();
                nudCav.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Cav"]).ToString();
                nudCavNG.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CavNG"]).ToString();
            }
            catch
            {

            }
        }
        #endregion

        #region Event

      

      

      

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

      

      
        private void btnExcel_Click(object sender, EventArgs e)
        {
            #region Xuất Excel
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            GCData.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            GCData.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            GCData.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            GCData.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            GCData.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            GCData.ExportToMht(exportFilePath);
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
            #endregion
        }
      

        #endregion


     
        void Save()
        {
            int IdMold = int.Parse(sglMoldCode.EditValue.ToString());
            string StatusMold = txtStatusMold.Text;
            int Cav = int.Parse(nudCav.Value.ToString());
            int CavNG = int.Parse(nudCavNG.Value.ToString());
            int ShotTC = int.Parse(nudShotTC.Value.ToString());
            int ShotTT = int.Parse(nudShotTT.Value.ToString());  // Sau khi bảo dưỡng thì thực tế phải về =0
            int TotalShot = int.Parse(nudTotalShot.Value.ToString());
            int Confirm = 0;
            string Catagory = cbCategory.Text;
            string DateCheck = DateTime.Now.ToString("dd/MM/yyyy"); // Ban đầu nhập liệu chưa có thì sẽ là ngày nhập thông tin khuôn.
            string PlanMold = txtPlan.Text.Trim();
            // Cảnh báo thì sẽ lấy theo tỷ lệ ( TotalShot/ShotPlan)
            // Khuôn chạy trên 90%:
            // Khuôn chạy 80%-90%:
            // Khuôn OK: 0%-80%:
            int Warn = (int)(((float)ShotTT / ShotTC) * 100);
            string Note = txtNote.Text.Trim();

            if (Insert)
            {                         
                bool Check = MoldDAO.Instance.CheckMoldUsingExist(IdMold);
                if (Check)
                { 
                    MessageBox.Show(" Mã khuôn đã tồn tại trong danh sách.!", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MoldDAO.Instance.InsertMoldUsing(IdMold,StatusMold,Cav,CavNG,ShotTC,ShotTT,TotalShot,Confirm,Catagory,DateCheck,PlanMold,Warn,Note);
                    MoldDTO moldDTO = MoldDAO.Instance.GetMoldDTO(IdMold);
                    MessageBox.Show($"Đã thêm mã khuôn: {moldDTO.MoldCode}.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Insert = false;
            }
            else
            {
                MoldDAO.Instance.UpdateMoldUsing(IdMold, StatusMold, Cav, CavNG, ShotTC, ShotTT, TotalShot, Confirm, Catagory, DateCheck, PlanMold, Warn, Note);
                MoldDTO moldDTO = MoldDAO.Instance.GetMoldDTO(IdMold);
                MessageBox.Show($"Đã sửa thông tin mã khuôn: {moldDTO.MoldCode}.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     

       

      
        //private void btnXoa_Click(object sender, EventArgs e)
        //{

        //    int dem = 0;

        //    List<int> LsIDMold = new List<int>();

        //    foreach (var item in gridView1.GetSelectedRows())
        //    {
        //        int IDMold = int.Parse(gridView1.GetRowCellValue(item, "IdMold").ToString());
        //        LsIDMold.Add(IDMold);
        //        dem++;
        //    }


        //    if (dem > 0)
        //    {
        //        DialogResult kq = MessageBox.Show($"Bạn muốn xóa {dem} mã khuôn được chọn?", "THÔNG BÁO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (kq == DialogResult.Yes)
        //        {
        //            foreach (int item in LsIDMold)
        //            {
        //                MoldUsingDAO.Instance.Delete(item);
        //            }
        //            MessageBox.Show($"Đã xóa {dem} mã khuôn được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        LoadControl();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Bạn chưa chọn mã khuôn để xóa.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    LoadControl();
        //}


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
                            GCData.ExportToXlsx(exportFilePath);
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

        private void btnXuatExcell_Click(object sender, EventArgs e)
        {
            XuatExCel();
            LoadControl();
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

                    GCData.DataSource = null;

                    switch (fileExtenstion)
                    {
                        case ".xlsx":

                            //  gridColumn1.Visible = false; // Bỏ cột đầu tiên đi.
                            gridView1.OptionsSelection.MultiSelect = false; // Bỏ cột lựa chọn khi xuất file Excell.
                            GCData.ExportToXlsx(exportFilePath);                          
                            gridView1.OptionsSelection.MultiSelect = true;
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

        private void btnFormmau_Click(object sender, EventArgs e)
        {
            TaiForm();
        }

        private void btnNhapExcell_Click(object sender, EventArgs e)
        {
            LockControl(false);
            frmExCellMoldInfor f = new frmExCellMoldInfor();
            f.ShowDialog();
            LoadControl();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                // MoldUsing(IdMold, StatusMold, Cav, CavNG, ShotPlan, ShotReality, TotalShot, ConfirmMold, Category, DateCheck, PlanMold, Warn, Note)               
                sglMoldCode.Text = gridView1.GetFocusedRowCellValue("MoldCode").ToString();
                nudShotTC.Value =int.Parse(gridView1.GetFocusedRowCellValue("ShotPlan").ToString());
                nudShotTT.Value =int.Parse(gridView1.GetFocusedRowCellValue("ShotReality").ToString());
                nudTotalShot.Value =int.Parse(gridView1.GetFocusedRowCellValue("TotalShot").ToString());
                cbCategory.Text = gridView1.GetFocusedRowCellValue("Category").ToString();
                txtNote.Text = gridView1.GetFocusedRowCellValue("Note").ToString();
                txtStatusMold.Text = gridView1.GetFocusedRowCellValue("StatusMold").ToString();
                nudCav.Value =int.Parse(gridView1.GetFocusedRowCellValue("Cav").ToString());
                nudCavNG.Value =int.Parse( gridView1.GetFocusedRowCellValue("CavNG").ToString());
                txtPlan.Text =gridView1.GetFocusedRowCellValue("PlanMold").ToString();             
            }
            catch
            {
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
            try
            {
                GridView view = sender as GridView;
                int Warn = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Warn"]).ToString());

                if (Warn >= 90)
                {
                    e.Appearance.BackColor = chk90.BackColor;
                }

                if (Warn >= 80 && Warn < 90)
                {
                    e.Appearance.BackColor = chk8090.BackColor;
                }

                if (Warn >= 0 && Warn < 80)
                {
                    e.Appearance.BackColor = chkOK.BackColor;
                }
            }
            catch 
            {

               
            }
           

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //string user = Kun_Static.accountDTO.UserName;
            //int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            //if (check < 1)
            //{
            //    MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            LockControl(false);
            Insert = true;
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            //string user = Kun_Static.accountDTO.UserName;
            //int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            //if (check < 1)
            //{
            //    MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            int Count = 0;

            List<string> LsMoldSelected = new List<string>();

            foreach (var item in gridView1.GetSelectedRows())
            {
                string MoldCode = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                LsMoldSelected.Add(MoldCode);
                Count++;
            }
            if (Count == 1)
            {
                LockControl(false);
                sglMoldCode.Enabled = false;
            }
            else
            {
                MessageBox.Show("Chưa chọn khuôn để sửa hoặc chọn quá 1 khuôn.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadControl();
            }

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            //string user = Kun_Static.accountDTO.UserName;
            //int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            //if (check < 2)
            //{
            //    MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            LockControl(false);
            int Count = 0;

            List<int> LsMoldSelected = new List<int>();

            foreach (var item in gridView1.GetSelectedRows())
            {
                int IdMold =int.Parse(gridView1.GetRowCellValue(item, "IdMold").ToString());
                LsMoldSelected.Add(IdMold);
                Count++;
            }

            if (Count > 0)
            {
                DialogResult kq = MessageBox.Show($"Bạn muốn xóa {Count} mã khuôn được chọn?", "THÔNG BÁO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    foreach (int item in LsMoldSelected)
                    {
                        MoldDAO.Instance.DeleteMoldUsing(item);
                    }
                    MessageBox.Show($"Đã xóa {Count} mã khuôn được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadControl();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã khuôn để xóa.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadControl();

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void GCData_DoubleClick(object sender, EventArgs e)
        {
            //string user = Kun_Static.accountDTO.UserName;
            //int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            //if (check < 1)
            //{
            //    MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            string IdMold = "";
            try
            {
                // MoldUsing(IdMold, StatusMold, Cav, CavNG, ShotPlan, ShotReality, TotalShot, ConfirmMold, Category, DateCheck, PlanMold, Warn, Note)               
                IdMold = gridView1.GetFocusedRowCellValue("IdMold").ToString();             
            }
            catch
            {

            }

            MoldUsing.IdMold = int.Parse(IdMold);
            MoldUsing.moldCode = sglMoldCode.Text;
            MoldUsing.shotTT = (int)nudShotTT.Value;
            MoldUsing.shotTC = int.Parse(nudShotTC.Value.ToString());
            MoldUsing.totalShot = (int)nudTotalShot.Value;
            frmMoldDetailCategory f = new frmMoldDetailCategory();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
    }
}