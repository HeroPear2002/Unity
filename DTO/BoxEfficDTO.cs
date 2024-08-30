using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class BoxEfficDTO
	{
		int id;
		string boxCode;
		string partCode;
		string styleBox;
		DateTime dateNew;
		int quantity;
		int countBox;
		int countBoxReal;
		int boxIventory;

		public BoxEfficDTO(int id, string boxCode, string partCode, string styleBox, DateTime dateNew, int quantity, int countBox, int countBoxReal, int boxIventory)
		{
			Id = id;
			BoxCode = boxCode;
			PartCode = partCode;
			StyleBox = styleBox;
			DateNew = dateNew;
			Quantity = quantity;
			CountBox = countBox;
			CountBoxReal = countBoxReal;
			BoxIventory = boxIventory;
		}

		public BoxEfficDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			BoxCode = row["BoxCode"].ToString();
			PartCode = row["PartCode"].ToString();
			StyleBox = row["StyleBox"].ToString();
			DateNew = DateTime.Parse(row["DateNew"].ToString());
			Quantity = int.Parse(row["Quantity"].ToString());
			CountBox = int.Parse(row["CountBox"].ToString());
			CountBoxReal = int.Parse(row["CountBoxReal"].ToString());
			BoxIventory = int.Parse(row["BoxIventory"].ToString());
		}

		public int Id { get => id; set => id = value; }
		public string BoxCode { get => boxCode; set => boxCode = value; }
		public string PartCode { get => partCode; set => partCode = value; }
		public string StyleBox { get => styleBox; set => styleBox = value; }
		public DateTime DateNew { get => dateNew; set => dateNew = value; }
		public int Quantity { get => quantity; set => quantity = value; }
		public int CountBox { get => countBox; set => countBox = value; }
		public int CountBoxReal { get => countBoxReal; set => countBoxReal = value; }
		public int BoxIventory { get => boxIventory; set => boxIventory = value; }
	}
}
