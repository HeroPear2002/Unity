using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class HistoryDeviceDTO
	{
		long id;
		long idRelationShip;
		string machineCode;
		string nameCategory;
		string method;
		string detail;
		string dataCount;
		DateTime dateCheck;
		int status;
		int timeReality;
		int timer;
		string result;
		string userName;
		string note;
		int statusCate;

		public HistoryDeviceDTO(long id, long idRelationShip, string machineCode, string nameCategory, string method, string detail, string dataCount, DateTime dateCheck, int status, int timeReality, int timer, string result, string userName, string note, int statusCate)
		{
			Id = id;
			IdRelationShip = idRelationShip;
			MachineCode = machineCode;
			NameCategory = nameCategory;
			Method = method;
			Detail = detail;
			DataCount = dataCount;
			DateCheck = dateCheck;
			Status = status;
			TimeReality = timeReality;
			Timer = timer;
			Result = result;
			UserName = userName;
			Note = note;
			StatusCate = statusCate;
		}
		public HistoryDeviceDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			NameCategory = row["NameCategory"].ToString();
			Method = row["Method"].ToString();
			Detail = row["Detail"].ToString();
			if (row["DataCount"].ToString() != "") DataCount = row["DataCount"].ToString();
			if (row["TimeReality"].ToString() != "") TimeReality = int.Parse(row["TimeReality"].ToString());
			if (row["Timer"].ToString() != "") Timer = int.Parse(row["Timer"].ToString());
			Result = row["Result"].ToString();
			Note = row["Note"].ToString();
			try
			{
				if (row["StatusCate"].ToString() != "") StatusCate = int.Parse(row["StatusCate"].ToString());
				MachineCode = row["MachineCode"].ToString();
				IdRelationShip = long.Parse(row["IdRelationShip"].ToString());
				if (row["Status"].ToString() != "") Status = int.Parse(row["Status"].ToString());
				if (row["DateCheck"].ToString() != "") DateCheck = DateTime.Parse(row["DateCheck"].ToString());
				if (row["UserName"].ToString() != "") UserName = row["UserName"].ToString();
			}
			catch (Exception)
			{
				UserName = "";
			}
			
			
		}
		public long Id { get => id; set => id = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string NameCategory { get => nameCategory; set => nameCategory = value; }
		public string Method { get => method; set => method = value; }
		public string Detail { get => detail; set => detail = value; }
		public string DataCount { get => dataCount; set => dataCount = value; }
		public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
		public int Status { get => status; set => status = value; }
		public int TimeReality { get => timeReality; set => timeReality = value; }
		public int Timer { get => timer; set => timer = value; }
		public string Result { get => result; set => result = value; }
		public string UserName { get => userName; set => userName = value; }
		public string Note { get => note; set => note = value; }
		public long IdRelationShip { get => idRelationShip; set => idRelationShip = value; }
		public int StatusCate { get => statusCate; set => statusCate = value; }
	}
}
