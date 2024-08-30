using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class FactoryDAO
	{
		private static FactoryDAO instance;

		public static FactoryDAO Instance
		{
			get { if (instance == null) instance = new FactoryDAO(); return instance; }
			set => instance = value;
		}
		public FactoryDAO() { }
		public FactoryDTO GetItemFac(string code)
		{
			return GetList().Find(x => x.FacCode == code);
		}
		public FactoryDTO GetItem(string code)
		{
			return GetList().Find(x => x.CodeCus == code);
		}
		public FactoryDTO GetItem(string code, string cusCode)
		{
			return GetList().Find(x => x.FacCode == code && x.CusCode == cusCode);
		}
		public List<FactoryDTO> GetList()
		{
			string query = "SELECT * FROM dbo.Factory,dbo.Customer WHERE IdCus=Customer.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<FactoryDTO> Lsv = new List<FactoryDTO>();
			foreach (DataRow item in data.Rows)
			{
				FactoryDTO DTO = new FactoryDTO(item);
				Lsv.Add(DTO);
			}
			return Lsv;
		}
		public object GetListFac()
		{
			string query = "SELECT FacCode, MIN(Id) as Id FROM dbo.Factory GROUP BY FacCode";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			return (object)data;
		}
		public FactoryDTO GetItem(int id)
		{
			string query = "SELECT * FROM dbo.Factory,dbo.Customer WHERE IdCus=Customer.Id and Id= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
			foreach (DataRow item in data.Rows)
			{
				FactoryDTO DTO = new FactoryDTO(item);
				return DTO;
			}
			return null;
		}

		public int Insert(string FacCode, string FacName, string CodeCus, int IdCus, string NameBillVN, string NameBillEN, string Address, string Phone, string Fax, string TaxCode)
		{
			string query = "INSERT dbo.Factory (FacCode,     FacName,     CodeCus,     IdCus,     NameBillVN,     NameBillEN,     Address,     Phone,     Fax,     TaxCode ) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { FacCode, FacName, CodeCus, IdCus, NameBillVN, NameBillEN, Address, Phone, Fax, TaxCode });
			return data;
		}
		public int Update(int id, string FacCode, string FacName, string CodeCus, int IdCus, string NameBillVN, string NameBillEN, string Address, string Phone, string Fax, string TaxCode)
		{
			string query = "Update dbo.Factory  set FacCode= @1  , FacName= @2  , CodeCus= @3  , IdCus= @4  , NameBillVN= @5  , NameBillEN= @6  , Address= @7  ,Phone= @8  , Fax= @9  , TaxCod= @10 where Id= @11 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, FacCode, FacName, CodeCus, IdCus, NameBillVN, NameBillEN, Address, Phone, Fax, TaxCode });
			return data;
		}
		public int Delete(int id)
		{
			string query = "Delete dbo.Factory   where Id= @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data;
		}
	}
}
