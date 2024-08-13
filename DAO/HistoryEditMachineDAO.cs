using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class HistoryEditMachineDAO
	{
		private static HistoryEditMachineDAO instance;

		public static HistoryEditMachineDAO Instance
		{
			get { if (instance == null) instance = new HistoryEditMachineDAO(); return instance; }
			set => instance = value;
		}
		public HistoryEditMachineDAO() { }

		public List<HistoryEditMachineDTO> GetList()
		{
			string query = "select * from HistoryEditMachine";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<HistoryEditMachineDTO> lsv = new List<HistoryEditMachineDTO>();
			foreach (DataRow item in data.Rows)
			{
				HistoryEditMachineDTO DTO = new HistoryEditMachineDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<HistoryEditMachineDTO> GetList(int idMachine)
		{
			string query = "select * from HistoryEditMachine where IdMachine = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idMachine });
			List<HistoryEditMachineDTO> lsv = new List<HistoryEditMachineDTO>();
			foreach (DataRow item in data.Rows)
			{
				HistoryEditMachineDTO DTO = new HistoryEditMachineDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public HistoryEditMachineDTO GetItem(long id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public bool Insert(int idMachine, DateTime dateMachine, int timeMachine, string errorName, string reason, string detail, string employees, string note, DateTime dateError, string timeStart, string timeMain)
		{
			string query;
			int data;
			if (timeMain == "" && timeStart == "")
			{
				query = "INSERT dbo.HistoryEditMachine ( IdMachine, DateMachine ,TimeMachine ,ErrorName ,Reason , Detail ,Employees , Note , DateError , TimeStart , TimeMain) VALUES  ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , NULL , NULL )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError  });

			}
			else if (timeStart == "")
			{
				query = "INSERT dbo.HistoryEditMachine ( IdMachine, DateMachine ,TimeMachine ,ErrorName ,Reason , Detail ,Employees , Note , DateError , TimeStart , TimeMain) VALUES  ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , NULL , @11 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, timeMain });
			}
			else if (timeMain == "")
			{
				query = "INSERT dbo.HistoryEditMachine ( IdMachine, DateMachine ,TimeMachine ,ErrorName ,Reason , Detail ,Employees , Note , DateError , TimeStart , TimeMain) VALUES  ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , NULL )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, timeStart });
			}
			else
			{
				query = "INSERT dbo.HistoryEditMachine ( IdMachine, DateMachine ,TimeMachine ,ErrorName ,Reason , Detail ,Employees , Note , DateError , TimeStart , TimeMain) VALUES  ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, timeStart, timeMain });
			}
				return data > 0;
		}
		public bool Update(long id, int idMachine, DateTime dateMachine, int timeMachine, string errorName, string reason, string detail, string employees, string note, DateTime dateError, string timeStart, string timeMain)
		{
			string query;
			int data;
			if (timeMain == "" && timeStart == "")
			{
				query = "update HistoryEditMachine set IdMachine= @1 , DateMachine = @2 , TimeMachine = @3 , ErrorName = @4 , Reason = @5 , Detail = @6 ,Employees = @7 , Note = @8 , DateError = @9 , TimeStart = NULL , TimeMain = NULL where Id = @12 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, id });
			}
			else if (timeStart == "")
			{
				query = "update HistoryEditMachine set IdMachine= @1 , DateMachine = @2 , TimeMachine = @3 , ErrorName = @4 , Reason = @5 , Detail = @6 ,Employees = @7 , Note = @8 , DateError = @9 , TimeStart = NULL , TimeMain = @11 where Id = @12 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, timeMain, id });
			}
			else if (timeMain == "")
			{
				query = "update HistoryEditMachine set IdMachine= @1 , DateMachine = @2 , TimeMachine = @3 , ErrorName = @4 , Reason = @5 , Detail = @6 ,Employees = @7 , Note = @8 , DateError = @9 , TimeStart = @10 , TimeMain = NULL where Id = @12 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, timeStart, id });
			}
			else
			{
				query = "update HistoryEditMachine set IdMachine= @1 , DateMachine = @2 , TimeMachine = @3 , ErrorName = @4 , Reason = @5 , Detail = @6 ,Employees = @7 , Note = @8 , DateError = @9 , TimeStart = @10 , TimeMain = @11 where Id = @12 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, dateMachine, timeMachine, errorName, reason, detail, employees, note, dateError, timeStart, timeMain, id });
			}

			return data > 0;
		}
		public bool Delete(long id)
		{
			string query = "delete HistoryEditMachine where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
