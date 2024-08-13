using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class MachineDTO
	{
		int id;
		string machineCode;
		string machineName;
		string machineInfor;
		string manufacturer;
		string serialNumber;
		string dateInput;
		string codeAsset;
		string vender;
		string dateProduct;
		int idDevice;
		int statusMachine;
		string note;
		string dateMaker;
		int dateUse;

		public MachineDTO(int id, string machineCode, string machineName, string machineInfor, string manufacturer, string serialNumber, string dateInput, string codeAsset, string vender, string dateProduct, int idDevice, int statusMachine, string note, string dateMaker, int dateUse)
		{
			Id = id;
			MachineCode = machineCode;
			MachineName = machineName;
			MachineInfor = machineInfor;
			Manufacturer = manufacturer;
			SerialNumber = serialNumber;
			DateInput = dateInput;
			CodeAsset = codeAsset;
			Vender = vender;
			DateProduct = dateProduct;
			IdDevice = idDevice;
			StatusMachine = statusMachine;
			Note = note;
			DateMaker = dateMaker;
			DateUse = CalculateMonthsUsed(DateTime.Parse(DateProduct), DateTime.Now);
		}
		public MachineDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			MachineCode = row["MachineCode"].ToString();
			MachineName = row["MachineName"].ToString();
			MachineInfor = row["MachineInfor"].ToString();
			Manufacturer = row["Manufacturer"].ToString();
			SerialNumber = row["SerialNumber"].ToString();
			DateInput = row["DateInput"] != DBNull.Value ? DateTime.Parse(row["DateInput"].ToString()).ToString("dd/MM/yyy") : "";
			CodeAsset = row["CodeAsset"].ToString();
			Vender = row["Vender"].ToString();
			DateProduct = row["DateProduct"] != DBNull.Value ? DateTime.Parse(row["DateProduct"].ToString()).ToString("dd/MM/yyy") : "";
			IdDevice = int.Parse(row["IdDevice"].ToString());
			StatusMachine = int.Parse(row["StatusMachine"].ToString());
			Note = row["Note"].ToString();
			DateMaker = row["DateMaker"] != DBNull.Value ? DateTime.Parse(row["DateMaker"].ToString()).ToString("dd/MM/yyy") : "";
			DateUse = CalculateMonthsUsed(
				!string.IsNullOrEmpty(DateProduct) ? DateTime.Parse(DateProduct) : DateTime.Now,
				DateTime.Now);
		}

		public int Id { get => id; set => id = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string MachineName { get => machineName; set => machineName = value; }
		public string MachineInfor { get => machineInfor; set => machineInfor = value; }
		public string Manufacturer { get => manufacturer; set => manufacturer = value; }
		public string SerialNumber { get => serialNumber; set => serialNumber = value; }
		public string DateInput { get => dateInput; set => dateInput = value; }
		public string CodeAsset { get => codeAsset; set => codeAsset = value; }
		public string Vender { get => vender; set => vender = value; }
		public string DateProduct { get => dateProduct; set => dateProduct = value; }
		public int IdDevice { get => idDevice; set => idDevice = value; }
		public int StatusMachine { get => statusMachine; set => statusMachine = value; }
		public string Note { get => note; set => note = value; }
		public string DateMaker { get => dateMaker; set => dateMaker = value; }
		public int DateUse { get => dateUse; set => dateUse = value; }

		private int CalculateMonthsUsed(DateTime startDate, DateTime endDate)
		{
			int months = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
			if (endDate.Day < startDate.Day)
			{
				months--;
			}
			return months;
		}

		private int CalculateMonthsUsed(string startDateStr, DateTime endDate)
		{
			DateTime startDate;
			if (DateTime.TryParse(startDateStr, out startDate))
			{
				return CalculateMonthsUsed(startDate, endDate);
			}
			return 0;
		}
	}
}
