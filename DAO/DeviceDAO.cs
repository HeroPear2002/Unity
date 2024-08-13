using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class DeviceDAO
	{
		private static DeviceDAO instance;

		public static DeviceDAO Instance
		{
			get { if (instance == null) instance = new DeviceDAO(); return instance; }
			set => instance = value;
		}
		public DeviceDAO() { }

		public List<DeviceDTO> GetList()
		{
			string query = "select * from Device";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<DeviceDTO> lsv = new List<DeviceDTO>();
			foreach (DataRow item in data.Rows)
			{
				DeviceDTO DTO = new DeviceDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public DeviceDTO GetItem(int id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public DeviceDTO GetItem(string name)
		{
			return GetList().Find(x => x.Name == name);
		}
		public bool Insert(string name, string urlEveryday, string urlMainten)
		{
			string query = "insert Device(Name,StatusDevice, UrlEveryday, UrlMainten, FormCode, Note) values ( @1 ,NULL, @2 , @3 , NULL, NULL )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, urlEveryday, urlMainten });
			return data > 0;
		}
		public bool Update(int id, string name, string urlEveryday, string urlMainten)
		{
			string query = "update Device set Name= @1 , UrlEveryday = @2 , UrlMainten = @3 where Id = @4 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, urlEveryday, urlMainten, id });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "delete Device where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
