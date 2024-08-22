using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MaterialMixDTO
    {
        public MaterialMixDTO(int id, string matmix, string matcode, float quantity, string note)
        {
            this.Id = id;
            this.MatMix = matmix;
            this.MatCode = matcode;
            this.Quantity = quantity;
            this.Note = note;
        }
        public MaterialMixDTO(DataRow row)
        {
            this.Id = int.Parse(row["ID"].ToString());
            this.MatMix = row["MatMix"].ToString();
            this.MatCode = row["MatCode"].ToString();
            this.Quantity = float.Parse(row["Quantity"].ToString());
            this.Note = row["Note"].ToString();
        }
        private int id;
        private string matMix;
        private string matCode;
        private float quantity;
        private string note;

        public int Id { get => id; set => id = value; }
        public string MatCode { get => matCode; set => matCode = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public string Note { get => note; set => note = value; }
        public string MatMix { get => matMix; set => matMix = value; }
    }
}
