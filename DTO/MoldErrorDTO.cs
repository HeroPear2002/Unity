using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoldErrorDTO
    {
        //  insert MoldError(Name, Status, Note)  
        public MoldErrorDTO(DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.Name = row["Name"].ToString();           
            this.Status = int.Parse(row["Status"].ToString());          
            this.Note = row["Note"].ToString();
        }

        //  insert MoldError(Id, Name, Status, Note)  

        private int id;
        private string name;
        private int status;
        private string note;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Status { get => status; set => status = value; }
        public string Note { get => note; set => note = value; }
    }
}
