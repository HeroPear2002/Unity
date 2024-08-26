using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
  public  class TemInforDAO
    {
        private static TemInforDAO instance;

        public static TemInforDAO Instance
        {
            get { if (instance == null) instance = new TemInforDAO(); return instance; }
            set => instance = value;
        }
        public List<TemInforDTO> GetList()
        {
            string query = "SELECT * FROM dbo.TemInfor,dbo.Part,dbo.Machine,dbo.Mold WHERE IdPart=Part.Id AND IdMachine=Machine.Id AND IdMold= Mold.Id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<TemInforDTO> Lsv = new List<TemInforDTO>();
            foreach (DataRow item in data.Rows)
            {
                TemInforDTO DTO = new TemInforDTO(item);
                Lsv.Add(DTO);
            }
            return Lsv;
        }
        public TemInforDTO GetItem(int id)
        {
            string query = "SELECT * FROM dbo.TemInfor,dbo.Part,dbo.Machine,dbo.Mold WHERE IdPart=Part.Id AND IdMachine=Machine.Id AND IdMold= Mold.Id and TemInfor.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id});
            
            foreach (DataRow item in data.Rows)
            {
                TemInforDTO DTO = new TemInforDTO(item);
                return DTO;
            }
            return null;
        }
		public TemInforDTO GetItem(int idPart, int idMachine, int idMold)
		{
			return GetList().Find(x => x.IdPart == idPart && x.IdMachine == idMachine && x.IdMold == idMold);
		}
		public List<TemInforDTO> GetList(int idPart, int idMachine, int idMold)
		{
			return GetList().Where(x => x.IdPart == idPart && x.IdMachine == idMachine && x.IdMold == idMold).ToList();
		}
		public object GetListPart()
		{
			string query = "SELECT DISTINCT(TemInfor.IdPart),PartCode,PartName,MatCode FROM dbo.TemInfor , dbo.Part WHERE IdPart = Part.Id";
			return (object)DataProvider.Instance.ExecuteQuery(query);
		}
		public object GetListMoldByPart(int IdPart)
		{
			string query = "SELECT DISTINCT(TemInfor.IdMold),NumberMold,MoldCode FROM dbo.TemInfor,dbo.Mold WHERE IdMold = Mold.Id AND IdPart = @1 ";
			return (object)DataProvider.Instance.ExecuteQuery(query, new object[] { IdPart });
		}
		public object GetListMachineByPartMold(int IdPart, int IdMold)
		{
			string query = "SELECT DISTINCT(IdMachine),MachineCode FROM dbo.TemInfor,dbo.Mold,dbo.Machine WHERE IdMold = Mold.Id AND IdMachine = Machine.Id AND IdPart = @1 AND IdMold = @2 ";
			return (object)DataProvider.Instance.ExecuteQuery(query, new object[] { IdPart, IdMold});
		}
		public object GetListFactoryCodeByAll(int IdPart, int IdMold, int IdMachine)
		{
			string query = "SELECT DISTINCT(FacCode) FROM dbo.TemInfor,dbo.Mold WHERE IdMold = Mold.Id AND IdPart = @1 AND IdMold = @2 AND IdMachine = @3 ";
			return (object)DataProvider.Instance.ExecuteQuery(query, new object[] { IdPart, IdMold, IdMachine });
		}
		public int Insert(int IdPart,int IdMachine,int IdMold,string Rev,string FacCode,string Standard)
        {
            string query = "INSERT dbo.TemInfor ( IdPart,  IdMachine, IdMold, Rev,CavStyle,  FacCode, Standard, Important ) VALUES ( @1 , @2 , @3 , @4 ,0, @5 , @6 , 0) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdPart, IdMachine, IdMold, Rev, FacCode, Standard });
            return data;
        }
		public int UpdateImport(int IdPart, int Important)
		{
			string query = "Update dbo.TemInfor set  Important= @4 where IdPart= @10 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Important, IdPart });
			return data;
		}
		public int Update(int id, int CavStyle )
        {
            string query = "Update dbo.TemInfor set  CavStyle= @4 where Id= @10 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { CavStyle ,id});
            return data;
        }
		public int Update(int id, int IdPart, int IdMachine, int IdMold, string Rev, string FacCode, string Standard)
		{
			string query = "Update dbo.TemInfor set IdPart= @1 , IdMachine= @2 , IdMold= @3 , Rev= @5 , FacCode= @6 , Standard= @7 where Id= @10 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdPart, IdMachine, IdMold, Rev, FacCode, Standard, id });
			return data;
		}
		public int Delete(int id)
        {
            string query = "Delete TemInfor where Id = @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {id });
            return data;
        }
		public int ImportantMac(int IdPart)
		{
			string query = "select Distinct(Important) from TemInfor where IdPart = @1 ";
			try
			{
				return int.Parse(DataProvider.Instance.ExecuteScalar(query, new object[] { IdPart }).ToString());
			}
			catch
			{
				return 0;
			}
		}
	}
}
