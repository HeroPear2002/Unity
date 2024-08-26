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
	}
}