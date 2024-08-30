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
    public partial class frmMoldConFirm : DevExpress.XtraEditors.XtraForm
    {
        public frmMoldConFirm(string MoldCode)
        {
            InitializeComponent();
            LoadData(MoldCode);
        }

        

        private void LoadData(string MoldCode)
        {
            txtMoldCode.Text = MoldCode;
            // Load Checkbox
          
            int IdMold = MoldDAO.Instance.GetMoldDTO1(MoldCode).Id;
            
            bool MoldConfirming = MoldDAO.Instance.CheckConfirming(IdMold);
            
            if (MoldConfirming) // Nếu có tồn tại Confirming thì lấy ConFirming đó
            {             
                MoldConFirmDTO a = MoldDAO.Instance.GetConfirmingDTO(IdMold);
                if(a.IdEmPC>=0)
                {
                    chkPC.Checked = true;
                }
                if (a.IdEmQC >= 0)
                {
                    chkQC.Checked = true;
                }
                if (a.IdEmTool >= 0)
                {
                    chkTooling.Checked = true;
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Phòng PC đã xác nhận rồi thì không xác nhận được nữa.
            // Bài toán: thay đổi mã phòng ban sẽ xử lý bằng cách lấy IdRoom thay cho RoomCode trong bảng Employess

            string MoldCode = txtMoldCode.Text;
            int IdMold = MoldDAO.Instance.GetMoldDTO1(MoldCode).Id;

            // Insert luôn cái MoldConfirming vào.


            bool MoldConfirming = MoldDAO.Instance.CheckConfirming(IdMold);

            int IdConFirming = 0;

            if(!MoldConfirming) // Nếu chưa tồn tại Confirming
            {
                MoldDAO.Instance.InsertMoldConfirm(IdMold, 0, DateTime.Now, 0, DateTime.Now, 0, DateTime.Now);
                MoldConFirmDTO a = MoldDAO.Instance.GetConfirmingDTO(IdMold);
                IdConFirming = a.Id;
            }
            else
            {
                MoldConFirmDTO a = MoldDAO.Instance.GetConfirmingDTO(IdMold);
                IdConFirming = a.Id;
            }


            string NoteReason = txtNote.Text;
            if(NoteReason=="")
            {
                MessageBox.Show("CHƯA NHẬP LÝ DO XÁC NHẬN KHUÔN.", " LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MoldConFirmDTO a = MoldDAO.Instance.GetConfirmingDTObyId(IdConFirming);
                UserDTO User = Common.CommonConstant.userConst;
                string EmCode = User.EmCode;
                EmployessDTO employess = EmployessDAO.Instance.GetItem(EmCode);
                string RoomCode = employess.RoomCode;

                    if(RoomCode=="PC")
                    {
                        if(a.IdEmPC==0) // Phòng PC chưa xác nhận
                        {
                        MoldDAO.Instance.UpdateConFirmPC(IdConFirming, employess.Id, DateTime.Now);
                        }
                        else
                        {
                            MessageBox.Show("PHÒNG PC ĐÃ XÁC NHẬN TRƯỚC ĐÓ.", " LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                    if(RoomCode=="QC")
                    {
                        if (a.IdEmQC == 0) // Phòng QC chưa xác nhận
                        {
                            MoldDAO.Instance.UpdateConFirmQC(IdConFirming, employess.Id, DateTime.Now);
                        }
                        else
                        {
                            MessageBox.Show("PHÒNG QC ĐÃ XÁC NHẬN TRƯỚC ĐÓ.", " LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if(RoomCode == "Tooling")
                    {
                        if (a.IdEmTool == 0) // Phòng Tool chưa xác nhận
                        {
                            MoldDAO.Instance.UpdateConFirmTool(IdConFirming, employess.Id, DateTime.Now);
                        }
                        else
                        {
                            MessageBox.Show("PHÒNG TOOL ĐÃ XÁC NHẬN TRƯỚC ĐÓ.", " LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } 
                    // Nếu cả 3 phòng ban này đã xác nhận rồi thì cập nhật lại ConFirm cho moldusing
            }
        }

       
    }
}