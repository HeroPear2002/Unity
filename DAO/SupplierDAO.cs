using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
  public  class SupplierDAO
    {
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get { if (instance == null) instance = new SupplierDAO();return instance; }
            set => instance = value;
        }
        public SupplierDAO() { }

        public List<SupplierDTO> Getlist()
        {
            string query = "Select * from Supplier";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<SupplierDTO> lsv = new List<SupplierDTO>();
            foreach (DataRow item in data.Rows)
            {
                SupplierDTO DTO = new SupplierDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public SupplierDTO GetItembyId(int id)
        {
            string query = "Select * from Supplier where ID= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query , new object[] { id});          
            foreach (DataRow item in data.Rows)
            {
                SupplierDTO DTO = new SupplierDTO(item);
                return DTO;
            }
            return null;
        }
        public SupplierDTO GetItembySupCode(string supcode)
        {
            string query = "Select * from Supplier where SupCode= @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { supcode });
            foreach (DataRow item in data.Rows)
            {
                SupplierDTO DTO = new SupplierDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert(string supCo, string supna,string addr, string phone, string email, string note)
        {
            string query = "Insert Supplier ( SupCode , SupName , Address , Phone , Email , Note ) values ( @1 , @2 , @3 , @4 , @5 , @6 )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { supCo, supna, addr, phone, email, note });
            return data;
        }
        public int Update(int id,string supCo, string supna, string addr, string phone, string email, string note)
        {
            string query = "Update Supplier set SupCode= @1 , SupName = @2 , Address= @3 , Phone= @4 , Email= @5 , Note= @6 where ID= @7 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { supCo, supna, addr, phone, email, note, id });
            return data;
        }
        public int Delete(int id)
        {
            string query = "Delete Supplier where Id= @1";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {id });
            return data;
        }
        public int check(string supcode)
        {
            string query = "Select * from Supplier where SupCode = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {supcode });
            return data.Rows.Count;
        }
    }
}
