using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class MachineDetailDAO
	{
		private static MachineDetailDAO instance;

		public static MachineDetailDAO Instance
		{
			get
			{
				if (instance == null) instance = new MachineDetailDAO();
				return instance;
			}
			set => instance = value;
		}
		public MachineDetailDAO() { }
		public List<MachineDetailDTO> GetListMachineDetail()
		{
			List<MachineDetailDTO> listM = new List<MachineDetailDTO>();
			string query = "SELECT * FROM MachineDetail";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				MachineDetailDTO m = new MachineDetailDTO(item);
				listM.Add(m);
			}
			return listM;
		}
		public List<MachineDetailDTO> GetListMachineDetail(int idMachine)
		{
			List<MachineDetailDTO> listM = new List<MachineDetailDTO>();
			string query = "SELECT * FROM MachineDetail WHERE IdMachine = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query , new object[] { idMachine});
			foreach (DataRow item in data.Rows)
			{
				MachineDetailDTO m = new MachineDetailDTO(item);
				listM.Add(m);
			}
			return listM;
		}

		public bool InsertMachineDetail(int idMachine, string detailName, string detailInfor, string note)
		{
			string query = "INSERT INTO [dbo].[MachineDetail] (IdMachine,DetailName,DetailInfor,Note) VALUES ( @1 , @2 , @3 , @4 )";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, detailName, detailInfor, note });
			return result > 0;
		}
		public bool UpdateMachineDetail(long Id, int idMachine, string detailName, string detailInfor, string note)
		{
			string query = "UPDATE [dbo].[MachineDetail] SET [IdMachine] = @1 ,DetailName = @2 ,DetailInfor = @3 ,Note = @4 WHERE Id = @5 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, detailName, detailInfor, note , Id });
			return result > 0;
		}
		public bool DeleteMachineDetail(long Id)
		{
			string query = "DELETE [dbo].[MachineDetail] WHERE Id = @1 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Id });
			return result > 0;
		}
	}
}
