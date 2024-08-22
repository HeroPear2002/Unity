using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DeliveryDetailDTO
	{
		long id;
		string pOCode;
		int quantity;
		DateTime dateDelivery;
		string partCode;
		string factoryCustomer;
		int carNumber;
		int status;
		int quantityOut;

		public long Id { get => id; set => id = value; }
		public string POCode { get => pOCode; set => pOCode = value; }
		public int Quantity { get => quantity; set => quantity = value; }
		public DateTime DateDelivery { get => dateDelivery; set => dateDelivery = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string FactoryCustomer { get => factoryCustomer; set => factoryCustomer = value; }
		public int CarNumber { get => carNumber; set => carNumber = value; }
		public int QuantityOut { get => quantityOut; set => quantityOut = value; }
		public int Status { get => status; set => status = value; }

		public DeliveryDetailDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			POCode = row["POCode"].ToString();
			Quantity = int.Parse(row["Quantity"].ToString());
			DateDelivery = DateTime.Parse(row["DateDelivery"].ToString());
			PartCode = row["PartCode"].ToString();
			FactoryCustomer = row["FactoryCustomer"].ToString();
			CarNumber = int.Parse(row["CarNumber"].ToString());
			Status = int.Parse(row["Status"].ToString());
			if (row["QuantityOut"].ToString() == "") QuantityOut = 0;
			else QuantityOut = int.Parse(row["QuantityOut"].ToString());
		}

		public DeliveryDetailDTO(long idPOFix, string pOCode, int quantity, DateTime dateDelivery, string partCode, string factoryCustomer, int carNumber, int Status, int quantityOut)
		{
			Id = idPOFix;
			POCode = pOCode;
			Quantity = quantity;
			DateDelivery = dateDelivery;
			PartCode = partCode;
			FactoryCustomer = factoryCustomer;
			CarNumber = carNumber;
			Status = status;
			QuantityOut = quantityOut;
		}
	}
}
