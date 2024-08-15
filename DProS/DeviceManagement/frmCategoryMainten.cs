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
using DTO;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace DProS.DeviceManagement
{
	public partial class frmCategoryMainten : DevExpress.XtraEditors.XtraForm
	{
		List<DeviceDTO> listdevice = new List<DeviceDTO>();
		List<CateTestMachineDTO> listcate = new List<CateTestMachineDTO>();
		bool insert = true;
		bool everyday = false;
		public frmCategoryMainten()
		{
			InitializeComponent();
			LoadControl();
			LoadDevice();
			if (everyday) this.Text = "HM KT HÀNG NGÀY";
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}

		private void LoadDevice()
		{
			listdevice = DeviceDAO.Instance.GetList();
			cbDeviceType.DataSource = listdevice;
			cbDeviceType.DisplayMember = "Name";
			cbDeviceType.ValueMember = "Id";
		}
		void LoadData()
		{
			if (Common.CommonConstant.checkCate == 0)
			{
				everyday = true;
				listcate = CateTestMachineDAO.Instance.GetList().Where(x=>x.Timer == 24).ToList();
				gcCategoryList.DataSource = listcate;
				gvcTimer.Visible = false;
			}
			else
			{
				everyday = false;
				listcate = CateTestMachineDAO.Instance.GetList().Where(x => x.Timer != 24).ToList();
				gcCategoryList.DataSource = listcate;
			}
		}


		private void CleanText()
		{
			txtMethodImplement.Text = string.Empty;
			txtNameCategory.Text = string.Empty;
			txtStandardVerdict.Text = string.Empty;
			txtTimeRoutineMainten.Text = string.Empty;
			cbDeviceType.Text = string.Empty;
			ckbMeasuringParameters.Checked = false;
		}

		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtNameCategory.Enabled = false;
				txtMethodImplement.Enabled = false;
				txtStandardVerdict.Enabled = false;
				txtTimeRoutineMainten.Enabled = false;
				cbDeviceType.Enabled = false;
				ckbMeasuringParameters.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtNameCategory.Enabled = true;
				txtMethodImplement.Enabled = true;
				txtStandardVerdict.Enabled = true;
				if(!everyday) txtTimeRoutineMainten.Enabled = true;
				cbDeviceType.Enabled = true;
				ckbMeasuringParameters.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			string nameCategory = txtNameCategory.Text;
			if (nameCategory.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập tên hạng mục.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string method = txtMethodImplement.Text;
			string detail = txtStandardVerdict.Text;
			int timer = 24;
			if (txtTimeRoutineMainten.Text != "" && !everyday)
				timer = int.Parse(txtTimeRoutineMainten.Text);
			else if(everyday) timer = 24;
			else
			{
				MessageBox.Show("BẠN PHẢI NHẬP THỜI GIAN BẢO DƯỠNG ĐỊNH KỲ.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			int idDevice = 0;
			if(cbDeviceType.Text.Length > 0) idDevice= int.Parse(cbDeviceType.SelectedValue.ToString());
			else
			{
				MessageBox.Show("BẠN PHẢI CHỌN LOẠI THIẾT BỊ.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			int statusCate = 0;
			if (ckbMeasuringParameters.Checked) statusCate = 1;
			else statusCate = 0;
			if (insert)
			{
				if (CateTestMachineDAO.Instance.GetListItem(nameCategory).Find(x => x.IdDevice == idDevice) == null)
				{
					bool insertCate = CateTestMachineDAO.Instance.Insert(nameCategory, detail, timer, method, statusCate, idDevice);
					if (insertCate)
					{
						MessageBox.Show("Bạn đã thêm thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Tên hạng mục này đã tồn tại hãy nhập tên hạng mục khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				int id = int.Parse(gvCategoryList.GetFocusedRowCellValue("Id").ToString());
				if (CateTestMachineDAO.Instance.GetListItem(nameCategory).Find(x => x.IdDevice == idDevice) == null || CateTestMachineDAO.Instance.GetListItem(nameCategory).Find(x => x.IdDevice == idDevice).Id == id)
				{
					bool updateCate = CateTestMachineDAO.Instance.Update(id, nameCategory, detail, timer, method, statusCate, idDevice);
					if (updateCate)
					{
						MessageBox.Show("Bạn đã sửa thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Tên hạng mục này đã tồn tại hãy nhập tên hạng mục khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}
		}
		private void btnInsert_Click(object sender, EventArgs e)
		{
			LockControl(false);
			insert = true;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
			insert = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvCategoryList.GetSelectedRows())
				{
					int id = int.Parse(gvCategoryList.GetRowCellValue(item, "Id").ToString());
					bool delete = CateTestMachineDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("BẠN MUỐN LƯU BẢN GHI NÀY?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				Save();
				LoadControl();
			}
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcCategoryList.FocusedView as GridView;
			if (view == null) return;
			view.OptionsSelection.EnableAppearanceHideSelection = false;
			view.BestFitColumns();
			ExportWithSaveFileDialog(view, exportSelected: false, exportFiltered: true);
		}
		private void ExportWithSaveFileDialog(GridView view, bool exportSelected, bool exportFiltered)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", Title = "Save SampleFile", FileName = "SampleForm" })
			{
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;
					string extension = System.IO.Path.GetExtension(filePath);

					XlsxExportOptionsEx options = new XlsxExportOptionsEx
					{
						ExportType = ExportType.WYSIWYG
					};
					bool hasSelectedRows = view.GetSelectedRows().Length > 0;
					if (hasSelectedRows)
					{
						view.OptionsPrint.PrintSelectedRowsOnly = true;
					}
					else
					{
						view.OptionsPrint.PrintSelectedRowsOnly = false;
						view.OptionsPrint.PrintFilterInfo = false;
					}
					view.ExportToXlsx(filePath, options);
					MessageBox.Show("Export successful!".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmCategorySampleForm sampleform = new frmCategorySampleForm();
			sampleform.ShowDialog();
			LoadControl();
		}

		private void btnImportExcel_Click(object sender, EventArgs e)
		{
			frmCategoryImportFile fileform = new frmCategoryImportFile();
			fileform.ShowDialog();
			LoadControl();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}
		private void gridView1_Click(object sender, EventArgs e)
		{
			try
			{
				txtNameCategory.Text = gvCategoryList.GetFocusedRowCellValue("NameCategory").ToString();
				txtMethodImplement.Text = gvCategoryList.GetFocusedRowCellValue("Method").ToString();
				txtStandardVerdict.Text = gvCategoryList.GetFocusedRowCellValue("Detail").ToString();
				txtTimeRoutineMainten.Text = gvCategoryList.GetFocusedRowCellValue("Timer").ToString();
				cbDeviceType.Text = gvCategoryList.GetFocusedRowCellValue("Name").ToString();
				int statusCate = int.Parse(gvCategoryList.GetFocusedRowCellValue("StatusCate").ToString());
				if(statusCate == 0) ckbMeasuringParameters.Checked = false;
				else if(statusCate == 1) ckbMeasuringParameters.Checked = true;
			}
			catch (Exception)
			{


			}
		}

		private void frmCategoryMainten_FormClosing(object sender, FormClosingEventArgs e)
		{
		
		}
	}
}