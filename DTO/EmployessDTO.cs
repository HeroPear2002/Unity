using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class EmployessDTO
	{
		public EmployessDTO(DataRow row)
		{
			this.Id = int.Parse(row["Id"].ToString());
			this.EmCode = row["EmCode"].ToString();
			this.EmName = row["EmName"].ToString();
			this.RoomCode = row["RoomCode"].ToString();
			this.DateInput = DateTime.Parse(row["DateInput"].ToString());
			this.Note = row["Note"].ToString();
		}

		private int id;
		private string emCode;
		private string emName;
		private string roomCode;
		private DateTime dateInput;
		private string note;

		public int Id { get => id; set => id = value; }
		public string EmCode { get => emCode; set => emCode = value; }
		public string EmName { get => emName; set => emName = value; }
		public string RoomCode { get => roomCode; set => roomCode = value; }
		public DateTime DateInput { get => dateInput; set => dateInput = value; }
		public string Note { get => note; set => note = value; }
	}
}