using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class CateDataDefaultDAO
	{
		private static CateDataDefaultDAO instance;

		public static CateDataDefaultDAO Instance { get { if (instance == null) instance = new CateDataDefaultDAO() { }; return instance; } set => instance = value; }

		public CateDataDefaultDAO() { }

		public List<CateDataDefaultDTO> GetList()
		{
			string query = "select * from CateDataDefault ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<CateDataDefaultDTO> lsv = new List<CateDataDefaultDTO>();
			foreach (DataRow item in data.Rows)
			{
				CateDataDefaultDTO DTO = new CateDataDefaultDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public CateDataDefaultDTO GetItem(int Id)
		{
			return GetList().Find(x => x.Id == Id);
		}
		public CateDataDefaultDTO GetItem(string name)
		{
			return GetList().Find(x => x.Name == name);
		}
		public bool Insert(string name, float upperLimit, float lowerLimit)
		{
			string query= "INSERT CateDataDefault (Name ,UpperLimit, LowerLimit, Note) VALUES ( @1 , @2 , @3 , NULL )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, upperLimit, lowerLimit });
			return data > 0;
		}
		public bool Update(int id, string name, float upperLimit, float lowerLimit)
		{
			string query = "update CateDataDefault set Name = @1 ,UpperLimit = @2 , LowerLimit = @3 where Id = @10 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, upperLimit, lowerLimit, id });
			return data > 0;
		}
		
		public bool Delete(int id)
		{
			string query = "delete CateDataDefault where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
