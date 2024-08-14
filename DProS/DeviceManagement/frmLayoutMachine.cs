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

namespace DProS.DeviceManagement
{
	public partial class frmLayoutMachine : DevExpress.XtraEditors.XtraForm
	{

		int statusform = 0;
		bool mainten = false;
		public frmLayoutMachine()
		{
			InitializeComponent();
			
			LoadControl();
		}
		async void LoadRelationShipAsync()
		{
			await UpdateTimeReality();
		}
		private void LoadControl()
		{
			statusform = 0;
			mainten = false;
			LoadRelationShipAsync();
			LoadLayout();
			LockControl(statusform, mainten);
		}

		private void LockControl(int statusform, bool mainten)
		{
			if(statusform == 0)
			{
				btnCheckMainten.Enabled = true;
				btnCheckEveryday.Enabled = true;
				btnInforMachine.Enabled = true;
				btnHistoryEdit.Enabled = true;
			}
			else if(statusform == 1 && mainten)
			{
				btnCheckMainten.Enabled = false;
				btnCheckEveryday.Enabled = true;
				btnInforMachine.Enabled = true;
				btnHistoryEdit.Enabled = true;
			}
			else if (statusform == 1 && !mainten)
			{
				btnCheckMainten.Enabled = true;
				btnCheckEveryday.Enabled = false;
				btnInforMachine.Enabled = true;
				btnHistoryEdit.Enabled = true;
			}
			else if (statusform == 2)
			{
				btnCheckMainten.Enabled = true;
				btnCheckEveryday.Enabled = true;
				btnInforMachine.Enabled = false;
				btnHistoryEdit.Enabled = true;
			}
			else if (statusform == 3)
			{
				btnCheckMainten.Enabled = true;
				btnCheckEveryday.Enabled = true;
				btnInforMachine.Enabled = true;
				btnHistoryEdit.Enabled = false;
			}
		}
		private void LoadLayout()
		{
			flpLayout.Controls.Clear();
			List<MachineDTO> listMachine = MachineDAO.Instance.GetList().Where(m => m.StatusMachine != 10).OrderByDescending(k => k.StatusMachine).ToList();
			flpLayout.AutoScroll = true;
			foreach (MachineDTO item in listMachine)
			{
				Button btn = new Button() { Width = 70, Height = 30 };
				btn.Margin = new Padding(0, 0, 3, 3);
				btn.Text = item.MachineCode;
				btn.Tag = item;
				btn.Click += btn_Click;
				btn.TextAlign = ContentAlignment.MiddleCenter;
				FontFamily f = new FontFamily("Times New Roman");
				int status = item.StatusMachine;
				btn.Font = new Font(f, 10);
				switch (status)
				{
					case 0:
						btn.BackColor = Color.White;

						break;
					case 1:
						btn.BackColor = Color.White;

						break;
					case 2:
						btn.BackColor = Color.Yellow;

						break;
					case 3:
						btn.BackColor = Color.Orange;

						break;
					case 4:
						btn.BackColor = Color.Gray;
						btn.ForeColor = Color.White;
						break;
					case 5:
						btn.BackColor = Color.Red;
						break;
					case 6:
						btn.BackColor = Color.Black;
						btn.ForeColor = Color.White;
						break;
					case 7:
						btn.BackColor = Color.GreenYellow;
						break;
					case 8:
						btn.BackColor = Color.Purple;
						btn.ForeColor = Color.White;
						break;
					default:
						btn.BackColor = Color.Orange;
						break;
				}
				flpLayout.Controls.Add(btn);
			}
		}

		private void btn_Click(object sender, EventArgs e)
		{
			int idMachine = ((sender as Button).Tag as MachineDTO).Id;
			Common.CommonConstant.idMachine = idMachine;
			if (statusform == 1)
			{
				frmCheckMaintenDevice form = new frmCheckMaintenDevice(mainten, idMachine);
				form.ShowDialog();
			}
			else if (statusform == 2)
			{
				frmInforDetailDevice form = new frmInforDetailDevice(idMachine);
				form.ShowDialog();
			}
			else if (statusform == 3)
			{
				frmHistoryEditMachine form = new frmHistoryEditMachine(idMachine);
				form.ShowDialog();
			}

			else MessageBox.Show("MỜI BẠN CHỌN LẠI.");
		}

