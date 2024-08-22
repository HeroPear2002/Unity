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
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Export;

namespace DProS.Production_Manager.PO_Manager
{
    public partial class frmPOInput : DevExpress.XtraEditors.XtraForm
    {
		List<POInputDTO> listPOInput = new List<POInputDTO>();
		bool insert = true;
		public frmPOInput()
        {
            InitializeComponent();
			LoadControl();
			LoadComboBox();
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadDataMonth(DateTime.Now.Month, DateTime.Now.Year);
			LoadAsycLoadStatus();
			LoadAsyc();
		}
		async void LoadAsycLoadStatus()
		{
			await LoadStatus();

		}
		async void LoadAsyc()
		{
			await LoadUpdatePO(dtpkDateOutput.Value);
		}
		private void LoadComboBox()
		{
			cbCustomerCode.DataSource = CustomerDAO.Instance.Getlist();
			cbCustomerCode.DisplayMember = "CusCode";
			cbCustomerCode.ValueMember = "Id";
			cbFactoryCode.DataSource = FactoryDAO.Instance.GetList().Select(f => f.FacCode).Distinct().ToList(); ;
			cbFactoryCode.DisplayMember = "FacCode";
			cbPartCode.DataSource = PartDAO.Instance.Getlist();
			cbPartCode.DisplayMember = "PartCode";
			cbPartCode.ValueMember = "Id";
		}
		private void LoadDataAll()
		{
			listPOInput = POInputDAO.Instance.GetList();
			gcPOInput.DataSource = listPOInput;
		}
		private void LoadDataMonth(int month, int year)
		{
			listPOInput = POInputDAO.Instance.GetList().Where(x => x.DateOut.Year == year && x.DateOut.Month == month).ToList();
			gcPOInput.DataSource = listPOInput;
		}

