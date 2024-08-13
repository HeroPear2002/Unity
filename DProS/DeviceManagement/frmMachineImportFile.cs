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

namespace DProS.DeviceManagement
{
	public partial class frmMachineImportFile : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		int iddevice;
		List<string> listError;
		public frmMachineImportFile()
		{
			InitializeComponent();
			btnListError.Enabled = false;
		}
		public frmMachineImportFile(int idDevice)
		{
			InitializeComponent();
			iddevice = idDevice;
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
				MessageBox.Show("Bạn hãy chọn file trước.".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if(cbSheet.Text.Length <= 0 )
			{
				MessageBox.Show("Bạn hãy chọn sheet trước.".ToUpper(), "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			int count = grvFile.RowCount;
			int i = 0;
			int countError = 0;
			listError = new List<string>();
			string machineCode;
			string machineName;
			string serialNumber;
			string manufacturer;
			string vender;
			string codeAsset;
			DateTime dateProduct;
			DateTime dateInput;
			DateTime dateMaker;
			foreach (DataGridViewRow row in grvFile.Rows)
			{
				i++;
				if(i<count)
				{
					machineCode = row.Cells[0].Value.ToString().TrimStart().TrimEnd();
					machineName = row.Cells[1].Value.ToString().TrimStart();
					serialNumber = row.Cells[2].Value.ToString().TrimStart();
					manufacturer = row.Cells[3].Value.ToString().TrimStart();
					vender = row.Cells[4].Value.ToString().TrimStart();
					if (row.Cells[6].Value.ToString() != "") dateMaker = DateTime.Parse(row.Cells[5].Value.ToString());
					else dateMaker = DateTime.MaxValue;
					dateInput = DateTime.Parse(row.Cells[6].Value.ToString());
					if (row.Cells[8].Value.ToString() != "") dateProduct = DateTime.Parse(row.Cells[7].Value.ToString());
					else dateProduct = DateTime.MaxValue;
					codeAsset = row.Cells[8].Value.ToString().TrimStart();
					if (machineCode.Trim().Length == 0)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã máy trống");
					}
					else if(MachineDAO.Instance.GetItem(machineCode) != null)
					{
						countError++;
						listError.Add("Dòng thứ " + i + " Mã máy đã có");
						//MachineDAO.Instance.Update(machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, dateMaker);
					}
					else
						MachineDAO.Instance.Insert(machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, iddevice, dateMaker);
				}
			}
			if(countError > 0)
			{
				txtError.Text = "Bạn có " + countError.ToString() + " bản ghi lỗi";
				btnListError.Enabled = true;
				MessageBox.Show("Bạn có lỗi khi nhập.".ToUpper());
			}
			else
			{
				MessageBox.Show("Bạn đã nhập thành công.".ToUpper());
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