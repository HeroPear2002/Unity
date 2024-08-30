using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   
    public class DirectiveProductDTO
    {
       

        public DirectiveProductDTO(DataRow row)
        {
            this.Id =int.Parse(row["Id"].ToString());
            this.DateInput =Convert.ToDateTime(row["DateInput"].ToString());
            this.IdPart = (int)row["IdPart"];
            this.Quantity = (int)row["Quantity"];
            this.IdMachine = (int)row["IdMachine"];
            this.IdMold = (int)row["IdMold"];
            this.NoteProduct= row["NoteProduct"].ToString();
            this.NoteMaterial= row["NoteMaterial"].ToString();
            this.FactoryCode = row["FactoryCode"].ToString();
            this.WeightUse=(float)row["WeightUse"];
            this.WeightOut = (float)row["WeightOut"];
            this.Status = (int)row["Status"];
            this.Note = row["Note"].ToString();
        }

        public DirectiveProductDTO(long id, DateTime dateInput, int idPart, int quantity, int idMachine, int idMold, string noteProduct, string noteMaterial, string factoryCode, float weightUse, float weightOut, int status, string note)
        {
            Id = id;
            DateInput = dateInput;
            IdPart = idPart;
            Quantity = quantity;
            IdMachine = idMachine;
            IdMold = idMold;
            NoteProduct = noteProduct;
            NoteMaterial = noteMaterial;
            FactoryCode = factoryCode;
            WeightUse = weightUse;
            WeightOut = weightOut;
            Status = status;
            Note = note;
        }

        DateTime dateInput;
        long id;
        int idPart;
        int quantity;
        int idMachine;
        int idMold;
        string noteProduct;
        string noteMaterial;
        string factoryCode;
        float weightUse;
        float weightOut;
        int status;      
        string note;

        public long Id { get => id; set => id = value; }
        public DateTime DateInput { get => dateInput; set => dateInput = value; }
        public int IdPart { get => idPart; set => idPart = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int IdMachine { get => idMachine; set => idMachine = value; }
        public int IdMold { get => idMold; set => idMold = value; }
        public string NoteProduct { get => noteProduct; set => noteProduct = value; }
        public string NoteMaterial { get => noteMaterial; set => noteMaterial = value; }
        public string FactoryCode { get => factoryCode; set => factoryCode = value; }
        public float WeightUse { get => weightUse; set => weightUse = value; }
        public float WeightOut { get => weightOut; set => weightOut = value; }
        public int Status { get => status; set => status = value; }
        public string Note { get => note; set => note = value; }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
