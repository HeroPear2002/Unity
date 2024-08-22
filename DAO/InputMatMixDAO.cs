using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class InputMatMixDAO
    {
        private static InputMatMixDAO instance;

        public static InputMatMixDAO Instance
        {
            get { if (instance == null) instance = new InputMatMixDAO();return instance; }
            set => instance = value;
        }
        public InputMatMixDAO() { }
        public List<InputMatMixDTO> GetList()
        {
            string query = " SELECT * FROM dbo.InputMatMix,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<InputMatMixDTO> lsv = new List<InputMatMixDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatMixDTO DTO = new InputMatMixDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<InputMatMixDTO> GetListLive()
        {
            string query = " SELECT * FROM dbo.InputMatMix,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and statusMix= 0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<InputMatMixDTO> lsv = new List<InputMatMixDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatMixDTO DTO = new InputMatMixDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<InputMatMixDTO> GetListLive(long idinput)
        {
            string query = " SELECT * FROM dbo.InputMatMix,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and statusMix= 0 and IdInput= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { idinput});
            List<InputMatMixDTO> lsv = new List<InputMatMixDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatMixDTO DTO = new InputMatMixDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public InputMatMixDTO GetItem(long id)
        {
            string query = "SELECT * FROM dbo.InputMatMix,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and InputMatMix.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id});
            foreach (DataRow item in data.Rows)
            {
                InputMatMixDTO DTO = new InputMatMixDTO(item);
                return DTO;
            }
            return null;
        }

        public InputMatMixDTO GetItemLive(long id)
        {
            string query = " SELECT * FROM dbo.InputMatMix,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and statusMix= 0 and InputMatMix.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            foreach (DataRow item in data.Rows)
            {
                InputMatMixDTO DTO = new InputMatMixDTO(item);
                return DTO;
            }
            return null;
        }


        public int Insert(long idinput, float quantity, int status, DateTime date, int idem, string note, float inventory,string name)
        {
            string query = "INSERT dbo.InputMatMix ( IdInput,QuantityMix,StatusMix, DateMix, IdEm, Note, QuantityInventory, Name) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {idinput,quantity,status,date,idem,note,inventory,name });
            return data;
        }
        public int Update(long id,  int status,  float inventory)
        {
            string query = "Update dbo.InputMatMix set  StatusMix = @1 , QuantityInventory = @2 where Id = @3 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status,inventory,id });
            return data;
        }
    }
}
