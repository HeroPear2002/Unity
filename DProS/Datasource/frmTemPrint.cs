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
using DProS.Datasource.Report;
using DevExpress.XtraReports.UI;

namespace DProS.Datasource
{
	public partial class frmTemPrint : DevExpress.XtraEditors.XtraForm
	{
		public frmTemPrint()
		{
			InitializeComponent();
		}
		private void btnPrint_Click(object sender, EventArgs e)
		{
			//string employess = Kun_Static.accountDTO.UserName;
			string PartCode = txtPartCode.Text.ToUpper();
			int countPart = (int)nudCountPart.Value;
			PartDTO DTO = PartDAO.Instance.GetItemByPartCode(PartCode);
			int idPart = DTO.Id;
			string PartName = DTO.PartName;
			string MoldNumber = cbMoldCode.Text;
			string MachineCode = cbMachineCode.Text;
			int idMachine = MachineDAO.Instance.GetItem(MachineCode).Id;
			string FactoryCode = cbFactoryCode.Text;
			TemInforDTO TemInfor = TemInforDAO.Instance.GetList().Find(x => x.IdPart == idPart && x.IdMachine == idMachine && x.NumberMold == MoldNumber);
			string FactoryName = FactoryDAO.Instance.GetList().FirstOrDefault(x => x.FacCode == FactoryCode).FacName;
			string Rev = TemInfor.Rev;
			string year = dtpkDate.Value.Year.ToString();
			string month = dtpkDate.Value.Month.ToString("D2");
			string date = dtpkDate.Value.Day.ToString("D2");
			string hour = dtpkDate.Value.Hour.ToString("D2");
			string min = dtpkDate.Value.Minute.ToString("D2");
			string secon = dtpkDate.Value.Second.ToString("D2");
			string millisecon = dtpkDate.Value.Millisecond.ToString("D2");
			int idMold = TemInfor.IdMold;

			string standard = TemInforDAO.Instance.GetList(idPart, idMachine, idMold).Find(x => x.FacCode == FactoryCode).Standard;
			int idMac = TemInforDAO.Instance.GetItem(idPart, idMachine, idMold).Id;
			string nameVN = PartDAO.Instance.GetItem(PartCode).NameVN;
			List<TemInforDTO> listM = TemInforDAO.Instance.GetList().Where(x => x.Standard == "OK" && x.IdPart == idPart && x.IdMold == idMold).ToList();
			if (standard != "OK")
			{
				if (MessageBox.Show("Linh kiện không đủ tiêu chuẩn 4M \nbạn vẫn muốn in mác với máy đã đủ 4M!".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					// Lấy mã máy theo ds 4M
					if (listM.Where(x => x.CavStyle == 1).ToList().Count > 0)
					{
						var result = from s in listM where (s.CavStyle == 1) select s.MachineCode;
						foreach (string item in result)
						{
							MachineCode = item;
						}
					}
					else
					{
						MessageBox.Show("mã sản phẩm này chưa có tiêu chuẩn 4M \nhoặc bạn chưa ưu tiên máy để in mác".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					return;
				}
			}
			int Important = TemInfor.Important;
			if (Important == 1)
			{
				int numTo = (int)nudTo.Value;
				int cav = DTO.Cav;
				int numFrom = (int)nudFrom.Value;
				int hs = 10;
				int nguyen = numFrom / hs;
				int du = numFrom % hs;
				string MoldNumberNew = "";
				List<ReportMacPartDTO> listR = new List<ReportMacPartDTO>();
				string BarCode = "";
				for (int o = 1; o <= cav; o++)
				{
					if (du > 0)
					{
						nguyen = nguyen + 1;
					}
					MoldNumberNew = MoldNumber + "-" + o.ToString();
					BarCode = PartCode + "&" + MachineCode + "&" + MoldNumberNew + "&" + FactoryCode;
					for (int j = 1; j <= nguyen; j++)
					{
						for (int i = 0; i < hs; i++)
						{
							int serial = (i * nguyen) + numTo + (j - 1);
							string datetime = year + month + date;
							string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
							string QrCode = "";

							QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumberNew + "&" + MachineCode + "&" + FactoryCode + "&&";
							listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumberNew, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", Rev, FactoryCode, FactoryName, nameVN));
						}
					}

					//if (Kun_Static.accountDTO.Type != 1)
					//{
					HistoryTemDAO.Instance.Insert(idPart, idMachine, idMold, DateTime.Now, "UserName O Day", numTo, numTo + numFrom, dtpkDate.Value);
					//}
				}
				if (FactoryCode == "D1")
				{
					rpMacInfor report = new rpMacInfor();
					report.DataSource = listR;
					report.LoadData();
					report.PrintDialog();
					this.Close();
				}
				else if (FactoryCode == "D2")
				{
					rpMacInfor2 report = new rpMacInfor2();
					report.DataSource = listR;
					report.LoadData();
					report.Print();
					this.Close();
				}
			}
			else
			{
				string BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
				int numTo = (int)nudTo.Value;
				int numFrom = (int)nudFrom.Value;
				int hs = 10;
				int nguyen = numTo / hs;
				int du = numFrom % hs;
				List<ReportMacPartDTO> listR = new List<ReportMacPartDTO>();
				for (int j = 1; j <= nguyen; j++)
				{
					for (int i = 0; i < hs; i++)
					{
						int serial = (i * nguyen) + numTo + (j - 1);
						string datetime = year + month + date;
						string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
						string QrCode = "";

						QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
						listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", Rev, FactoryCode, FactoryName, nameVN));
					}
				}
				if (du > 0)
				{
					for (int i = (nguyen * hs) + numTo; i < numTo + numFrom; i++)
					{
						int serial = i;
						string datetime = year + month + date;
						string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
						string QrCode = "";

						QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
						listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", Rev, FactoryCode, FactoryName, nameVN));
					}
				}
				//if (Kun_Static.accountDTO.Type != 1)
				//{
				HistoryTemDAO.Instance.Insert(idPart, idMachine, idMold, DateTime.Now, "UserName O Day", numTo, numTo + numFrom, dtpkDate.Value);
				//}
				if (FactoryCode == "D1")
				{
					rpMacInfor report = new rpMacInfor();
					report.DataSource = listR;
					report.LoadData();
					report.Print();
					this.Close();
				}
				else if (FactoryCode == "D2")
				{
					rpMacInfor2 report = new rpMacInfor2();
					report.DataSource = listR;
					report.LoadData();
					report.Print();
					this.Close();
				}
			}
		}
		private void btnPrintMacT_Click(object sender, EventArgs e)
		{
			nudCountPart.Enabled = true;
			if (MessageBox.Show("Bạn chọn NO để sửa số lượng chọn YES để tiếp tục in Mác?".ToUpper(), "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				btnPrintTem.Enabled = false;
				return;
			}
			if (MessageBox.Show("bạn muốn in mác thùng tạm ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				string PartCode = txtPartCode.Text.ToUpper();
				int countPart = (int)nudCountPart.Value;
				PartDTO DTO = PartDAO.Instance.GetItemByPartCode(PartCode);
				int idPart = DTO.Id;
				string PartName = DTO.PartName;
				string MoldNumber = cbMoldCode.Text;
				string MachineCode = cbMachineCode.Text;
				int idMachine = MachineDAO.Instance.GetItem(MachineCode).Id;
				string FactoryCode = cbFactoryCode.Text;
				TemInforDTO TemInfor = TemInforDAO.Instance.GetList().Find(x => x.IdPart == idPart && x.IdMachine == idMachine && x.NumberMold == MoldNumber);
				string FactoryName = FactoryDAO.Instance.GetList().FirstOrDefault(x => x.FacCode == FactoryCode).FacName;
				string Rev = TemInfor.Rev;
				string year = dtpkDate.Value.Year.ToString();
				string month = dtpkDate.Value.Month.ToString("D2");
				string date = dtpkDate.Value.Day.ToString("D2");
				string hour = dtpkDate.Value.Hour.ToString("D2");
				string min = dtpkDate.Value.Minute.ToString("D2");
				string secon = dtpkDate.Value.Second.ToString("D2");
				string millisecon = dtpkDate.Value.Millisecond.ToString("D2");
				int idMold = TemInfor.IdMold;

				string standard = TemInforDAO.Instance.GetList(idPart, idMachine, idMold).Find(x => x.FacCode == FactoryCode).Standard;
				int idMac = TemInforDAO.Instance.GetItem(idPart, idMachine, idMold).Id;
				string nameVN = PartDAO.Instance.GetItem(PartCode).NameVN;
				List<TemInforDTO> listM = TemInforDAO.Instance.GetList().Where(x => x.Standard == "OK" && x.IdPart == idPart && x.IdMold == idMold).ToList();
				if (standard != "OK")
				{
					if (MessageBox.Show("Linh kiện không đủ tiêu chuẩn 4M \nbạn vẫn muốn in mác với máy đã đủ 4M!".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						// Lấy mã máy theo ds 4M
						if (listM.Where(x => x.CavStyle == 1).ToList().Count > 0)
						{
							var result = from s in listM where (s.CavStyle == 1) select s.MachineCode;
							foreach (string item in result)
							{
								MachineCode = item;
							}
						}
						else
						{
							MessageBox.Show("mã sản phẩm này chưa có tiêu chuẩn 4M \nhoặc bạn chưa ưu tiên máy để in mác".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					else
					{
						return;
					}
				}
				int Important = TemInforDAO.Instance.ImportantMac(idPart);
				if (Important == 1)
				{
					int numTo = (int)nudTo.Value;
					int cav = DTO.Cav;
					int numFrom = (int)nudFrom.Value;
					int hs = 12;
					int nguyen = numFrom / hs;
					int du = numFrom % hs;
					string MoldNumberNew = "";
					List<ReportMacPartDTO> listR = new List<ReportMacPartDTO>();
					string BarCode = "";
					for (int o = 1; o <= cav; o++)
					{
						MoldNumberNew = MoldNumber + "-" + o.ToString();
						BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
						for (int j = 1; j <= nguyen; j++)
						{
							for (int i = 0; i < hs; i++)
							{
								int serial = (i * nguyen) + numTo + (j - 1);
								string datetime = year + month + date;
								string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
								string QrCode = "";

								QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumberNew + "&" + MachineCode + "&" + FactoryCode + "&&";
								listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumberNew, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
							}
						}
						if (du > 0)
						{
							for (int i = (nguyen * 12) + numTo; i < numTo + numFrom; i++)
							{
								int serial = i;
								string datetime = year + month + date;
								string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
								string QrCode = "";
								QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumberNew + "&" + MachineCode + "&" + FactoryCode + "&&";
								listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumberNew, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
							}
						}

						rpMacTT report = new rpMacTT();
						report.DataSource = listR;
						report.LoadData();
						report.Print();
						//if (Kun_Static.accountDTO.Type != 1)
						//{
						HistoryTemDAO.Instance.Insert(idPart, idMachine, idMold, DateTime.Now, "UserName O Day", numTo, numTo + numFrom, dtpkDate.Value);
						//}
						this.Close();
					}
				}
				else
				{
					int numTo = (int)nudTo.Value;
					int numFrom = (int)nudFrom.Value;
					int hs = 12;
					int nguyen = numFrom / hs;
					int du = numFrom % hs;
					List<ReportMacPartDTO> listR = new List<ReportMacPartDTO>();
					string BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
					for (int j = 1; j <= nguyen; j++)
					{
						for (int i = 0; i < hs; i++)
						{
							int serial = (i * nguyen) + numTo + (j - 1);
							string datetime = year + month + date;
							string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
							string QrCode = "";

							QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
							listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
						}
					}
					if (du > 0)
					{
						for (int i = (nguyen * 12) + numTo; i < numTo + numFrom; i++)
						{
							int serial = i;
							string datetime = year + month + date;
							string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
							string QrCode = "";
							QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
							listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
						}
					}

					rpMacTT report = new rpMacTT();
					report.DataSource = listR;
					report.LoadData();
					report.Print();
					//if (Kun_Static.accountDTO.Type != 1)
					//{
					HistoryTemDAO.Instance.Insert(idPart, idMachine, idMold, DateTime.Now, "UserName O Day", numTo, numTo + numFrom, dtpkDate.Value);
					//}
					this.Close();
				}
			}
			else
			{
				btnPrintTem.Enabled = false;
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			TextChange();
			txtBarCode.Enabled = false;
			timer1.Stop();
		}
		void TextChange()
		{
			string BarCode = txtBarCode.Text.ToUpper();
			if (BarCode.Length > 0)
			{
				try
				{
					string[] array = BarCode.Split('&');
					txtPartCode.Text = array[1];
					cbMachineCode.Text = array[2];
					cbMoldCode.Text = array[3];
					cbFactoryCode.Text = array[5];
					PartDTO DTO = PartDAO.Instance.GetItemByPartCode(array[1]);
					float quantityPart = DTO.CountPart;
					int idPart = DTO.Id;
					int Important = TemInforDAO.Instance.ImportantMac(idPart);
					int a = int.Parse(array[4]);
					if (Important == 1)
					{
						int cav = PartDAO.Instance.GetItem(array[1]).Cav;
						a = a / cav;
					}
					nudFrom.Value = a;
					nudCountPart.Value = int.Parse(quantityPart.ToString());

				}
				catch
				{
					timer1.Stop();
					MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

			}
			else
			{
				timer1.Stop();
				MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		private void txtBarCode_TextChanged(object sender, EventArgs e)
		{
			timer1.Start();
		}
	}
}