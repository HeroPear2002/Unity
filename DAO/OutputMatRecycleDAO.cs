using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public  class OutputMatRecycleDAO
    {
        private static OutputMatRecycleDAO instance;
        public static OutputMatRecycleDAO Instance
        {
            get { if (instance == null) instance = new OutputMatRecycleDAO(); return instance; }
            set => instance = value;
        }
        public OutputMatRecycleDAO() { }
        public List<OutputMatDTO> Getlist()
        {
            string query = "SELECT OutputMatRecyle.Id,IdReInputCycle,DateReOutput,MatCode,MatName,QuantityReOutput,OutputMatRecyle.IdEm,OutputMatRecyle.Lot,OutputMatRecyle.Note,Reason,LotCycle,QuantityCyclePlan FROM dbo.OutputMatRecyle,dbo.InputMatRecycle,dbo.Material,dbo.InputMat WHERE InputMatRecycle.Id=IdReInputCycle AND InputMat.Id=IdInput AND IdMat=Material.Id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<OutputMatDTO> lsv = new List<OutputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                OutputMatDTO DTO = new OutputMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public OutputMatDTO GetItem(int id)
        {
            string query = "SELECT OutputMatRecyle.Id,IdReInputCycle,DateReOutput,MatCode,MatName,QuantityReOutput,OutputMatRecyle.IdEm,OutputMatRecyle.Lot,OutputMatRecyle.Note,Reason,LotCycle,QuantityCyclePlan FROM dbo.OutputMatRecyle,dbo.InputMatRecycle,dbo.Material,dbo.InputMat WHERE InputMatRecycle.Id=IdReInputCycle AND InputMat.Id=IdInput AND IdMat=Material.Id and OutputMatRecyle.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                OutputMatDTO DTO = new OutputMatDTO(item);
                return DTO;
            }
            return null;
        }
        public OutputMatDTO GetItem(string code)
        {
            string query = "SELECT OutputMatRecyle.Id,IdReInputCycle,DateReOutput,MatCode,MatName,QuantityReOutput,OutputMatRecyle.IdEm,OutputMatRecyle.Lot,OutputMatRecyle.Note,Reason,LotCycle,QuantityCyclePlan FROM dbo.OutputMatRecyle,dbo.InputMatRecycle,dbo.Material,dbo.InputMat WHERE InputMatRecycle.Id=IdReInputCycle AND InputMat.Id=IdInput AND IdMat=Material.Id and MatCode= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { code });
            foreach (DataRow item in data.Rows)
            {
                OutputMatDTO DTO = new OutputMatDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert(long idreinputcycle,DateTime datereoutput,float quantityreoutput, int idem,string lot,string note,string reason,string lotcycle,float quantitycycleplan)
        {
            string query = "INSERT dbo.OutputMatRecyle (     IdReInputCycle,     DateReOutput,     QuantityReOutput,     IdEm,     Lot,     Note,     Reason,     LotCycle,     QuantityCyclePlan ) VALUES  ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idreinputcycle,  datereoutput,  quantityreoutput, idem, lot, note, reason, lotcycle, quantitycycleplan });
            return data;
        }
        public int Update( long id,long idreinputcycle, DateTime datereoutput, float quantityreoutput, int idem, string lot, string note, string reason, string lotcycle, float quantitycycleplan)
        {
            string query = "Update dbo.OutputMatRecyle set     IdReInputCycle= @1 ,     DateReOutput= @2 ,     QuantityReOutput= @3 ,     IdEm= @4 ,     Lot = @5 ,     Note = @6 ,     Reason= @7 ,     LotCycle= @8 ,     QuantityCyclePlan = @9  where Id= @10 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idreinputcycle, datereoutput, quantityreoutput, idem, lot, note, reason, lotcycle, quantitycycleplan,id });
            return data; ;
        }
        public int Delete(int id)
        {
            string query = "Delete dbo.OutputMatRecyle  where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
    }
}
