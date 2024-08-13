using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class DataCheckDAO
	{
		private static DataCheckDAO instance;

		public static DataCheckDAO Instance { get { if (instance == null) instance = new DataCheckDAO(); return instance; } set => instance = value; }

		public DataCheckDAO() { }
		public List<HistoryCheckDataDTO> GetList()
		{
			List<HistoryCheckDataDTO> list = new List<HistoryCheckDataDTO>();
			string query = "select * from DataCheck,SetupDefault,Mold,Machine,CateDataDefault,[dbo].[User] where IdSetup = SetupDefault.Id and IdMold = Mold.Id and IdMachine = Machine.Id and IdUser = [dbo].[User].Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				HistoryCheckDataDTO DTO = new HistoryCheckDataDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public List<HistoryCheckDataDTO> GetList(string moldCode, string machineCode)
		{
			List<HistoryCheckDataDTO> list = new List<HistoryCheckDataDTO>();
			string query = "select * from DataCheck,SetupDefault,Mold,Machine,CateDataDefault,[dbo].[User] where IdSetup = SetupDefault.Id and IdMold = Mold.Id and IdMachine = Machine.Id and IdUser = [dbo].[User].Id and MoldCode = @1 and MachineCode = @2 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {moldCode, machineCode });
			foreach (DataRow item in data.Rows)
			{
				HistoryCheckDataDTO DTO = new HistoryCheckDataDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public List<HistoryCheckDataDTO> GetListHistory(string moldCode, string machineCode, DateTime dateFrom, DateTime dateTo)
		{
			return GetList(moldCode, machineCode).Where(x => x.DateCheck >= dateFrom && x.DateCheck <= dateTo ).ToList();
		}
		public bool Insert(long idSetup, DateTime dateCheck, float valueReal, int idUser)
		{
			string query = "insert DataCheck(idSetup, DateCheck, ValueReal, Note, IdUser) values ( @1 , @2 , @3 , NULL , @5 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idSetup, dateCheck, valueReal, idUser });
			return data > 0;
		}
		public bool Update(long id, float valueReal, string note)
		{
			string query = "update DataCheck set ValueReal = @3 , Note = @4 where Id = @6 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { valueReal, note, id });
			return data > 0;
		}
		public bool Delete(long id)
		{
			string query = "Delete DataCheck where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
