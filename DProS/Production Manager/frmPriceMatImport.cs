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
using System.Globalization;

namespace DProS.Production_Manager
{
	public partial class frmPriceMatImport : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmPriceMatImport()
		{
			InitializeComponent();
			btnListError.Enabled = false;
		}

		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			ReadData();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if(txtPathFile.Text == "")
			{
				MessageBox.Show("Bạn hãy chọn file trước.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if(cbSheet.Text.Length <= 0 )
			{
				MessageBox.Show("Bạn hãy chọn sheet trước.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int count = grvFile.RowCount;
			int i = 0;
			int countError = 0;
			listError = new List<string>();
			string MaterialCode = "";
			DateTime DateInput = DateTime.Now;
			Decimal PriceVND = 0;
			string PriceUSD = "";
			int StatusPrice = 0;
			string Note = "";
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					try
					{
						MaterialCode = row.Cells["Material Code"].Value.ToString();
					}
					catch
					{
						listError.Add("Dòng " + i + ": Mã Nguyên Liệu không đúng".ToUpper());
						countError++;
					}
					try
					{
						DateInput = DateTime.Parse(row.Cells["Month Year"].Value.ToString());
						if (DateInput.Day < 15)
						{
							DateInput = DateInput.AddDays(1 - DateInput.Day);
						}
						else
						{
							DateInput = DateInput.AddDays(1 - DateInput.Day + 14);
						}
					}
					catch
					{
						listError.Add("Dòng " + i + ": Định dạng ngày tháng năm không đúng".ToUpper());
						countError++;
					}
					try
					{
						PriceVND = decimal.Parse(row.Cells["VND"].Value.ToString());
					}
					catch
					{
						listError.Add("Dòng " + i + ": Đơn giá VND không đúng".ToUpper());
						countError++;
					}
					try
					{
						PriceUSD = row.Cells["USD"].Value.ToString();
					}
					catch
					{
						listError.Add("Dòng " + i + ": đơn giá USD không đúng".ToUpper());
						countError++;
					}
					try
					{
						Note = row.Cells["Note"].Value.ToString();
					}
					catch
					{
						listError.Add("Dòng " + i + ": Ghi chú không đúng".ToUpper());
						countError++;
					}
					if (MaterialCode.Length == 0)
					{
						listError.Add("Dòng " + i + ": mã nguyên liệu trống".ToUpper());
						countError++;
					}
					else
					{
						PriceMatDTO test = PriceMatDAO.Instance.GetItem(MaterialCode, DateInput);
						if (test == null)
						{
							int idMat = MaterialDAO.Instance.GetItem(MaterialCode).Id;
							PriceMatDAO.Instance.Insert(idMat, DateInput, PriceVND, PriceUSD, StatusPrice, Note);

						}
						else
						{
							listError.Add("Dòng " + i + ": Thông tin đã tồn tại".ToUpper());
							countError++;
						}
					}
				}
			}
			if(countError > 0)
			{
				txtError.Text = "Bạn có " + countError.ToString() + " bản ghi lỗi";
				btnListError.Enabled = true;
				MessageBox.Show("Bạn có lỗi khi nhập.".ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Bạn đã nhập thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void btnListError_Click(object sender, EventArgs e)
		{
			frmErrorList fileform = new frmErrorList(listError);
			fileform.ShowDialog();
		}
		void ReadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
					txtPathFile.Text = ofd.FileName;
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
						cbSheet.SelectedIndex = 0;
                        reader.Close();

                    }
                }
            }
        }

		private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
		{
			grvFile.DataSource = ds.Tables[cbSheet.SelectedIndex];
		}
	}
}