using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OutputMatDAO
    {
        private static OutputMatDAO instance;

        public static OutputMatDAO Instance
        {
            get { if (instance == null) instance = new OutputMatDAO(); return instance; }
            set => instance = value;
        }
        public OutputMatDAO() { }
        public List<OutputMatDTO> Getlist()
        {
            string query = "SELECT OutputMat.Id, IdInput,MatCode,MatName,Name,DateOutput,QuatityOutput,StyleOutput,InputMat.IdEm,IdPart,IdMachine,OutputMat.Lot,OutputMat.Note FROM dbo.OutputMat,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id";
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
            string query = "SELECT OutputMat.Id, IdInput,MatCode,MatName,Name,DateOutput,QuatityOutput,StyleOutput,InputMat.IdEm,IdPart,IdMachine,OutputMat.Lot,OutputMat.Note FROM dbo.OutputMat,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and SELECT OutputMat.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id});
            foreach (DataRow item in data.Rows)
            {
                OutputMatDTO DTO = new OutputMatDTO(item);
                return DTO;
            }
            return null;
        }
        public OutputMatDTO GetItem(string code)
        {
            string query = "SELECT OutputMat.Id, IdInput,MatCode,MatName,Name,DateOutput,QuatityOutput,StyleOutput,InputMat.IdEm,IdPart,IdMachine,OutputMat.Lot,OutputMat.Note FROM dbo.OutputMat,dbo.InputMat,dbo.Material,dbo.WarehouseMat WHERE IdInput=InputMat.Id AND IdMat=Material.Id AND IdWH=WarehouseMat.Id and SELECT MatCode = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { code });
            foreach (DataRow item in data.Rows)
            {
                OutputMatDTO DTO = new OutputMatDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert (long idinput, DateTime date,float quantity, string style, int idem,int idpart, int idmachine, string lot, string note)
        {
            string query = "INSERT dbo.OutputMat ( IdInput,DateOutput, QuatityOutput, StyleOutput, IdEm, IdPart, IdMachine,Lot, Note ) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idinput,  date,  quantity,  style, idem, idpart,idmachine, lot, note });
            return data;
        }
        public int Update(long id,long idinput, DateTime date, float quantity, string style, int idem, int idpart, int idmachine, string lot, string note)
        {
            string query = "Update dbo.OutputMat set IdInput = @1 ,DateOutput= @2 , QuatityOutput = @3 , StyleOutput= @4 , IdEm = @5, IdPart = @6 , IdMachine = @7 ,Lot = @8 , Note = @9 where Id= @10 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idinput, date, quantity, style, idem, idpart, idmachine, lot, note , id});
            return data;
        }
        public int Delete(int id)
        {
            string query = "Delete dbo.OutputMat  where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {  id });
            return data;
        }
    }
}
