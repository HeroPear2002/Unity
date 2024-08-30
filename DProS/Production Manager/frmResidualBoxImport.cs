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
	public partial class frmResidualBoxImport : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmResidualBoxImport()
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
			string PartCode;
			int DateLV;
			float DateIventory;
			DateTime DateNew;
			int QuantityPart, CountBox, CountBoxTT;
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					PartCode = row.Cells["Part Code"].Value.ToString();
					DateNew = DateTime.Parse(row.Cells["Date Month"].Value.ToString());
					QuantityPart = int.Parse(row.Cells["Quantity Part"].Value.ToString());
					CountBoxTT = int.Parse(row.Cells["Quantity Box"].Value.ToString());
					DateIventory = (float)Convert.ToDouble(row.Cells["Date Iventory"].Value.ToString());
					DateLV = int.Parse(row.Cells["Date Works"].Value.ToString());
					if (PartCode == "")
					{
						listError.Add("Dòng " + i + ": Thông Tin Trống".ToUpper());
						countError++;
					}
					else
					{
						BoxEfficDTO test = BoxEfficDAO.Instance.GetItem(DateNew, PartCode);
						PartDTO DTO = PartDAO.Instance.GetItem(PartCode);
						int countPart = DTO.CountBox;
						CountBox = (int)Math.Ceiling((((QuantityPart * DateIventory) / DateLV) / countPart) + ((0.02 * QuantityPart) / countPart));
						if (test == null)
						{
							BoxEfficDAO.Instance.Insert(DateNew, DTO.Id, QuantityPart, CountBox, CountBoxTT);
						}
						else
						{
							BoxEfficDAO.Instance.Update(test.Id, DateNew, DTO.Id, QuantityPart, CountBox, CountBoxTT);
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