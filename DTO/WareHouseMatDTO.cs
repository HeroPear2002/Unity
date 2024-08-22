using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 public   class WareHouseMatDTO
    {
        public WareHouseMatDTO(int id, string name,int statusWH,string styles, int weight,string note, int maxrow,string rowname)
        {
            this.Id = id;
            this.Name = name;
            this.StatusWH = statusWH;
            this.Style = style;
            this.WeightWH = weight;
            this.Note = note;
            this.MaxRow = maxrow;
            this.RowName = rowname;
        }
        public WareHouseMatDTO(DataRow row)
        {
            this.Id = int.Parse(row["Id"].ToString());
            this.Name = row["Name"].ToString();
            this.StatusWH = int.Parse(row["StatusWH"].ToString());
            this.Style = row["Style"].ToString();
            this.WeightWH = int.Parse(row["WeightWH"].ToString());
            this.Note = row["Note"].ToString(); 
            this.MaxRow = int.Parse(row["MaxRow"].ToString());
            this.RowName = row["RowName"].ToString(); 
        }
        private int id;
        private int statusWH;
        private string style;
        private int weightWH;
        private string note;
        private int maxRow;
        private string rowName;
        private string name;

        public int Id { get => id; set => id = value; }
        public int StatusWH { get => statusWH; set => statusWH = value; }
        public string Style { get => style; set => style = value; }
        public int WeightWH { get => weightWH; set => weightWH = value; }
        public string Note { get => note; set => note = value; }
        public int MaxRow { get => maxRow; set => maxRow = value; }
        public string RowName { get => rowName; set => rowName = value; }
        public string Name { get => name; set => name = value; }
    }
}
