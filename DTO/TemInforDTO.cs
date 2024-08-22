using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class TemInforDTO
    {
        public TemInforDTO(int id, int idPart, string partCode, int idMachine, string machineCode, int idMold, string moldCode, string numbermold,int cavStyle, string rev, string facCode, string standard, int important, string note)
        {
            Id = id;
            IdPart = idPart;
            PartCode = partCode;
            IdMachine = idMachine;
            MachineCode = machineCode;
            IdMold = idMold;
            MoldCode = moldCode;
            NumberMold = numbermold;
            CavStyle = cavStyle;
            Rev = rev;
            FacCode = facCode;
            Standard = standard;
            Important = important;
            Note = note;
        }
        public TemInforDTO(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            IdPart = int.Parse(row["IdPart"].ToString());
            PartCode = row["PartCode"].ToString();
            IdMachine = int.Parse(row["IdMachine"].ToString());
            MachineCode = row["MachineCode"].ToString();
            IdMold = int.Parse(row["IdMold"].ToString());
            MoldCode = row["MoldCode"].ToString();
            NumberMold= row["NumberMold"].ToString();
            CavStyle = int.Parse(row["CavStyle"].ToString());
            Rev = row["Rev"].ToString();
            FacCode = row["FacCode"].ToString();
            Standard = row["Standard"].ToString();
            Important = int.Parse(row["Important"].ToString());
            Note = row["Note"].ToString();
        }
        private int id;
        private int idPart;
        private string partCode;
        private int idMachine;
        private string machineCode;
        private int idMold;
        private string moldCode;
        private string numberMold;
        private int cavStyle;
        private string rev;
        private string facCode;
        private string standard;
        private int important;
        private string note;

        

        public int Id { get => id; set => id = value; }
        public int IdPart { get => idPart; set => idPart = value; }
        public string PartCode { get => partCode; set => partCode = value; }
        public int IdMachine { get => idMachine; set => idMachine = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public int IdMold { get => idMold; set => idMold = value; }
        public string MoldCode { get => moldCode; set => moldCode = value; }
        public int CavStyle { get => cavStyle; set => cavStyle = value; }
        public string Rev { get => rev; set => rev = value; }
        public string FacCode { get => facCode; set => facCode = value; }
        public string Standard { get => standard; set => standard = value; }
        public int Important { get => important; set => important = value; }
        public string Note { get => note; set => note = value; }
        public string NumberMold { get => numberMold; set => numberMold = value; }
    }
}
