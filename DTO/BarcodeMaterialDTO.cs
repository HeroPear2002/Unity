using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class BarcodeMaterialDTO
    {
        public BarcodeMaterialDTO(string MaterialCode, string MaterialName, float Count, string Name, string DateInput, string Employess, string Nature)
        {
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.Count = Count;
            this.Name = Name;
            this.DateInput = DateInput;
            this.Employess = Employess;
            this.Nature = Nature;
        }
        public BarcodeMaterialDTO(DataRow row)
        {
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.Count = (float)Convert.ToDouble(row["Count"].ToString());
            this.Name = row["Name"].ToString();
            this.DateInput = row["DateInput"].ToString();
            this.Employess = row["Employess"].ToString();
            this.Nature = row["Nature"].ToString();
        }
        private string materialCode;
        private string materialName;
        private float count;
        private string name;
        private string dateInput;
        private string employess;
        private string nature;

        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public float Count { get => count; set => count = value; }
        public string Name { get => name; set => name = value; }
        public string DateInput { get => dateInput; set => dateInput = value; }
        public string Employess { get => employess; set => employess = value; }
        public string Nature { get => nature; set => nature = value; }
    }
}
