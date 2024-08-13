using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class RelationMachineCateDTO
	{
		long id;
		int idMachine;
		string machineCode;
		string nameCategory;
		string method;
		string detail;
		int timeReality;
		int statusRe;
		int timer;
		int statusCate;

		public RelationMachineCateDTO(long id,int idMachine, string machineCode, string nameCategory, string method, string detail, int timeReality, int statusRe, int timer, int statusCate)
		{
			Id = id;
			IdMachine = idMachine;
			MachineCode = machineCode;
			NameCategory = nameCategory;
			Method = method;
			Detail = detail;
			TimeReality = timeReality;
			StatusRe = statusRe;
			Timer = timer;
			StatusCate = statusCate;
		}
		public RelationMachineCateDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			IdMachine = int.Parse(row["IdMachine"].ToString());
			MachineCode = row["MachineCode"].ToString();
			NameCategory = row["NameCategory"].ToString();
			Method = row["Method"].ToString();
			Detail = row["Detail"].ToString();
			if(row["TimeReality"].ToString() != "") TimeReality = int.Parse(row["TimeReality"].ToString());
			if (row["StatusRe"].ToString() != "") StatusRe = int.Parse(row["StatusRe"].ToString());
			if (row["Timer"].ToString() != "") Timer = int.Parse(row["Timer"].ToString());
			if (row["StatusCate"].ToString() != "") StatusCate = int.Parse(row["StatusCate"].ToString());
		}
		public long Id { get => id; set => id = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string NameCategory { get => nameCategory; set => nameCategory = value; }
		public string Method { get => method; set => method = value; }
		public string Detail { get => detail; set => detail = value; }
		public int TimeReality { get => timeReality; set => timeReality = value; }
		public int StatusRe { get => statusRe; set => statusRe = value; }
		public int Timer { get => timer; set => timer = value; }
		public int IdMachine { get => idMachine; set => idMachine = value; }
		public int StatusCate { get => statusCate; set => statusCate = value; }
	}
}
