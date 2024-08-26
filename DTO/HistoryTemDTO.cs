using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class HistoryTemDTO
	{
		int id;
		string partCode;
		string machineCode;
		string moldCode;
		DateTime datePrint;
		string emCode;
		int numberTo;
		int numberFrom;
		string numberMold;
		DateTime lot;

		public HistoryTemDTO(int id, string partCode, string machineCode, string moldCode, DateTime datePrint, string emCode, int numberTo, int numberFrom, string numberMold, DateTime lot)
		{
			Id = id;
			PartCode = partCode;
			MachineCode = machineCode;
			MoldCode = moldCode;
			DatePrint = datePrint;
			EmCode = emCode;
			NumberTo = numberTo;
			NumberFrom = numberFrom;
			NumberMold = numberMold;
			Lot = lot;
		}
		public HistoryTemDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			PartCode = row["PartCode"].ToString();
			MachineCode = row["MachineCode"].ToString();
			MoldCode = row["MoldCode"].ToString();
			DatePrint = DateTime.Parse(row["DatePrint"].ToString());
			EmCode = row["EmCode"].ToString();
			NumberTo = int.Parse(row["NumberTo"].ToString());
			NumberFrom = int.Parse(row["NumberFrom"].ToString());
			NumberMold = row["NumberMold"].ToString();
			Lot = DateTime.Parse(row["Lot"].ToString());
		}

		public int Id { get => id; set => id = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string MoldCode { get => moldCode; set => moldCode = value; }
		public DateTime DatePrint { get => datePrint; set => datePrint = value; }
		public string EmCode { get => emCode; set => emCode = value; }
		public int NumberTo { get => numberTo; set => numberTo = value; }
		public int NumberFrom { get => numberFrom; set => numberFrom = value; }
		public string NumberMold { get => numberMold; set => numberMold = value; }
		public DateTime Lot { get => lot; set => lot = value; }
	}
}
