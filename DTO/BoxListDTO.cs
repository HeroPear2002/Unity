using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class BoxListDTO
	{
		int id;
		string boxCode;
		string boxName;
		string styleBox;
		int boxIventory;

		public BoxListDTO(int id, string boxCode, string boxName, string styleBox, int boxIventory)
		{
			Id = id;
			BoxCode = boxCode;
			BoxName = boxName;
			StyleBox = styleBox;
			BoxIventory = boxIventory;
		}
		public BoxListDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			BoxCode = row["BoxCode"].ToString();
			BoxName = row["BoxName"].ToString();
			StyleBox = row["StyleBox"].ToString();
			BoxIventory = int.Parse(row["BoxIventory"].ToString());
		}
		public int Id { get => id; set => id = value; }
		public string BoxCode { get => boxCode; set => boxCode = value; }
		public string BoxName { get => boxName; set => boxName = value; }
		public string StyleBox { get => styleBox; set => styleBox = value; }
		public int BoxIventory { get => boxIventory; set => boxIventory = value; }
	}
}
