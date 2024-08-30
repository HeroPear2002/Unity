using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class PartInforDAO
	{
		private static PartInforDAO instance;

		public static PartInforDAO Instance
		{
			get { if (instance == null) instance = new PartInforDAO(); return instance; }
			set => instance = value;
		}
		public PartInforDAO() { }
		public List<PartInforDTO> Getlist()
		{
			string query = "SELECT * FROM dbo.PartInfor,Part WHERE IdPart=Part.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<PartInforDTO> lsv = new List<PartInforDTO>();
			foreach (DataRow item in data.Rows)
			{
				PartInforDTO DTO = new PartInforDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public PartInforDTO GetItem(int id)
		{
			string query = "SELECT * FROM dbo.PartInfor,Part WHERE IdPart=Part.Id and PartInfor.Id= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
			foreach (DataRow item in data.Rows)
			{
				PartInforDTO DTO = new PartInforDTO(item);
				return DTO;
			}
			return null;
		}
		public PartInforDTO GetItemPart(int idPart)
		{
			string query = "SELECT * FROM dbo.PartInfor,Part WHERE IdPart=Part.Id and IdPart= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idPart });
			foreach (DataRow item in data.Rows)
			{
				PartInforDTO DTO = new PartInforDTO(item);
				return DTO;
			}
			return null;
		}
		public PartInforDTO GetItemPart(string partCode)
		{
			string query = "SELECT * FROM dbo.PartInfor,Part WHERE IdPart=Part.Id and Part.PartCode= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { partCode });
			foreach (DataRow item in data.Rows)
			{
				PartInforDTO DTO = new PartInforDTO(item);
				return DTO;
			}
			return null;
		}
	}
}
