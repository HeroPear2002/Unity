using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class CateDataDefaultDTO
	{
		int id;
		string name;
		float upperLimit;
		float lowerLimit;
		string note;

		public CateDataDefaultDTO(int id, string name, float upperLimit, float lowerLimit, string note)
		{
			Id = id;
			Name = name;
			UpperLimit = upperLimit;
			LowerLimit = lowerLimit;
			Note = note;
		}
		public CateDataDefaultDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			Name = row["Name"].ToString();
			UpperLimit = float.Parse(row["UpperLimit"].ToString());
			LowerLimit = float.Parse(row["LowerLimit"].ToString());
			Note = row["Note"].ToString();
		}

		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public float UpperLimit { get => upperLimit; set => upperLimit = value; }
		public float LowerLimit { get => lowerLimit; set => lowerLimit = value; }
		public string Note { get => note; set => note = value; }
	}
}
