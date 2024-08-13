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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace DProS.DeviceManagement
{
	public partial class frmCheckMaintenDevice : DevExpress.XtraEditors.XtraForm
	{
		DataTable listHistoryDevice = new DataTable();
		bool mainten = true;
		public frmCheckMaintenDevice()
		{
			InitializeComponent();
			LoadData();
			LoadCombobox();
		}

		int idMachine = 0;
		public frmCheckMaintenDevice(bool ismainten, int idmachine)
		{
			InitializeComponent();
			mainten = ismainten;
			idMachine = idmachine;
			string machineCode = MachineDAO.Instance.GetItem(idmachine).MachineCode;
			if (!mainten)
			{
				this.Text = "Kiểm Tra Hàng Ngày Máy " + machineCode;
				gvcTimeReality.Visible = false;
				gvcTimer.Visible = false;
			}
			else
			{
				this.Text = "Kiểm Tra Định Kỳ Máy " + machineCode;
			}
			LoadData();
			LoadCombobox();
		}

		private void LoadCombobox()
		{
			cbResult.Items.Add("OK");
			cbResult.Items.Add("NG");
			cbResult.Items.Add("OK CÓ ĐK");
			cbResult.Items.Add("STOP");
		}
		private void LoadData()
		{
			List<RelationMachineCateDTO> relationMachineCates = RelationMachineCateDAO.Instance.GetListMachine(idMachine);
			List<HistoryDeviceDTO> historyDevicesMainten = new List<HistoryDeviceDTO>();
			List<HistoryDeviceDTO> historyDevicesEveryday = new List<HistoryDeviceDTO>();
			foreach (RelationMachineCateDTO item in relationMachineCates)
			{
				long idRelationShip = item.Id;
				string nameCategory = item.NameCategory;
				string method = item.Method;
				string detail = item.Detail;
				int timeReality = item.TimeReality;
				int timer = item.Timer;
				int statusCate = item.StatusCate;
				List<HistoryDeviceDTO> historyDeviceDTOs = HistoryDeviceDAO.Instance.GetItemRelation(idRelationShip);
				HistoryDeviceDTO DTO = null;
				if (historyDeviceDTOs.Count >0 && historyDeviceDTOs[0].DateCheck.Date == DateTime.Now.Date) DTO = historyDeviceDTOs[0];
				else if((float)timeReality/timer >=0.8) DTO = new HistoryDeviceDTO(0, idRelationShip, null, nameCategory, method, detail, null, DateTime.Now, 0, timeReality, timer, null, null, null, statusCate);
				if  (DTO != null && DTO.Timer > 24 && ((float)DTO.TimeReality / DTO.Timer >= 0.8 || DTO.DateCheck.Date == DateTime.Now.Date))
				{
					historyDevicesMainten.Add(DTO);
				}
				else if (DTO != null && DTO.Timer == 24 && ((float)DTO.TimeReality / DTO.Timer >= 0.8 || DTO.DateCheck.Date == DateTime.Now.Date))
				{
					historyDevicesEveryday.Add(DTO);
				}
			}
			if(mainten) gcCheckDevice.DataSource = historyDevicesMainten;
			else gcCheckDevice.DataSource = historyDevicesEveryday;
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("BẠN MUỐN LƯU BẢN GHI NÀY?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				if(LoadCondition())
				{
					int countdata = 0;
					foreach (var item in gvCheckDevice.GetSelectedRows())
					{
						try
						{
							int idRelationShip = int.Parse(gvCheckDevice.GetRowCellValue(item, "IdRelationShip").ToString());
							int statusCate = int.Parse(gvCheckDevice.GetRowCellValue(item, "StatusCate").ToString());
							float dataCount = 0;
							if (gvCheckDevice.GetRowCellValue(item, "DataCount") != null) dataCount = float.Parse(gvCheckDevice.GetRowCellValue(item, "DataCount").ToString());
							string results;
							results = gvCheckDevice.GetRowCellValue(item, "Result").ToString();
							int status = 0;
							DateTime dateCheck = DateTime.Now;
							string note = "";
							if (gvCheckDevice.GetRowCellValue(item, "Note") != null) note = gvCheckDevice.GetRowCellValue(item, "Note").ToString();
							float statutsReality = float.Parse(gvCheckDevice.GetRowCellValue(item, "TimeReality").ToString()) / int.Parse(gvCheckDevice.GetRowCellValue(item, "Timer").ToString());
							int idUser = 1;
							if (results != "" && statutsReality > 0.8)
							{
								if (results == "OK") status = 1;
								else if (results == "NG") status = 5;
								else if (results == "OK CÓ ĐK") status = 4;
								else if (results == "STOP") status = 0;
								bool insert = HistoryDeviceDAO.Instance.Insert(idRelationShip, results, dataCount, status, dateCheck, idUser, note);
								if (insert)
								{
									RelationMachineCateDAO.Instance.UpdateTimeReality(idRelationShip, 0);
									countdata++;
								}
							}
						}
						catch (Exception)
						{

						}
					}
					if (countdata > 0) MessageBox.Show("BẠN ĐÃ LƯU THÀNH CÔNG.");
					LoadData();
				}
				else
				{
					MessageBox.Show("bạn chưa điền đúng thông tin !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		bool LoadCondition()
		{
			int count = 0;
			try
			{
				int i = 0;
				foreach (var item in gvCheckDevice.GetSelectedRows())
				{
					var obj = gvCheckDevice.GetRowCellValue(item, "IdCategory");
					try
					{
						int idRelationShip = int.Parse(gvCheckDevice.GetRowCellValue(item, "IdRelationShip").ToString());
						int statusCate = int.Parse(gvCheckDevice.GetRowCellValue(item, "StatusCate").ToString());
						float dataCount = 0;
						if (gvCheckDevice.GetRowCellValue(item, "DataCount") != null) dataCount = float.Parse(gvCheckDevice.GetRowCellValue(item, "DataCount").ToString());
						string results;
						results = gvCheckDevice.GetRowCellValue(item, "Result").ToString();
						DateTime dateCheck = DateTime.Now;
						string note = "";
						if (gvCheckDevice.GetRowCellValue(item, "Note") != null) note = gvCheckDevice.GetRowCellValue(item, "Note").ToString();
						if (statusCate == 1)
						{
							string detailString = gvCheckDevice.GetRowCellValue(item, "Detail").ToString();
							string[] array = detailString.Split('~');
							float min = (float)Convert.ToDouble(array[0].Trim());
							float max = (float)Convert.ToDouble(array[1].Trim());
							if (dataCount < min || dataCount > max)
							{
								if (results == "OK" || results == "STOP")
								{
									count++;
								}
							}
							else
							{
								gvCheckDevice.SetRowCellValue(item, "Result", "OK");
							}
						}
						else
						{
							if (results == "NG" || results == "OK CÓ ĐK")
							{
								if (note.Length == 0)
								{
									count++;
								}
							}
							else
							{
								if (results.Length == 0)
								{
									count++;
								}
							}
						}
					}
					catch
					{
						count++;
					}
					i++;
				}
				if (i == 0)
				{
					count++;
				}
			}
			catch
			{
				count++;
			}
			if (count == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void gvCheckDevice_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView grv = sender as GridView;
			if (e.RowHandle >= 0)
			{
				if (float.Parse(grv.GetRowCellDisplayText(e.RowHandle, "TimeReality").ToString())/ int.Parse(grv.GetRowCellDisplayText(e.RowHandle, "Timer").ToString()) > 0.8)
				{
					e.Appearance.BackColor = Color.Yellow;
					e.Appearance.ForeColor = Color.Black;
				}
			}
		}

		private void gvCheckDevice_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView grv = sender as GridView;
			
			if(e.RowHandle >= 0 && e.Column.Name == "gvcDataCount")
			{
				string detail = gvCheckDevice.GetFocusedRowCellValue("Detail").ToString();
				int statusCate = int.Parse(gvCheckDevice.GetFocusedRowCellValue("StatusCate").ToString());
				if (statusCate == 1)
				{
					string[] parts = detail.Split('~');
					float lowerBound = float.Parse(parts[0]);
					float upperBound = float.Parse(parts[1]);

					if (e.Value.ToString() != "" )
					{
						gvCheckDevice.SetFocusedRowCellValue("Result", e.Value.ToString());
						bool isInRange = float.Parse(e.Value.ToString()) >= lowerBound && float.Parse(e.Value.ToString()) <= upperBound;
						if (isInRange == true)
						{
							gvCheckDevice.SetFocusedRowCellValue("Result", "OK");
						}
						else
						{
							gvCheckDevice.SetFocusedRowCellValue("Result", "NG");
						}
					}
					else gvCheckDevice.SetFocusedRowCellValue("Result", "");
				}
			}
		}

		private void gvCheckDevice_RowCellStyle(object sender, RowCellStyleEventArgs e)
		{
			if (e.RowHandle >= 0)
			{
				if (gvCheckDevice.GetRowCellDisplayText(e.RowHandle, "Result") == "NG") e.Appearance.BackColor = Color.Red;
				else if (gvCheckDevice.GetRowCellDisplayText(e.RowHandle, "Result") == "OK CÓ ĐK") e.Appearance.BackColor = Color.Gray;
			}
		}
	}
}