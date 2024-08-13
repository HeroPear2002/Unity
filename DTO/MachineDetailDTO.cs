using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class MachineDetailDTO
	{
		long id;
		int idMachine;
		string detailName;
		string detailInfor;
		string note;

		public MachineDetailDTO(long id, int idMachine, string detailName, string detailInfor, string note)
		{
			Id = id;
			IdMachine = idMachine;
			DetailName = detailName;
			DetailInfor = detailInfor;
			Note = note;
		}
		public MachineDetailDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			IdMachine = int.Parse(row["IdMachine"].ToString());
			DetailName = row["DetailName"].ToString();
			DetailInfor = row["DetailInfor"].ToString();
			Note = row["Note"].ToString();
		}

		public long Id { get => id; set => id = value; }
		public int IdMachine { get => idMachine; set => idMachine = value; }
		public string DetailName { get => detailName; set => detailName = value; }
		public string DetailInfor { get => detailInfor; set => detailInfor = value; }
		public string Note { get => note; set => note = value; }
	}
}
