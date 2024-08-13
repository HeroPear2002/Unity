using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class HistoryCheckDataDTO
	{
		long id;
		string moldCode;
		string machineCode;
		string name;
		DateTime dateCheck;
		float valueDefault;
		float valueReal;
		string userName;
		string note;

		public HistoryCheckDataDTO(long id, string moldCode, string machineCode, string name, DateTime dateCheck, float valueDefault, float valueReal, string userName, string note)
		{
			Id = id;
			MoldCode = moldCode;
			MachineCode = machineCode;
			Name = name;
			DateCheck = dateCheck;
			ValueDefault = valueDefault;
			ValueReal = valueReal;
			UserName = userName;
			Note = note;
		}
		public HistoryCheckDataDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			MoldCode = row["MoldCode"].ToString();
			MachineCode = row["MachineCode"].ToString();
			Name = row["Name"].ToString();
			DateCheck = DateTime.Parse(row["DateCheck"].ToString());
			ValueDefault = float.Parse(row["ValueDefault"].ToString());
			ValueReal = float.Parse(row["ValueReal"].ToString());
			UserName = row["UserName"].ToString();
			Note = row["Note"].ToString();
		}

		public long Id { get => id; set => id = value; }
		public string MoldCode { get => moldCode; set => moldCode = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string Name { get => name; set => name = value; }
		public DateTime DateCheck { get => dateCheck; set => dateCheck = value; }
		public float ValueDefault { get => valueDefault; set => valueDefault = value; }
		public float ValueReal { get => valueReal; set => valueReal = value; }
		public string UserName { get => userName; set => userName = value; }
		public string Note { get => note; set => note = value; }
	}
}
