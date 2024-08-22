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
using ExcelDataReader;
using System.IO;
using DAO;
using DTO;

namespace DProS.Datasource
{
    public partial class frmImpExcelMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmImpExcelMaterial()
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

            string colorcode = "";
            string matname = "";
            string matcode = "";
            string supcode = "";
            string nature = "";
            string rohsfile = "";
            int warnyllow;
            int warncount;
            int idsup;
            string note = "";
            int dem = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                dem++;
                matcode = item.Cells[0].ToString();
                int check = MaterialDAO.Instance.check(matcode);
                if (check > 0)
                {
                    demloi++;
					err = "Dòng :" + dem + " lỗi." + "     Nội dung: Trùng mã nguyên liệu";
					listerr.Add(err);
					continue;
                }
                matname = item.Cells[1].ToString();
                colorcode = item.Cells[2].ToString();
                supcode = (item.Cells[3].ToString());
                SupplierDTO supDTO = SupplierDAO.Instance.GetItembySupCode(supcode);
                if (supDTO == null)
                {
                    demloi++;
                     err = "Dòng :" + dem + " lỗi." + "     Nội dung: Sai mã  nhà cung cấp" ;
					listerr.Add(err);
					continue;
                }
                idsup = supDTO.ID;
                rohsfile = item.Cells[6].ToString();
                try
                {
                    
                    warnyllow = int.Parse(item.Cells[4].ToString());
                    warncount = int.Parse(item.Cells[5].ToString());
                }
                catch (Exception)
                {
                    demloi++;
                     err = "Dòng :" + dem + " lỗi." + "     Nội dung:Sai định dạng cảnh báo" ;
					listerr.Add(err);
					continue;
                }

                nature = item.Cells[7].ToString();
                note = "";
                int Insert = MaterialDAO.Instance.Insert(matcode, matname, warnyllow, warncount, idsup, nature, rohsfile, colorcode, note);

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