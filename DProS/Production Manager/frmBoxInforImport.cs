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
	public partial class frmBoxInforImport : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmBoxInforImport()
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
			string boxCode;
			string partCode;
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					boxCode = row.Cells["Box Code"].Value.ToString().TrimStart().TrimEnd();
					partCode = row.Cells["Part Code"].Value.ToString().TrimStart();
					if (boxCode.Trim().Length == 0 || partCode.Trim().Length == 0)
					{
						countError++;
						listError.Add("Dòng thứ " + i + "Dữ liệu trống.");
					}
					else if(BoxListDAO.Instance.GetItem(boxCode) == null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + "Mã hộp không hợp lệ.");
					}
					else if (PartDAO.Instance.GetItem(partCode) == null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + "Mã thiết bị không hợp lệ.");
					}
					else if (BoxInforDAO.Instance.GetItem(boxCode, partCode) != null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + "Dữ liệu này đã có.");
					}
					else
					{
						int idBox = BoxListDAO.Instance.GetItem(boxCode).Id;
						int idPart = PartDAO.Instance.GetItem(partCode).Id;
						BoxInforDAO.Instance.Insert(idBox, idPart);
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