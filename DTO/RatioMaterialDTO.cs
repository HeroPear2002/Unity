using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class RatioMaterialDTO
    {
        public RatioMaterialDTO(int id, int idmat, string matcode, string matname, int rau,int rat,string note)
        {
            this.Id = id;
            this.IdMat = idmat;
            this.MatCode = matcode;
            this.MatName = matname;
            this.RatioUsing = rau;
            this.RatioInput = rat;
            this.Note = note;
        }

        public RatioMaterialDTO (DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.IdMat= int.Parse(row["IdMat"].ToString());
            this.MatCode= row["MatCode"].ToString();
            this.MatName = row["MatName"].ToString();
            this.RatioUsing = int.Parse(row["RatioUsing"].ToString());
            this.RatioInput = int.Parse(row["RatioInput"].ToString());
            this.Note = row["Note"].ToString();
        }
        private int id;
        private int idMat;
        private string matCode;
        private string matName;
        private int ratioUsing;
        private int ratioInput;
        private string note;

        public int Id { get => id; set => id = value; }
        public int IdMat { get => idMat; set => idMat = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public int RatioUsing { get => ratioUsing; set => ratioUsing = value; }
        public int RatioInput { get => ratioInput; set => ratioInput = value; }
        public string Note { get => note; set => note = value; }
    }
}
