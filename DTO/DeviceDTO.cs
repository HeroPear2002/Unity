using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DeviceDTO
	{
		int id;
		string name;
		int statusDevice;
		string urlEveryday;
		string urlMainten;
		string formCode;
		string note;

		public DeviceDTO(int id, string name, int statusDevice, string urlEveryday, string urlMainten, string formCode, string note)
		{
			Id = id;
			Name = name;
			StatusDevice = statusDevice;
			UrlEveryday = urlEveryday;
			UrlMainten = urlMainten;
			FormCode = formCode;
			Note = note;
		}
		public DeviceDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			Name = row["Name"].ToString();
			if (row["StatusDevice"].ToString() != "")
				StatusDevice = int.Parse(row["StatusDevice"].ToString());
			UrlEveryday = row["UrlEveryday"].ToString();
			UrlMainten = row["UrlMainten"].ToString();
			FormCode = row["FormCode"].ToString();
			Note = row["Note"].ToString();
		}

		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public int StatusDevice { get => statusDevice; set => statusDevice = value; }
		public string UrlEveryday { get => urlEveryday; set => urlEveryday = value; }
		public string UrlMainten { get => urlMainten; set => urlMainten = value; }
		public string FormCode { get => formCode; set => formCode = value; }
		public string Note { get => note; set => note = value; }
	}
}
