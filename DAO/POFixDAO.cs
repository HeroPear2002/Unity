using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class POFixDAO
	{
		private static POFixDAO instance;

		public static POFixDAO Instance
		{
			get { if (instance == null) instance = new POFixDAO(); return instance; }
			set => instance = value;
		}
		public POFixDAO() { }
		public List<POFixDTO> GetList()
		{
			string query = "select * from POFix,POInput,Part,Factory where IdPOInput = POInput.Id and IdPart = Part.Id and IdFactory = Factory.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<POFixDTO> lsv = new List<POFixDTO>();
			foreach (DataRow item in data.Rows)
			{
				POFixDTO DTO = new POFixDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<POFixDTO> GetList(string factoryCustomer, string facCode, int carNumber, DateTime dateOut)
		{
			string query = "select * from POFix,POInput,Part,Factory where IdPOInput = POInput.Id and IdPart = Part.Id and IdFactory = Factory.Id and FactoryCustomer = @1 and FacCode = @2 and CarNumber = @3 and POFix.DateOut = @4 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { factoryCustomer, facCode, carNumber, dateOut });
			List<POFixDTO> lsv = new List<POFixDTO>();
			foreach (DataRow item in data.Rows)
			{
				POFixDTO DTO = new POFixDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public int GetQuantity(long idPOInput)
		{
			string query = "select Sum(Quantity) as Quantity from POFix where IdPOInput = @1 ";
			object data = DataProvider.Instance.ExecuteScalar(query, new object[] { idPOInput });
			if(data.ToString() == "") return 0;
			else return int.Parse(data.ToString());
		}
		public POFixDTO GetItem(long Id)
		{
			return GetList().Find(x => x.Id == Id);
		}
		public POFixDTO GetItemDe(long id)
		{
			return GetList().Find(x => x.IdDe == id.ToString());
		}
		public bool Insert(long idPOInput, int quantity, DateTime dateOut, string factoryCustomer, int carNumber)
		{
			DateTime now = DateTime.Now;
			string query;
			int data;
			if (carNumber == 0)
			{
				query = "insert POFix(IdPOInput, IdDe, Quantity, DateOut, Note, [Status], DateInput, FactoryCustomer, CarNumber) Values( @1 , NULL , @3 , @4 , NULL , 0 , @7 , @8 , NULL )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idPOInput, quantity, dateOut, now, factoryCustomer });
			}
			else
			{
				query = "insert POFix(IdPOInput, IdDe, Quantity, DateOut, Note, [Status], DateInput, FactoryCustomer, CarNumber) Values( @1 , NULL , @3 , @4 , NULL , 0 , @7 , @8 , @9 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idPOInput, quantity, dateOut, now, factoryCustomer, carNumber });
			}
			return data > 0;
		}
		public bool Update(long id, long idPOInput, int quantity, DateTime dateOut, string factoryCustomer, int carNumber)
		{
			string query = "update POFix set IdPOInput = @1 , Quantity = @2 , DateOut = @3 , FactoryCustomer = @4 , CarNumber = @5 where Id = @6 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idPOInput, quantity, dateOut, factoryCustomer, carNumber, id });
			return data > 0;
		}
		public bool Update(long id, int status, string Note, long IdDe)
		{
			string query;
			int data;
			if (IdDe == -1)
			{
				query = "update POFix set Status = @1 , Note = @2 , IdDe = NULL where Id = @6 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, Note, id });
			}
			else
			{
				query= "update POFix set Status = @1 , Note = @2 , IdDe = @3 where Id = @6 ";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, Note, IdDe, id });
			}
			 
			return data > 0;
		}
		public bool Update(long id, int status, string Note)
		{
			string query = "update POFix set Status = @1 , Note = @2 where Id = @6 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, Note, id });
			return data > 0;
		}
		public bool Update(long id, int status, int quantityOut)
		{
			string query = "update POFix set Status = @1 , QuantityOut = @2 where Id = @6 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, quantityOut, id });
			return data > 0;
		}
		public bool Update(long IdDe)
		{
			string query = "update POFix set Status = 0 , Note = NULL where IdDe = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdDe });
			return data > 0;
		}
		public bool Delete(long id)
		{
			string query = "delete POFix where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
		public bool DeleteWherePOInput(long id)
		{
			string query = "delete POFix where IdPOInput = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
