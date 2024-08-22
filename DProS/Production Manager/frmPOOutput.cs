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
    public partial class frmPOOutput : DevExpress.XtraEditors.XtraForm
    {
		List<POOutputDTO> listPOOutput = new List<POOutputDTO>();
        public frmPOOutput()
        {
            InitializeComponent();
			LoadControl();
        }

		private void LoadControl()
		{
			SetDateTimePickers();
			LoadData();
		}

		private void LoadData()
		{
			listPOOutput = POOutputDAO.Instance.GetList().Where(x => x.DateOutput >= dtpkDateFrom.Value && x.DateOutput <= dtpkDateTo.Value).ToList();
			gcPOOutput.DataSource = listPOOutput;
		}

		private void btnSee_Click(object sender, EventArgs e)
		{
			frmImpEmCode from = new frmImpEmCode("new");
			from.ShowDialog();
			frmExportWareHousePart f = new frmExportWareHousePart();
			f.ShowDialog();

			//LoadData();
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcPOOutput.FocusedView as GridView;
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
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}
		private void SetDateTimePickers()
		{
			DateTime today = DateTime.Now;
			dtpkDateFrom.Value = new DateTime(today.Year, today.Month, 1);
			DateTime lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
			dtpkDateTo.Value = lastDayOfMonth;
		}
	}
}