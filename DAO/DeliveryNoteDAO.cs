using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class DeliveryNoteDAO
	{
		private static DeliveryNoteDAO instance;

		public static DeliveryNoteDAO Instance { get { if (instance == null) instance = new DeliveryNoteDAO(); return instance; } set => instance = value; }

		public DeliveryNoteDAO() { }

		public List<DeliveryNoteDTO> GetList()
		{
			string query = "select * from DeliveryNote";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<DeliveryNoteDTO> lsv = new List<DeliveryNoteDTO>();
			foreach (DataRow item in data.Rows)
			{
				DeliveryNoteDTO DTO = new DeliveryNoteDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public DeliveryNoteDTO GetItem(long id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public DeliveryNoteDTO GetItem(string code)
		{
			return GetList().Find(x => x.DeCode == code);
		}
		public bool Insert(string DeCode, DateTime DateInput, string EmployessCreate, string EmployessChange, int StatusDe, string Note, DateTime DateDelivery)
		{
			string query = "INSERT INTO [dbo].[DeliveryNote] ([DeCode],[DateInput],[EmCreate],[EmChange],[StatusDe],[Note],[DateDelivery])VALUES( @1 , @2 , @3 , @4 , @5 , @6 , @7 )";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DeCode, DateInput, EmployessCreate, EmployessChange, StatusDe, Note, DateDelivery });
			return result > 0;
		}
		public long MaxIdDelivery()
		{
			return long.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM DeliveryNote").ToString());
		}
		public bool Update(long Id, DateTime DateChange, string EmployessChange)
		{
			string query = "UPDATE [dbo].[DeliveryNote] SET [DateChange] = @1 , [EmChange] = @2 WHERE Id = @3 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DateChange, EmployessChange, Id });
			return result > 0;
		}
		public bool Update(long Id, int StatusDe, string Note)
		{
			string query = "UPDATE [dbo].[DeliveryNote] SET [StatusDe] = @1 , [Note] = @2 WHERE Id = @3 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { StatusDe, Note, Id });
			return result > 0;
		}
		public bool UpdateOut(long Id, int StatusDe, string Note, DateTime DateOutput, string EmOut)
		{
			string query = "UPDATE [dbo].[DeliveryNote] SET [StatusDe] = @1 , [Note] = @2 , [DateOutput] = @3 , [EmOut] = @4 WHERE Id = @5 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { StatusDe, Note, DateOutput, EmOut, Id });
			return result > 0;
		}
		public bool Delete(long id)
		{
			string query = "delete DeliveryNote where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
