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
using ExcelDataReader;
using System.IO;
using DTO;

namespace DProS.Datasource
{
    public partial class frmImpExSup : DevExpress.XtraEditors.XtraForm
    {
        public frmImpExSup()
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
            string supCo = "";
            string supna = "";
            string addr = "";
            string phone = "";
            string email = "";
            string note = "";
            
            int dem = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                dem++;
                supCo = item.Cells[0].ToString();
                int check = SupplierDAO.Instance.check(supCo);
                if(check>0)
                {
                    demloi++;
                    err = "Dòng thứ " + dem + " có lỗi.    Nội dung: Mã khách hàng  trùng.";
					listerr.Add(err);
					continue;
                }
                supna= item.Cells[2].ToString();
                addr= item.Cells[3].ToString();
                phone= item.Cells[4].ToString();
                email= item.Cells[5].ToString();
                note= item.Cells[6].ToString();
                int insert = SupplierDAO.Instance.Insert(supCo, supna, addr, phone, email, note);
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
