using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class PartDTO
	{

		private int id;
		private string partCode;
		private string partName;
		private string matCode;
		private int idCus;
		private string cusCode;
		private int countPart;
		private int countBox;
		private float weightPart;
		private float weightRunner;
		private float cyleTime;
		private int cav;
		private string nameVN;
		private int height;
		private string note;
		private string matName;


		public PartDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			PartCode = row["PartCode"].ToString();
			PartName = row["Partname"].ToString();
			MatCode = row["MatCode"].ToString();
			MatName = row["MatName"].ToString();
			IdCus = int.Parse(row["IdCus"].ToString());
			CusCode = row["CusCode"].ToString();
			CountPart = int.Parse(row["CountPart"].ToString());
			CountBox = int.Parse(row["CountBox"].ToString());
			WeightPart = float.Parse(row["WeightPart"].ToString());
			WeightRunner = float.Parse(row["WeightRunner"].ToString());
			CyleTime = float.Parse(row["CycleTime"].ToString());
			Cav = int.Parse(row["Cav"].ToString());
			NameVN = row["NameVN"].ToString();
			Height = int.Parse(row["Height"].ToString());
			Note = row["Note"].ToString();
		}

		public PartDTO(int id, string partCode, string partName, string matCode, int idCus, int countPart, int countBox, float weightPart, float weightRunner, float cyleTime, int cav, string nameVN, int height, string note, string cusCode, string matName, int num)
		{
			Id = id;
			PartCode = partCode;
			PartName = partName;
			MatCode = matCode;
			IdCus = idCus;
			CountPart = countPart;
			CountBox = countBox;
			WeightPart = weightPart;
			WeightRunner = weightRunner;
			CyleTime = cyleTime;
			Cav = cav;
			NameVN = nameVN;
			Height = height;
			Note = note;
			CusCode = cusCode;
			MatName = matName;
		}

		public int Id { get => id; set => id = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string PartName { get => partName; set => partName = value; }
		public string MatCode { get => matCode; set => matCode = value; }

		public int IdCus { get => idCus; set => idCus = value; }

		public int CountPart { get => countPart; set => countPart = value; }
		public int CountBox { get => countBox; set => countBox = value; }
		public float WeightPart { get => weightPart; set => weightPart = value; }
		public float WeightRunner { get => weightRunner; set => weightRunner = value; }
		public float CyleTime { get => cyleTime; set => cyleTime = value; }
		public int Cav { get => cav; set => cav = value; }
		public string NameVN { get => nameVN; set => nameVN = value; }
		public int Height { get => height; set => height = value; }
		public string Note { get => note; set => note = value; }
		public string CusCode { get => cusCode; set => cusCode = value; }
		public string MatName { get => matName; set => matName = value; }

	}
}