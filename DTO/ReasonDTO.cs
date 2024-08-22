using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ReasonDTO
    {
        public ReasonDTO(int id, string re, string note)
        {
            this.Id = id;
            this.ReasonDetail = re;
            this.Note = note;
        }
        public ReasonDTO(DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.ReasonDetail = row["ReasonDetail"].ToString();
            this.Note = row["Note"].ToString();
        }
        private int id;
        private string reasonDetail;
        private string note;

        public int Id { get => id; set => id = value; }
        public string ReasonDetail { get => reasonDetail; set => reasonDetail = value; }
        public string Note { get => note; set => note = value; }
    }
}
