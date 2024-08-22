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
	public partial class frmPOInputImportFile : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmPOInputImportFile()
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
			string pOCode;
			string partCode;
			DateTime dateInput;
			DateTime dateOut;
			int quantityIn;
			string CusCodeFac;
			string cusCode;
			float price;
			int idPart = 0;
			int idFactory = 0;
			int idCustomer = 0;
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					pOCode = row.Cells["Purchasing number"].Value.ToString().TrimStart().TrimEnd();
					string[] arrayList = pOCode.Split('-');
					pOCode = "";
					foreach (var item in arrayList)
					{
						pOCode += item.ToUpper();
					}
					partCode = row.Cells["Material number"].Value.ToString().TrimStart();
					CusCodeFac = row.Cells["Vendor"].Value.ToString().TrimStart();
					cusCode = row.Cells["Customer"].Value.ToString().TrimStart();
					if (pOCode.Trim().Length == 0)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã PO trống.");
					}
					else if (row.Cells["Date Input"].Value.ToString().TrimStart() == "" ||
						row.Cells["Delivery date"].Value.ToString().TrimStart() == "" ||
						row.Cells["PO quantity"].Value.ToString().TrimStart() == "" ||
						row.Cells["Unit Price"].Value.ToString().TrimStart() == "")
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Bạn không được để trống thông tin.");
					}
					else if (PartDAO.Instance.GetItem(partCode) == null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã linh kiện không hợp lệ.");
					}
					else if (FactoryDAO.Instance.GetItem(CusCodeFac) == null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã nhà máy không hợp lệ.");
					}
					else if (CustomerDAO.Instance.GetItem(cusCode) == null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã khách hàng không hợp.");
					}
					else
					{
						string input = row.Cells["Date Input"].Value.ToString();
						if (input.Length > 5)
						{
							string[] arrayB = input.Split('.');
							dateInput = DateTime.ParseExact(arrayB[0] + "/" + arrayB[1] + "/" + arrayB[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
						}
						else
						{
							dateInput = DateTime.Now;
						}
						string output = row.Cells["Delivery date"].Value.ToString();
						string[] array = output.Split('.');
						if (array.Count() == 1)
						{
							dateOut = DateTime.Parse(output);
						}
						else
						{
							dateOut = DateTime.ParseExact(array[0] + "/" + array[1] + "/" + array[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
						}
						quantityIn = int.Parse(row.Cells["PO quantity"].Value.ToString().TrimStart());
						float roundedPrice = float.Parse(row.Cells["Unit Price"].Value.ToString().TrimStart());
						price = (float)Math.Round(roundedPrice, 4);
						idFactory = FactoryDAO.Instance.GetItem(CusCodeFac).Id;
						idCustomer = CustomerDAO.Instance.GetItem(cusCode).Id;
						idPart = PartDAO.Instance.GetItem(partCode).Id;
						if (POInputDAO.Instance.GetItem(pOCode, partCode, price) != null)
						{
							countError++;
							listError.Add("Dòng thứ " + i + " Mã PO đã có.");
						}
						else POInputDAO.Instance.Insert(pOCode, idPart, quantityIn, dateInput, 0, idFactory, price, dateOut, idCustomer, 0);
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