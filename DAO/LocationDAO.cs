using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class LocationDAO
	{
		private static LocationDAO instance;

		public static LocationDAO Instance { get { if (instance == null) instance = new LocationDAO(); return instance; } set => instance = value; }

		public LocationDAO() { }

		public List<LocationDTO> GetList()
		{
			string query = "select * from Location";
			List<LocationDTO> lis = new List<LocationDTO>();
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				LocationDTO DTO = new LocationDTO(item);
				lis.Add(DTO);
			}
			return lis;
		}
		public LocationDTO GetItem(int id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public LocationDTO GetItem(string name)
		{
			return GetList().Find(x => x.Name == name);
		}
		public bool Insert(string name)
		{
			string query = "insert Location(Name, Note) Values( @1 , NULL )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });
			return data > 0;
		}
		public bool Update(int id, string name)
		{
			string query = "update Location set Name = @1 where Id = @2 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, id });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "Delete Location where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
