using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
  public  class InputMatRecycleDAO
    {
        private static InputMatRecycleDAO instance;

        public static InputMatRecycleDAO Instance
        {
            get { if (instance == null) instance = new InputMatRecycleDAO(); return instance; }
            set => instance = value;
        }
        public InputMatRecycleDAO() { }


        public List<InputMatRecycleDTO> Getlist()
        {
            string query = "SELECT InputMatRecycle.Id,IdInput,MatCode,MatName,Name,Quantity,InputMatRecycle.QuantityInventory,StatusRecycle,DateRecycle,InputMatRecycle.IdEm,InputMatRecycle.Note FROM dbo.InputMat,dbo.InputMatRecycle,dbo.Material,dbo.WarehouseMat WHERE InputMat.Id=IdInput AND IdMat=Material.Id AND IdWH=WarehouseMat.Id ORDER BY DateRecycle ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<InputMatRecycleDTO> lsv = new List<InputMatRecycleDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatRecycleDTO DTO = new InputMatRecycleDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public InputMatRecycleDTO GetItem(long id)
        {
            string query = "SELECT InputMatRecycle.Id,IdInput,MatCode,MatName,Name,Quantity,InputMatRecycle.QuantityInventory,StatusRecycle,DateRecycle,InputMatRecycle.IdEm,InputMatRecycle.Note FROM dbo.InputMat,dbo.InputMatRecycle,dbo.Material,dbo.WarehouseMat WHERE InputMat.Id=IdInput AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and InputMatRecycle.Id = @1  ORDER BY DateRecycle ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {id });
            List<InputMatRecycleDTO> lsv = new List<InputMatRecycleDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatRecycleDTO DTO = new InputMatRecycleDTO(item);
                return DTO;
            }
            return null;
        }
        public List< InputMatRecycleDTO> GetListByIdInput(long idinput)
        {
            string query = "SELECT InputMatRecycle.Id,IdInput,MatCode,MatName,Name,Quantity,InputMatRecycle.QuantityInventory,StatusRecycle,DateRecycle,InputMatRecycle.IdEm,InputMatRecycle.Note FROM dbo.InputMat,dbo.InputMatRecycle,dbo.Material,dbo.WarehouseMat WHERE InputMat.Id=IdInput AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and InputMatRecycle.IdInput = @1  ORDER BY DateRecycle ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idinput });
            List<InputMatRecycleDTO> lsv = new List<InputMatRecycleDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatRecycleDTO DTO = new InputMatRecycleDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public List<InputMatRecycleDTO> GetlistByCode(string matcode)
        {
            string query = "SELECT InputMatRecycle.Id,IdInput,MatCode,MatName,Name,Quantity,InputMatRecycle.QuantityInventory,StatusRecycle,DateRecycle,InputMatRecycle.IdEm,InputMatRecycle.Note FROM dbo.InputMat,dbo.InputMatRecycle,dbo.Material,dbo.WarehouseMat WHERE InputMat.Id=IdInput AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and MatCode= @1 ORDER BY DateRecycle ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { matcode});
            List<InputMatRecycleDTO> lsv = new List<InputMatRecycleDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatRecycleDTO DTO = new InputMatRecycleDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public List<InputMatRecycleDTO> GetlistNonNewByIdInput(long id)
        {
            string query = "SELECT InputMatRecycle.Id,IdInput,MatCode,MatName,Name,Quantity,InputMatRecycle.QuantityInventory,StatusRecycle,DateRecycle,InputMatRecycle.IdEm,InputMatRecycle.Note FROM dbo.InputMat,dbo.InputMatRecycle,dbo.Material,dbo.WarehouseMat WHERE InputMat.Id=IdInput AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and IdInput= @1 and StatusRecycle= 0 ORDER BY DateRecycle ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { id});
            List<InputMatRecycleDTO> lsv = new List<InputMatRecycleDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatRecycleDTO DTO = new InputMatRecycleDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        
       
        public int Insert( long  idinput,float quantity, float quantityinventory, int statusrecycle,DateTime daterecycle,int idem,string note)
        {
            string query = "INSERT dbo.InputMatRecycle ( IdInput,Quantity,QuantityInventory,StatusRecycle, DateRecycle, IdEm, Note) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7  )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idinput,quantity, quantityinventory, statusrecycle,daterecycle,idem,note});
            return data;
        }
        public int Update(long id, float quantityinventory, int statusrecycle)
        {
            string query = "Update dbo.InputMatRecycle set QuantityInventory = @1  ,StatusRecycle = @2 where Id= @3 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { quantityinventory, statusrecycle ,id});
            return data;
        }
    }
}
