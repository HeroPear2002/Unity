using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class WeatherDAO
	{
		private static WeatherDAO instance;

		public static WeatherDAO Instance { get { if (instance == null) instance = new WeatherDAO(); return instance; } set => instance = value; }

		public WeatherDAO() { }

		public List<WeatherDTO> GetList()
		{
			string query = "select * from Weather,Location,[dbo].[User] where idLocation = Location.Id and IdUser = [dbo].[User].Id";
			List<WeatherDTO> lis = new List<WeatherDTO>();
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				WeatherDTO DTO = new WeatherDTO(item);
				lis.Add(DTO);
			}
			return lis;
		}
		public WeatherDTO GetItem(int id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public WeatherDTO GetItem(string name)
		{
			return GetList().Find(x => x.Name == name);
		}
		public bool Insert(int idLocation, float temperature, float humidity, DateTime dateWeather, int idUser)
		{
			string query = "insert Weather(IdLocation, Temperature, Humidity, DateWeather, IdUser) Values( @1 , @2 , @3 , @4 , @5 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idLocation, temperature, humidity, dateWeather, idUser });
			return data > 0;
		}
		public bool Update(int id, int idLocation, float temperature, float humidity)
		{
			string query = "update Weather set IdLocation = @1 , Temperature = @2 , Humidity = @3  where Id = @4 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idLocation, temperature, humidity, id });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "Delete Weather where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
