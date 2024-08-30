using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
	public class BoxListDAO
	{
		private static BoxListDAO instance;

		public static BoxListDAO Instance { get { if (instance == null) instance = new BoxListDAO(); return instance; } set => instance = value; }

		public BoxListDAO() { }

		public List<BoxListDTO> GetList()
		{
			string query = "select * from BoxList";
			List<BoxListDTO> list = new List<BoxListDTO>();
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				BoxListDTO DTO = new BoxListDTO(item);
				list.Add(DTO);
			}
			return list;
		}

		public BoxListDTO GetItem(int id)
		{
			return GetList().FirstOrDefault(x => x.Id == id);
		}

		public BoxListDTO GetItem(string boxCode)
		{
			return GetList().FirstOrDefault(x => x.BoxCode == boxCode);
		}

		public bool Insert(string boxCode, string boxName, string styleBox, int boxIventory)
		{
			string query = "insert BoxList(BoxCode,BoxName,StyleBox,BoxIventory) Values( @1 , @2 , @3 , @4 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { boxCode, boxName, styleBox, boxIventory });
			return data > 0;
		}

		public bool Update(int id, string boxCode, string boxName, string styleBox, int boxIventory)
		{
			string query = "update BoxList set BoxCode = @1 , BoxName = @2 , StyleBox = @3 , BoxIventory = @4 where Id = @5 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { boxCode, boxName, styleBox, boxIventory, id });
			return data > 0;
		}

		public bool Update(int id, int boxIventory)
		{
			string query = "update BoxList set BoxIventory = @4 where Id = @5 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { boxIventory, id });
			return data > 0;
		}

		public bool Delete(int id)
		{
			string query = "Delete BoxList where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
