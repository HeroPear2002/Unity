using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class MachineDryDTO
    {
        public MachineDryDTO(int id, string drycode, string dryname, int weighttray, string note)
        {
            this.Id = id;
            this.DryCode = drycode;
            this.DryName =dryname;
            this.WeightTray = weighttray;
            this.Note = note;
        }
        public MachineDryDTO(DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.DryCode = row["DryCode"].ToString();
            this.DryName= row["DryName"].ToString();
            this.WeightTray= int.Parse(row["WeightTray"].ToString());
            this.Note= row["Note"].ToString();            
        }
        private int id;
        private string dryCode;
        private string dryName;
        private int weightTray;
        private string note;

        public int Id { get => id; set => id = value; }
        public string DryCode { get => dryCode; set => dryCode = value; }
        public string DryName { get => dryName; set => dryName = value; }
        public int WeightTray { get => weightTray; set => weightTray = value; }
        public string Note { get => note; set => note = value; }
    }
}
