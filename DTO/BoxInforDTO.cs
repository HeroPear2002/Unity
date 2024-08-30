using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class BoxInforDTO
	{
		int id;
		string boxCode;
		string partCode;
		string note;

		public BoxInforDTO(int id, string boxCode, string partCode, string note)
		{
			Id = id;
			BoxCode = boxCode;
			PartCode = partCode;
			Note = note;
		}

		public BoxInforDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			BoxCode = row["BoxCode"].ToString();
			PartCode = row["PartCode"].ToString();
			Note = row["Note"].ToString();
		}

		public int Id { get => id; set => id = value; }
		public string BoxCode { get => boxCode; set => boxCode = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string Note { get => note; set => note = value; }
	}
}
