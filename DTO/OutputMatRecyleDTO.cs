using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OutputMatRecyleDTO
    {
        public OutputMatRecyleDTO(DataRow r)
        {
            this.Id = long.Parse(r["Id"].ToString());
            this.IdReInputCycle = long.Parse(r["IdReInputCycle"].ToString());
            this.DateReOutput = DateTime.Parse(r["DateReOutput"].ToString());
            this.MatCode = r["MatCode"].ToString();
            this.MatName = r["MatName"].ToString();
            this.QuantityReOutput = float.Parse(r["QuantityReOutput"].ToString());
            this.IdEm = int.Parse(r["IdEm"].ToString());
            this.Lot = r["Lot"].ToString();
            this.Note = r["Note"].ToString();
            this.Reason = r["Reason"].ToString();
            this.LotCycle = r["LotCycle"].ToString();
            this.QuantityCyclePlan = float.Parse(r["QuantityCyclePlan"].ToString());
        }
        private long id;
        private long idReInputCycle;
        private DateTime dateReOutput;
        private string matCode;
        private string matName;
        private float quantityReOutput;
        private int idEm;
        private string lot;
        private string note;
        private string reason;
        private string lotCycle;
        private float quantityCyclePlan;

        public long Id { get => id; set => id = value; }
        public long IdReInputCycle { get => idReInputCycle; set => idReInputCycle = value; }
        public DateTime DateReOutput { get => dateReOutput; set => dateReOutput = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public string MatName { get => matName; set => matName = value; }
        public float QuantityReOutput { get => quantityReOutput; set => quantityReOutput = value; }
        public int IdEm { get => idEm; set => idEm = value; }
        public string Lot { get => lot; set => lot = value; }
        public string Note { get => note; set => note = value; }
        public string Reason { get => reason; set => reason = value; }
        public string LotCycle { get => lotCycle; set => lotCycle = value; }
        public float QuantityCyclePlan { get => quantityCyclePlan; set => quantityCyclePlan = value; }
    }
}
