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

namespace DProS.DeviceManagement
{
	public partial class frmHistoryMainten : DevExpress.XtraEditors.XtraForm
	{
		List<HistoryDeviceDTO> listHistoryDevice = new List<HistoryDeviceDTO>();
		public frmHistoryMainten()
		{
			InitializeComponent();
			if (Common.CommonConstant.checkHistoryDevice == 0) this.Text = "LL KT HÀNG NGÀY";
			LoadControl();
			SetDateTimePickers();
			LoadCombobox();
		}
		private void LoadControl()
		{
			LockControl(true);
			CleanText();
			LoadData();
		}
		private void LoadCombobox()
		{
			cbStatus.Items.Add("OK");
			cbStatus.Items.Add("NG");
			cbStatus.Items.Add("OK CÓ ĐK");
			cbStatus.Items.Add("STOP");
		}
		private void LoadData()
		{
			gcHistoryDeviceList.DataSource = null;
		}

		private void CleanText()
		{
			txtMeasuringParameters.Text = string.Empty;
			txtNote.Text = string.Empty;
			cbStatus.Text = string.Empty;
		}

		private void LockControl(bool isLock)
		{
			if (isLock)
			{
				txtMeasuringParameters.Enabled = false;
				txtNote.Enabled = false;
				dtpTestDate.Enabled = false;
				cbStatus.Enabled = false;
				btnEdit.Enabled = true;
				btnSave.Enabled = false;
				btnImport.Enabled = false;
			}
			else
			{
				txtMeasuringParameters.Enabled = true;
				txtNote.Enabled = true;
				dtpTestDate.Enabled = true;
				cbStatus.Enabled = true;
				btnEdit.Enabled = false;
				btnSave.Enabled = true;
				btnImport.Enabled = true;
			}
		}
		void Save()
		{
			float datacount = 0;
			if (txtMeasuringParameters.Text != "") datacount = float.Parse(txtMeasuringParameters.Text);
			int status = 0;
			string result = "";
			if (cbStatus != null)
			{
				status = cbStatus.SelectedIndex;
				result = cbStatus.Text;
			}
			string note = txtNote.Text;
			DateTime dateCheck = dtpTestDate.Value;
			long id = 0;
			if (gvHistoryDeviceList.GetFocusedRowCellValue("Id") != null) id = long.Parse(gvHistoryDeviceList.GetFocusedRowCellValue("Id").ToString());
			bool updated = HistoryDeviceDAO.Instance.Update(id, result, datacount, status, dateCheck, note);
			if (updated)
			{
				MessageBox.Show("Bạn đã sửa thành công".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			MessageBox.Show("Bạn sửa bị thất bại".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
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

		private void gvHistoryDeviceList_Click(object sender, EventArgs e)
		{
			try
			{
				cbStatus.SelectedIndex = loadstatus(int.Parse(gvHistoryDeviceList.GetFocusedRowCellValue("Status").ToString()));
				dtpTestDate.Value = DateTime.Parse(gvHistoryDeviceList.GetFocusedRowCellValue("DateCheck").ToString());
				if(gvHistoryDeviceList.GetFocusedRowCellValue("Note") != null )txtNote.Text = gvHistoryDeviceList.GetFocusedRowCellValue("Note").ToString();
				if (gvHistoryDeviceList.GetFocusedRowCellValue("DataCount") != null) txtMeasuringParameters.Text = gvHistoryDeviceList.GetFocusedRowCellValue("DataCount").ToString();
			}
			catch (Exception)
			{


			}
		}
		private int loadstatus(int status)
		{
			if (status == 1) return 0;
			else if (status == 4) return 2;
			else if (status == 5) return 1;
			else if (status == 6) return 3;
			return 0;
		}
		private void btnSee_Click(object sender, EventArgs e)
		{
			if(dtpFromTime.Value>dtpToTime.Value || dtpFromTime.Value > DateTime.Now)
			{
				MessageBox.Show("BẠN CHỌN NGÀY XEM KHÔNG HỢP LÝ.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (Common.CommonConstant.checkHistoryDevice == 0) listHistoryDevice = HistoryDeviceDAO.Instance.GetList().Where(x => x.DateCheck >= dtpFromTime.Value && x.DateCheck <= dtpToTime.Value && x.Timer == 24 && x.Result != "").ToList();
			else listHistoryDevice = HistoryDeviceDAO.Instance.GetList().Where(x => x.DateCheck >= dtpFromTime.Value && x.DateCheck <= dtpToTime.Value && x.Timer != 24 && x.Result != "").ToList();
			gcHistoryDeviceList.DataSource = listHistoryDevice;
		}
		private void SetDateTimePickers()
		{
			DateTime today = DateTime.Now;
			dtpFromTime.Value = new DateTime(today.Year, today.Month, 1);
			DateTime lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
			dtpToTime.Value = lastDayOfMonth;
		}
		private void gvHistoryDeviceList_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView grv = sender as GridView;
			if (e.RowHandle >= 0)
			{
				if (grv.GetRowCellDisplayText(e.RowHandle, "Status") == "1") e.Appearance.BackColor = Color.White;
				else if (grv.GetRowCellDisplayText(e.RowHandle, "Status") == "5") e.Appearance.BackColor = Color.Red;
				else if (grv.GetRowCellDisplayText(e.RowHandle, "Status") == "4") e.Appearance.BackColor = Color.Gray;
				else if (grv.GetRowCellDisplayText(e.RowHandle, "Status") == "6")
				{
					e.Appearance.BackColor = Color.Black;
					e.Appearance.ForeColor = Color.White;
				}
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtNote.Text = ofd.FileName;
			}
		}
	}
}