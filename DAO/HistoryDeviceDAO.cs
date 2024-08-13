using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class HistoryDeviceDAO
	{
		private static HistoryDeviceDAO instance;

		public static HistoryDeviceDAO Instance
		{
			get { if (instance == null) instance = new HistoryDeviceDAO(); return instance; }
			set => instance = value;
		}
		public HistoryDeviceDAO() { }

		public List<HistoryDeviceDTO> GetList()
		{
			string query = "select * from HistoryDevice,RelationMachineCate,Machine,CateTestMachine,[dbo].[User] where IdRelationship = RelationMachineCate.Id and IdMachine = Machine.Id and IdCategory = CateTestMachine.Id and IdUser = dbo.[User].Id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<HistoryDeviceDTO> lsv = new List<HistoryDeviceDTO>();
			foreach (DataRow item in data.Rows)
			{
				HistoryDeviceDTO DTO = new HistoryDeviceDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<HistoryDeviceDTO> GetListRelation()
		{
			string query = "select * from HistoryDevice,RelationMachineCate,Machine,CateTestMachine,[dbo].[User] where IdRelationship = RelationMachineCate.Id and IdMachine = Machine.Id and IdCategory = CateTestMachine.Id and IdUser = dbo.[User].Id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<HistoryDeviceDTO> lsv = new List<HistoryDeviceDTO>();
			foreach (DataRow item in data.Rows)
			{
				HistoryDeviceDTO DTO = new HistoryDeviceDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<HistoryDeviceDTO> GetItemRelation(long idRelationShip)
		{
			string query = "select * from HistoryDevice,RelationMachineCate,Machine,CateTestMachine,[dbo].[User] where IdRelationship = RelationMachineCate.Id and IdMachine = Machine.Id and IdCategory = CateTestMachine.Id and IdUser = dbo.[User].Id and IdRelationShip = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRelationShip });
			List<HistoryDeviceDTO> lsv = new List<HistoryDeviceDTO>();
			foreach (DataRow item in data.Rows)
			{
				HistoryDeviceDTO DTO = new HistoryDeviceDTO(item);
				lsv.Add(DTO);
			}
			lsv = lsv.OrderByDescending(dto => dto.DateCheck).ToList();
			return lsv;
		}
		public bool Insert(long idRelationShip,string result, float datacount, int status, DateTime dateCheck,int idUser, string note)
		{
			string query;
			int data;
			if (datacount == 0)
			{
				query = "insert HistoryDevice(idRelationShip, Result, DataCount, Status, DateCheck, IdUser, Note) values ( @1 , @2 , NULL , @4 , @5 , @6 , @7 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idRelationShip, result, status, dateCheck, idUser, note });
			}
			else
			{
				query = "insert HistoryDevice(idRelationShip, Result, DataCount, Status, DateCheck, IdUser, Note) values ( @1 , @2 , @3 , @4 , @5 , @6 , @7 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idRelationShip, result, datacount, status, dateCheck, idUser, note });
			}
			return data > 0;
		}
		public bool Update(long id, string result, float datacount, int status, DateTime dateCheck, string note)
		{
			string query;
			int data;
			if (datacount == 0)
			{
				query = "update HistoryDevice set Result = @1 ,DataCount = NULL, Status = @2 , DateCheck = @3 , Note = @4 where Id = @5 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { result, status, dateCheck, note, id });
			}
			else
			{
				query = "update HistoryDevice set Result = @0 ,  DataCount = @1 , Status = @2 , DateCheck = @3 , Note = @4 where Id = @5 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {result, datacount, status, dateCheck, note, id });
			}
			return data > 0;
		}
		public bool Delete(long id)
		{
			string query = "delete HistoryDevice where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
