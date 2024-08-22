using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class POFixDTO
	{
		long id;
		long idPOInput;
		string pOCode;
		string partCode;
		string idDe;
		int quantity;
		DateTime dateOut;
		string note;
		int status;
		DateTime dateInput;
		string factoryCustomer;
		string carNumber;
		string facCode;

		public POFixDTO(long id, long idPOInput, string pOCode, string partCode, string idDe, int quantity, DateTime dateOut, string note, int status, DateTime dateInput, string factoryCustomer, string carNumber, string facCode)
		{
			Id = id;
			IdPOInput = idPOInput;
			POCode = pOCode;
			PartCode = partCode;
			IdDe = idDe;
			Quantity = quantity;
			DateOut = dateOut;
			Note = note;
			Status = status;
			DateInput = dateInput;
			FactoryCustomer = factoryCustomer;
			CarNumber = carNumber;
			FacCode = facCode;
		}
		public POFixDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			IdPOInput = int.Parse(row["IdPOInput"].ToString());
			POCode = row["POCode"].ToString();
			PartCode = row["PartCode"].ToString();
			IdDe = row["IdDe"].ToString();
			Quantity = int.Parse(row["Quantity"].ToString());
			DateOut = DateTime.Parse(row["DateOut"].ToString());
			Note = row["Note"].ToString();
			Status = int.Parse(row["Status"].ToString());
			DateInput = DateTime.Parse(row["DateInput"].ToString());
			FactoryCustomer = row["FactoryCustomer"].ToString();
			CarNumber = row["CarNumber"].ToString();
			FacCode = row["FacCode"].ToString();
		}
		public long Id { get => id; set => id = value; }
		public long IdPOInput { get => idPOInput; set => idPOInput = value; }
		public string POCode { get => pOCode; set => pOCode = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string IdDe { get => idDe; set => idDe = value; }
		public int Quantity { get => quantity; set => quantity = value; }
		public DateTime DateOut { get => dateOut; set => dateOut = value; }
		public string Note { get => note; set => note = value; }
		public int Status { get => status; set => status = value; }
		public DateTime DateInput { get => dateInput; set => dateInput = value; }
		public string FactoryCustomer { get => factoryCustomer; set => factoryCustomer = value; }
		public string CarNumber { get => carNumber; set => carNumber = value; }
		public string FacCode { get => facCode; set => facCode = value; }
	}
}
