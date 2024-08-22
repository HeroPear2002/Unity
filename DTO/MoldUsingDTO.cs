using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class MoldUsingDTO
    {
        // insert MoldUsing(IdMold, StatusMold, Cav, CavNG, ShotPlan, ShotReality, TotalShot, ConfirmMold, Category, DateCheck, PlanMold, Warn, Note)     
        public MoldUsingDTO(DataRow row)
        {
            this.IdMold= int.Parse(row["IdMold"].ToString());         
            this.StatusMold = row["StatusMold"].ToString();
            this.Cav =int.Parse(row["Cav"].ToString());
            this.CavNG =int.Parse(row["CavNG"].ToString());
            this.ShotPlan =int.Parse(row["ShotPlan"].ToString());
            this.ShotReality =int.Parse(row["ShotReality"].ToString());
            this.TotalShot =int.Parse(row["TotalShot"].ToString());
            this.ConfirmMold =int.Parse(row["ConfirmMold"].ToString());
            this.Category = row["Category"].ToString();
            this.DateCheck = row["DateCheck"].ToString();
            this.PlanMold = row["PlanMold"].ToString();
            this.Warn =int.Parse(row["Warn"].ToString());
            this.Note = row["Note"].ToString();
        }


        private int idMold;
      
        private string statusMold;
        private int cav;
        private int cavNG;
        private int shotPlan;
        private int shotReality;
        private int totalShot;
        private int confirmMold;
        private string category;
        private string dateCheck;
        private string planMold;
        private int warn;
        private string note;

        public int IdMold { get => idMold; set => idMold = value; }
        public string StatusMold { get => statusMold; set => statusMold = value; }
        public int Cav { get => cav; set => cav = value; }
        public int CavNG { get => cavNG; set => cavNG = value; }
        public int ShotPlan { get => shotPlan; set => shotPlan = value; }
        public int ShotReality { get => shotReality; set => shotReality = value; }
        public int TotalShot { get => totalShot; set => totalShot = value; }
        public int ConfirmMold { get => confirmMold; set => confirmMold = value; }
      
        public string DateCheck { get => dateCheck; set => dateCheck = value; }
        public string PlanMold { get => planMold; set => planMold = value; }
        public int Warn { get => warn; set => warn = value; }
        public string Note { get => note; set => note = value; }
        public string Category { get => category; set => category = value; }
    }
}
