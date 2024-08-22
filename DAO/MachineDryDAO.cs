using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace DAO
{
    public class MachineDryDAO
    {
        private static MachineDryDAO instance;

        public static MachineDryDAO Instance
        {
            get
            {
                if (instance == null) instance = new MachineDryDAO(); return instance;
            }

            set => instance = value;
        }
        public MachineDryDAO() { }
        public List<MachineDryDTO> Getlist()
        {
            string query = "select * from MachineDry ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<MachineDryDTO> lsv = new List<MachineDryDTO>();
            foreach (DataRow item in data.Rows)
            {
                MachineDryDTO DTO = new MachineDryDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public MachineDryDTO GetitembyId(int id)
        {
            string query = "select * from MachineDry where ID = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id});
          
            foreach (DataRow item in data.Rows)
            {
                MachineDryDTO DTO = new MachineDryDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert( string DryCode,string DryName, int WeightTray,string Note)
        {
            string query = "INSERT dbo.MachineDry (  DryCode,  DryName, WeightTray,  Note ) VALUES ( @1 , @2 , @3 , @4 )";

            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DryCode, DryName, WeightTray, Note });
            return data;
        }
        public int Update(int id,string DryCode, string DryName, int WeightTray, string Note)
        {
            string query = "Update dbo.MachineDry set  DryCode= @1 ,  DryName= @2 , WeightTray= @3 ,  Note= @4 where Id= @5";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DryCode, DryName, WeightTray, Note , id});
            return data;
        }
        public int Delete(int id)
        {
            string query = "Delete dbo.MachineDry where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
    }
}
