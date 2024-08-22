using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class PartDAO
	{
		private static PartDAO instance;

		public static PartDAO Instance
		{
			get { if (instance == null) instance = new PartDAO(); return instance; }
			set => instance = value;
		}
		public PartDAO() { }
		public List<PartDTO> Getlist()
		{
			string query = "SELECT * FROM dbo.Part,dbo.Customer,dbo.Material WHERE IdCus=Customer.Id AND Material.MatCode=Part.MatCode";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<PartDTO> lsv = new List<PartDTO>();
			foreach (DataRow item in data.Rows)
			{
				PartDTO DTO = new PartDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public PartDTO GetItem(int id)
		{
			string query = "SELECT * FROM dbo.Part,dbo.Customer,dbo.Material WHERE IdCus=Customer.Id AND Material.MatCode=Part.MatCode and dbo.Part.Id= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
			foreach (DataRow item in data.Rows)
			{
				PartDTO DTO = new PartDTO(item);
				return DTO;
			}
			return null;
		}
		public PartDTO GetItemByPartCode(string partcode)
		{
			string query = "SELECT * FROM dbo.Part,dbo.Customer,dbo.Material WHERE IdCus=Customer.Id AND Material.MatCode=Part.MatCode and dbo.Part.PartCode= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { partcode });
			foreach (DataRow item in data.Rows)
			{
				PartDTO DTO = new PartDTO(item);
				return DTO;
			}
			return null;
		}
		public PartDTO GetItem(string matcode)
		{
			string query = "SELECT * FROM dbo.Part,dbo.Customer,dbo.Material WHERE IdCus=Customer.Id AND Material.MatCode=Part.MatCode and dbo.Part.MatCode= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { matcode });
			foreach (DataRow item in data.Rows)
			{
				PartDTO DTO = new PartDTO(item);
				return DTO;
			}
			return null;
		}
		public int Insert(string partCode, string partName, string matCode, int idCus, int countPart, int countBox, float weightPart, float weightRunner, float cyleTime, int cav, string nameVN, int height, string note)
		{
			string query = "INSERT dbo.Part " +
				"(PartCode, Partname,MatCode,  IdCus,CountPart,CountBox,WeightPart,WeightRunner,CycleTime,Cav,Height,NameVN,Note)" +
				" VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 , @12 , @13 ) ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { partCode, partName, matCode, idCus, countPart, countBox, weightPart, weightRunner, cyleTime, cav, height, nameVN, note });
			return data;
		}
		public int Update(int id, string partCode, string partName, string matCode, int idCus, int countPart, int countBox, float weightPart, float weightRunner, float cyleTime, int cav, string nameVN, int height, string note)
		{
			string query = "Update dbo.Part  set PartCode= @1  , Partname= @2  , MatCode= @3  , IdCus= @4  , CountPart= @5  , CountBox= @6  , WeightPart= @7  ,WeightRunner= @8  , CycleTime= @9  , Cav= @10 , Height= @11 , NameVN= @12  , Note= @13  where Id= @14 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { partCode, partName, matCode, idCus, countPart, countBox, weightPart, weightRunner, cyleTime, cav, height, nameVN, note, id });
			return data;
		}
		public int Delete(int id)
		{
			string query = "Delete dbo.Part where Id= @1  ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data;
		}
	}
}