using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class LocationDTO
	{
		int id;
		string name;
		string note;

		public LocationDTO(int id, string name, string note)
		{
			Id = id;
			Name = name;
			Note = note;
		}
		public LocationDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			Name = row["Name"].ToString();
			Note = row["Note"].ToString();
		}

		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public string Note { get => note; set => note = value; }
	}
}
