using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class PriceMatDTO
	{
		public PriceMatDTO(DataRow row)
		{
			this.Id = (long)row["Id"];
			this.MatCode = row["MatCode"].ToString();
			this.MatName = row["MatName"].ToString();
			this.DateInput = (DateTime)row["DateInput"];
			this.PriceVND = (decimal)row["PriceVND"];
			this.PriceUSD = row["PriceUSD"].ToString();
			this.StatusPrice = (int)row["StatusPrice"];
			this.SupName = row["SupName"].ToString();
			this.Note = row["Note"].ToString();
		}

		public PriceMatDTO(long id, DateTime dateInput, string matCode, decimal priceVND, string priceUSD, int statusPrice, string note, string supName, string matName)
		{
			Id = id;
			DateInput = dateInput;
			MatCode = matCode;
			PriceVND = priceVND;
			PriceUSD = priceUSD;
			StatusPrice = statusPrice;
			Note = note;
			SupName = supName;
			MatName = matName;
		}

		private long id;
		private DateTime dateInput;
		private string matCode;
		private Decimal priceVND;
		private string priceUSD;
		private int statusPrice;
		private string note;
		private string supName;
		private string matName;

		public long Id { get => id; set => id = value; }
		public DateTime DateInput { get => dateInput; set => dateInput = value; }
		public string MatCode { get => matCode; set => matCode = value; }
		public decimal PriceVND { get => priceVND; set => priceVND = value; }
		public string PriceUSD { get => priceUSD; set => priceUSD = value; }
		public int StatusPrice { get => statusPrice; set => statusPrice = value; }
		public string Note { get => note; set => note = value; }
		public string SupName { get => supName; set => supName = value; }
		public string MatName { get => matName; set => matName = value; }
	}
}
