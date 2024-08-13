using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class HistoryEditMachineDTO
	{
		long id;
		int idMachine;
		string dateMachine;
		int timeMachine;
		string errorName;
		string reason;
		string detail;
		string employees;
		string note;
		string dateError;
		string timeStart;
		string timeMain;

		public HistoryEditMachineDTO(long id, int idMachine, string dateMachine, 
			int timeMachine, string errorName, string reason, string detail, 
			string employees, string note, string dateError, string timeStart, string timeMain)
		{
			Id = id;
			IdMachine = idMachine;
			DateMachine = dateMachine;
			TimeMachine = timeMachine;
			ErrorName = errorName;
			Reason = reason;
			Detail = detail;
			Employees = employees;
			Note = note;
			DateError = dateError;
			TimeStart = timeStart;
			TimeMain = timeMain;
		}
		public HistoryEditMachineDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			IdMachine = int.Parse(row["IdMachine"].ToString());
			DateMachine = row["DateMachine"].ToString();
			TimeMachine = int.Parse(row["TimeMachine"].ToString());
			ErrorName = row["ErrorName"].ToString();
			Reason = row["Reason"].ToString();
			Detail = row["Detail"].ToString();
			Employees = row["Employees"].ToString();
			Note = row["Note"].ToString();
			DateError = row["DateError"].ToString();
			TimeStart = row["TimeStart"].ToString();
			TimeMain = row["TimeMain"].ToString();
		}

		public long Id { get => id; set => id = value; }
		public int IdMachine { get => idMachine; set => idMachine = value; }
		public string DateMachine { get => dateMachine; set => dateMachine = value; }
		public int TimeMachine { get => timeMachine; set => timeMachine = value; }
		public string ErrorName { get => errorName; set => errorName = value; }
		public string Reason { get => reason; set => reason = value; }
		public string Detail { get => detail; set => detail = value; }
		public string Employees { get => employees; set => employees = value; }
		public string Note { get => note; set => note = value; }
		public string DateError { get => dateError; set => dateError = value; }
		public string TimeStart { get => timeStart; set => timeStart = value; }
		public string TimeMain { get => timeMain; set => timeMain = value; }
	}
}
