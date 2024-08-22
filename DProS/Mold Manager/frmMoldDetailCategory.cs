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

namespace DProS.Mold_Manager
{
    public partial class frmMoldDetailCategory : DevExpress.XtraEditors.XtraForm
    {
        public frmMoldDetailCategory()
        {
            InitializeComponent();
            LoadControl();
        }

        public EventHandler LamMoi;

        void LoadControl()
        {
            LoadData();
            LoadMachine();
            LoadMoldCategory();
            LoadErrorMold();
            LoadTribeMold();
        }

        #region LoadCombobox
        void LoadData()
        {
            MoldDTO a = MoldDAO.Instance.GetMoldDTO(frmMoldUsing.MoldUsing.IdMold);
            txtMoldCode.Text = a.MoldCode;
            txtMoldName.Text = a.MoldName;
            txtMoldCode.Enabled = false;
            txtMoldName.Enabled = false;
        }
        void LoadMachine()
        {
            List<MachineDTO> listM = MachineDAO.Instance.GetList(1);
            cbMachine.DataSource = listM;
            cbMachine.DisplayMember = "MachineCode";
            cbMachine.ValueMember = "Id";
        }
        void LoadErrorMold()
        {
            cbErrorM.DataSource = MoldDAO.Instance.GetListMoldError();
            cbErrorM.DisplayMember = "Name";
            cbErrorM.ValueMember = "Id";
        }
        void LoadMoldCategory()
        {
            cbCategory.DataSource = MoldDAO.Instance.GetListMoldCategory();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }
        void LoadTribeMold()
        {
            cbTribe.DataSource = MoldDAO.Instance.GetListMoldTribe();
            cbTribe.DisplayMember = "Name";
            cbTribe.ValueMember = "Id";
        }
        #endregion

        private void frmMoldDetailCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int IdMoldUsing = frmMoldUsing.MoldUsing.IdMold;

            DateTime today = DateTime.Now;
            string check = (today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString());
            int IdMachine =int.Parse(cbMachine.SelectedValue.ToString());
            DateTime DateError = dtpkDateError.Value;
            int ShotTT = frmMoldUsing.MoldUsing.shotTT;
            int TotalShot = frmMoldUsing.MoldUsing.totalShot;
            string Category = cbCategory.Text;
            int id = (int)cbCategory.SelectedValue;
            // Lấy phần ghi chú của hạng mục bảo dưỡng để xét có thay đổi số Shot hay không?
            string note = MoldDAO.Instance.GetItemMoldErrorDTO(id).Note;
            string Error = cbErrorM.Text;
            string Tribe = cbTribe.Text;
            string Detail = txtDetail.Text;
            DateTime DateStart = dtpDateStart.Value;
            DateTime DateEnd = dtpDateEnd.Value;
            string Detail1 = txtDetail1.Text;
            string Detail2 = txtDetail2.Text;
            string Detail3 = txtDetail3.Text;
            string Detail4 = txtDetail4.Text;
            string Detail5 = txtDetail5.Text;
            string Detail6 = txtDetail6.Text;
            string MoldCode = txtMoldCode.Text;
            int warn = MoldDAO.Instance.GetMoldUsingDTO(frmMoldUsing.MoldUsing.IdMold).Warn;
            if (txtTime.Text.Length == 0)
            {
                MessageBox.Show("tổng số giờ bảo dưỡng không được phép trống !".ToUpper(),"LỖI:",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                int TotalTime = int.Parse(txtTime.Text);
                if (MessageBox.Show("Xác nhận khuôn đã được Bảo Dưỡng ".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Thêm vào bảng lịch sử sửa chữa.
                    MoldDAO.Instance.InsertMoldHistory(IdMachine, IdMoldUsing, DateError, ShotTT, TotalShot, Category, Error, Tribe, Detail, DateStart, DateEnd,  TotalTime, Detail1, Detail2, Detail3, Detail4, Detail5, Detail6);
                   
                   
                    if (note != "1") // Xác nhận tình trạng thay đổi số Shot
                    {
                        // Chưa có phần Update tổng Shot. Tổng Shot=Tổng Shot hiện tại + Shot thực tế hiện tại.
                        int ToTalShot = frmMoldUsing.MoldUsing.shotTT + frmMoldUsing.MoldUsing.totalShot;
                        MoldDAO.Instance.UpdateTotalShotMoldUsing(IdMoldUsing, ToTalShot);

                        // Reset số Shot thực tế về 0.
                        MoldDAO.Instance.UpdateShotRealMoldUsing(IdMoldUsing, 0);

                        // Update lại cảnh bảo màu khi thay đổi số Shot thực tế.
                        int ShotReal = 0;
                        int ShotTC = frmMoldUsing.MoldUsing.shotTC;
                        int Warn = (int)(((float)ShotReal / ShotTC) * 100);
                        MoldDAO.Instance.UpdateWarnMoldUsing(IdMoldUsing, Warn);

                        // Cập nhật lại kế hoạch Khuôn ="";
                        MoldDAO.Instance.UpdatePlanMoldUsing(IdMoldUsing, "");

                        // Cập nhật lại  xác nhận khuôn nếu có thì về =0;
                        MoldDAO.Instance.UpdateConfirmMoldUsing(IdMoldUsing, 0);

                        //Xóa trong bảng xác nhận khuôn. ( Chưa có bảng xác nhận khuôn )
                        //   MoldDAO.Instance.DeleteMoldConfirm(MoldCode);

                        // Cập nhật lại ghi chú bảng Quản lý khuôn
                        MoldDAO.Instance.UpdateNoteMoldUsing(IdMoldUsing, "");
                        MessageBox.Show("Đã thêm lý lịch sửa chữa !","THÀNH CÔNG:",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã thêm lý lịch sửa chữa !", "THÀNH CÔNG:",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
        }
    }
}