using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class InputMatMixDTO
    {
        public InputMatMixDTO(DataRow row)
        {
            this.Id = long.Parse(row["Id"].ToString());
            this.IdInput= long.Parse(row["IdInput"].ToString());
            this.MatCode = row["MatCode"].ToString();
            this.MatName= row["MatName"].ToString();
            this.QuantityMix=float.Parse(row["QuantityMix"].ToString());
            this.QuantityInventory= float.Parse(row["QuantityInventory"].ToString());
            this.StatusMix = int.Parse(row["StatusMix"].ToString());
            this.DateMix = DateTime.Parse(row["DateMix"].ToString());
            this.IdEm= int.Parse(row["IdEm"].ToString());
            this.Note= row["Note"].ToString();
            this.Name= row["Name"].ToString();
        }
        private long id;
        private long idInput;
        private string matCode;
        private string matName;
        private float quantityMix;
        private int statusMix;
        private DateTime dateMix;
        private int idEm;
        private string note;
        private float quantityInventory;
        private string name;

        public long Id { get => id; set => id = value; }
        public long IdInput { get => idInput; set => idInput = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public float QuantityMix { get => quantityMix; set => quantityMix = value; }
        public int StatusMix { get => statusMix; set => statusMix = value; }
        public DateTime DateMix { get => dateMix; set => dateMix = value; }
        public int IdEm { get => idEm; set => idEm = value; }
        public string Note { get => note; set => note = value; }
        public float QuantityInventory { get => quantityInventory; set => quantityInventory = value; }
        public string Name { get => name; set => name = value; }
    }
}
