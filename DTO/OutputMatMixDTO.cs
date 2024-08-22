using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class OutputMatMixDTO
    {
        public OutputMatMixDTO(long id, long idReInputMix, string matCode, string matName, string name, DateTime dateOutputMix, float quantityOutputMix, int idEm, string note, string reason, string lotMix, float quantityMixPlan)
        {
            Id = id;
            IdReInputMix = idReInputMix;
            MatCode = matCode;
            MatName = matName;
            Name = name;
            DateOutputMix = dateOutputMix;
            QuantityOutputMix = quantityOutputMix;
            IdEm = idEm;
            Note = note;
            Reason = reason;
            LotMix = lotMix;
            QuantityMixPlan = quantityMixPlan;
        }
        public OutputMatMixDTO(DataRow row)
        {
            Id = long.Parse(row["Id"].ToString());
            IdReInputMix = long.Parse(row["Id"].ToString());
            MatCode = row["MatCode"].ToString();
            MatName = row["MatName"].ToString();
            Name = row["Name"].ToString();
            DateOutputMix =DateTime.Parse( row["DateOutputMix"].ToString());
            QuantityOutputMix = float.Parse(row["QuantityOutputMix"].ToString());
            IdEm = int.Parse(row["IdEm"].ToString());
            Note = row["Note"].ToString(); ;
            Reason = row["Reason"].ToString(); ;
            LotMix = row["LotMix"].ToString(); ;
            QuantityMixPlan = float.Parse(row["QuantityMixPlan"].ToString());
            
        }

        public long Id { get => id; set => id = value; }
        public long IdReInputMix { get => idReInputMix; set => idReInputMix = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateOutputMix { get => dateOutputMix; set => dateOutputMix = value; }
        public float QuantityOutputMix { get => quantityOutputMix; set => quantityOutputMix = value; }
        public int IdEm { get => idEm; set => idEm = value; }
        public string Note { get => note; set => note = value; }
        public string Reason { get => reason; set => reason = value; }
        public string LotMix { get => lotMix; set => lotMix = value; }
        public float QuantityMixPlan { get => quantityMixPlan; set => quantityMixPlan = value; }
        long id;
        long idReInputMix;
        string matCode;
        string matName;
        string name;
        DateTime dateOutputMix;
        float quantityOutputMix;
        int idEm;
        string note;
        string reason;
        string lotMix;
        float quantityMixPlan;


    }
}
