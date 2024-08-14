using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class SetupDefaultDAO
	{
		private static SetupDefaultDAO instance;

		public static SetupDefaultDAO Instance { get { if (instance == null) instance = new SetupDefaultDAO(); return instance; } set => instance = value; }

		public SetupDefaultDAO() { }

		public List<SetupDefaultDTO> GetList()
		{
			string query = "select * from SetupDefault,CateDataDefault,Machine,Mold where IdCate = CateDataDefault.Id and IdMachine = Machine.Id and IdMold = Mold.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<SetupDefaultDTO> lsv = new List<SetupDefaultDTO>();
			foreach (DataRow item in data.Rows)
			{
				SetupDefaultDTO DTO = new SetupDefaultDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}

		public SetupDefaultDTO GetItem(long Id)
		{
			return GetList().Find(x => x.Id == Id);
		}
		public List<SetupDefaultDTO> GetItem(string moldCode)
		{
			return GetList().Where(x => x.MoldCode == moldCode).ToList();
		}
		public List<SetupDefaultDTO> GetItem(string moldCode, string machineCode)
		{
			return GetList().Where(x => x.MoldCode == moldCode && x.MachineCode == machineCode).ToList();
		}
		public bool GetItem(int idCate, int idMold, int idMachine)
		{
			string query = "select * from SetupDefault where IdCate = @1 and IdMachine = @2 and IdMold = @3 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idCate, idMachine, idMold });
			return data.Rows.Count != 0;
		}
		public bool Insert(int idCate, int idMold, int idMachine, float valueDefault)
		{
			string query = "INSERT SetupDefault (IdCate ,IdMold, IdMachine, ValueDefault) VALUES ( @1 , @2 , @3 , @4 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idCate, idMold, idMachine, valueDefault });
			return data > 0;
		}
		public bool Update(long id, int idCate, int idMold, int idMachine, float valueDefault)
		{
			string query = "update SetupDefault set IdCate = @1 ,IdMold = @2 , IdMachine = @3 , ValueDefault = @4 where Id = @5 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idCate, idMold, idMachine, valueDefault, id });
			return data > 0;
		}

		public bool Delete(long Id)
		{
			string query = "delete SetupDefault where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Id });
			return data > 0;
		}
	}
}
