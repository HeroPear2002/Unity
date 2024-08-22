using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
  public  class WareHouseMatDAO
    {
        private static WareHouseMatDAO instance;

        public static WareHouseMatDAO Instance
        { get
            {
                if (instance == null) instance = new WareHouseMatDAO(); return instance;
            }
          set => instance = value;
        }
        public WareHouseMatDAO() { }

        public object GetMaxRow()
        {
            string query = "SELECT MAX(MaxRow) FROM dbo.WarehouseMat ";
            object data = DataProvider.Instance.ExecuteScalar(query);
            return data;
        }

        public List<string>GetHeader()
        {
            string query = "SELECT DISTINCT (RowName) as RowName FROM dbo.WarehouseMat";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<string> lsv = new List<string>();
            foreach (DataRow item in data.Rows)
            {
                string nameheader = item["RowName"].ToString();
                lsv.Add(nameheader);
            }
            return lsv;
        }

        public List<WareHouseMatDTO> GetList()
        {
            string query = "SELECT * FROM dbo.WarehouseMat";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<WareHouseMatDTO> lsv = new List<WareHouseMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                WareHouseMatDTO DTO = new WareHouseMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<WareHouseMatDTO> GetListNull()
        {
            string query = "SELECT * FROM dbo.WarehouseMat where StatusWH = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<WareHouseMatDTO> lsv = new List<WareHouseMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                WareHouseMatDTO DTO = new WareHouseMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<WareHouseMatDTO> GetListSpecialNull()
        {
            string query = "SELECT * FROM dbo.WarehouseMat where StatusWH = 11";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<WareHouseMatDTO> lsv = new List<WareHouseMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                WareHouseMatDTO DTO = new WareHouseMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public List<WareHouseMatDTO> GetListSpecialNotNull()
        {
            string query = "SELECT * FROM dbo.WarehouseMat where StatusWH = 10";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<WareHouseMatDTO> lsv = new List<WareHouseMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                WareHouseMatDTO DTO = new WareHouseMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public List<WareHouseMatDTO> GetListByRowName(string rowname)
        {
            string query = "SELECT * FROM dbo.WarehouseMat   where RowName= @1 ORDER BY Number ASC, RowName ASC  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { rowname});
            List<WareHouseMatDTO> lsv = new List<WareHouseMatDTO>();
            foreach (DataRow item in data.Rows)
            {
                WareHouseMatDTO DTO = new WareHouseMatDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }

        public WareHouseMatDTO GetItem(int id)
        {
            string query = "SELECT * FROM dbo.WarehouseMat   where Id = @1 ORDER BY Number ASC, RowName ASC  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
           
            foreach (DataRow item in data.Rows)
            {
                WareHouseMatDTO DTO = new WareHouseMatDTO(item);
                return DTO;
            }
            return null;
        }
        public object CountLocationRow(string rowname)
        {
            string query = "SELECT count(*) FROM dbo.WarehouseMat where RowName= @1 ";
            object data = DataProvider.Instance.ExecuteScalar(query, new object[] { rowname });
            return data;
        }
        public int CheckNameExit(string name)
        {
            string query = "SELECT * FROM dbo.WarehouseMat where Name= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            return data.Rows.Count;
        }
        public int Insert(string name, int status, string style,int weight, string note,int maxrow,string rowname, int num)
        {
            string query= "INSERT dbo.WarehouseMat ( Name , StatusWH , Style , WeightWH , Note , MaxRow , RowName , Number) VALUES( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, status, style, weight, note, maxrow, rowname ,num});
            return data;

        }
        public int Update(int id, int status, int weight)
        {
            string query = "Update dbo.WarehouseMat set  StatusWH = @1  ,  WeightWH = @2 where Id = @3 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status,  weight, id });
            return data;

        }
        public int Update(int id, int status)
        {
            string query = "Update dbo.WarehouseMat set  StatusWH = @1   where Id = @2 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status,  id });
            return data;

        }
        public int SetupMaxLayOut(int max)
        {
            string query = "Update dbo.WarehouseMat set MaxRow= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { max });
            return data;

        }
    }
}
