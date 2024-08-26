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
using DProS.Datasource.Report;
using DevExpress.XtraReports.UI;
using DTO;

namespace DProS.Datasource
{
	public partial class frmTemTemMaPrint : DevExpress.XtraEditors.XtraForm
	{
		public frmTemTemMaPrint()
		{
			InitializeComponent();
		}
		private void btnPrint_Click(object sender, EventArgs e)
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
				if (MessageBox.Show("Linh kiện không đủ tiêu chuẩn 4M \nbạn vẫn muốn in mác !".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
						MessageBox.Show("mã sản phẩm này chưa có tiêu chuẩn 4M".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					return;
				}
			}
			int Important = TemInforDAO.Instance.ImportantMac(idPart);
			int numTo = (int)nudTo.Value;
			int numFrom = (int)nudFrom.Value;
			int hs = 10;
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
					string LotNo = year + month + date;
					string QrCode = "";

					listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode, serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, "", nameVN));
				}
			}
			if (du > 0)
			{
				for (int i = (nguyen * hs + numTo); i < numTo + numFrom; i++)
				{
					int serial = i;
					string datetime = year + month + date;
					string LotNo = year + month + date;
					string QrCode = "";

					listR.Add(new ReportMacPartDTO(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode, serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, "", nameVN));
				}
			}
			rpMacTemma report = new rpMacTemma();
			report.DataSource = listR;
			report.LoadData();
			report.PrintDialog();
			//string employess = Kun_Static.accountDTO.UserName;
			HistoryTemDAO.Instance.Insert(idPart, idMachine, idMold, DateTime.Now, "UserName O Day", numTo, numTo + numFrom, dtpkDate.Value);
			this.Close();
		}
		private void txtBarCode_TextChanged(object sender, EventArgs e)
		{
			timer1.Start();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			TextChange();
			txtBarCode.Enabled = false;
			timer1.Stop();
		}
		void TextChange()
		{
			string BarCode = txtBarCode.Text;
			try
			{
				string[] array = BarCode.Split('&');
				txtPartCode.Text = array[1];
				cbMachineCode.Text = array[2];
				cbMoldCode.Text = array[3];
				nudFrom.Value = int.Parse(array[4]);
				cbFactoryCode.Text = array[5].ToUpper();

				float quantityPart = PartDAO.Instance.GetItem(array[1]).CountPart;
				nudCountPart.Value = int.Parse(quantityPart.ToString());
			}
			catch
			{
				timer1.Stop();
				MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}