using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class CateTestMachineDAO
	{
		private static CateTestMachineDAO instance;

		public static CateTestMachineDAO Instance
		{
			get { if (instance == null) instance = new CateTestMachineDAO(); return instance; }
			set => instance = value;
		}
		public CateTestMachineDAO() { }
		public List<CateTestMachineDTO> GetList()
		{
			string query = "select ctm.Id, NameCategory, Detail, timer, Method, StatusCate, Name, Limit, NoteCate, ctm.IdDevice  from CateTestMachine ctm join Device d on ctm.IdDevice = d.Id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<CateTestMachineDTO> lsv = new List<CateTestMachineDTO>();
			foreach (DataRow item in data.Rows)
			{
				CateTestMachineDTO DTO = new CateTestMachineDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<CateTestMachineDTO> GetList(int idDevice)
		{
			string query = "select ctm.Id, NameCategory, Detail, timer, Method, StatusCate, Name, Limit, NoteCate, ctm.IdDevice  from CateTestMachine ctm join Device d on ctm.IdDevice = d.Id where IdDevice = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idDevice });
			List<CateTestMachineDTO> lsv = new List<CateTestMachineDTO>();
			foreach (DataRow item in data.Rows)
			{
				CateTestMachineDTO DTO = new CateTestMachineDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public CateTestMachineDTO GetItem(int Id)
		{
			return GetList().Find(x => x.Id == Id);
		}
		public List<CateTestMachineDTO> GetListItem(string code)
		{
			return GetList().Where(x => x.NameCategory == code).ToList();
		}
		public bool Insert(string nameCategory, string detail, int timer, string method, int statusCate, int idDevice, string limit)
		{
			string query;
			if (idDevice == 0) query = "INSERT CateTestMachine(NameCategory,Detail,Timer,Method,StatusCate,IdDevice,Limit,NoteCate) VALUES( @1 , @2 , @3 , @4 , @5 , @6 , NULL , NULL )";
			else query = "INSERT CateTestMachine(NameCategory,Detail,Timer,Method,StatusCate,IdDevice,Limit,NoteCate) VALUES( @1 , @2 , @3 , @4 , @5 , @6 , @7 , NULL )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { nameCategory, detail, timer, method, statusCate, idDevice, limit });
			return data > 0;
		}
		public bool Insert(string nameCategory, string detail,int timer,string method,int statusCate,int idDevice)
		{
			string query = "INSERT CateTestMachine(NameCategory,Detail,Timer,Method,StatusCate,IdDevice,Limit,NoteCate) VALUES( @1 , @2 , @3 , @4 , @5 , @6 , NULL , NULL )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { nameCategory, detail, timer, method,statusCate, idDevice });
			return data > 0;
		}
		public bool Update(int id, string nameCategory, string detail, int timer, string method, int statusCate, int idDevice)
		{
			string query = "update CateTestMachine set NameCategory = @1 ,Detail = @2 ,Timer = @3 ,Method = @4 , StatusCate = @5 ,IdDevice = @6 where Id = @9 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { nameCategory, detail, timer, method, statusCate, idDevice, id });
			return data > 0;
		}
		public bool Update(string nameCategory, string detail, int timer, string method, int statusCate, int idDevice, string limit)
		{
			string query = "update CateTestMachine set Detail = @2 ,Timer = @3 ,Method = @4 , StatusCate = @5 ,IdDevice = @6 , Limit = @7 where NameCategory = @9 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { detail, timer, method, statusCate, idDevice, limit , nameCategory });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "delete CateTestMachine where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
