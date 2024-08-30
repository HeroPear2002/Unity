using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class PartInforDTO
	{
		int id;
		int idPart;
		string partCode;
		float percentage;
		float weightBy;

		public PartInforDTO(int id, int idPart, string partCode, float percentage, float weightBy)
		{
			Id = id;
			IdPart = idPart;
			PartCode = partCode;
			Percentage = percentage;
			WeightBy = weightBy;
		}
		public PartInforDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			IdPart = int.Parse(row["IdPart"].ToString());
			PartCode = row["PartCode"].ToString();
			Percentage = float.Parse(row["Percentage"].ToString());
			WeightBy = float.Parse(row["WeightBy"].ToString());
		}

		public int Id { get => id; set => id = value; }
		public int IdPart { get => idPart; set => idPart = value; }
		public float Percentage { get => percentage; set => percentage = value; }
		public float WeightBy { get => weightBy; set => weightBy = value; }
		public string PartCode { get => partCode; set => partCode = value; }
	}
}
