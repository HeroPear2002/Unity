using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class CustomerDAO
	{
		private static CustomerDAO instance;

		public static CustomerDAO Instance
		{
			get { if (instance == null) instance = new CustomerDAO(); return instance; }
			set => instance = value;
		}
		public CustomerDAO() { }

		public CustomerDTO GetItem(string code)
		{
			return Getlist().Find(x => x.CusCode == code);
		}
		public List<CustomerDTO> Getlist()
		{
			string query = "Select * from Customer";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<CustomerDTO> lsv = new List<CustomerDTO>();
			foreach (DataRow item in data.Rows)
			{
				CustomerDTO DTO = new CustomerDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public CustomerDTO GetItemById(int id)
		{
			string query = "Select * from Customer where Id= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
			foreach (DataRow item in data.Rows)
			{
				CustomerDTO DTO = new CustomerDTO(item);
				return DTO;
			}
			return null;
		}
		public int Insert(string cusCo, string cusna, string addr, string phone, string email, string note, int warnintputpo, int warnfixpo, int warncus)
		{
			string query = "Insert Customer ( CusCode , CusName , Address , Phone , Email , Note , WarnInputPO , WarnPOFix , WarnCus ) values ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { cusCo, cusna, addr, phone, email, note, warnintputpo, warnfixpo, warncus });
			return data;
		}
		public int Update(int id, string cusCo, string cusna, string addr, string phone, string email, string note, int warnintputpo, int warnfixpo, int warncus)
		{
			string query = "Update Customer set CusCode= @1 , CusName = @2 , Address= @3 , Phone= @4 , Email= @5 , Note= @6 , WarnInputPO= @7 , WarnPOFix= @8 , WarnCus= @9 where ID= @10 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { cusCo, cusna, addr, phone, email, note, warnintputpo, warnfixpo, warncus, id });
			return data;
		}
		public int Delete(int id)
		{
			string query = "Delete Customer where Id= @1";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data;
		}
	}
}
