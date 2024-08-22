using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class RatioMaterialDAO
    {
        private static RatioMaterialDAO instance;

        public static RatioMaterialDAO Instance
        {
            get { if (instance == null) instance = new RatioMaterialDAO(); return instance; }
            set => instance = value;
        }
        private RatioMaterialDAO() { }
        public List<RatioMaterialDTO> Getlist()
        {
            string query = "SELECT RatioMaterial.Id,IdMat,MatCode,MatName,RatioUsing,RatioInput,RatioMaterial.Note FROM dbo.Material,dbo.RatioMaterial WHERE Material.Id=IdMat ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<RatioMaterialDTO> lsv = new List<RatioMaterialDTO>();
            foreach (DataRow item in data.Rows)
            {
                RatioMaterialDTO DTO = new RatioMaterialDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public DataTable GetDatatable()
        {
            string query = "SELECT RatioMaterial.Id,IdMat,MatCode,MatName,RatioUsing,RatioInput,RatioMaterial.Note FROM dbo.Material,dbo.RatioMaterial WHERE Material.Id=IdMat ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public RatioMaterialDTO Getitem(int id)
        {
            string query = "SELECT RatioMaterial.Id,IdMat,MatCode,MatName,RatioUsing,RatioInput,RatioMaterial.Note FROM dbo.Material,dbo.RatioMaterial WHERE Material.Id=IdMat and RatioMaterial.Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                RatioMaterialDTO DTO = new RatioMaterialDTO(item);
                return DTO;
            }
            return null;
        }
        public RatioMaterialDTO Getitem(string matcode)
        {
            string query = "SELECT RatioMaterial.Id,IdMat,MatCode,MatName,RatioUsing,RatioInput,RatioMaterial.Note FROM dbo.Material,dbo.RatioMaterial WHERE Material.Id=IdMat and MatCode = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { matcode });
            foreach (DataRow item in data.Rows)
            {
                RatioMaterialDTO DTO = new RatioMaterialDTO(item);
                return DTO;
            }
            return null;
        }

        public int Insert(int idmat, int rau, int rat, string note)
        {
            string query = "INSERT dbo.RatioMaterial ( IdMat,RatioUsing, RatioInput,Note) VALUES ( @1 , @2 , @3 , @4 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idmat, rau, rat, note });
            return data;

        }

        public int Update(int id, int idmat, int rau, int rat, string note)
        {
            string query = "Update dbo.RatioMaterial set IdMat = @1 , RatioUsing = @2 , RatioInput = @3 , Note = @4 where Id= @5 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idmat, rau, rat, note, id });
            return data;

        }
        public int Update(int id, int rau, int rat, string note)
        {
            string query = "Update dbo.RatioMaterial set  RatioUsing = @1 , RatioInput = @2 , Note = @3 where Id= @4 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { rau, rat, note, id });
            return data;

        }
        public int Delete(int id)
        {
            string query = "Delete dbo.RatioMaterial where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
    }
}
