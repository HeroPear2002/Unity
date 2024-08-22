using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoldHistoryDTO
    {

        // insert MoldHistory(IdMachine,IdMold,DateError,CountShort,TotalShort,Category,Error,TribeError,Detail,DateStart,DateEnd,TotalTime,Detail1,Detail2,Detail3,Detail4,Detail5,Detail6)

        public MoldHistoryDTO(DataRow row)
        {           
            this.Id = int.Parse(row["Id"].ToString());
            this.IdMachine = int.Parse(row["IdMachine"].ToString());
            this.IdMold = int.Parse(row["IdMold"].ToString());
            var checkDateError = row["DateError"];
            if (checkDateError.ToString() != "")
            {
                this.DateError = (DateTime)checkDateError;
            }          
            this.CountShort = int.Parse(row["CountShort"].ToString());
            this.TotalShort = int.Parse(row["TotalShort"].ToString());
            this.Category = row["Category"].ToString();
            this.Error = row["Error"].ToString();
            this.TribeError = row["TribeError"].ToString();
            this.Detail = row["Detail"].ToString();
            var checkDateStart = row["DateStart"];
            if (checkDateStart.ToString() != "")
            {
                this.DateStart = (DateTime)checkDateStart;
            }
            var checkDateEnd = row["DateEnd"];
            if (checkDateEnd.ToString() != "")
            {
                this.DateEnd = (DateTime)checkDateEnd;
            }
            this.TotalTime = row["TotalTime"].ToString();
            this.Detail1 = row["Detail1"].ToString();
            this.Detail2 = row["Detail2"].ToString();
            this.Detail3 = row["Detail3"].ToString();
            this.Detail4 = row["Detail4"].ToString();
            this.Detail5 = row["Detail5"].ToString();
            this.Detail6 = row["Detail6"].ToString();
        }


        // insert MoldHistory(IdMachine,IdMold,DateError,CountShort,TotalShort,Category,Error,TribeError,Detail,DateStart,DateEnd,TotalTime,Detail1,Detail2,Detail3,Detail4,Detail5,Detail6)


        private int id;
        private int idMachine;
        private int idMold;
        private DateTime dateError;
        private int countShort;
        private int totalShort;
        private string category;
        private string error;
        private string tribeError;
        private string detail;
        private DateTime dateStart;
        private DateTime dateEnd;             
        private string totalTime;
        private string detail1;
        private string detail2;
        private string detail3;
        private string detail4;
        private string detail5;
        private string detail6;

        public int Id { get => id; set => id = value; }
        public int IdMachine { get => idMachine; set => idMachine = value; }
        public int IdMold { get => idMold; set => idMold = value; }
        public DateTime DateError { get => dateError; set => dateError = value; }
        public int CountShort { get => countShort; set => countShort = value; }
        public int TotalShort { get => totalShort; set => totalShort = value; }
        public string Category { get => category; set => category = value; }
        public string Error { get => error; set => error = value; }
        public string TribeError { get => tribeError; set => tribeError = value; }
        public string Detail { get => detail; set => detail = value; }
        public DateTime DateStart { get => dateStart; set => dateStart = value; }
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }
        public string TotalTime { get => totalTime; set => totalTime = value; }
        public string Detail1 { get => detail1; set => detail1 = value; }
        public string Detail2 { get => detail2; set => detail2 = value; }
        public string Detail3 { get => detail3; set => detail3 = value; }
        public string Detail4 { get => detail4; set => detail4 = value; }
        public string Detail5 { get => detail5; set => detail5 = value; }
        public string Detail6 { get => detail6; set => detail6 = value; }
    }
}
