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
		private float cycleTime;
		private int cav;
		private string nameVN;
		private int height;
		private string note;
		private string matName;
		private string stylePart;


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
			CycleTime = float.Parse(row["CycleTime"].ToString());
			Cav = int.Parse(row["Cav"].ToString());
			NameVN = row["NameVN"].ToString();
			Height = int.Parse(row["Height"].ToString());
			Note = row["Note"].ToString();
			StylePart = row["StylePart"].ToString();
		}

		public PartDTO(int id, string partCode, string partName, string matCode, int idCus, string cusCode, int countPart, int countBox, float weightPart, float weightRunner, float cycleTime, int cav, string nameVN, int height, string note, string matName, string stylePart)
		{
			Id = id;
			PartCode = partCode;
			PartName = partName;
			MatCode = matCode;
			IdCus = idCus;
			CusCode = cusCode;
			CountPart = countPart;
			CountBox = countBox;
			WeightPart = weightPart;
			WeightRunner = weightRunner;
			CycleTime = cycleTime;
			Cav = cav;
			NameVN = nameVN;
			Height = height;
			Note = note;
			MatName = matName;
			StylePart = stylePart;
		}

		public int Id { get => id; set => id = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string PartName { get => partName; set => partName = value; }
		public string MatCode { get => matCode; set => matCode = value; }
		public int IdCus { get => idCus; set => idCus = value; }
		public string CusCode { get => cusCode; set => cusCode = value; }
		public int CountPart { get => countPart; set => countPart = value; }
		public int CountBox { get => countBox; set => countBox = value; }
		public float WeightPart { get => weightPart; set => weightPart = value; }
		public float WeightRunner { get => weightRunner; set => weightRunner = value; }
		public float CycleTime { get => cycleTime; set => cycleTime = value; }
		public int Cav { get => cav; set => cav = value; }
		public string NameVN { get => nameVN; set => nameVN = value; }
		public int Height { get => height; set => height = value; }
		public string Note { get => note; set => note = value; }
		public string MatName { get => matName; set => matName = value; }
		public string StylePart { get => stylePart; set => stylePart = value; }
	}
}