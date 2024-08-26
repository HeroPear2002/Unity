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

namespace DProS.Datasource
{
	public partial class frmTemPartImportFile : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmTemPartImportFile()
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
			string moldCode = "";
			string partCode = "";
			string machineCode = "";
			int idPart = 0;
			int idMachine = 0;
			int idMold = 0;
			string rev = "";
			string factory = "";
			string standard = "";
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					try
					{
						moldCode = row.Cells["Mold Code"].Value.ToString();
						partCode = row.Cells["Part Code"].Value.ToString();
						machineCode = row.Cells["Machine Code"].Value.ToString();
						rev = row.Cells["Rev"].Value.ToString();
						factory = row.Cells["Factory Code"].Value.ToString();
						standard = row.Cells["Standard"].Value.ToString();
						
						if (moldCode == "" || partCode == "" || machineCode == "" || factory == "")
						{
							listError.Add("Dòng " + i + ": Dữ Liệu Trống".ToUpper());
							countError++;
						}
						else if (PartDAO.Instance.GetItemByPartCode(partCode) == null)
						{
							listError.Add("Dòng " + i + ": mã linh kiện không đúng".ToUpper());
							countError++;
						}
						else if (MachineDAO.Instance.GetItem(machineCode) == null)
						{
							listError.Add("Dòng " + i + ": Mã máy không đúng".ToUpper());
							countError++;
						}
						else if (MoldDAO.Instance.GetMoldDTO1(moldCode) == null)
						{
							listError.Add("Dòng " + i + ": Mã khuôn không đúng".ToUpper());
							countError++;
						}
						else
						{
							idPart = PartDAO.Instance.GetItemByPartCode(partCode).Id;
							idMachine = MachineDAO.Instance.GetItem(machineCode).Id;
							idMold = MoldDAO.Instance.GetMoldDTO1(moldCode).Id;
							TemInforDTO test = TemInforDAO.Instance.GetItem(idPart, idMachine, idMold);
							if (test != null)
							{
								TemInforDAO.Instance.Update(test.Id, idPart, idMachine, idMold, rev, factory, standard);
							}
							else
							{
								TemInforDAO.Instance.Insert(idPart, idMachine, idMold, rev, factory, standard);
							}
						}
					}
					catch
					{

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