using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class ReasonDAO
    {
        private static ReasonDAO instance;

        public static ReasonDAO Instance
        {
            get { if (instance == null) instance = new ReasonDAO(); return instance; }
            set => instance = value;
        }
        private ReasonDAO() { }
        public List<ReasonDTO> Getlist()
        {
            string query = "select * from Reason ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<ReasonDTO> lsv = new List<ReasonDTO>();
            foreach (DataRow item in data.Rows)
            {
                ReasonDTO DTO = new ReasonDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public ReasonDTO GetitembyId(int id)
        {
            string query = "select * from Reason where Id= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                ReasonDTO DTO = new ReasonDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert(string re, string note)
        {
            string query = "INSERT Reason ( ReasonDetail, Note ) VALUES ( @1 , @2 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { re , note });
            return data;

        }

        public int Update(int id, string re, string note)
        {
            string query = "Update  Reason set  ReasonDetail = @1 , Note = @2   where Id= @3 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { re, note, id });
            return data;
        }
        public int Delete(int id)
        {
            string query = "Delete dbo.Reason where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
    }
}
