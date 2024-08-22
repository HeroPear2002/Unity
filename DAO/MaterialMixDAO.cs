using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
 public  class MaterialMixDAO
    {
        private static MaterialMixDAO instance;

        public static MaterialMixDAO Instance
        {
            get { if (instance == null) instance = new MaterialMixDAO(); return instance; }
            set => instance = value;
        }
        public MaterialMixDAO() { }

        public List<MaterialMixDTO> Getlist()
        {
            string query = "select * from MaterialMix ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<MaterialMixDTO> lsv = new List<MaterialMixDTO>();
            foreach (DataRow item in data.Rows)
            {
                MaterialMixDTO DTO = new MaterialMixDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public MaterialMixDTO GetitembyId(int id)
        {
            string query = "select * from MaterialMix where Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { id});         
            foreach (DataRow item in data.Rows)
            {
                MaterialMixDTO DTO = new MaterialMixDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert(string matmix, string matcode, float quantity, string note)
        {
            string query = "INSERT dbo.MaterialMix ( MatMix , MatCode,  Quantity , Note ) VALUES ( @1 , @2 , @3 , @4 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matmix,matcode,quantity,note});
            return data;

        }

        public int Update(int id, string matmix, string matcode, float quantity, string note)
        {
            string query = "Update dbo.MaterialMix set MatMix = @1  , MatCode = @2 ,  Quantity = @3 , Note = @4  where Id= @5 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matmix, matcode, quantity, note ,id});
            return data;
        }
        public int Delete (int id)
        {
            string query = "Delete dbo.MaterialMix where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {id});
            return data;
        }
    }
}