		private static async Task UpdateTimeReality()
		{
			await Task.Run(() =>
			{
				List<MachineDTO> listMachine = MachineDAO.Instance.GetList().Where(x => x.StatusMachine != 10).ToList();
				foreach (var item1 in listMachine)
				{
					int statusMachine = item1.StatusMachine;
					List<int> statusre = new List<int>();
					int hour = DateTime.Now.Hour;
					DateTime now = DateTime.Now;
					List<RelationMachineCateDTO> listRe = RelationMachineCateDAO.Instance.GetListMachine(item1.Id);
					if (listRe.Count == 0)
					{
						statusMachine = 6;
					}
					else
					{
						foreach (var item in listRe)
						{
							List<HistoryDeviceDTO> listdto = HistoryDeviceDAO.Instance.GetItemRelation(item.Id);
							if (listdto.Count != 0)
							{
								DateTime dateCheck = listdto[0].DateCheck.Date;
								TimeSpan elapsed = now - dateCheck;
								int timeReality = (int)elapsed.TotalHours;
								RelationMachineCateDAO.Instance.UpdateTimeReality(item.Id, timeReality);
							}
							else
							{
								if (MachineDAO.Instance.GetItem(item.IdMachine) != null)
								{
									DateTime datePro = DateTime.Parse(MachineDAO.Instance.GetItem(item.IdMachine).DateProduct).Date;
									TimeSpan elapsed = now - datePro;
									int timeReality = (int)elapsed.TotalHours;
									RelationMachineCateDAO.Instance.UpdateTimeReality(item.Id, timeReality);
								}
							}
							float statusRe = (float)item.TimeReality / item.Timer;
							if (listdto.Count > 0 && listdto[0].DateCheck.Date == now.Date)
							{
								statusre.Add(listdto[0].Status);
							}
							if (statusRe > 0.8 && item.Timer == 24 && statusMachine < 4)
							{
								if (hour >= 12) statusre.Add(3);
								else if (hour >= 8) statusre.Add(2);
							}
							else if (statusRe > 0.8 && item.Timer > 24 && (statusMachine > 6 || statusMachine < 4))
							{
								if (statusRe > 1)
								{
									statusre.Add(8);
									MachineDAO.Instance.UpdateStatusMachine(item1.Id, statusMachine);
									break;
								}
								else
								{
									statusre.Add(7);
									MachineDAO.Instance.UpdateStatusMachine(item1.Id, statusMachine);
									break;
								}
							}
							else if (statusMachine >= 4 && statusMachine <= 6)
							{
								int status = 1;
								if (listdto.Count > 0 && listdto[0].DateCheck.Date == now.Date)
								{
									if (status < listdto[0].Status)
									{
										statusre.Add(listdto[0].Status);
									}
									statusre.Add(status);
								}
							}
						}
						if (statusre.Contains(8)) statusMachine = 8;
						else if (statusre.Contains(7)) statusMachine = 7;
						else if (statusre.Contains(3)) statusMachine = 3;
						else if (statusre.Contains(2)) statusMachine = 2;
						else if (statusre.Contains(5)) statusMachine = 5;
						else if (statusre.Contains(4)) statusMachine = 4;
						else if (statusre.Contains(1)) statusMachine = 1;
					}
					MachineDAO.Instance.UpdateStatusMachine(item1.Id, statusMachine);
				}
			});
			
		}
		private void btnCheckMainten_Click(object sender, EventArgs e)
		{
			mainten = true;
			statusform = 1;
			frmCheckMachineQrCode form = new frmCheckMachineQrCode(mainten);
			form.ShowDialog();
			LockControl(statusform, mainten);
		}
		private void btnCheckEveryday_Click(object sender, EventArgs e)
		{
			mainten = false;
			statusform = 1;
			frmCheckMachineQrCode form = new frmCheckMachineQrCode(mainten);
			form.ShowDialog();
			LockControl(statusform, mainten);
		}

		private void btnInforMachine_Click(object sender, EventArgs e)
		{
			statusform = 2;
			LockControl(statusform, mainten);
		}

		private void btnHistoryEdit_Click(object sender, EventArgs e)
		{
			statusform = 3;
			LockControl(statusform, mainten);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}
	}
}