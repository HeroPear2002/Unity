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

namespace DProS.Production_Manager.Oder_Manager 
{
    public partial class frmPriceMat : DevExpress.XtraEditors.XtraForm
    {
		List<PriceMatDTO> listPrice = new List<PriceMatDTO>();
		List<MaterialDTO> listMat = new List<MaterialDTO>();
        public frmPriceMat()
        {
            InitializeComponent();
			LoadGridLookUpEdit();
			LoadControl();
		}
		public bool IsInsert = false;
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadDataMonth(DateTime.Now);
		}
		void LoadData()
		{
			listPrice = PriceMatDAO.Instance.GetList();
			gcPriceMat.DataSource = listPrice;
		}
		void LoadDataMonth(DateTime date)
		{
			listPrice = PriceMatDAO.Instance.GetList().Where(x => x.DateInput.Month == date.Month && x.DateInput.Year == date.Year).ToList();
			gcPriceMat.DataSource = listPrice;
		}
		void LoadGridLookUpEdit()
		{
			listMat = MaterialDAO.Instance.Getlist();
			glMatCode.Properties.DataSource = listMat;
			glMatCode.Properties.DisplayMember = "MatCode";
			glMatCode.Properties.ValueMember = "Id";
		}
		private void CleanText()
		{
			txtPriceVND.Text = string.Empty;
			txtPriceUSD.Text = string.Empty;
			txtNote.Text = string.Empty;
			dtpkDateInput.Value = DateTime.Now;
		}

		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtNote.Enabled = false;
				txtPriceUSD.Enabled = false;
				txtPriceVND.Enabled = false;
				glMatCode.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtNote.Enabled = true;
				txtPriceUSD.Enabled = true;
				txtPriceVND.Enabled = true;
				glMatCode.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			int idMat = int.Parse(glMatCode.EditValue.ToString());
			DateTime dateInput = dtpkDateInput.Value;
			decimal priceVND = decimal.Parse(txtPriceVND.Text);
			string priceUSD = txtPriceUSD.Text;
			string note = txtNote.Text;
			if (IsInsert)
			{
				if (PriceMatDAO.Instance.GetItem(glMatCode.Text, dateInput) == null)
				{
					bool insert = PriceMatDAO.Instance.Insert(idMat, dateInput, priceVND, priceUSD, 0, note);
					if (insert)
					{
						MessageBox.Show("Bạn đã thêm thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Nguyên liệu này đã tồn tại hãy nhập nguyên liệu khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				long id = long.Parse(gvPriceMat.GetFocusedRowCellValue("Id").ToString());
				if (PriceMatDAO.Instance.GetItem(glMatCode.Text, dateInput) == null || PriceMatDAO.Instance.GetItem(glMatCode.Text, dateInput).Id == id)
				{
					bool update = PriceMatDAO.Instance.Update(id, idMat, dateInput, priceVND, priceUSD, note);
					if (update)
					{
						MessageBox.Show("Bạn đã sửa thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Nguyên liệu này đã tồn tại hãy nhập nguyên liệu khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = true;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvPriceMat.GetSelectedRows())
				{
					long id = long.Parse(gvPriceMat.GetRowCellValue(item, "Id").ToString());
					bool delete = PriceMatDAO.Instance.Delete(id);
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

		private void btnSee_Click(object sender, EventArgs e)
		{
			LoadDataMonth(dtpkDateInput.Value);
		}

		private void btnSeeAll_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn phê duyệt thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gvPriceMat.GetSelectedRows())
				{
					long id = long.Parse(gvPriceMat.GetRowCellValue(item, "Id").ToString());
					PriceMatDAO.Instance.Update(id, 1);
				}
				LoadControl();
			}
		}

		private void btnImportExcel_Click(object sender, EventArgs e)
		{
			frmPriceMatImport form = new frmPriceMatImport();
			form.ShowDialog();
			LoadControl();
		}

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmPriceMatSample form = new frmPriceMatSample();
			form.ShowDialog();
			LoadControl();
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcPriceMat.FocusedView as GridView;
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

		private void gvPriceMat_Click(object sender, EventArgs e)
		{
			try
			{
				txtPriceVND.Text = gvPriceMat.GetFocusedRowCellValue("PriceVND").ToString();
				txtPriceUSD.Text = gvPriceMat.GetFocusedRowCellValue("PriceUSD").ToString();
				txtNote.Text = gvPriceMat.GetFocusedRowCellValue("Note").ToString();
				dtpkDateInput.Text = gvPriceMat.GetFocusedRowCellValue("DateInput").ToString();
				string matCode = gvPriceMat.GetFocusedRowCellValue("MatCode").ToString();
				glMatCode.EditValue = MaterialDAO.Instance.GetItem(matCode).Id;
			}
			catch (Exception)
			{
			}
		}

		private void gvPriceMat_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.RowHandle >= 0)
			{
				int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusPrice"]).ToString());
				if (status == 0)
				{
					e.Appearance.BackColor = Color.Orange;
				}
			}
		}

		private void txtPriceUSD_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
			 (e.KeyChar == '.' && (txtPriceUSD.Text.Length == 0 || txtPriceUSD.Text.IndexOf('.') != -1))))
				e.Handled = true;
		}
	}
}