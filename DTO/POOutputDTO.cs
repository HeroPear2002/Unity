using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class POOutputDTO
	{
		string pOCode;
		DateTime dateOutput;
		int quantityOut;
		long idDe;
		string partCode;
		DateTime dateManufacturi;
		string machineCode;
		string numberMold;
		string name;
		string lot;

		public POOutputDTO(string pOCode, DateTime dateOutput, int quantityOut, int idDe, string partCode, DateTime dateManufacturi, string machineCode, string numberMold, string name, string lot)
		{
			POCode = pOCode;
			DateOutput = dateOutput;
			QuantityOut = quantityOut;
			IdDe = idDe;
			PartCode = partCode;
			DateManufacturi = dateManufacturi;
			MachineCode = machineCode;
			NumberMold = numberMold;
			Name = name;
			Lot = lot;
		}
		public POOutputDTO(DataRow row)
		{
			POCode = row["POCode"].ToString();
			DateOutput = DateTime.Parse(row["DateOutput"].ToString());
			QuantityOut = int.Parse(row["QuantityOut"].ToString());
			IdDe = long.Parse(row["IdDe"].ToString());
			PartCode = row["PartCode"].ToString();
			DateManufacturi = DateTime.Parse(row["DateManufacturi"].ToString());
			MachineCode = row["MachineCode"].ToString();
			NumberMold = row["NumberMold"].ToString();
			Name = row["Name"].ToString();
			Lot = row["Lot"].ToString();
		}

		public string POCode { get => pOCode; set => pOCode = value; }
		public DateTime DateOutput { get => dateOutput; set => dateOutput = value; }
		public int QuantityOut { get => quantityOut; set => quantityOut = value; }
		public long IdDe { get => idDe; set => idDe = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public DateTime DateManufacturi { get => dateManufacturi; set => dateManufacturi = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string NumberMold { get => numberMold; set => numberMold = value; }
		public string Name { get => name; set => name = value; }
		public string Lot { get => lot; set => lot = value; }
	}
}
