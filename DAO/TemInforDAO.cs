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
        public List<TemInforDTO> Getlist()
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
       public int Insert(int IdPart,int IdMachine,int IdMold,int CavStyle,string Rev,string FacCode,string Standard,int Important,string Note)
        {
            string query = "INSERT dbo.TemInfor (  IdPart,  IdMachine, IdMold, CavStyle, Rev,  FacCode, Standard,  Important,  Note ) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 ) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdPart, IdMachine, IdMold, CavStyle, Rev, FacCode, Standard, Important, Note });
            return data;
        }
        public int Update(int id,int IdPart, int IdMachine, int IdMold, int CavStyle, string Rev, string FacCode, string Standard, int Important, string Note)
        {
            string query = "Update dbo.TemInfor set IdPart= @1 , IdMachine= @2 , IdMold= @3 , CavStyle= @4 , Rev= @5 , FacCode= @6 , Standard= @7 ,Important= @8 , Note= @9 where Id= @10 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdPart, IdMachine, IdMold, CavStyle, Rev, FacCode, Standard, Important, Note ,id});
            return data;
        }
        public int Delete(int id)
        {
            string query = "";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {id });
            return data;
        }
    }
}
