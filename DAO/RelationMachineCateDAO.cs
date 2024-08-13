using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class RelationMachineCateDAO
	{
		private static RelationMachineCateDAO instance;

		public static RelationMachineCateDAO Instance
		{
			get { if (instance == null) instance = new RelationMachineCateDAO(); return instance; }
			set => instance = value;
		}
		public RelationMachineCateDAO() { }
		
		public List<RelationMachineCateDTO> GetList(int idDevice)
		{
			string query = "select * from RelationMachineCate,Machine,CateTestMachine where IdMachine = Machine.Id and IdCategory = CateTestMachine.Id and Machine.IdDevice = @1 and StatusRe = 1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idDevice });
			List<RelationMachineCateDTO> lsv = new List<RelationMachineCateDTO>();
			foreach (DataRow item in data.Rows)
			{
				RelationMachineCateDTO DTO = new RelationMachineCateDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<RelationMachineCateDTO> GetList()
		{
			string query = "select * from RelationMachineCate,Machine,CateTestMachine where IdMachine = Machine.Id and IdCategory = CateTestMachine.Id and StatusRe = 1";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<RelationMachineCateDTO> lsv = new List<RelationMachineCateDTO>();
			foreach (DataRow item in data.Rows)
			{
				RelationMachineCateDTO DTO = new RelationMachineCateDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<RelationMachineCateDTO> GetListMachine(int idMachine)
		{
			string query = "select * from RelationMachineCate,Machine,CateTestMachine where IdMachine = Machine.Id and IdCategory = CateTestMachine.Id and IdMachine = @1 and StatusRe = 1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idMachine });
			List<RelationMachineCateDTO> lsv = new List<RelationMachineCateDTO>();
			foreach (DataRow item in data.Rows)
			{
				RelationMachineCateDTO DTO = new RelationMachineCateDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public RelationMachineCateDTO GetItem(long id)
		{
			return GetList().Find(x => x.Id == id);
		}
		public RelationMachineCateDTO GetItem(string machineCode, string nameCategory)
		{
			return GetList().Find(x => x.MachineCode == machineCode && x.NameCategory == nameCategory);
		}
		public bool Insert(int idMachine, int idCategory)
		{
			string query = "insert RelationMachineCate(IdMachine, IdCategory, TimeReality, StatusRe, Note) values( @1 , @2 ,NULL, 1 ,NULL)";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idMachine, idCategory });
			return data > 0;
		}
		public bool Update(long id, int timeReality, int statusRe)
		{
			string query = "update RelationMachineCate set TimeReality= @1 , StatusRe = @2 where Id = @3 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { timeReality, statusRe, id });
			return data > 0;
		}
		public bool Update(long id)
		{
			string query = "update RelationMachineCate set StatusRe = 1 where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
		public bool Delete(long id)
		{
			string query = "Update RelationMachineCate set StatusRe = 0 where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
		public bool UpdateTimeReality(long id, int timeReality)
		{
			string query = "update RelationMachineCate set TimeReality = @1 where Id = @2 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { timeReality ,id });
			return data > 0;
		}
	}
}
