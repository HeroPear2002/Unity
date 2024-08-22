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
	public partial class frmCategoryImportFile : DevExpress.XtraEditors.XtraForm
	{
		DataSet ds;
		List<string> listError;
		public frmCategoryImportFile()
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
			DialogResult result = MessageBox.Show("BẠN MUỐN LƯU BẢN GHI NÀY?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				if (txtPathFile.Text == "")
				{
					MessageBox.Show("Bạn hãy chọn file trước.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				else if (cbSheet.Text.Length <= 0)
				{
					MessageBox.Show("Bạn hãy chọn sheet trước.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				int count = grvFile.RowCount;
				int i = 0;
				int countError = 0;
				listError = new List<string>();
				string nameCategory;
				string method;
				string detail;
				string deviceType;
				int timer;
				int statusCate;
				string limit;
				foreach (DataGridViewRow row in grvFile.Rows)
				{
					i++;
					if (i < count)
					{
						nameCategory = row.Cells["Tên hạng mục"].Value.ToString().TrimStart();
						method = row.Cells["Phương pháp thực hiện"].Value.ToString().TrimStart();
						detail = row.Cells["Tiêu chuẩn phán định"].Value.ToString().TrimStart();
						timer = int.Parse(row.Cells["Thời gian"].Value.ToString());
						deviceType = row.Cells["Loại thiết bị"].Value.ToString().TrimStart().TrimEnd();
						statusCate = int.Parse(row.Cells["Trạng thái"].Value.ToString());
						DeviceDTO DTO = null;
						if (!string.IsNullOrEmpty(deviceType))
						{
							DTO = DeviceDAO.Instance.GetList()
								.Find(x => string.Equals(x.Name, deviceType, StringComparison.OrdinalIgnoreCase));
						}
						int idDevice = 0;
						if (DTO != null) idDevice = DTO.Id;
						limit = row.Cells["Giới hạn"].Value.ToString();
						if (nameCategory.Trim().Length == 0)
						{
							countError++;
							listError.Add("Dòng thứ " + i + " Tên hạng mục trống");
						}
						else if (CateTestMachineDAO.Instance.GetListItem(nameCategory) != null && CateTestMachineDAO.Instance.GetListItem(nameCategory).Find(x => x.IdDevice == idDevice) != null)
						{
							countError++;
							listError.Add("Dòng thứ " + i + " Tên hạng mục đã có");
							//CateTestMachineDAO.Instance.Update(nameCategory, detail, timer, method, statusCate, idDevice, limit);
						}
						else if (idDevice == 0)
						{
							countError++;
							listError.Add("Dòng thứ " + i + " Bạn nhập sai loại thiết bị");
						}
						else
							CateTestMachineDAO.Instance.Insert(nameCategory, detail, timer, method, statusCate, idDevice, limit);
					}
				}
				if (countError > 0)
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
                        reader.Close();
						cbSheet.SelectedIndex = 0;
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