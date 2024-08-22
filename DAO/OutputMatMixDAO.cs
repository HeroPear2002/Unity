using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public  class OutputMatMixDAO
    {

        private static OutputMatMixDAO instance;

        public static OutputMatMixDAO Instance
        {
            get { if (instance == null) instance = new OutputMatMixDAO(); return instance; }
            set => instance = value;
        }
        public OutputMatMixDAO() { }


        public List<OutputMatMixDTO> Getlist()
        {
            string query = "SELECT * FROM dbo.OutputMatMix,dbo.InputMatMix,dbo.Material,dbo.InputMat,dbo.WarehouseMat WHERE IdReInputMix=InputMatMix.Id AND IdInput=InputMat.Id AND IdWH=WarehouseMat.Id AND IdMat=Material.Id ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<OutputMatMixDTO> lsv = new List<OutputMatMixDTO>();
            foreach (DataRow item in data.Rows)
            {
                OutputMatMixDTO DTO = new OutputMatMixDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public OutputMatMixDTO GetItem( long id)
        {
            string query = "SELECT * FROM dbo.OutputMatMix,dbo.InputMatMix,dbo.Material,dbo.InputMat,dbo.WarehouseMat WHERE IdReInputMix=InputMatMix.Id AND IdInput=InputMat.Id AND IdWH=WarehouseMat.Id AND IdMat=Material.Id and OutputMatMix.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { id});
            foreach (DataRow item in data.Rows)
            {
                OutputMatMixDTO DTO = new OutputMatMixDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert(long IdReInputMix,DateTime DateOutputMix,float QuantityOutputMix,int IdEm,string Note,string Reason,string LotMix,float QuantityMixPlan)
        {
            string query = "INSERT dbo.OutputMatMix ( IdReInputMix, DateOutputMix, QuantityOutputMix, IdEm, Note, Reason, LotMix, QuantityMixPlan ) VALUES( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8  ) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {IdReInputMix,DateOutputMix,QuantityOutputMix,IdEm,Note,Reason,LotMix,QuantityOutputMix });
            return data;
        }

    }
}
