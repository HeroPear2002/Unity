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

namespace DProS.Production_Manager.Box_Manager
{
    public partial class frmBox : DevExpress.XtraEditors.XtraForm
    {
		List<BoxListDTO> listBox = new List<BoxListDTO>();
        public frmBox()
        {
            InitializeComponent();
			LoadControl();
			LoadColum();
		}
		public bool IsInsert = false;
		void LoadColum()
		{
			gvBoxList.Columns["BoxIventory"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "BoxIventory", "Tổng = {0}");
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			DeleteReBox();
			LoadData();
		}
		void LoadData()
		{

			listBox = BoxListDAO.Instance.GetList();
			gcBoxList.DataSource = listBox;
			
		}
		private void CleanText()
		{
			txtBoxCode.Text = string.Empty;
			txtBoxName.Text = string.Empty;
			txtStyleBox.Text = string.Empty;
			nudBoxIventory.Value = 0;
		}

		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtBoxCode.Enabled = false;
				txtBoxName.Enabled = false;
				txtStyleBox.Enabled = false;
				nudBoxIventory.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				txtBoxCode.Enabled = true;
				txtBoxName.Enabled = true;
				txtStyleBox.Enabled = true;
				nudBoxIventory.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void Save()
		{
			string boxCode = txtBoxCode.Text;
			if (txtBoxCode.Text.Trim() == "")
			{
				MessageBox.Show("Bạn phải nhập mã hộp.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string boxName = txtBoxName.Text;
			string styleBox = txtStyleBox.Text;
			int boxIventory = int.Parse(nudBoxIventory.Value.ToString());
			if (IsInsert)
			{
				if (BoxListDAO.Instance.GetItem(boxCode) == null)
				{
					bool insert = BoxListDAO.Instance.Insert(boxCode, boxName, styleBox, boxIventory);
					if (insert)
					{
						MessageBox.Show("Bạn đã thêm thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn thêm bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Mã hộp này đã tồn tại hãy nhập mã hộp khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				int id = int.Parse(gvBoxList.GetFocusedRowCellValue("Id").ToString());
				if (BoxListDAO.Instance.GetItem(boxCode) == null || BoxListDAO.Instance.GetItem(boxCode).Id == id)
				{
					bool update = BoxListDAO.Instance.Update(id, boxCode, boxName, styleBox, boxIventory);
					if (update)
					{
						MessageBox.Show("Bạn đã sửa thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Bạn sửa bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("Mã hộp này đã tồn tại hãy nhập mã hộp khác.".ToUpper(), "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				foreach (var item in gvBoxList.GetSelectedRows())
				{
					int id = int.Parse(gvBoxList.GetRowCellValue(item, "Id").ToString());
					bool delete = BoxListDAO.Instance.Delete(id);
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

		private void btnRebox_Click(object sender, EventArgs e)
		{
			frmReBox form = new frmReBox();
			form.LamMoi += new EventHandler(btnUpdate_Click);
			form.ShowDialog();
			LoadControl();
		}

		private void btnBarCode_Click(object sender, EventArgs e)
		{
			List<BoxListDTO> listB = new List<BoxListDTO>();

			if (txtBoxCode.Text.Length > 0)
			{
				for (int i = 0; i < 52; i++)
				{
					listB.Add(new BoxListDTO(0,txtBoxCode.Text, txtBoxName.Text, txtStyleBox.Text, (int)nudBoxIventory.Value));
				}
				rpBarCodeBox report = new rpBarCodeBox();
				report.DataSource = listB;
				report.PrintDialog();
			}
			else
			{
				MessageBox.Show("bạn chưa chọn mã hộp cần in !".ToUpper());
			}
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcBoxList.FocusedView as GridView;
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
			frmBoxListImport form = new frmBoxListImport();
			form.ShowDialog();
			LoadControl();
		}

		private void gvBoxList_Click(object sender, EventArgs e)
		{
			try
			{
				txtBoxCode.Text = gvBoxList.GetFocusedRowCellValue("BoxCode").ToString();
				txtBoxName.Text = gvBoxList.GetFocusedRowCellValue("BoxName").ToString();
				txtStyleBox.Text = gvBoxList.GetFocusedRowCellValue("StyleBox").ToString();
				nudBoxIventory.Text = gvBoxList.GetFocusedRowCellValue("BoxIventory").ToString();
			}
			catch (Exception)
			{
			}
		}

		private void btnSampleForm_Click(object sender, EventArgs e)
		{
			frmBoxListSample form = new frmBoxListSample();
			form.ShowDialog();
			LoadControl();
		}
		void DeleteReBox()
		{
			DateTime today = DateTime.Today;
			ReBoxDAO.Instance.Delete(today.AddMonths(-2));
		}
	}
}