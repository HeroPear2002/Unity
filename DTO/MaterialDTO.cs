using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class MaterialDTO
    {
        public MaterialDTO(int id, string matcode, string matname, int warny, int  warnc, int idsup,string supcode, string nature, string rohs, string color, string note)
        {
            this.Id =id;
            this.MatCode = matcode;
            this.MatName = matname;
            this.WarnYllow = warny;
            this.WarnCount = warnc;
            this.IdSup = idsup;
            this.supCode = supCode;
            this.Nature = nature;
            this.RohsFile = rohs;
            this.ColorCode = color;
            this.Note = note;
        }
        public MaterialDTO(DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.MatCode = row["MatCode"].ToString();
            this.MatName = row["MatName"].ToString();
            this.WarnYllow= int.Parse(row["WarnYllow"].ToString());
            this.WarnCount= int.Parse(row["WarnCount"].ToString());
            this.IdSup= int.Parse(row["IdSup"].ToString());
            this.SupCode = row["SupCode"].ToString();
            this.Nature= row["Nature"].ToString();
            this.RohsFile= row["RohsFile"].ToString();
            this.ColorCode = row["ColorCode"].ToString();
            this.Note= row["Note"].ToString();
        }
        private int id;
        private string matCode;
        private string matName;
        private int warnYllow;
        private int warnCount;
        private int idSup;
        private string supCode;
        private string nature;
        private string rohsFile;
        private string colorCode;
        private string note;

        public int Id { get => id; set => id = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public int WarnYllow { get => warnYllow; set => warnYllow = value; }
        public int WarnCount { get => warnCount; set => warnCount = value; }
        public int IdSup { get => idSup; set => idSup = value; }
        public string Nature { get => nature; set => nature = value; }
        public string RohsFile { get => rohsFile; set => rohsFile = value; }
        public string ColorCode { get => colorCode; set => colorCode = value; }
        public string Note { get => note; set => note = value; }
        public string SupCode { get => supCode; set => supCode = value; }
    }
}
