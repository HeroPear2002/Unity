using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class POInputDAO
	{
		private static POInputDAO instance;

		public static POInputDAO Instance
		{
			get { if (instance == null) instance = new POInputDAO(); return instance; }
			set => instance = value;
		}
		public POInputDAO() { }

		public List<POInputDTO> GetList()
		{
			string query = "select * from POInput,Part,Factory,Customer where IdPart = Part.Id and IdFactory = Factory.Id and POInput.IdCustomer = Customer.Id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<POInputDTO> lsv = new List<POInputDTO>();
			foreach (DataRow item in data.Rows)
			{
				POInputDTO DTO = new POInputDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public POInputDTO GetItem(long id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public POInputDTO GetItem(string code)
		{
			return GetList().Find(x => x.POCode == code);
		}
		public POInputDTO GetItem(string code, string partCode, float price)
		{
			return GetList().Find(x => x.POCode == code && x.PartCode == partCode && x.Price == price);
		}
		public bool Insert(string pOCode, int idPart, int quantityIn, DateTime dateInput, int statusPO, int idFactory, float price, DateTime dateOutput, int idCustomer, int quantityOut)
		{
			string query = "insert POInput(POCode, IdPart, QuantityIn,DateInput,StatusPO,IdFactory,Price,DateOut,IdCustomer, QuantityOut,  Note) Values ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , NULL )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { pOCode, idPart, quantityIn, dateInput, statusPO, idFactory, price, dateOutput, idCustomer, quantityOut });
			return data > 0;
		}
		public bool Update(long id, string pOCode, int idPart, int quantityIn, DateTime dateInput, int statusPO, int idFactory, float price, DateTime dateOutput, int idCustomer, int quantityOut)
		{
			string query = "update POInput set POCode = @1 , IdPart = @2 , QuantityIn = @3 ,DateInput = @4 ,StatusPO = @5 ,IdFactory = @6 ,Price = @7 ,DateOut = @8 ,IdCustomer = @9 , QuantityOut = @10 where Id = @11 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { pOCode, idPart, quantityIn, dateInput, statusPO, idFactory, price, dateOutput, idCustomer, quantityOut, id });
			return data > 0;
		}
		public bool Update(long Id, int QuantityOut)
		{
			string query = "UPDATE POInput SET QuantityOut = @1 WHERE Id = @2 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { QuantityOut, Id });
			return result > 0;
		}
		public bool UpdateStatusPO(long Id, int status)
		{
			string query = "UPDATE POInput SET StatusPO = @1 WHERE Id = @2 ";
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, Id });
			return result > 0;
		}
		public bool Delete(long id)
		{
			string query = "delete POInput where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
		
	}
}
