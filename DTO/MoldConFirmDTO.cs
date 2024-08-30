using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoldConFirmDTO
    {
        // insert MoldConFirm(IdMold, IdEmPC, TimePC, IdEmQC, TimeQC, IdEmTool, TimeTool)

        public MoldConFirmDTO(DataRow row)
        {
            this.Id= int.Parse(row["Id"].ToString());
            this.IdMold = int.Parse(row["IdMold"].ToString());
            this.IdEmPC = int.Parse(row["IdEmPC"].ToString());
            this.TimePC = DateTime.Parse(row["TimePC"].ToString());
            this.IdEmQC = int.Parse(row["IdEmQC"].ToString());
            this.TimeQC = DateTime.Parse(row["TimeQC"].ToString());
            this.IdEmTool = int.Parse(row["IdEmTool"].ToString());
            this.TimeTool = DateTime.Parse(row["TimeTool"].ToString());
        }

        public MoldConFirmDTO(int id, int idMold, int idEmPC, DateTime timePC, int idEmQC, DateTime timeQC, int idEmTool, DateTime timeTool)
        {
            Id = id;
            IdMold = idMold;
            IdEmPC = idEmPC;
            TimePC = timePC;
            IdEmQC = idEmQC;
            TimeQC = timeQC;
            IdEmTool = idEmTool;
            TimeTool = timeTool;
        }
        
        private int id;
        private int idMold;      
        private int idEmPC;
        private DateTime timePC;
        private int idEmQC;
        private DateTime timeQC;
        private int idEmTool;
        private DateTime timeTool;

        public int Id { get => id; set => id = value; }
        public int IdMold { get => idMold; set => idMold = value; }
        public int IdEmPC { get => idEmPC; set => idEmPC = value; }
        public DateTime TimePC { get => timePC; set => timePC = value; }
        public int IdEmQC { get => idEmQC; set => idEmQC = value; }
        public DateTime TimeQC { get => timeQC; set => timeQC = value; }
        public int IdEmTool { get => idEmTool; set => idEmTool = value; }
        public DateTime TimeTool { get => timeTool; set => timeTool = value; }
    }
}
