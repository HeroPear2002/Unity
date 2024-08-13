using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class SetupDefaultDTO
	{
		long id;
		string machineCode;
		string name;
		string moldCode;
		float valueDefault;

		public SetupDefaultDTO(long id, string machineCode, string name, string moldCode, float valueDefault)
		{
			Id = id;
			MachineCode = machineCode;
			Name = name;
			MoldCode = moldCode;
			ValueDefault = valueDefault;
		}
		public SetupDefaultDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			MachineCode = row["MachineCode"].ToString();
			Name = row["Name"].ToString();
			MoldCode = row["MoldCode"].ToString();
			ValueDefault = int.Parse(row["ValueDefault"].ToString());
		}

		public long Id { get => id; set => id = value; }
		public string MachineCode { get => machineCode; set => machineCode = value; }
		public string Name { get => name; set => name = value; }
		public string MoldCode { get => moldCode; set => moldCode = value; }
		public float ValueDefault { get => valueDefault; set => valueDefault = value; }
	}
}
