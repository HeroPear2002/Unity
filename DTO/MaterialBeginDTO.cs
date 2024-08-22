using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class MaterialBeginDTO
    {
        public MaterialBeginDTO(int id, int idmat,string matcode,string matname, string weight, string time)
        {
            this.Id = id;
            this.IdMat = idmat;
            this.MatCode = matcode;
            this.MatName = matname;
            this.WeightMin = weight;
            this.TimeMin = time;
        }
        public MaterialBeginDTO(DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.IdMat = int.Parse(row["IdMat"].ToString());
            this.MatCode= row["MatCode"].ToString();
            this.MatName= row["MatName"].ToString();
            
            this.WeightMin = row["WeightMin"].ToString();
            this.TimeMin = row["TimeMin"].ToString();
        }
        private int id;
        private int idMat;
        private string matCode;
        private string matName;
        private string weightMin;
        private string timeMin;
        public int Id { get => id; set => id = value; }
        public int IdMat { get => idMat; set => idMat = value; }
        public string WeightMin { get => weightMin; set => weightMin = value; }
        public string TimeMin { get => timeMin; set => timeMin = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
    }
}