		private void CleanText()
		{
			txtPOCode.Text = string.Empty;
			txtPrice.Text = string.Empty;
			cbCustomerCode.Text = string.Empty;
			cbFactoryCode.Text = string.Empty;
			cbPartCode.Text = string.Empty;
		}
		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtPOCode.Enabled = false;
				txtPrice.Enabled = false;
				cbCustomerCode.Enabled = false;
				cbFactoryCode.Enabled = false;
				cbPartCode.Enabled = false;
				nudQuantityIn.Enabled = false;
				dtpkDateInput.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtPOCode.Enabled = true;
				txtPrice.Enabled = true;
				cbCustomerCode.Enabled = true;
				cbFactoryCode.Enabled = true;
				cbPartCode.Enabled = true;
				nudQuantityIn.Enabled = true;
				dtpkDateInput.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		public static async Task LoadStatus()
		{
			await Task.Run(() =>
			{
				List<POInputDTO> listP = POInputDAO.Instance.GetList();
				DateTime today = DateTime.Now;
				foreach (POInputDTO item in listP)
				{
					if (item.QuantityRemai == 0)
					{
						POInputDAO.Instance.UpdateStatusPO(item.Id, 1);
					}
					else
					{
						int warn = CustomerDAO.Instance.GetItem(item.CusCode).WarnInputPO;
						int a = (int)(item.DateOut.Date - today.Date).TotalDays;
						if (a == 0)
						{
							POInputDAO.Instance.UpdateStatusPO(item.Id, 3);
						}
						else if (a < 0)
						{
							POInputDAO.Instance.UpdateStatusPO(item.Id, 4);
						}
						else if (a <= warn)
						{
							POInputDAO.Instance.UpdateStatusPO(item.Id, 2);
						}
						else if (a > warn && item.StatusPO != 1)
						{
							POInputDAO.Instance.UpdateStatusPO(item.Id, 0);
						}
					}
				}
			});
		}
		public static async Task LoadUpdatePO(DateTime today)
		{
			await Task.Run(() =>
			{
				List<POInputDTO> listP = new List<POInputDTO>();
				DateTime date1 = today.AddDays(1 - today.Day);
				DateTime date2 = date1.AddMonths(1).AddSeconds(-10);
				listP = POInputDAO.Instance.GetList()
				.Where(x => x.DateOut.Year == today.Year && x.DateOut.Month == today.Month).ToList();
				foreach (POInputDTO item in listP.Where(x => x.StatusPO == 2).ToList())
				{
					List<DateTime> listO = POOutputDAO.Instance.GetListOnlyDateOut(item.Id);
					if (listO.Count == 0)
					{
						POInputDAO.Instance.UpdateStatusPO(item.Id, 0);
						POInputDAO.Instance.Update(item.Id, 0);
					}
					else
					{
						int sum = POOutputDAO.Instance.SumQuantityOut(item.Id);
						if (sum == item.QuantityIn)
						{
							POInputDAO.Instance.UpdateStatusPO(item.Id, 1);
							POInputDAO.Instance.Update(item.Id, item.QuantityOut);
						}
					}
				}
				foreach (POInputDTO item in listP.Where(x => x.StatusPO == 1).ToList())
				{
					int sum = POOutputDAO.Instance.SumQuantityOut(item.Id);
					if (sum != item.QuantityIn)
					{
						POInputDAO.Instance.UpdateStatusPO(item.Id, 0);
					}
				}
			});
		}
		void Save()
		{
			string pOCode = txtPOCode.Text;
			if (pOCode.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập mã PO.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string cusCode = cbCustomerCode.SelectedValue.ToString();
			string facCode = cbFactoryCode.SelectedValue.ToString();
			int idPart = int.Parse(cbPartCode.SelectedValue.ToString());
			int idFactory = FactoryDAO.Instance.GetItem(facCode, cusCode).Id;
			int idCustomer = int.Parse(cbCustomerCode.SelectedValue.ToString());
			int quantityIn = int.Parse(nudQuantityIn.Value.ToString());
			float price = float.Parse(txtPrice.Text);
			DateTime dateInput = dtpkDateInput.Value;
			DateTime dateOut = dtpkDateOutput.Value;
			if (dateInput > dateOut)
			{
				MessageBox.Show("Ngày nhập phải trước hoặc bằng ngày giao.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (insert)
			{
				if (POInputDAO.Instance.GetItem(pOCode, cbPartCode.Text, price) == null)
				{
					bool insertPOInput = POInputDAO.Instance.Insert(pOCode, idPart, quantityIn, dateInput, 0 , idFactory, price, dateOut, idCustomer, 0);
					if (insertPOInput)
					{
						MessageBox.Show("Bạn đã thêm thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Mã máy này đã tồn tại hãy nhập mãy máy khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}
			else
			{
				long id = long.Parse(gvPOInput.GetFocusedRowCellValue("Id").ToString());
				if (POInputDAO.Instance.GetItem(pOCode, cbPartCode.Text, price) == null || POInputDAO.Instance.GetItem(pOCode, cbPartCode.Text, price).Id == id)
				{
					bool updatePOInput = POInputDAO.Instance.Update(id, pOCode, idPart, quantityIn, dateInput, 0, idFactory, price, dateOut, idCustomer, 0);
					if (updatePOInput)
					{
						MessageBox.Show("Bạn đã sửa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else MessageBox.Show("Mã máy này đã tồn tại hãy nhập mãy máy khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				foreach (var item in gvPOInput.GetSelectedRows())
				{
					long id = long.Parse(gvPOInput.GetRowCellValue(item, "Id").ToString());
					POFixDAO.Instance.DeleteWherePOInput(id);
					bool delete = POInputDAO.Instance.Delete(id);
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

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void btnSeeAllPO_Click(object sender, EventArgs e)
		{
			LoadDataAll();
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcPOInput.FocusedView as GridView;
			if (view == null) return;
			view.OptionsSelection.EnableAppearanceHideSelection = false;
			view.BestFitColumns();
			ExportWithSaveFileDialog(view, exportSelected: false, exportFiltered: true);
			LoadControl();
		}
		private void ExportWithSaveFileDialog(GridView view, bool exportSelected, bool exportFiltered)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", Title = "Export File" })
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

		private void btnImportExcel_Click(object sender, EventArgs e)
		{
			frmPOInputImportFile importFile = new frmPOInputImportFile();
			importFile.ShowDialog();
			LoadControl();
		}

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmPOInputSampleForm sampleform = new frmPOInputSampleForm();
			sampleform.ShowDialog();
			LoadControl();
		}

		private void btnSee_Click(object sender, EventArgs e)
		{
			int month = dtpkDateOutput.Value.Month;
			int year = dtpkDateOutput.Value.Year;
			LoadDataMonth(month, year);
		}

		private void gvPOInput_Click(object sender, EventArgs e)
		{
			try
			{
				txtPOCode.Text = gvPOInput.GetFocusedRowCellValue("POCode").ToString();
				txtPrice.Text = gvPOInput.GetFocusedRowCellValue("Price").ToString();
				cbCustomerCode.Text = gvPOInput.GetFocusedRowCellValue("CusCode").ToString();
				cbFactoryCode.Text = gvPOInput.GetFocusedRowCellValue("FacCode").ToString();
				cbPartCode.Text = gvPOInput.GetFocusedRowCellValue("PartCode").ToString();
				nudQuantityIn.Value = int.Parse(gvPOInput.GetFocusedRowCellValue("QuantityIn").ToString());
				dtpkDateInput.Value = DateTime.Parse(gvPOInput.GetFocusedRowCellValue("DateInput").ToString());
				dtpkDateOutput.Value = DateTime.Parse(gvPOInput.GetFocusedRowCellValue("DateOut").ToString());
			}
			catch (Exception)
			{


			}
		}

		private void gvPOInput_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			DateTime today = DateTime.Now.Date;
			if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
			{
				int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusPO"]).ToString());
				switch (status)
				{
					case 2:
						e.Appearance.BackColor = Color.GreenYellow;
						break;
					case 3:
						e.Appearance.BackColor = Color.Yellow;
						break;
					case 4:
						e.Appearance.BackColor = Color.Red;
						break;
					default:
						break;
				}
			}
		}
	}
}