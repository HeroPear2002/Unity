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
using DevExpress.XtraGrid.Views.Grid;
using DAO;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace DProS.Datasource
{
    public partial class frmTem4M : DevExpress.XtraEditors.XtraForm
    {
		List<TemInforDTO> listInfor = new List<TemInforDTO>();
        public frmTem4M()
        {
            InitializeComponent();
			LoadControl();
        }

		private void LoadControl()
		{
			LoadData();
		}

		private void LoadData()
		{
			listInfor = TemInforDAO.Instance.GetList().Where(x => x.Standard == "OK").ToList();
			gc4M.DataSource = listInfor;
		}

		private void btnTemPrioritize_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn ưu tiên in mác trên máy này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gv4M.GetSelectedRows())
				{
					int id = int.Parse(gv4M.GetRowCellValue(item, "Id").ToString());
					TemInforDAO.Instance.Update(id, 1);
				}
				LoadData();
			}
		}

		private void btnRemoveMacPrioritize_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn bỏ ưu tiên in mác trên máy này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gv4M.GetSelectedRows())
				{
					int id = int.Parse(gv4M.GetRowCellValue(item, "Id").ToString());
					TemInforDAO.Instance.Update(id, 0);
				}
			}
		}

		private void btnExpExcel_Click(object sender, EventArgs e)
		{
			GridView view = gc4M.FocusedView as GridView;
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

		private void gv4M_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
			{

				int id = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Id"]).ToString());
				int akun = TemInforDAO.Instance.GetItem(id).CavStyle;
				if (akun == 1)
				{
					e.Appearance.BackColor = Color.Orange;
					e.Appearance.ForeColor = Color.White;
				}

			}
		}
	}
}