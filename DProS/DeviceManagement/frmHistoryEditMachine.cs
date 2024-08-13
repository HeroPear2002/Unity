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

namespace DProS.DeviceManagement
{
	public partial class frmHistoryEditMachine : DevExpress.XtraEditors.XtraForm
	{
		int idMachine;
		bool Isinsert = false;
		List<HistoryEditMachineDTO> listMachineDetail = new List<HistoryEditMachineDTO>();
		MachineDTO machine = null;
		public frmHistoryEditMachine()
		{
			InitializeComponent();
			LoadControl();
			LoadData();
		}
		public frmHistoryEditMachine(int idmachine)
		{
			InitializeComponent();
			idMachine = idmachine;
			LoadControl();
			LoadData();
		}
		void LoadControl()
		{
			LoadData();
			LockControl();
			DeleteText();
		}
		private void LoadData()
		{
			listMachineDetail = HistoryEditMachineDAO.Instance.GetList(idMachine);
			machine = MachineDAO.Instance.GetItem(idMachine);
			gcHistoryEditMachine.DataSource = listMachineDetail;
		}
		void LockControl()
		{
			dtpkDate.Enabled = false;
			nudtime.Enabled = false;
			txtDetail.Enabled = false;
			txtEmployess.Enabled = false;
			txtErrorName.Enabled = false;
			txtnote.Enabled = false;
			txtReason.Enabled = false;
			txtTimeStart.Enabled = false;
			txtTimeMain.Enabled = false;
			dtpkDateError.Enabled = false;

			btnInsert.Enabled = true;
			btnEdit.Enabled = true;
			btnDelete.Enabled = true;
			btnSave.Enabled = false;
		}
		void OpenControl()
		{
			dtpkDate.Enabled = true;
			nudtime.Enabled = true;
			txtDetail.Enabled = true;
			txtEmployess.Enabled = true;
			txtErrorName.Enabled = true;
			txtnote.Enabled = true;
			txtReason.Enabled = true;
			txtTimeStart.Enabled = true;
			dtpkDateError.Enabled = true;
			txtTimeMain.Enabled = true;

			btnInsert.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnSave.Enabled = true;
		}
		void DeleteText()
		{
			dtpkDate.Text = String.Empty;
			nudtime.Text = String.Empty;
			txtDetail.Text = String.Empty;
			txtEmployess.Text = String.Empty;
			txtErrorName.Text = String.Empty;
			txtnote.Text = String.Empty;
			txtReason.Text = String.Empty;
			txtTimeStart.Text = String.Empty;
			txtTimeMain.Text = String.Empty;
			dtpkDateError.Text = String.Empty;
		}
		void AddText()
		{
			try
			{
				dtpkDateError.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["DateError"]).ToString();
				dtpkDate.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["DateMachine"]).ToString();
				nudtime.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["TimeMachine"]).ToString();
				txtDetail.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["Detail"]).ToString();
				txtEmployess.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["Employees"]).ToString();
				txtErrorName.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["ErrorName"]).ToString();
				txtnote.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["Note"]).ToString();
				txtReason.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["Reason"]).ToString();
				txtTimeStart.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["TimeStart"]).ToString();
				txtTimeMain.Text = gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["TimeMain"]).ToString();
				
			}
			catch
			{
			}
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			DeleteText();
			OpenControl();
			Isinsert = true;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			OpenControl();
			Isinsert = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
			{
				foreach (var item in gvHistoryEditMachine.GetSelectedRows())
				{
					long id = long.Parse(gvHistoryEditMachine.GetRowCellValue(item, "Id").ToString());
					HistoryEditMachineDAO.Instance.Delete(id);
				}
				LoadControl();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DateTime DateMachine = dtpkDate.Value;
			DateTime DateError = dtpkDateError.Value;
			int TimeMachine = 0;
			if (nudtime.Value != 0) TimeMachine = (int)nudtime.Value;
			else MessageBox.Show("BẠN PHẢI NHẬP THỜI GIAN XỬ LÝ.");
			string ErrorName = txtErrorName.Text;
			string Reason = txtReason.Text;
			string Detail = txtDetail.Text;
			string Employess = txtEmployess.Text;
			string Note = txtnote.Text;
			string timeStart = txtTimeStart.Text;
			string timeMain = txtTimeMain.Text;
			if (Isinsert == true)
			{
				HistoryEditMachineDAO.Instance.Insert( idMachine, DateMachine, TimeMachine, ErrorName, Reason, Detail, Employess, Note, DateError, timeStart, timeMain);
				MessageBox.Show("thêm thông tin thành công !".ToUpper());
				LoadControl();
			}
			else
			{
				long Id =long.Parse(gvHistoryEditMachine.GetRowCellValue(gvHistoryEditMachine.FocusedRowHandle, gvHistoryEditMachine.Columns["Id"]).ToString());
				HistoryEditMachineDAO.Instance.Update(Id,idMachine, DateMachine, TimeMachine, ErrorName, Reason, Detail, Employess, Note, DateError, timeStart, timeMain);
				MessageBox.Show("sửa thông tin thành công !".ToUpper());
				LoadControl();
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void txtTimeStart_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
			 (e.KeyChar == '.' && (txtTimeStart.Text.Length == 0 || txtTimeStart.Text.IndexOf('.') != -1))))
				e.Handled = true;
		}

		private void txtTimeMain_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
			 (e.KeyChar == '.' && (txtTimeMain.Text.Length == 0 || txtTimeMain.Text.IndexOf('.') != -1))))
				e.Handled = true;
		}

		private void gvHistoryEditMachine_Click(object sender, EventArgs e)
		{
			AddText();
		}
	}
}