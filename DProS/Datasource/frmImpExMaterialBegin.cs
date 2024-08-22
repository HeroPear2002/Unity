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
using ExcelDataReader;
using System.IO;

namespace DProS.Datasource
{
    public partial class frmImpExMaterialBegin : DevExpress.XtraEditors.XtraForm
    {
        public frmImpExMaterialBegin()
        {
            InitializeComponent();
        }
        DataSet ds;
        public EventHandler LamMoi;
        public int demloi = 0;
        public string err = "";
		public List<string> listerr;
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
            string matcode = "";
            string weightmin= "";
            string timemin = "";
            int dem = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                dem++;
                matcode = item.Cells[0].ToString();
                MaterialDTO material = MaterialDAO.Instance.GetItem(matcode);
                if (material == null)
                {
                    demloi++;
                    err = "Dòng :" + dem + " lỗi." + "     Nội dung: mã nguyên liệu không tồn tại";
					listerr.Add(err);
					continue;
                }
                int idmat = material.Id;
                int check = MaterialBeginDAO.Instance.check(idmat);
                if(idmat>0)
                {
                    demloi++;
                    err = "Dòng :" + dem + " lỗi." + "     Nội dung: mã nguyên liệu đã được settup trước đó" ;
					listerr.Add(err);
					continue;
                }
                try
                {
                    int weight = int.Parse(item.Cells[1].ToString());
                    weightmin = weight.ToString();
                }
                catch (Exception)
                {
                    demloi++;
                    err = "Dòng :" + dem + " lỗi." + "     Nội dung: Sai định dạng kiểu dữ liệu cột : Số lượng sấy tối thiểu";
					listerr.Add(err);
					continue;
                }
                try
                {
                    int time = int.Parse(item.Cells[12].ToString());
                    timemin = time.ToString();
                }
                catch (Exception)
                {
                    demloi++;
                    err = "Dòng :" + dem + " lỗi." + "     Nội dung: Sai định dạng kiểu dữ liệu cột : Thời gian sấy tối thiểu";
					listerr.Add(err);
					continue;
                }
                           
                int Insert = MaterialBeginDAO.Instance.Insert(idmat,weightmin,timemin);
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