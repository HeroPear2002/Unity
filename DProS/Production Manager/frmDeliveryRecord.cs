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
using DAO;
using DTO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace DProS.Production_Manager.PO_Manager
{
    public partial class frmDeliveryRecord : DevExpress.XtraEditors.XtraForm
    {
		List<DeliveryNoteDTO> listDelivery = new List<DeliveryNoteDTO>();
        public frmDeliveryRecord()
        {
            InitializeComponent();
			LoadControl();
		}

		private void LoadControl()
		{
			SetDateTimePickers();
			LoadData();
			LoadStatusAsync();
		}

		private void LoadData()
		{
			DateTime dateFrom = dtpkDateFrom.Value;
			DateTime dateTo = dtpkDateTo.Value;
			listDelivery = DeliveryNoteDAO.Instance.GetList().Where(x => x.DateInput >= dateFrom && x.DateInput <= dateTo).ToList();
			gcDeliveryNote.DataSource = listDelivery;
		}
		private void SetDateTimePickers()
		{
			DateTime today = DateTime.Now;
			dtpkDateFrom.Value = new DateTime(today.Year, today.Month, 1);
			DateTime lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
			dtpkDateTo.Value = lastDayOfMonth;
		}
		async void LoadStatusAsync()
		{
			await LoadStatus();
		}
		public static async Task LoadStatus()
		{
			await Task.Run(() =>
			{
				List<DeliveryNoteDTO> listDe = new List<DeliveryNoteDTO>();
				listDe = DeliveryNoteDAO.Instance.GetList().Where(x => x.StatusDe != 4 ).ToList();
				foreach (DeliveryNoteDTO item in listDe)
				{
					int a = (int)(DateTime.Now - (DateTime)item.DateDelivery).TotalHours;
					if (a >= 12 && item.StatusDe == 2)
					{
						DeliveryNoteDAO.Instance.Update(item.Id, 3, "BB chưa được giao");
					}
					else if(item.StatusDe == 2)
					{
						int count = 0;
						List<DeliveryDetailDTO> listDetail = new List<DeliveryDetailDTO>();
						listDetail = DeliveryDetailDAO.Instance.GetList(item.Id);
						foreach (DeliveryDetailDTO jtem in listDetail)
						{
							if (jtem.Status == 1 && (jtem.QuantityOut != jtem.Quantity))
							{
								POFixDAO.Instance.Update(jtem.Id, 1, "PO đã làm BBGH");
								DeliveryNoteDAO.Instance.Update(item.Id, 1, "BB đang xuất hàng");
								count++;
							}
						}
						if (item.EmOut.Length > 0 && count == 0)
						{
							DeliveryNoteDAO.Instance.Update(item.Id, 2, "BB đã xuất hàng");
						}
					}
						
				}
			});
		}
		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvDeliveryNote.GetSelectedRows())
				{
					long id = long.Parse(gvDeliveryNote.GetRowCellValue(item, "Id").ToString());
					POFixDAO.Instance.Update(id);
					bool delete = DeliveryNoteDAO.Instance.Delete(id);
					if (delete) countid++;
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

		private void btnPrintDelivery_Click(object sender, EventArgs e)
		{
			try
			{
				List<DeliveryPrintDTO> listDP = new List<DeliveryPrintDTO>();
				long id = long.Parse(gvDeliveryNote.GetRowCellValue(gvDeliveryNote.FocusedRowHandle, gvDeliveryNote.Columns["Id"]).ToString());
				string DeCode = gvDeliveryNote.GetRowCellValue(gvDeliveryNote.FocusedRowHandle, gvDeliveryNote.Columns["DeCode"]).ToString() + "&" + id;
				DateTime dateDelivery = DateTime.Parse(gvDeliveryNote.GetRowCellValue(gvDeliveryNote.FocusedRowHandle, gvDeliveryNote.Columns["DateDelivery"]).ToString());
				string dateOut = dateDelivery.ToString("dd/MM/yyyy");
				string time = dateDelivery.ToString("hh:mm");
				List<DeliveryDetailDTO> listDetail = DeliveryDetailDAO.Instance.GetList(id);
				int i = 0;
				int sum = 0;
				foreach (DeliveryDetailDTO item in listDetail)
				{
					i++;
					POFixDTO pOFixDTO = POFixDAO.Instance.GetItem(item.Id);
					PartDTO DTO = PartDAO.Instance.GetItem(item.PartCode);
					string PartName = DTO.PartName;
					int countPart = DTO.CountPart;
					int countBox = (int)Math.Ceiling((Double)item.Quantity / countPart);
					if (countPart == 0)
					{
						countBox = 0;
					}
					listDP.Add(new DeliveryPrintDTO(i, DeCode.ToUpper(), item.POCode, item.PartCode, PartName, item.Quantity, countPart, countBox, pOFixDTO.FactoryCustomer, dateOut, time, pOFixDTO.CarNumber));
					sum += countBox;
				}
				rpDeliveryNote report = new rpDeliveryNote(id);
				report.DataSource = listDP;
				report.PrintDialog();
			}
			catch (Exception)
			{
			}
		}
		private void btnWatchDetail_Click(object sender, EventArgs e)
		{
			long id = long.Parse(gvDeliveryNote.GetFocusedRowCellValue("Id").ToString());
			frmDeliveryDetail form = new frmDeliveryDetail(id);
			form.ShowDialog();
			LoadControl();
		}

		private void btnApplyDeliverry_Click(object sender, EventArgs e)
		{
			frmImpEmCode form = new frmImpEmCode("mix");
			form.ShowDialog();
			frmApproveDelivery f = new frmApproveDelivery();
			f.ShowDialog();
		}

		private void btnSee_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void gvDeliveryNote_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			DateTime today = DateTime.Now.Date;
			if (e.RowHandle >= 0)
			{
				int statusDe = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusDe"]).ToString());
				if (statusDe == 0 || statusDe == 1)
				{
					e.Appearance.BackColor = Color.Yellow;
				}
				else if (statusDe == 3)
				{
					e.Appearance.BackColor = Color.Red;
				}
				else if (statusDe == 4 || statusDe == 2)
				{
					e.Appearance.BackColor = Color.White;
				}
			}
		}
	}
}