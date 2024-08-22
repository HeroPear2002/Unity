using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace DProS.DeviceManagement
{
	public partial class frmMachineList : DevExpress.XtraEditors.XtraForm
	{
		List<MachineDTO> listMachine = new List<MachineDTO>();
		bool insert = true;
		int iddevice;
		public frmMachineList()
		{
			InitializeComponent();
			LoadControl();
		}
		public frmMachineList(int idDevice)
		{
			InitializeComponent();
			iddevice = idDevice;
			LoadControl();
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}

		private void LoadData()
		{
			listMachine = MachineDAO.Instance.GetList(iddevice);
			gcMachineList.DataSource = listMachine;
		}

		private void CleanText()
		{
			txtMachineCode.Text = string.Empty;
			txtMachineName.Text = string.Empty;
			txtSerialNumber.Text = string.Empty;
			txtManufacturer.Text = string.Empty;
			txtVender.Text = string.Empty;
			txtCodeAsset.Text = string.Empty;
			dtpDateMaker.Value = DateTime.Now;
			dtpDateInput.Value = DateTime.Now;
			dtpDateProduct.Value = DateTime.Now;
		}
		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtMachineCode.Enabled = false;
				txtMachineName.Enabled = false;
				txtSerialNumber.Enabled = false;
				txtManufacturer.Enabled = false;
				txtVender.Enabled = false;
				txtCodeAsset.Enabled = false;
				dtpDateMaker.Enabled = false;
				dtpDateInput.Enabled = false;
				dtpDateProduct.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtMachineCode.Enabled = true;
				txtMachineName.Enabled = true;
				txtSerialNumber.Enabled = true;
				txtManufacturer.Enabled = true;
				txtVender.Enabled = true;
				txtCodeAsset.Enabled = true;
				dtpDateMaker.Enabled = true;
				dtpDateInput.Enabled = true;
				dtpDateProduct.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			string machineCode = txtMachineCode.Text;
			if (machineCode.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập mã thiết bị.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string machineName = txtMachineName.Text;
			string serialNumber = txtSerialNumber.Text;
			string manufacturer = txtManufacturer.Text;
			string vender = txtVender.Text;
			string codeAsset = txtCodeAsset.Text;
			DateTime dateMaker = dtpDateMaker.Value;
			DateTime dateInput = dtpDateInput.Value;
			DateTime dateProduct = dtpDateProduct.Value;
			if(dateMaker >= dateInput)
			{
				MessageBox.Show("Ngày chế tạo TB phải trước hoặc bằng ngày nhập.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if (dateInput >= dateProduct)
			{
				MessageBox.Show("Ngày nhập phải trước hoặc bằng ngày bắt đầu sản xuất.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (insert)
			{
				if (MachineDAO.Instance.GetItem(machineCode) == null )
				{
					bool insertMachine = MachineDAO.Instance.Insert(machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, iddevice, dateMaker);
					if (insertMachine)
					{
						MessageBox.Show("Bạn đã thêm thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Mã máy này đã tồn tại hãy nhập mã máy khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}
			else
			{
				int id = int.Parse(gvMachineList.GetFocusedRowCellValue("Id").ToString());
				if (MachineDAO.Instance.GetItem(machineCode) == null || MachineDAO.Instance.GetItem(machineCode).Id == id )
				{
					bool updateMachine = MachineDAO.Instance.Update(id, machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, dateMaker);
					if (updateMachine)
					{
						MessageBox.Show("Bạn đã sửa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Mã máy này đã tồn tại hãy nhập mãy má khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				foreach (var item in gvMachineList.GetSelectedRows())
				{
					int id = int.Parse(gvMachineList.GetRowCellValue(item, "Id").ToString());
					bool delete = MachineDAO.Instance.Delete(id);
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
			GridView view = gcMachineList.FocusedView as GridView;
			if (view == null) return;
			view.OptionsSelection.EnableAppearanceHideSelection = false;
			view.BestFitColumns();
			ExportWithSaveFileDialog(view, exportSelected: false, exportFiltered: true);
			LoadControl();
		}
		private void ExportWithSaveFileDialog(GridView view, bool exportSelected, bool exportFiltered)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", Title = "Export File", FileName = "FileMachineList" })
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
					if (hasSelectedRows) view.OptionsPrint.PrintSelectedRowsOnly = true;
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
		private void btnMachineTemporary_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn xác nhận máy tạm!".ToUpper(), "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
			{
				foreach (var item in gvMachineList.GetSelectedRows())
				{
					int id = int.Parse(gvMachineList.GetRowCellValue(item, "Id").ToString());
					MachineDAO.Instance.UpdateStatusMachine(id, 10);
				}
				LoadControl();
			}
		}

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmMachineSampleForm sampleform = new frmMachineSampleForm();
			sampleform.ShowDialog();
			LoadControl();
		}

		private void btnImportExcel_Click(object sender, EventArgs e)
		{
			frmMachineImportFile fileform = new frmMachineImportFile(iddevice);
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
				txtMachineCode.Text = gvMachineList.GetFocusedRowCellValue("MachineCode").ToString();
				txtMachineName.Text = gvMachineList.GetFocusedRowCellValue("MachineName").ToString();
				txtSerialNumber.Text = gvMachineList.GetFocusedRowCellValue("SerialNumber").ToString();
				txtManufacturer.Text = gvMachineList.GetFocusedRowCellValue("Manufacturer").ToString();
				txtVender.Text = gvMachineList.GetFocusedRowCellValue("Vender").ToString();
				txtCodeAsset.Text = gvMachineList.GetFocusedRowCellValue("CodeAsset").ToString();
				dtpDateMaker.Value = DateTime.Parse(gvMachineList.GetFocusedRowCellValue("DateMaker").ToString());
				dtpDateInput.Value = DateTime.Parse(gvMachineList.GetFocusedRowCellValue("DateInput").ToString());
				dtpDateProduct.Value = DateTime.Parse(gvMachineList.GetFocusedRowCellValue("DateProduct").ToString());
			}
			catch (Exception)
			{


			}
		}

		private void gvMachineList_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
			{
				int id = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Id"]).ToString());
				int status = MachineDAO.Instance.GetItem(id).StatusMachine;
				if (status == 10)
				{
					e.Appearance.BackColor = Color.Gray;
				}
			}
		}
	}
}