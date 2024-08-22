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
using DevExpress.XtraReports.UI;

namespace DProS.Production_Manager.PO_Manager
{
    public partial class frmPOFix : DevExpress.XtraEditors.XtraForm
    {
		List<POFixDTO> listPOFix = new List<POFixDTO>();
		bool insert = true;
		public frmPOFix()
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
			LoadStatus();
		}
		async void LoadStatus()
		{
			await LoadStatusPOFix(dtpkDateOut.Value.Date);
		}
		public static async Task LoadStatusPOFix(DateTime today)
		{
			await Task.Run(() =>
			{
				DateTime todayNow = DateTime.Now;
				List<POFixDTO> listPOFix = POFixDAO.Instance.GetList()
				.Where(x => x.DateOut.Year == today.Year && x.DateOut.Month == today.Month).ToList();
				foreach (POFixDTO item in listPOFix)
				{
					long id = item.Id;
					int statusCheck = POFixDAO.Instance.GetItem(id).Status;
					DateTime dateOut = item.DateOut;
					long idPOInput = item.IdPOInput;
					string customer = POInputDAO.Instance.GetItem(idPOInput).CusCode;
					int warn = CustomerDAO.Instance.GetItem(customer).WarnPOFix;
					double a = (todayNow - dateOut).TotalHours;
					if (a >= -warn && statusCheck == 0)
					{
						POFixDAO.Instance.Update(id, 4, "PO chưa xuất");
					}
					else if (a < -warn && statusCheck == 1)
					{
						POFixDAO.Instance.Update(id, 1, "PO đã làm BBGH");
					}
					else if (a >= -warn && statusCheck == 1)
					{
						POFixDAO.Instance.Update(id, 4, "PO làm BBGH nhưng chưa xuất");
					}
					else if (statusCheck == 2 && a >= 12)
					{
						POFixDAO.Instance.Update(id, 5, "PO chưa giao");
					}
					else if (statusCheck == 3)
					{
						POFixDAO.Instance.Update(id, 3, "PO đã giao");
					}
					else if (statusCheck == 5)
					{
						long idDe = long.Parse(item.IdDe.ToString());
						int statDe = DeliveryNoteDAO.Instance.GetItem(idDe).StatusDe;
						if (statDe == 4)
						{
							POFixDAO.Instance.Update(id, 3, "PO đã giao");
						}
						else if (a <= 12)
						{
							POFixDAO.Instance.Update(id, 2, "PO đã xuất");
						}
					}
					
				}
			});
		}
		private void LoadComboBox()
		{
			var gridView = glPOInput.Properties.View;
			gridView.Columns.Clear();
			gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = "POCode", Caption = "Mã PO", Visible = true });
			gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = "PartCode", Caption = "Mã linh kiện", Visible = true });
			gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = "QuantityIn", Caption = "Số lượng", Visible = true });
			gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = "CusCode", Caption = "Mã khách hàng", Visible = true });
			gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = "Price", Caption = "Đơn giá", Visible = true });
			glPOInput.Properties.DataSource = POInputDAO.Instance.GetList();
			glPOInput.Properties.DisplayMember = "POCode";
			glPOInput.Properties.ValueMember = "Id";
		}
		private void LoadDataMonth(int month, int year)
		{
			listPOFix = POFixDAO.Instance.GetList().Where(x => x.DateOut.Year == year && x.DateOut.Month == month).ToList();
			gcPOFix.DataSource = listPOFix;
		}

		private void CleanText()
		{
			txtCarNumber.Text = string.Empty;
			txtFactoryCustomer.Text = string.Empty;
			txtPartCode.Text = string.Empty;
			txtPrice.Text = string.Empty;
		}
		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				glPOInput.Enabled = false;
				txtCarNumber.Enabled = false;
				txtFactoryCustomer.Enabled = false;
				txtPartCode.Enabled = false;
				txtPrice.Enabled = false;
				nudQuantity.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				glPOInput.Enabled = true;
				txtCarNumber.Enabled = true;
				txtFactoryCustomer.Enabled = true;
				nudQuantity.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			long idPOInput = long.Parse(glPOInput.EditValue.ToString());
			string factoryCustomer = txtFactoryCustomer.Text;
			int carNumber = 0;
			if (txtCarNumber.Text != "")
			{
				carNumber = int.Parse(txtCarNumber.Text);
			}
			int quantity = int.Parse(nudQuantity.Value.ToString());
			POInputDTO DTO = POInputDAO.Instance.GetItem(idPOInput);
			int sum = POFixDAO.Instance.GetQuantity(idPOInput);
			DateTime dateOut = dtpkDateOut.Value;
			if (insert)
			{
				if (quantity + sum > DTO.QuantityIn)
				{
					MessageBox.Show("SỐ LƯỢNG GIAO POFIX PHẢI NHỎ HƠN HOẶC BẰNG SỐ LƯỢNG CÒN LẠI TRONG POINPUT".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				bool insertPOFix = POFixDAO.Instance.Insert(idPOInput, quantity, dateOut, factoryCustomer, carNumber);
				if (insertPOFix)
				{
					MessageBox.Show("Bạn đã thêm thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				MessageBox.Show("Bạn thêm bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				long id = long.Parse(gvPOFix.GetFocusedRowCellValue("Id").ToString());
				int quantityOLD = POFixDAO.Instance.GetItem(id).Quantity;
				if (quantity + sum - quantityOLD > DTO.QuantityIn)
				{
					MessageBox.Show("SỐ LƯỢNG GIAO POFIX PHẢI NHỎ HƠN HOẶC BẰNG SỐ LƯỢNG CÒN LẠI TRONG POINPUT".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				bool updatePOFix = POFixDAO.Instance.Update(id, idPOInput, quantity, dateOut, factoryCustomer, carNumber);
				if (updatePOFix)
				{
					MessageBox.Show("Bạn đã sửa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				MessageBox.Show("Bạn sửa bị thất bại.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				foreach (var item in gvPOFix.GetSelectedRows())
				{
					int id = int.Parse(gvPOFix.GetRowCellValue(item, "Id").ToString());
					bool delete = POFixDAO.Instance.Delete(id);
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

		private void btnInsertDe_Click(object sender, EventArgs e)
		{
			string factoryCustomer = "";
			string facCode = "";
			string carNumber = "";
			string dateOut = "";
			int count = 0;
			int page = 1;
			string formattedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
			foreach (var item in gvPOFix.GetSelectedRows())
			{
				string idDe = gvPOFix.GetRowCellValue(item,"IdDe").ToString();
				if (idDe.Trim().TrimStart().TrimEnd() != "")
				{
					string POFix = gvPOFix.GetRowCellValue(item, "POCode").ToString();
					MessageBox.Show("Mã PO " + POFix + " này đã thêm vào BBGH rồi \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if(facCode != gvPOFix.GetRowCellValue(item, "FacCode").ToString() && facCode != "")
				{
					MessageBox.Show("nhà máy sản xuất không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if (factoryCustomer != gvPOFix.GetRowCellValue(item, "FactoryCustomer").ToString() && factoryCustomer != "")
				{
					MessageBox.Show("nhà máy giao hàng không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if (carNumber != gvPOFix.GetRowCellValue(item, "CarNumber").ToString() && carNumber != "")
				{
					MessageBox.Show("nhà máy sản xuất không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if (dateOut != gvPOFix.GetRowCellValue(item, "DateOut").ToString() && dateOut != "")
				{
					MessageBox.Show("nhà máy sản xuất không trùng nhau \nbạn hãy kiển tra lại.".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{
					facCode = gvPOFix.GetRowCellValue(item, "FacCode").ToString();
					factoryCustomer = gvPOFix.GetRowCellValue(item, "FactoryCustomer").ToString();
					carNumber = gvPOFix.GetRowCellValue(item, "CarNumber").ToString();
					dateOut = gvPOFix.GetRowCellValue(item, "DateOut").ToString();
					if (count % 20 == 0)
					{
						DeliveryNoteDAO.Instance.Insert("DD"+formattedDateTime + "-" + page.ToString(), DateTime.Now, "admin", "", 0, "BB chưa được xuất", DateTime.Parse(dateOut));
						count = 0;
						page++;
					}
					long MaxId = DeliveryNoteDAO.Instance.MaxIdDelivery();
					long idPOFix = long.Parse(gvPOFix.GetRowCellValue(item, "Id").ToString());
					POFixDAO.Instance.Update(idPOFix, 1, "PO đã làm BBGH", MaxId);
					count++;
				}
			}
			MessageBox.Show("Thêm biên bản thành công!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			LoadControl();
		}

		private void btnSeeMonth_Click(object sender, EventArgs e)
		{
			int month = dtpkDateOut.Value.Month;
			int year = dtpkDateOut.Value.Year;
			LoadDataMonth(month, year);
		}

		private void btnPrintPO_Click(object sender, EventArgs e)
		{
			List<POFixDTO> listP = new List<POFixDTO>();
			foreach (var item in gvPOFix.GetSelectedRows())
			{
				POFixDTO DTO = null;
				int id = int.Parse(gvPOFix.GetRowCellValue(item, "Id").ToString());
				DTO = POFixDAO.Instance.GetItem(id);
				listP.Add(DTO);
			}
			rpPOFix report = new rpPOFix();
			report.DataSource = listP;
			report.PrintDialog();
		}

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmPOFixSampleForm sampleform = new frmPOFixSampleForm();
			sampleform.ShowDialog();
			LoadControl();
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcPOFix.FocusedView as GridView;
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
			frmPOFixImportFile importFile = new frmPOFixImportFile();
			importFile.ShowDialog();
			LoadControl();
		}

		private void glPOInput_EditValueChanged(object sender, EventArgs e)
		{
			long id = long.Parse(glPOInput.EditValue.ToString());
			POInputDTO DTO = POInputDAO.Instance.GetItem(id);
			txtPartCode.Text = DTO.PartCode;
			txtPrice.Text = DTO.Price.ToString();
			nudQuantity.Value = DTO.QuantityRemai;
		}

		private void gvPOFix_Click(object sender, EventArgs e)
		{
			try
			{
				glPOInput.EditValue = gvPOFix.GetFocusedRowCellValue("IdPOInput").ToString();
				txtCarNumber.Text = gvPOFix.GetFocusedRowCellValue("CarNumber").ToString();
				txtFactoryCustomer.Text = gvPOFix.GetFocusedRowCellValue("FactoryCustomer").ToString();
				nudQuantity.Value = int.Parse(gvPOFix.GetFocusedRowCellValue("Quantity").ToString());
				dtpkDateOut.Value = DateTime.Parse(gvPOFix.GetFocusedRowCellValue("DateOut").ToString());
			}
			catch (Exception)
			{


			}
		}

		private void gvPOFix_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			DateTime today = DateTime.Now;
			if (e.RowHandle >= 0)
			{
				int statusCheck = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Status"]).ToString());
				switch (statusCheck)
				{
					case 1:
						e.Appearance.BackColor = Color.Pink;
						break;
					case 2:
						e.Appearance.BackColor = Color.Yellow;
						break;
					case 3:
						e.Appearance.BackColor = Color.White;
						break;
					case 4:
						e.Appearance.BackColor = Color.Red;
						break;
					case 5:
						e.Appearance.BackColor = Color.GreenYellow;
						break;
					default:
						break;
				}
			}
		}
	}
}