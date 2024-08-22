using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OutputMatDTO
    {
        public OutputMatDTO(DataRow row)
        {
            this.Id = long.Parse(row["Id"].ToString());
            this.IdInput= long.Parse(row["IdInput"].ToString());
            this.MatCode = row["MatCode"].ToString();
            this.MatName = row["MatName"].ToString();
            this.Name = row["Name"].ToString();
            this.DateOutput = DateTime.Parse(row["DateOutput"].ToString());
            this.QuantityOutput = float.Parse(row["QuantityOutput"].ToString());
            this.StyleOutput = row["StyleOutput"].ToString();
            this.IdEm = int.Parse(row["IdEm"].ToString());
            this.IdPart = int.Parse(row["IdPart"].ToString());
            this.IdMachine = int.Parse(row["IdMachine"].ToString());
            this.Lot = row["Lot"].ToString();
            this.Note = row["Note"].ToString();
        }
        private long id;
        private long idInput;
        private string matCode;
        private string matName;
        private string name;
        private DateTime dateOutput;
        private float quantityOutput;
        private string styleOutput;
        private int idEm;
        private int idPart;
        private int idMachine;
        private string lot;
        private string note;

        public long Id { get => id; set => id = value; }
        public long IdInput { get => idInput; set => idInput = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateOutput { get => dateOutput; set => dateOutput = value; }
        public float QuantityOutput { get => quantityOutput; set => quantityOutput = value; }
        public string StyleOutput { get => styleOutput; set => styleOutput = value; }
        public int IdEm { get => idEm; set => idEm = value; }
        public int IdPart { get => idPart; set => idPart = value; }
        public int IdMachine { get => idMachine; set => idMachine = value; }
        public string Lot { get => lot; set => lot = value; }
        public string Note { get => note; set => note = value; }
    }
}
