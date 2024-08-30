using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class BoxInforDAO
	{
		private static BoxInforDAO instance;

		public static BoxInforDAO Instance { get { if (instance == null) instance = new BoxInforDAO(); return instance; } set => instance = value; }

		public BoxInforDAO() { }

		public List<BoxInforDTO> GetList()
		{
			string query = "select * from BoxInfor,BoxList,Part where IdBox = BoxList.Id and IdPart = Part.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<BoxInforDTO> list = new List<BoxInforDTO>();
			foreach (DataRow item in data.Rows)
			{
				BoxInforDTO DTO = new BoxInforDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public BoxInforDTO GetItem(int idBox, int idPart)
		{
			string query = "select * from BoxInfor,BoxList,Part where IdBox = BoxList.Id and IdPart = Part.Id and IdBox = @1 and IdPart = @2 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBox, idPart});
			if(data == null)
			{
				BoxInforDTO DTO = new BoxInforDTO(data.Rows[0]);
				return DTO;
			}
			else return null;
		}
		public BoxInforDTO GetItem(string boxCode, string partCode)
		{
			return GetList().FirstOrDefault(x => x.BoxCode == boxCode && x.PartCode == partCode);
		}
		public bool Insert(int idBox, int idPart)
		{
			string query = "Insert BoxInfor(IdBox, IdPart) values( @1 , @2 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBox, idPart });
			return data > 0;
		}
		public bool Update(int id, int idBox, int idPart)
		{
			string query = "Update BoxInfor set IdBox = @1 , IdPart = @2 where Id = @3 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBox, idPart, id });
			return data>0;
		}
		public bool Delete(int id)
		{
			string query = "Delete BoxInfor where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
