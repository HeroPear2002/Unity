using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class BoxEfficDAO
	{
		private static BoxEfficDAO instance;

		public static BoxEfficDAO Instance { get { if (instance == null) instance = new BoxEfficDAO(); return instance; } set => instance = value; }

		public BoxEfficDAO() { }

		public List<BoxEfficDTO> GetList()
		{
			string query = "Select * from BoxEffic, BoxInfor, BoxList, Part where BoxEffic.IdPart = BoxInfor.IdPart and IdBox = BoxList.Id and BoxEffic.IdPart = Part.Id ";
			List<BoxEfficDTO> list = new List<BoxEfficDTO>();
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				BoxEfficDTO DTO = new BoxEfficDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public BoxEfficDTO GetItem(DateTime dateNew, string partCode)
		{
			return GetList().FirstOrDefault(x => x.DateNew.Month == dateNew.Month && x.DateNew.Year == dateNew.Year && x.PartCode == partCode);
		}
		public bool Insert(DateTime dateNew, int idPart, int quantity, int countBox, int countBoxReal)
		{
			string query = "Insert BoxEffic(DateNew, IdPart, Quantity, CountBox, CountBoxReal) Values( @1 , @2 , @3 , @4 , @5 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { dateNew, idPart, quantity, countBox, countBoxReal});
			return data > 0;
		}
		public bool Update(int id, DateTime dateNew, int idPart, int quantity, int countBox, int countBoxReal)
		{
			string query = "Upadte BoxEffic set DateNew = @1 , IdPart = @2 , Quantity = @3 , CountBox = @4 , CountBoxReal= @5 where Id = @6 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { dateNew, idPart, quantity, countBox, countBoxReal, id });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "Delete BoxEffic where Id = @1  ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}

	}
}
