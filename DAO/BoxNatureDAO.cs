using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class BoxNatureDAO
	{
		private static BoxNatureDAO instance;

		public static BoxNatureDAO Instance
		{
			get
			{
				if (instance == null) instance = new BoxNatureDAO();
				return instance;
			}

			set
			{
				instance = value;
			}
		}
		public List<BoxNatureDTO> GetList()
		{
			List<BoxNatureDTO> listB = new List<BoxNatureDTO>();
			string query = "SELECT * from dbo.BoxNature";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				BoxNatureDTO b = new BoxNatureDTO(item);
				listB.Add(b);
			}
			return listB;
		}
		public List<BoxNatureDTO> GetlistBoxbyNote(string code)
		{
			List<BoxNatureDTO> listB = new List<BoxNatureDTO>();
			string query = "SELECT * from dbo.BoxNature WHERE Note = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { code });
			foreach (DataRow item in data.Rows)
			{
				BoxNatureDTO b = new BoxNatureDTO(item);
				listB.Add(b);
			}
			return listB;
		}
		public int QuantityBoxByName(string BoxName, string Code)
		{
			try
			{
				return GetList().FirstOrDefault(x => x.BoxName == BoxName && x.Note == Code).Quantity;
			}
			catch (Exception)
			{
				return 0;
			}
		}
		public int Insert(string boxName, int quantity, string note)
		{
			string query = "INSERT BoxNature(BoxName, Quantity,Note) VALUES ( @1 , @2 , @3 ) ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { boxName, quantity, note });
			return data;
		}
		public int Update(int id, string boxName, int quantity, string note)
		{
			string query = "Update BoxNature set BoxName= @1  , Quantity= @2  , Note= @3 where Id= @4 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { boxName, quantity, note, id });
			return data;
		}
		public int Delete(int id)
		{
			string query = "Delete BoxNature where Id= @1  ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data;
		}
	}
}