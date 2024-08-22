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

namespace DProS.Production_Manager
{
	public partial class frmDeliveryDetail : DevExpress.XtraEditors.XtraForm
	{
		List<DeliveryDetailDTO> deliveryDetailDTOs = new List<DeliveryDetailDTO>();
		List<POFixDTO> listPOFix = new List<POFixDTO>();
		long IdDe;
		public frmDeliveryDetail()
		{
			InitializeComponent();
			LoadControl();
		}
		public frmDeliveryDetail(long idDe)
		{
			InitializeComponent();
			IdDe = idDe;
			this.Name = "CHI TIẾT BBGH SỐ " + IdDe.ToString();
			LoadControl();
		}
		private void LoadGridLookUpEdit()
		{
			POFixDTO DTO = POFixDAO.Instance.GetItemDe(IdDe);
			if (DTO != null) listPOFix = POFixDAO.Instance.GetList(DTO.FactoryCustomer, DTO.FacCode, int.Parse(DTO.CarNumber), DTO.DateOut).Where(x => x.IdDe == "").ToList();
			else listPOFix = POFixDAO.Instance.GetList().Where(x => x.IdDe == "").ToList();
			glPOFix.Properties.DataSource = listPOFix;
			glPOFix.Properties.DisplayMember = "POCode";
			glPOFix.Properties.ValueMember = "Id";
		}
		private void LoadControl()
		{
			LoadData();
			LoadGridLookUpEdit();
			btnInsert.Enabled = false;
			LoadCheck();
		}

		private void LoadData()
		{
			deliveryDetailDTOs = DeliveryDetailDAO.Instance.GetList(IdDe);
			foreach (DeliveryDetailDTO item in deliveryDetailDTOs)
			{
				if (item.Quantity == item.QuantityOut && (item.Status == 1 || item.Status == 4))
				{
					POFixDAO.Instance.Update(item.Id, 2, item.Quantity);
				}
				else if (item.Quantity != item.QuantityOut && (item.Status == 1 || item.Status == 4))
				{
					POFixDAO.Instance.Update(item.Id, 4, item.QuantityOut);
				}
			}
			gcDeliveryDetail.DataSource = deliveryDetailDTOs;
		}
		private void LoadCheck()
		{
			List<DeliveryDetailDTO> listDe = new List<DeliveryDetailDTO>();
			listDe = DeliveryDetailDAO.Instance.GetList(IdDe);
			int count = 0;
			int status = DeliveryNoteDAO.Instance.GetItem(IdDe).StatusDe;
			foreach (DeliveryDetailDTO item in listDe)
			{
				if (item.QuantityOut == item.Quantity && status != 3 && status!= 4 && item.Status != 3 && item.Status != 2 && item.Status != 5)
				{
					POFixDAO.Instance.Update(item.Id, 2, "PO đã xuất");
				}
				else if (item.QuantityOut != item.Quantity && (item.Status == 0 || item.Status == 1 || item.Status == 4))
				{
					POFixDAO.Instance.Update(item.Id, 4, "PO chưa xuất");
					count++;
				}
			}
			if (count == 0 && (status == 0 || status == 1))
			{
				DeliveryNoteDAO.Instance.Update(IdDe, 2, "BB đã xuất hàng");
			}
			else if (count > 0 && status != 0)
			{
				DeliveryNoteDAO.Instance.Update(IdDe, 1, "BB đang xuất hàng");
			}
			else if(listDe.Count == count)
			{
				DeliveryNoteDAO.Instance.Update(IdDe, 0, "");
			}
		}
		private void btnInsert_Click(object sender, EventArgs e)
		{
			long id = long.Parse(glPOFix.EditValue.ToString());
			int statusDe = DeliveryNoteDAO.Instance.GetItem(IdDe).StatusDe;
			if (statusDe == 3)
			{
				MessageBox.Show("BBGH đã xuất kho thành công không thể thêm PO!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else
			{
				POFixDAO.Instance.Update(id, 2,"", IdDe);
				MessageBox.Show("thêm thông tin thành công!".ToUpper());
			}
			LoadControl();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvDeliveryDetail.GetSelectedRows())
				{
					long id = long.Parse(gvDeliveryDetail.GetRowCellValue(item, "Id").ToString());
					string poCode = gvDeliveryDetail.GetRowCellValue(item, "POCode").ToString();
					int status = int.Parse(gvDeliveryDetail.GetRowCellValue(item, "Status").ToString());
					if (status == 1)
					{
						MessageBox.Show("PO " + poCode + " đã xuất kho không thể xóa?".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						if(POFixDAO.Instance.Update(id, 0,"",-1)) countid++;
					}
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcDeliveryDetail.FocusedView as GridView;
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

		private void btnExportPOInfor_Click(object sender, EventArgs e)
		{
			string a = "";
			foreach (var item in gvDeliveryDetail.GetSelectedRows())
			{
				string po = gvDeliveryDetail.GetRowCellValue(item, "POCode").ToString();
				a += po + ",";
			}
			if(a != "") txtArrayPOCode.Text = a.Substring(0, a.Length - 1);
		}

		private void glPOFix_EditValueChanged(object sender, EventArgs e)
		{
			long id = long.Parse(glPOFix.EditValue.ToString());
			POFixDTO DTO = POFixDAO.Instance.GetItem(id);
			DeliveryDetailDTO deliveryDetail = DeliveryDetailDAO.Instance.GetItem(IdDe);
			if(DTO.CarNumber == "" || DTO.FactoryCustomer =="")
			{
				MessageBox.Show("mã nhà máy hoặc số xe không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnInsert.Enabled = false;
				return;
			}
			else if (deliveryDetail == null)
			{
				btnInsert.Enabled = true;
			}
			else
			{
				string carNumber = deliveryDetail.CarNumber.ToString().ToUpper();
				string factory = deliveryDetail.FactoryCustomer.ToUpper();
				if (DTO.CarNumber == carNumber)
				{
					if (DTO.FactoryCustomer == factory)
					{
						btnInsert.Enabled = true;
					}
					else
					{
						MessageBox.Show("mã nhà máy không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						btnInsert.Enabled = false;
						return;
					}
				}
				else
				{
					MessageBox.Show("số xe không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					btnInsert.Enabled = false;
					return;
				}
			}
		}
		private void gvDeliveryDetail_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			DateTime today = DateTime.Now.Date;
			if (e.RowHandle >= 0)
			{
				int statusDe = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Status"]).ToString());
				if (statusDe == 0 || statusDe == 1 || statusDe == 4 )
				{
					e.Appearance.BackColor = Color.Yellow;
				}
				else e.Appearance.BackColor = Color.White;
			}
		}
	}
}