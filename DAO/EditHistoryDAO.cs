using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class EditHistoryDAO
	{
		private static EditHistoryDAO instance;

		public static EditHistoryDAO Instance
		{
			get
			{
				if (instance == null) instance = new EditHistoryDAO();
				return instance;
			}
			set => instance = value;
		}
		public object GetListData()
		{
			return (object)DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.EditHistory");
		}
		public bool Insert(DateTime DateInput, string Employess, string Detail, string note)
		{
			string query = "INSERT dbo.EditHistory ( DateInput, Employess, Detail, Note ) VALUES  ( @1 ,  @2 , @3 , @4 )";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DateInput, Employess, Detail, note });
			return result > 0;
		}
	}
}
