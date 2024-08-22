using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 public   class SupplierDTO
    {
        public SupplierDTO(int id, string supcode,string supname,string add, string phone, string email, string note)
        {
            this.ID = id;
            this.SupCode = supcode;
            this.SupName = supname;
            this.Address = add;
            this.Phone = phone;
            this.Email = email;
            this.Note = note;
        }
        public SupplierDTO(DataRow row)
        {
            this.ID = int.Parse(row["ID"].ToString());
            this.SupCode = row["SupCode"].ToString();
            this.SupName = row["SupName"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Email = row["Email"].ToString();
            this.Note = row["Note"].ToString();
        }

        private int iD;
        private string supCode;
        private string supName;
        private string address;
        private string phone;
        private string email;
        private string note;

        public int ID { get => iD; set => iD = value; }
        public string SupCode { get => supCode; set => supCode = value; }
        public string SupName { get => supName; set => supName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Note { get => note; set => note = value; }
    }
}
