using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class ReBoxDAO
	{
		private static ReBoxDAO instance;

		public static ReBoxDAO Instance { get { if (instance == null) instance = new ReBoxDAO(); return instance; } set => instance = value; }

		public ReBoxDAO() { }

		public bool Insert(int idBox, DateTime DateCheck)
		{
			string query = "INSERT dbo.ReBox ( IdBox, DateCheck ) VALUES  ( @1 , @2 )";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBox, DateCheck });
			return result > 0;
		}
		public bool Delete(DateTime DateCheck)
		{
			string query = "DELETE dbo.ReBox WHERE DateCheck = @1 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DateCheck });
			return result > 0;
		}
		public bool Delete(int id)
		{
			string query = "DELETE dbo.ReBox WHERE Id = @1 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return result > 0;
		}
	}
}
