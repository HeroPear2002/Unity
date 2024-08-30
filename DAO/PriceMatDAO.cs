using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class PriceMatDAO
	{
		private static PriceMatDAO instance;

		public static PriceMatDAO Instance { get { if (instance == null) instance = new PriceMatDAO(); return instance; } set => instance = value; }

		public PriceMatDAO() { }

		public List<PriceMatDTO> GetList()
		{
			string query = "Select * from MaterialPrice, Material, Supplier where IdMat = Material.Id and IdSup = Supplier.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<PriceMatDTO> list = new List<PriceMatDTO>();
			foreach (DataRow item in data.Rows)
			{
				PriceMatDTO DTO = new PriceMatDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public PriceMatDTO GetItem(long id)
		{
			return GetList().FirstOrDefault(x => x.Id == id);
		}
		public PriceMatDTO GetItem(string matCode,DateTime dateInput)
		{
			return GetList().FirstOrDefault(x => x.MatCode == matCode && x.DateInput == dateInput);
		}
		public bool Insert(int idMat, DateTime dateInput, decimal priceVND, string priceUSD, int statusPrice, string note)
		{
			string query = "Insert MaterialPrice(IdMat, DateInput, PriceVND, PriceUSD, StatusPrice, Note) Values( @1 , @2 , @3 , @4 , @5 , @6 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMat, dateInput, priceVND, priceUSD, statusPrice, note});
			return data > 0;
		}
		public bool Update(long id, int idMat, DateTime dateInput, decimal priceVND, string priceUSD, string note)
		{
			string query = "Update MaterialPrice set IdMat = @1 , DateInput = @2 , PriceVND = @3 , PriceUSD = @4 ,  Note = @6 where Id = @7 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMat, dateInput, priceVND, priceUSD, note, id });
			return data > 0;
		}
		public bool Update(long id, int statusPrice)
		{
			string query = "Update MaterialPrice set StatusPrice = @1 where Id = @2 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { statusPrice, id });
			return data > 0;
		}
		public bool Delete(long id)
		{
			string query = "Delete MaterialPrice where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
