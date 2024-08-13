using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class CateTestMachineDTO
	{
		int id;
		string nameCategory;
		string detail;
		int timer;
		string method;
		int statusCate;
		int idDevice;
		string name;
		string limit;
		string noteCate;

		public CateTestMachineDTO(int id, string nameCategory, string detail, int timer, string method, int statusCate, int idDevice, string name, string limit, string noteCate)
		{
			Id = id;
			NameCategory = nameCategory;
			Detail = detail;
			Timer = timer;
			Method = method;
			StatusCate = statusCate;
			IdDevice = idDevice;
			Name = name;
			Limit = limit;
			NoteCate = noteCate;
		}
		public CateTestMachineDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			NameCategory = row["NameCategory"].ToString();
			Detail = row["Detail"].ToString();
			Timer = int.Parse(row["Timer"].ToString());
			Method = row["Method"].ToString();
			StatusCate = int.Parse(row["StatusCate"].ToString());
			IdDevice = int.Parse(row["IdDevice"].ToString());
			Name = row["Name"].ToString();
			Limit = row["Limit"].ToString();
			NoteCate = row["NoteCate"].ToString();
		}

		public int Id { get => id; set => id = value; }
		public string NameCategory { get => nameCategory; set => nameCategory = value; }
		public string Detail { get => detail; set => detail = value; }
		public int Timer { get => timer; set => timer = value; }
		public string Method { get => method; set => method = value; }
		public int StatusCate { get => statusCate; set => statusCate = value; }
		public string Limit { get => limit; set => limit = value; }
		public string NoteCate { get => noteCate; set => noteCate = value; }
		public string Name { get => name; set => name = value; }
		public int IdDevice { get => idDevice; set => idDevice = value; }
	}
}
