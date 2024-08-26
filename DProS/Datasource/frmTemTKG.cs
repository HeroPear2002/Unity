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
	public partial class frmTemTKG : DevExpress.XtraEditors.XtraForm
	{
		public frmTemTKG()
		{
			InitializeComponent();
			LoadControl();
		}
		void LoadControl()
		{
			this.AcceptButton = btnPrintTem;
			LockControl();
			txtLine.Text = "75";
			txtRoll.Text = "V";
			LoadPart();
		}
		void LockControl()
		{
			glPartCode.Enabled = false;
			cbMachineCode.Enabled = false;
			cbMoldCode.Enabled = false;
			nudCountPart.Enabled = false;
			nudFrom.Enabled = false;
			nudTo.Enabled = false;
			btnPrintTem.Enabled = false;
			txtLine.Enabled = false;
			txtRoll.Enabled = false;
			dtpkDate.Enabled = false;
			cbFactoryCode.Enabled = false;
		}
		void OpenControl()
		{
			glPartCode.Enabled = true;
			cbMachineCode.Enabled = true;
			cbMoldCode.Enabled = true;
			nudCountPart.Enabled = true;
			nudFrom.Enabled = true;
			nudTo.Enabled = true;
			btnPrintTem.Enabled = true;
			txtLine.Enabled = true;
			txtRoll.Enabled = true;
			dtpkDate.Enabled = true;
			cbFactoryCode.Enabled = true;
		}
		int kun = 0;
		string[] arrayAB = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };



		void LoadPart()
		{
			glPartCode.Properties.DataSource = TemInforDAO.Instance.GetListPart();
			glPartCode.Properties.DisplayMember = "PartCode";
			glPartCode.Properties.ValueMember = "IdPart";
		}
		void LoadMoldCode()
		{
			int idPart = int.Parse(glPartCode.EditValue.ToString());
			cbMoldCode.ValueMember = "IdMold";
			cbMoldCode.DataSource = TemInforDAO.Instance.GetListMoldByPart(idPart);
			cbMoldCode.DisplayMember = "MoldCode";
		}
		void LoadMachineCode()
		{
			int idPart = int.Parse(glPartCode.EditValue.ToString());
			int idMold = int.Parse(cbMoldCode.SelectedValue.ToString());
			cbMachineCode.DataSource = TemInforDAO.Instance.GetListMachineByPartMold(idPart, idMold);
			cbMachineCode.DisplayMember = "MachineCode";
			cbMachineCode.ValueMember = "IdMachine";
		}
		void LoadFactoryCode()
		{
			int idPart = int.Parse(glPartCode.EditValue.ToString());
			int idMold = int.Parse(cbMoldCode.SelectedValue.ToString());
			int idMachine = int.Parse(cbMachineCode.SelectedValue.ToString());
			cbFactoryCode.DataSource = TemInforDAO.Instance.GetListFactoryCodeByAll(idPart, idMold,idMachine);
			cbFactoryCode.DisplayMember = "FacCode";
			cbFactoryCode.ValueMember = "FacCode";
		}
		void LoadCountPart()
		{
			int idPart = int.Parse(glPartCode.EditValue.ToString());
			PartDTO DTO = PartDAO.Instance.GetItem(idPart);
			int countpart = 0;
			if (kun == 0)
			{
				countpart = DTO.CountPart;
			}
			else
			{
				countpart = (int)DTO.WeightPart;
			}
			nudCountPart.Value = countpart;
		}
		private void glPartCode_EditValueChanged(object sender, EventArgs e)
		{
			LoadMoldCode();
			LoadCountPart();
			LoadFactoryCode();
		}
		private void btnPrintTem_Click(object sender, EventArgs e)
		{
			DateTime today = dtpkDate.Value;
			int idPart = int.Parse(glPartCode.EditValue.ToString());
			string PartCode = glPartCode.Text;
			PartDTO DTO = PartDAO.Instance.GetItemByPartCode(PartCode);
			string FactoryCode = cbFactoryCode.Text;
			int countPart = (int)nudCountPart.Value;
			string PartNameJP = DTO.PartName;
			string MoldCode = cbMoldCode.Text;
			string MachineCode = cbMachineCode.Text;
			int idMold = int.Parse(cbMoldCode.SelectedValue.ToString());
			int idMachine = int.Parse(cbMachineCode.SelectedValue.ToString());
			string materialCode = DTO.MatCode;
			string materialName = DTO.MatName;
			string nameVN = DTO.NameVN;
			int month = today.Month;
			int year = (today.Year) % 10;
			if (year == 0)
			{
				year = 10;
			}
			int day = today.Day;
			int numTo = (int)nudTo.Value;
			int numFrom = (int)nudFrom.Value;
			string LotNo = (arrayAB[year - 1] + arrayAB[month - 1] + day + txtLine.Text + txtRoll.Text).ToUpper();
			List<ReportMacPartDTO> listR = new List<ReportMacPartDTO>();
			List<TemInforDTO> listM = TemInforDAO.Instance.GetList(idPart, idMachine, idMold).Distinct().ToList();
			int hs = 4;
			int nguyen = numFrom / hs;
			int du = numFrom % hs;
			for (int j = 1; j <= nguyen; j++)
			{
				for (int i = 0; i < hs; i++)
				{
					int serial = (i * nguyen) + numTo + (j - 1);
					foreach (TemInforDTO item in listM)
					{
						string QrCode = "&";
						string BarCode = item.PartCode + "&" + item.MachineCode + "&" + item.NumberMold + "&" + FactoryCode;
						listR.Add(new ReportMacPartDTO(PartCode, PartNameJP, item.NumberMold, item.MachineCode, countPart, BarCode, QrCode, serial.ToString("D4"), LotNo, materialCode, materialName, "", FactoryCode, "", nameVN));
					}
				}
			}
			if (du > 0)
			{
				for (int i = (nguyen * hs + numTo); i < numTo + numFrom; i++)
				{
					int serial = i;
					foreach (TemInforDTO item in listM)
					{
						string QrCode = "&";
						string BarCode = item.PartCode + "&" + item.MachineCode + "&" + item.NumberMold + "&" + FactoryCode;
						listR.Add(new ReportMacPartDTO(PartCode, PartNameJP, item.NumberMold, item.MachineCode, countPart, BarCode, QrCode, serial.ToString("D4"), LotNo, materialCode, materialName, "", FactoryCode, "", nameVN));
					}
				}
			}
			if (kun == 0)
			{
				rpMacTKG report = new rpMacTKG();
				report.DataSource = listR;
				report.LoadData();
				report.PrintDialog();
			}
			else
			{
				rpMacTKGIN report = new rpMacTKGIN();
				report.DataSource = listR;
				report.LoadData();
				report.PrintDialog();
			}
			//string employess = Kun_Static.accountDTO.UserName;
			HistoryTemDAO.Instance.Insert(idPart, idMachine, idMold, DateTime.Now, "UserName O Day", numTo, numTo + numFrom, dtpkDate.Value);
			this.Close();
		}
		private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadMachineCode();
		}

		private void btnOut_Click(object sender, EventArgs e)
		{
			kun = 0;
			OpenControl();
			try
			{
				LoadCountPart();
			}
			catch
			{

			}
		}

		private void btnIn_Click(object sender, EventArgs e)
		{
			kun = 1;
			OpenControl();
			try
			{
				LoadCountPart();
			}
			catch
			{

			}
		}
	}
}