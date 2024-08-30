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
using ExcelDataReader;
//using OfficeOpenXml;

namespace DProS.Mold_Manager
{
    public partial class frmExCellMoldInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmExCellMoldInfor()
        {
            InitializeComponent();
        }
       
        List<ExcelWorksheet> Lsv;
        ExcelWorksheet worksheet;
        ExcelPackage package;
        DataTable dt = new DataTable();
        List<MoldDTO> dsMold = new List<MoldDTO>();
        DataSet ds = new DataSet();
        public List<string> Err;



        //  Chọn Sheet.

        #region Hàm đọc File Excell.

        void ReadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
               
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                   txtPathFile.Text = ofd.FileName;
                    // dòng này dùng try catch lỗi do File đang mở

                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 2)
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        else
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                        ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }

                        });

                        cbSheet.Items.Clear();
                        foreach (DataTable dt in ds.Tables)
                        {
                            cbSheet.Items.Add(dt.TableName);
                        }
                        reader.Close();

                    }
                }
            }
        }

        #endregion

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[cbSheet.SelectedIndex];      
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ReadData();
        }


        List<string> LsMaKhuonDaTT = new List<string>();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtPathFile.Text == "")
            {
                MessageBox.Show("Bạn hãy chọn file trước.".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cbSheet.Text.Length <= 0)
            {
                MessageBox.Show("Bạn hãy chọn sheet trước.".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int count = dataGridView1.RowCount;
            int i = 0;
            int countError = 0;
            List<string> listError = new List<string>();

            string MaKhuon;
            string TenKhuon;
            string ModelKhuon;
            string NhaSX;
            DateTime NgayNhan;
            string NoiNhap;
            string NgaySXLuotDau;
            string NguoiNhan;
             int  SoShotBD;
            string SoKhuon;
            string ghichu;
          
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                i++;
                if (i < count)
                {
                    MaKhuon  = row.Cells[0].Value.ToString();
                    //1: vị trí xảy ra lỗi.
                    TenKhuon = row.Cells[1].Value.ToString();
                    ModelKhuon = row.Cells[2].Value.ToString();
                    NhaSX = row.Cells[3].Value.ToString();

                    NgayNhan =DateTime.Parse( row.Cells[4].Value.ToString());
                    //2: Vị trí xảy ra lỗi
                    NoiNhap = row.Cells[5].Value.ToString();

                    NgaySXLuotDau =DateTime.Parse(row.Cells[6].Value.ToString()).ToString("dd/MM/yyyy");    
                    
                    SoShotBD =int.Parse( row.Cells[7].Value.ToString());
                    //3: Vị trí xảy ra lỗi.
                    NguoiNhan = row.Cells[8].Value.ToString();
                    SoKhuon = row.Cells[9].Value.ToString();
                    ghichu = row.Cells[10].Value.ToString(); 
                    
                    if (MaKhuon.Trim().Length != 0) // Kiểm tra mã bị trống.
                    {
                        bool CheckKhExist = MoldDAO.Instance.CheckMoldExist(MaKhuon);  // Kiểm tra Mã khuôn bị trùng trong cơ sở dữ liệu.
                        if(!CheckKhExist)
                        {
                            MoldDAO.Instance.InsertMold(MaKhuon, TenKhuon, ModelKhuon, NhaSX, NgayNhan, NoiNhap, NgaySXLuotDau, NguoiNhan, SoShotBD, SoKhuon, ghichu);
                        }
                        else
                        {
                            countError++;
                            listError.Add("Dòng thứ " + i + " Mã khuôn đã có");
                           
                        }
                    }                 
                }
            }
            if (countError > 0)
            {
                txtError.Text = "Bạn có " + countError.ToString() + " bản ghi lỗi";
                btnListError.Enabled = true;
              
                MessageBox.Show("Bạn có lỗi khi nhập.".ToUpper());
            }
            else
            {
                MessageBox.Show("Bạn đã nhập thành công.".ToUpper());
                this.Close();
            }
            Err = listError;
        }
       
        private void btnListError_Click(object sender, EventArgs e)
        {
            frmErrorList fileform = new frmErrorList(Err);
            fileform.ShowDialog();
        }

    }



   
}

