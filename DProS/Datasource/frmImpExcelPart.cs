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
using System.IO;
using ExcelDataReader;
using DAO;
using DTO;

namespace DProS.Datasource
{
    public partial class frmImpExcelPart : DevExpress.XtraEditors.XtraForm
    {
        public frmImpExcelPart()
        {
            InitializeComponent();
        }
        DataSet ds;
        public EventHandler LamMoi;
        public int demloi = 0;
        public string err = "";
		List<string> listerr = new List<string>();
        #region Hàm đọc file excel đưa vào
        void ReadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtLink.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 2)
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
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
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            float cyleTime ;
            string nameVN ;
            string note ;
            string partCode ;
            string partName ;
            float weightPart ;
            float weightRunner ;

            int countBox ;
            int cav ;
            int countPart ;
            int height ;

            string matCode ;
            int idCus ;

            int dem = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                dem++;
                              
                partCode = item.Cells[0].ToString();
                partName = item.Cells[1].ToString();
                PartDTO part = PartDAO.Instance.GetItem(partCode);
                if (part == null)
                {
                    demloi++;
					err = "Dòng thứ " + dem + " có lỗi.    Nội dung: Trùng mã linh kiện. ";
					listerr.Add(err);
					continue;
                }

                matCode = item.Cells[2].ToString();
                MaterialDTO material = MaterialDAO.Instance.GetItem(matCode);
                if(material==null)
                {
                    demloi++;
                    err = "Dòng thứ " + dem + " có lỗi.    Nội dung: Mã nguyên liệu không tồn tại. ";
					listerr.Add(err);
					continue;
                }
                string cuscode= item.Cells[4].ToString();
                CustomerDTO customer= CustomerDAO.Instance.GetItem(cuscode);
                if (customer == null)
                {
                    demloi++;
                    err = "Dòng thứ " + dem + " có lỗi.    Nội dung: Khách hàng không tồn tại. ";
					listerr.Add(err);
					continue;
                }
                idCus = customer.Id;
                try
                {
                    countPart = int.Parse(item.Cells[5].ToString());
                    countBox = int.Parse(item.Cells[6].ToString());
                    height = int.Parse(item.Cells[7].ToString());
                    weightPart = float.Parse(item.Cells[8].ToString());
                    weightRunner = float.Parse(item.Cells[9].ToString());
                    cyleTime = float.Parse(item.Cells[10].ToString());
                    cav = int.Parse(item.Cells[11].ToString());
                }
                catch (Exception)
                {
                    demloi++;
                    err = "Dòng thứ " + dem + " có lỗi.    Nội dung: Sai định dạng số. ";
					listerr.Add(err);
					continue;
                }
                
                note = item.Cells[12].ToString();
          
                nameVN = item.Cells[13].ToString();
                
                int insert = PartDAO.Instance.Insert(partCode, partName, matCode, idCus, countPart, countBox, weightPart, weightRunner, cyleTime, cav, nameVN, height, note);
            }

            txtTotalError.Text = demloi.ToString();

        }

        private void cbSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }

        private void btnErrorList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(listerr);
            f.ShowDialog();
        }
    }
}