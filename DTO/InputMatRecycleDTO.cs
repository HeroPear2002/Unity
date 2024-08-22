using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class InputMatRecycleDTO
    {
        public InputMatRecycleDTO(long id,long idinput, string matcode, string matname,string name, float quantity, int status, DateTime daterecycle, int idem, string note,float inventory)
        {
            this.Id = id;
            this.IdInput = idinput;
            this.MatCode = matcode;
            this.MatName = matname;
            this.NameWH = name;
            this.Quantity = quantity;
            this.StatusRecyle = status;
            this.DateRecyle = dateRecyle;
            this.IdEm = idem;
            this.Note = note;
            this.QuantityInventory = inventory;
        }
        public InputMatRecycleDTO (DataRow row)
        {
            this.Id = long.Parse(row["Id"].ToString());
            this.IdInput = long.Parse(row["IdInput"].ToString());                                  
            this.MatCode = row["MatCode"].ToString();
            this.MatName = row["MatName"].ToString();
            this.NameWH= row["Name"].ToString();
            this.Quantity = float.Parse(row["Quantity"].ToString());
            this.StatusRecyle = int.Parse(row["StatusRecycle"].ToString());
            var check = row["DateRecycle"].ToString();
            if(check !="")
            {
                this.DateRecyle = DateTime.Parse(row["DateRecycle"].ToString());
            }            
            this.IdEm= int.Parse(row["IdEm"].ToString());
            this.Note = row["Note"].ToString();
            this.QuantityInventory= float.Parse(row["QuantityInventory"].ToString());
        }
        private long id;
        private long idInput;
        private string matCode;
        private string matName;
        private string nameWH;
        private float quantity;
        private int statusRecyle;
        private DateTime dateRecyle;
        private int idEm;
        private string note;
        private float quantityInventory;


        public long Id { get => id; set => id = value; }
        public long IdInput { get => idInput; set => idInput = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public int StatusRecyle { get => statusRecyle; set => statusRecyle = value; }
        public DateTime DateRecyle { get => dateRecyle; set => dateRecyle = value; }
        public int IdEm { get => idEm; set => idEm = value; }
        public string Note { get => note; set => note = value; }
        public string NameWH { get => nameWH; set => nameWH = value; }
        public float QuantityInventory { get => quantityInventory; set => quantityInventory = value; }
    }
}
