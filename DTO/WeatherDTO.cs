using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class WeatherDTO
	{
		int id;
		string name;
		float temperature;
		float humidity;
		DateTime dateWeather;
		string userName;

		public WeatherDTO(int id, string name, float temperature, float humidity, DateTime dateWeather, string userName)
		{
			Id = id;
			Name = name;
			Temperature = temperature;
			Humidity = humidity;
			DateWeather = dateWeather;
			UserName = userName;
		}
		public WeatherDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			Name = row["Name"].ToString();
			Temperature = float.Parse(row["Temperature"].ToString());
			Humidity = float.Parse(row["Humidity"].ToString());
			DateWeather = DateTime.Parse(row["DateWeather"].ToString());
			UserName = row["UserName"].ToString();
		}

		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public float Temperature { get => temperature; set => temperature = value; }
		public float Humidity { get => humidity; set => humidity = value; }
		public DateTime DateWeather { get => dateWeather; set => dateWeather = value; }
		public string UserName { get => userName; set => userName = value; }
	}
}
