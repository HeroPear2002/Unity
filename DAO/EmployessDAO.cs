using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
	public class EmployessDAO
	{
		private static EmployessDAO instance;

		public static EmployessDAO Instance
		{
			get { if (instance == null) instance = new EmployessDAO(); return instance; }
			set => instance = value;
		}
		public EmployessDAO() { }
		public List<EmployessDTO> Getlist()
		{
			string query = "select * from Employess ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<EmployessDTO> Lsv = new List<EmployessDTO>();
			foreach (DataRow item in data.Rows)
			{
				EmployessDTO DTO = new EmployessDTO(item);
				Lsv.Add(DTO);
			}
			return Lsv;
		}
		public EmployessDTO GetItem(int id)
		{
			string query = "select * from Employess where Id= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
			foreach (DataRow item in data.Rows)
			{
				EmployessDTO DTO = new EmployessDTO(item);
				return DTO;
			}
			return null;
		}
		public EmployessDTO GetItem(string emcode)
		{
			string query = "select * from Employess where EmCode= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { emcode });
			foreach (DataRow item in data.Rows)
			{
				EmployessDTO DTO = new EmployessDTO(item);
				return DTO;
			}
			return null;
		}
		public int Insert(string emcode, string emname, string roomcode, DateTime date, string note)
		{
			string query = "INSERT dbo.Employess ( EmCode, EmName, RoomCode, DateInput,Note ) VALUES ( @1 , @2 , @3 , @4 , @5 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { emcode, emname, roomcode, date, note });
			return data;
		}
		public int Update(int id, string emcode, string emname, string roomcode, DateTime date, string note)
		{
			string query = "Update dbo.Employess set EmCode = @1 , EmName = @2 , RoomCode = @3 , DateInput = @4 , Note = @5 where Id = @6";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { emcode, emname, roomcode, date, note, id });
			return data;
		}
		public int Delete(int id)
		{
			string query = "Delete dbo.Employess where Id= @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data;
		}
	}
}