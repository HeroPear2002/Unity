using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class MoldDTO
	{

		// insert Mold(MoldCode,MoldName,Model,Maker,DateInput,Where,DateProduct,EmCode,ShotCount,Note)

		public MoldDTO(DataRow row)
		{
			this.Id = int.Parse(row["Id"].ToString());
			this.MoldCode = row["MoldCode"].ToString();
			this.MoldName = row["MoldName"].ToString();
			this.Model = row["Model"].ToString();
			this.Maker = row["Maker"].ToString();
			this.DateInput = Convert.ToDateTime(row["DateInput"].ToString());
			this.Where = row["Where"].ToString();
			this.DateProduct = row["DateProduct"].ToString();
			this.EmCode = row["EmCode"].ToString();
			this.ShotCount = int.Parse(row["ShotCount"].ToString());
			this.NumberMold = row["NumberMold"].ToString();
			this.Note = row["Note"].ToString();
		}

        public MoldDTO(string moldCode, string moldName, string model, string maker, DateTime dateInput, string where, string dateProduct, string emCode, int shotCount, string note, string numberMold, int id)
        {
            MoldCode = moldCode;
            MoldName = moldName;
            Model = model;
            Maker = maker;
            DateInput = dateInput;
            Where = where;
            DateProduct = dateProduct;
            EmCode = emCode;
            ShotCount = shotCount;
            Note = note;
            NumberMold = numberMold;
            Id = id;
        }

        private int id;
        private string moldCode;
        private string moldName;
        private string model;
        private string maker;
        private DateTime dateInput;
        private string where;
        private string dateProduct;
        private string emCode;
        private int shotCount;
        private string numberMold;
        private string note;


		public string MoldCode { get => moldCode; set => moldCode = value; }
		public string MoldName { get => moldName; set => moldName = value; }
		public string Model { get => model; set => model = value; }
		public string Maker { get => maker; set => maker = value; }
		public DateTime DateInput { get => dateInput; set => dateInput = value; }
		public string Where { get => where; set => where = value; }
		public string DateProduct { get => dateProduct; set => dateProduct = value; }
		public string EmCode { get => emCode; set => emCode = value; }
		public int ShotCount { get => shotCount; set => shotCount = value; }
		public string Note { get => note; set => note = value; }
		public string NumberMold { get => numberMold; set => numberMold = value; }
		public int Id { get => id; set => id = value; }


	}
}
