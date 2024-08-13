using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DataCheckDTO
	{
		long id;
		long idSetup;
		string name;
		float upperLimit;
		float valueDefault;
		float lowerLimit;
		string valueReal;

		public DataCheckDTO(long id, long idSetup, string name, float upperLimit, float valueDefault, float lowerLimit, string valueReal)
		{
			Id = id;
			IdSetup = idSetup;
			Name = name;
			UpperLimit = upperLimit;
			ValueDefault = valueDefault;
			LowerLimit = lowerLimit;
			ValueReal = valueReal;
		}
		public DataCheckDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			IdSetup = long.Parse(row["IdSetup"].ToString());
			Name = row["Name"].ToString();
			UpperLimit = float.Parse(row["UpperLimit"].ToString());
			ValueDefault = float.Parse(row["ValueDefault"].ToString());
			LowerLimit = float.Parse(row["LowerLimit"].ToString());
			ValueReal = row["ValueReal"].ToString();
		}

		public long Id { get => id; set => id = value; }
		public long IdSetup { get => idSetup; set => idSetup = value; }
		public string Name { get => name; set => name = value; }
		public float UpperLimit { get => upperLimit; set => upperLimit = value; }
		public float ValueDefault { get => valueDefault; set => valueDefault = value; }
		public float LowerLimit { get => lowerLimit; set => lowerLimit = value; }
		public string ValueReal { get => valueReal; set => valueReal = value; }
	}
}
