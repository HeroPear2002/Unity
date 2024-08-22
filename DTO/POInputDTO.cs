using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class POInputDTO
	{
		long id;
		string pOCode;
		string partCode;
		float price;
		int quantityIn;
		int quantityOut;
		int quantityRemai;
		int ratio;
		DateTime dateInput;
		DateTime dateOut;
		string cusCode;
		string facCode;
		int statusPO;

		public POInputDTO(long id, string pOCode, string partCode, float price, int quantityIn, int quantityOut, DateTime dateInput, DateTime dateOut, string cusCode, string facCode, int statusPO)
		{
			Id = id;
			POCode = pOCode;
			PartCode = partCode;
			Price = price;
			QuantityIn = quantityIn;
			QuantityOut = quantityOut;
			QuantityRemai = QuantityIn - QuantityOut;
			Ratio = (int)(100*(float)QuantityOut/ QuantityIn);
			DateInput = dateInput;
			DateOut = dateOut;
			CusCode = cusCode;
			FacCode = facCode;
			StatusPO = statusPO;
		}
		public POInputDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			POCode = row["POCode"].ToString();
			PartCode = row["PartCode"].ToString();
			Price = float.Parse(row["Price"].ToString()); 
			QuantityIn = int.Parse(row["QuantityIn"].ToString()); 
			QuantityOut = int.Parse(row["QuantityOut"].ToString()); 
			QuantityRemai = QuantityIn - QuantityOut;
			Ratio = (int)(100 * (float)QuantityOut / QuantityIn);
			DateInput = DateTime.Parse(row["DateInput"].ToString()); 
			DateOut = DateTime.Parse(row["DateOut"].ToString()); 
			CusCode = row["CusCode"].ToString();
			FacCode = row["FacCode"].ToString();
			StatusPO = int.Parse(row["StatusPO"].ToString());
		}
		public long Id { get => id; set => id = value; }
		public string POCode { get => pOCode; set => pOCode = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public float Price { get => price; set => price = value; }
		public int QuantityIn { get => quantityIn; set => quantityIn = value; }
		public int QuantityOut { get => quantityOut; set => quantityOut = value; }
		public int QuantityRemai { get => quantityRemai; set => quantityRemai = value; }
		public int Ratio { get => ratio; set => ratio = value; }
		public DateTime DateInput { get => dateInput; set => dateInput = value; }
		public DateTime DateOut { get => dateOut; set => dateOut = value; }
		public string CusCode { get => cusCode; set => cusCode = value; }
		public string FacCode { get => facCode; set => facCode = value; }
		public int StatusPO { get => statusPO; set => statusPO = value; }
	}
}
