using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
  public  class MaterialBeginDAO
    {
        private static MaterialBeginDAO instance;

        public static MaterialBeginDAO Instance
        {
            get { if (instance == null) instance = new MaterialBeginDAO(); return instance; }
            set => instance = value;
        }
        private MaterialBeginDAO() { }
        public List<MaterialBeginDTO> Getlist()
        {
            string query = "SELECT MaterialBegin.Id, IdMat , MatCode,MatName,WeightMin,TimeMin FROM dbo.Material, dbo.MaterialBegin WHERE Material.Id=IdMat ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<MaterialBeginDTO> lsv = new List<MaterialBeginDTO>();
            foreach (DataRow item in data.Rows)
            {
                MaterialBeginDTO DTO = new MaterialBeginDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public MaterialBeginDTO GetItem(int id)
        {
            string query = "SELECT MaterialBegin.Id, IdMat , MatCode,MatName,WeightMin,TimeMin FROM dbo.Material, dbo.MaterialBegin WHERE Material.Id=IdMat and Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                MaterialBeginDTO DTO = new MaterialBeginDTO(item);
                return DTO;
            }
            return null;
        }

        public int Insert(int idmat, string weight, string time)
        {
            string query = " INSERT dbo.MaterialBegin ( IdMat,WeightMin, TimeMin) VALUES ( @1 , @2 , @3 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idmat,weight,time });
            return data;
        }
        public int Update(int id,int idmat, string weight,string time)
        {
            string query = " Update dbo.MaterialBegin set IdMat= @1 , WeightMin = @2 , TimeMin = @3  where ID= @4 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idmat,weight,time, id });
            return data;
        }
        public int Delete(int id)
        {
            string query = " Delete dbo.MaterialBegin where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
        public int check(int idmat)
        {
            string query = "select * from dbo.MaterialBegin where IdMat= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idmat });
            return data.Rows.Count;
        }
    }
}
