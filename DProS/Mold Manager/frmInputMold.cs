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
using System.Globalization;

namespace DProS.Mold_Manager
{
    public partial class frmInputMold : DevExpress.XtraEditors.XtraForm
    {
        public frmInputMold()
        {
            InitializeComponent();
        }

        public EventHandler LamMoi;

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool CheckEmCode = EmployessDAO.Instance.GetItem(txtEmployes.Text) != null;
           
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            if (CheckEmCode)  //  mã nhân viên tồn tại
            {
                // QrCode = moldCode + "&" + moldName + "&" + numberMold + "&" + dateSX + "&" + shotTC + "&" + shotTT + "&" + totalShot + "&" + cav + "&" + cavNG + "&"+ IdCategory.ToString();
                string QrCode = txtQrCode.Text;
                if (QrCode.Length > 0)
                {
                    string[] array = QrCode.Split('&');
                    string moldCode = array[0];
                    string moldName = array[1];
                    string moldNumber = array[2];
                    string dateSX = array[3];
                    int shotTC = int.Parse(array[4]);
                    int shotTT = int.Parse(array[5]);
                    int totalShot = int.Parse(array[6]);
                    string cav = array[7];
                    string cavNG = array[8];
                    int Idcategory = int.Parse(array[9]);
                    string category = "";

                    if (Idcategory != -1 && Idcategory != 0)
                    {
                        category = MoldDAO.Instance.GetItemMoldErrorDTO(Idcategory).Name;
                    }
                    string StatusMold = "";
                    if (totalShot>1000000)
                    {
                        StatusMold = "OVER SHOT";
                    }
                    else
                    {
                        StatusMold = "OK";
                    }


                    DateTime date = DateTime.Now;
                    try
                    {
                        date = DateTime.Parse(dateSX);
                    }
                    catch
                    {

                    }

                    bool CheckMoldUsingExist = MoldDAO.Instance.CheckMoldUsingExistByCode(moldCode);

                    if (CheckMoldUsingExist)  // Khuôn đã tồn tại thì Update
                    {
                        // moldCode, shotTC, shotTT, totalShot, category, cav, 0

                        int IdMold = MoldDAO.Instance.GetMoldDTO1(moldCode).Id;

                        MoldDAO.Instance.UpdateMoldUsingQRcode(IdMold, shotTC, shotTT, totalShot,0, category, int.Parse(cav));

                        MessageBox.Show("nhận khuôn thành công !".ToUpper());
                        this.Close();
                    }

                    else // Khuôn chưa tồn tại thì Insert.
                    {
                        bool Check = MoldDAO.Instance.CheckMoldExist(moldCode);
                        if (Check)  // đã tồn tại thì chỉ thêm vào bảng khuôn đang sử dụng.
                        {
                            int IdMold = MoldDAO.Instance.GetMoldDTO1(moldCode).Id;
                            MoldDAO.Instance.InsertMoldUsing(IdMold,StatusMold,int.Parse(cav),int.Parse(cavNG) , shotTC, shotTT, totalShot, 0, category,DateTime.Now.ToString("dd/MM/yyyy"), "",0, "");
                            MessageBox.Show("nhận khuôn thành công !".ToUpper());
                            this.Close();
                        }
                        else
                        {
                            int IdMold = MoldDAO.Instance.GetMoldDTO1(moldCode).Id;

                            // Thêm vào bảng Mold:
                          
                            MoldDAO.Instance.InsertMold(moldCode, moldName, "", "", DateTime.Now, "", date.ToString("dd/MM/yyyy"), txtEmployes.Text, totalShot, moldNumber, "");

                            // Thêm vào bảng MoldUsing
                            MoldDAO.Instance.InsertMoldUsing(IdMold, StatusMold, int.Parse(cav), int.Parse(cavNG), shotTC, shotTT, totalShot, 0, category, DateTime.Now.ToString("dd/MM/yyyy"), "", 0, "");
                            MessageBox.Show("nhận khuôn thành công !".ToUpper());
                            this.Close();
                        }
                    }

                    // Thêm vào Bảng lịch sử.

                  //  EditHistoryDAO.Instance.Insert(DateTime.Now, txtEmployess.Text, " Đã nhận khuôn : " + moldCode, "");

                }
                else
                {
                    MessageBox.Show("mã QRCode trống. !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("mã nhân viên không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmInputMold_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}