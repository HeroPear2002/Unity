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
	public partial class frmPOFixImportFile : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmPOFixImportFile()
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
			DateTime dateInput = DateTime.Now;
			DateTime dateOut;
			int quantity;
			string factoryCustomer;
			int carNumber;
			float price;
			long idPOInput = 0;
			int sumquantity = 0;
			int secon;
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					pOCode = row.Cells["Purchasing number"].Value.ToString().TrimStart().TrimEnd();
					try
					{
						string[] arrayList = pOCode.Split('-');
						pOCode = arrayList[0] + arrayList[1];
					}
					catch
					{
						listError.Add("Dòng " + i + ": Cột Purchasing number không đúng".ToUpper());
						countError++;
					}
					partCode = row.Cells["Material number"].Value.ToString().TrimStart();
					factoryCustomer = row.Cells["Factory"].Value.ToString().TrimStart();
					try
					{
						carNumber = int.Parse(row.Cells["Car Number"].Value.ToString().TrimStart());
					}
					catch
					{
						carNumber = 0;
					}
					try
					{
						DateTime DateDK1 = DateTime.Parse(row.Cells["Time Receive"].Value.ToString());
						secon = (int)(DateDK1 - DateDK1.Date).TotalSeconds;
					}
					catch
					{
						secon = 0;
					}
					if (pOCode.Trim().Length == 0)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã PO trống.");
					}
					else if (row.Cells["Delivery date"].Value.ToString().TrimStart() == "" ||
						row.Cells["PO quantity"].Value.ToString().TrimStart() == "" ||
						row.Cells["Unit price"].Value.ToString().TrimStart() == "")
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Bạn không được để trống thông tin.");
					}
					else if (PartDAO.Instance.GetItem(partCode) == null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã linh kiện không hợp lệ.");
					}
					else
					{
						string a = row.Cells["Delivery date"].Value.ToString();
						string[] array = a.Split('.');
						DateTime DateDK2 = DateTime.ParseExact(array[0] + "/" + array[1] + "/" + array[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
						dateOut = DateDK2.Date.AddSeconds(secon);
						quantity = int.Parse(row.Cells["PO quantity"].Value.ToString().TrimStart());
						float roundedPrice = float.Parse(row.Cells["Unit Price"].Value.ToString().TrimStart());
						price = (float)Math.Round(roundedPrice, 4);
						if (POInputDAO.Instance.GetItem(pOCode, partCode, price) == null)
						{
							countError++;
							listError.Add("Dòng thứ " + i + " Thông tin PO không hợp lệ: Mã Po, Mã linh kiện, Đơn giá.");
						}
						else
						{
							idPOInput = POInputDAO.Instance.GetItem(pOCode, partCode, price).Id;
							sumquantity = POFixDAO.Instance.GetQuantity(idPOInput);
							POInputDTO DTO = POInputDAO.Instance.GetItem(idPOInput);
							if (quantity + sumquantity > DTO.QuantityIn)
							{
								countError++;
								listError.Add("Dòng thứ " + i + " Số lượng đã vượt qua số lượng PO yêu cầu.");
							}
							else POFixDAO.Instance.Insert(idPOInput, quantity, dateOut, factoryCustomer, carNumber);
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