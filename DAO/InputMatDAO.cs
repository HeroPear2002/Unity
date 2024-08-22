using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
  public  class InputMatDAO
    {
        private static InputMatDAO instance;

        public static InputMatDAO Instance
        {
            get { if (instance == null) instance = new InputMatDAO(); return instance; }
            set => instance = value;
        }
        private InputMatDAO() { }
        public List<InputMatDTO> Getlist()
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<InputMatDTO> lsv = new List<InputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public List<InputMatDTO> GetlistMat()
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id and StyleInput= N'new' and StatusInput = 0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<InputMatDTO> lsv = new List<InputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public List<InputMatDTO> GetlistMatByCode(string matcode)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id and StyleInput= N'new' and StatusInput = 0  and MatCode= @1 ORDER BY DateInput ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { matcode});
            List<InputMatDTO> lsv = new List<InputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<InputMatDTO> GetlistMatByCodeByStyle(string matcode,string style)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id and StyleInput= @1  and StatusInput = 0  and MatCode= @2 ORDER BY DateInput ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { style,matcode });
            List<InputMatDTO> lsv = new List<InputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }


        public InputMatDTO GetItemMatByCodeByStyle(string matcode, string style)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id and StyleInput= @1  and StatusInput = 0  and MatCode= @2 ORDER BY DateInput ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { style, matcode });
            List<InputMatDTO> lsv = new List<InputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                return DTO;
            }
            return null;
        }
        public List<InputMatDTO> GetlistMatAllByCode(string matcode)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id  and StatusInput = 0  and MatCode= @1 ORDER BY DateInput ASC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { matcode });
            List<InputMatDTO> lsv = new List<InputMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public InputMatDTO GetItem(int id)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id and InputMat.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                return DTO;
            }
            return null;
        }

        public InputMatDTO GetitemMat( int idWH)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id and StyleInput= N'new' and StatusInput = 0 and IdWH= @1  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idWH});
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                return DTO;
            }
            return null;
        }
        public InputMatDTO GetitemAllMat(int idWH)
        {
            string query = "SELECT InputMat.Id,IdMat,MatCode,MatName,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput,StyleInput,IdEm,Lot,Rohs,InputMat.Note,Name " +
                "FROM dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdMat=Material.Id AND IdWH=WarehouseMat.Id  and StatusInput = 0 and IdWH= @1  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idWH });
            foreach (DataRow item in data.Rows)
            {
                InputMatDTO DTO = new InputMatDTO(item);
                return DTO;
            }
            return null;
        }



        public int Insert(int idmat, DateTime dateinput, float quantityinput, float quantityInventory, int idwh, int statusinput, string styleinput,int idem,string lot,string rohs,string note)
        {
            string query = "INSERT dbo.InputMat (IdMat,DateInput,QuantityInput,QuantityInventory,IdWH,StatusInput, StyleInput,IdEm,Lot, Rohs,Note) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idmat,dateinput,quantityinput,quantityInventory,idwh,statusinput,styleinput,idem,lot, rohs,note});
            return data;
        }
        public int Update(long id, int idmat, DateTime dateinput, float quantityinput, int idwh, int statusinput, string styleinput, int idem, string lot, string rohs, string note,float quantityInventory)
        {
            string query = "Update  dbo.InputMat set IdMat= @1 , DateInput = @2 , QuantityInput = @3 , IdWH = @4 , StatusInput = @5 , StyleInput = @6 , IdEm = @7 , Lot = @8 , Rohs = @9 , Note = @10 , QuantityInventory = @11  where Id = @12 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idmat,dateinput,quantityinput,idwh,statusinput,styleinput,idem,lot,rohs,note,quantityInventory, id });
            return data;
        }

        public int UpdateStatus(long id, int statusinput, float quantityInventory)
        {
            string query = "Update  dbo.InputMat set StatusInput = @5 , QuantityInventory = @11  where Id = @12 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {  statusinput,  quantityInventory, id });
            return data;
        }
        public int Delete(long id)
        {
            string query = "Delete dbo.InputMat where Id= @1";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
    }
}
