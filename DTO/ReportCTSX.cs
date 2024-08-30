using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ReportCTSX
    {
        public ReportCTSX(string PartCode, string PartName, string MaterialCode, string MaterialName, string NumberMold, string MachineCode, int Quantity, int QuantityPart, int QuantityBox, float Hour, DateTime Date, float TotalWeight, string Employess, string BarCode, string NoteSX, string NoteNL, string Customer, string StatusMold, string TimeMin, string WeightMin)
        {
            this.PartCode = PartCode;
            this.PartName = PartName;
            this.MaterialCode = MaterialCode;
            this.MaterialName = MaterialName;
            this.NumberMold = NumberMold;
            this.MachineCode = MachineCode;
            this.Quantity = Quantity;
            this.QuantityPart = QuantityPart;
            this.Hour = Hour;
            this.Date = Date;
            this.TotalWeight = TotalWeight;
            this.QuantityBox = QuantityBox;
            this.Employess = Employess;
            this.BarCode = BarCode;
            this.NoteSX = NoteSX;
            this.NoteNL = NoteNL;
            this.Customer = Customer;
            this.StatusMold = StatusMold;
            this.TimeMin = TimeMin;
            this.WeightMin = WeightMin;
        }

        public ReportCTSX(DataRow row)
        {
            this.PartCode = row["PartCode"].ToString();
            this.PartName = row["PartName"].ToString();
            this.MaterialCode = row["MaterialCode"].ToString();
            this.MaterialName = row["MaterialName"].ToString();
            this.NumberMold = row["MoldNumber"].ToString();
            this.MachineCode = row["MachineCode"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.QuantityPart = (int)row["QuantityPart"];
            this.Hour = (float)Convert.ToDouble(row["Hour"].ToString());
            this.Date = (DateTime)row["Date"];
            this.TotalWeight = (float)Convert.ToDouble(row["TotalWeight"].ToString());
            this.QuantityBox = (int)row["QuantityBox"];
            this.Employess = row["Employess"].ToString();
            this.BarCode = row["BarCode"].ToString();
            this.NoteSX = row["NoteSX"].ToString();
            this.NoteNL = row["NoteNL"].ToString();
            this.Customer = row["Customer"].ToString();
            this.StatusMold = row["StatusMold"].ToString();
            this.TimeMin = row["TimeMin"].ToString();
            this.WeightMin = row["WeightMin"].ToString();
        }
        private string partCode;
        private string partName;
        private string materialCode;
        private string materialName;
        private string numberMold;
        private string machineCode;
        private int quantity;
        private int quantityPart;
        private int quantityBox;
        private float hour;
        private DateTime date;
        private float totalWeight;
        private string employess;
        private string barCode;
        private string noteSX;
        private string noteNL;
        private string customer;
        private string statusMold;
        private string timeMin;
        private string weightMin;

        public string PartCode { get => partCode; set => partCode = value; }
        public string PartName { get => partName; set => partName = value; }
        public string MaterialCode { get => materialCode; set => materialCode = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public string NumberMold { get => numberMold; set => numberMold = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int QuantityPart { get => quantityPart; set => quantityPart = value; }
        public int QuantityBox { get => quantityBox; set => quantityBox = value; }
        public float Hour { get => hour; set => hour = value; }
        public DateTime Date { get => date; set => date = value; }
        public float TotalWeight { get => totalWeight; set => totalWeight = value; }
        public string Employess { get => employess; set => employess = value; }
        public string BarCode { get => barCode; set => barCode = value; }
        public string NoteSX { get => noteSX; set => noteSX = value; }
        public string NoteNL { get => noteNL; set => noteNL = value; }
        public string Customer { get => customer; set => customer = value; }
        public string StatusMold { get => statusMold; set => statusMold = value; }
        public string TimeMin { get => timeMin; set => timeMin = value; }
        public string WeightMin { get => weightMin; set => weightMin = value; }

        public override bool Equals(object obj)
        {
            var cTSX = obj as ReportCTSX;
            return cTSX != null &&
                   PartCode == cTSX.PartCode &&
                   PartName == cTSX.PartName &&
                   MaterialCode == cTSX.MaterialCode &&
                   MaterialName == cTSX.MaterialName &&
                   NumberMold == cTSX.NumberMold &&
                   MachineCode == cTSX.MachineCode &&
                   Quantity == cTSX.Quantity &&
                   QuantityPart == cTSX.QuantityPart &&
                   QuantityBox == cTSX.QuantityBox &&
                   Hour == cTSX.Hour &&
                   Date == cTSX.Date &&
                   TotalWeight == cTSX.TotalWeight &&
                   Employess == cTSX.Employess &&
                   BarCode == cTSX.BarCode &&
                   NoteSX == cTSX.NoteSX &&
                   NoteNL == cTSX.NoteNL &&
                   Customer == cTSX.Customer &&
                   StatusMold == cTSX.StatusMold &&
                   TimeMin == cTSX.TimeMin &&
                   WeightMin == cTSX.WeightMin;
        }
    }
}
