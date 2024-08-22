using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class InputMatDTO
    {
        public InputMatDTO(long id, int idmat, string matcode,string matname,DateTime dateinput, float quantity, int idwh,string name, int status,string styleintput, int idem, string lot, string rohs, string note,float inventory)
        {
            this.Id = id;
            this.IdMat = idmat;
            this.MatCode = matcode;
            this.MatName = matname;
            this.DateInput = dateinput;
            this.QuantityInput = quantity;
            this.IdWH = idwh;
            this.StatusInput = status;
            this.StyleInput = styleintput;
            this.IdEm = idem;
            this.Lot = lot;
            this.Rohs = rohs;
            this.Note = note;
            this.Name = name;
            this.QuantityInventory = inventory;
        }
        public InputMatDTO(DataRow row)
        {
            this.Id = long.Parse(row["Id"].ToString());
            this.IdMat = int.Parse(row["IdMat"].ToString());
            this.MatCode= row["MatCode"].ToString();
            this.MatName= row["MatName"].ToString();
            this.DateInput = DateTime.Parse(row["DateInput"].ToString());
            this.QuantityInput = float.Parse(row["QuantityInput"].ToString());
            this.IdWH = int.Parse(row["IdWH"].ToString());
            this.Name= row["Name"].ToString();
            this.StatusInput=int.Parse(row["StatusInput"].ToString());
            this.StyleInput = row["StyleInput"].ToString();
            this.IdEm = int.Parse(row["IdEm"].ToString());
            this.Lot = row["Lot"].ToString();
            this.Rohs= row["Rohs"].ToString();
            this.Note= row["Note"].ToString();
            this.QuantityInventory= float.Parse(row["QuantityInventory"].ToString());
        }
        private long id;
        private int idMat;
        private string matCode;
        private string matName;
        private DateTime dateInput;
        private float quantityInput;
        private int idWH;
        private string name;
        private int statusInput;
        private string styleInput;
        private int idEm;
        private string lot;
        private string rohs;
        private string note;
        private float quantityInventory;

        public long Id { get => id; set => id = value; }
        public int IdMat { get => idMat; set => idMat = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public float QuantityInput { get => quantityInput; set => quantityInput = value; }
        public int IdWH { get => idWH; set => idWH = value; }
        public int StatusInput { get => statusInput; set => statusInput = value; }
        public string StyleInput { get => styleInput; set => styleInput = value; }
        public int IdEm { get => idEm; set => idEm = value; }
        public string Lot { get => lot; set => lot = value; }
        public string Rohs { get => rohs; set => rohs = value; }
        public string Note { get => note; set => note = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public float QuantityInventory { get => quantityInventory; set => quantityInventory = value; }
        public string Name { get => name; set => name = value; }
    }
}
