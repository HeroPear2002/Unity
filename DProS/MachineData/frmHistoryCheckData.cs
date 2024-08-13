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

namespace DProS.MachineData
{
	public partial class frmHistoryCheckData : DevExpress.XtraEditors.XtraForm
	{
		List<HistoryCheckDataDTO> listHistory = new List<HistoryCheckDataDTO>();
		List<MoldDTO> listMold = new List<MoldDTO>();
		List<DataCheckDTO> listDataCheck = new List<DataCheckDTO>();
		List<CateDataDefaultDTO> listCate = new List<CateDataDefaultDTO>();
		List<SetupDefaultDTO> listSetup = new List<SetupDefaultDTO>();
		public frmHistoryCheckData()
		{
			InitializeComponent();
			LoadControl();
		}
		private void LoadControl()
		{
			SetDateTimePickers();
			LoadComboBox();
			gcHistoryCheckData.DataSource = null;
		}

		private void LoadComboBox()
		{
			listMold = MoldDAO.Instance.GetListMold();
			cbMoldCode.DataSource = listMold;
			cbMoldCode.DisplayMember = "MoldCode";
			cbMoldCode.ValueMember = "Id";
		}
		private void LoadData()
		{
			string moldCode = cbMoldCode.Text;
			string machineCode = cbMachineCode.Text;
			DateTime dateFrom = dtpFromDate.Value;
			DateTime dateTo = dtpToDate.Value;
			if (machineCode == "")
			{
				MessageBox.Show("BẠN PHẢI CHỌN MÃ KHUÔN VÀ MÃ MÁY.");
				return;
			}
			else if (dateFrom > dateTo || dateFrom > DateTime.Now)
			{
				MessageBox.Show("BẠN CHỌN NGÀY XEM KHÔNG HỢP LÝ.");
				return;
			}
			listHistory = DataCheckDAO.Instance.GetListHistory(moldCode, machineCode, dateFrom, dateTo);
			gcHistoryCheckData.DataSource = listHistory;
		}
		private void SetDateTimePickers()
		{
			DateTime today = DateTime.Now;
			dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
			DateTime lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
			dtpToDate.Value = lastDayOfMonth;
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int count = 0;
				foreach (var item in gvHistoryDataCheck.GetSelectedRows())
				{
					long id = long.Parse(gvHistoryDataCheck.GetRowCellValue(item, "Id").ToString());
					float valueReal = float.Parse(gvHistoryDataCheck.GetRowCellValue(item, "ValueReal").ToString());
					string note = gvHistoryDataCheck.GetRowCellValue(item, "Note").ToString();
					bool update = DataCheckDAO.Instance.Update(id, valueReal, note);
					if (update) count++;
				}
				if (count > 0) MessageBox.Show("Bạn đã Sửa thành công.".ToUpper());
				else MessageBox.Show("SỬA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI SỬA.");
			}
			LoadControl();
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			if(gcHistoryCheckData.DataSource == null)
			{
				MessageBox.Show("BẠN CẦN TÌM TRƯỚC KHI IN FILE EXCEL");
				return;
			}
			GridView view = gcHistoryCheckData.FocusedView as GridView;
			if (view == null) return;
			view.OptionsSelection.EnableAppearanceHideSelection = false;
			view.BestFitColumns();
			ExportWithSaveFileDialog(view, exportSelected: false, exportFiltered: true);
			LoadControl();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvHistoryDataCheck.GetSelectedRows())
				{
					long id = long.Parse(gvHistoryDataCheck.GetRowCellValue(item, "Id").ToString());
					bool delete = DataCheckDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper());
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA");
			}
			LoadControl();
		}

		private void btnSee_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			string moldcode = cbMoldCode.Text;
			listSetup = SetupDefaultDAO.Instance.GetItem(moldcode);
			cbMachineCode.DataSource = listSetup;
			cbMachineCode.DisplayMember = "MachineCode";
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
					MessageBox.Show("Export successful!".ToUpper());
				}
			}
		}
	}
}