using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DeliveryNoteDTO
	{
		long id;
		string deCode;
		DateTime dateInput;
		string emCreate;
		string dateOutput;
		string emOut;
		string dateChange;
		string emChange;
		string note;
		DateTime dateDelivery;
		int statusDe;

		public DeliveryNoteDTO(long id, string deCode, DateTime dateInput, string emCreate, string dateOutput, string emOut, string dateChange, string emChange, string note, DateTime dateDelivery, int statusDe)
		{
			Id = id;
			DeCode = deCode;
			DateInput = dateInput;
			EmCreate = emCreate;
			DateOutput = dateOutput;
			EmOut = emOut;
			DateChange = dateChange;
			EmChange = emChange;
			Note = note;
			DateDelivery = dateDelivery;
			StatusDe = statusDe;
		}
		public DeliveryNoteDTO(DataRow row)
		{
			Id = long.Parse(row["Id"].ToString());
			DeCode = row["DeCode"].ToString();
			DateInput = DateTime.Parse(row["DateInput"].ToString());
			EmCreate = row["EmCreate"].ToString();
			DateOutput = row["DateOutput"].ToString();
			EmOut = row["EmOut"].ToString();
			DateChange = row["DateChange"].ToString();
			EmChange = row["EmChange"].ToString();
			Note = row["Note"].ToString();
			DateDelivery = DateTime.Parse(row["DateDelivery"].ToString());
			StatusDe = int.Parse(row["StatusDe"].ToString());
		}
		public long Id { get => id; set => id = value; }
		public string DeCode { get => deCode; set => deCode = value; }
		public DateTime DateInput { get => dateInput; set => dateInput = value; }
		public string EmCreate { get => emCreate; set => emCreate = value; }
		public string DateOutput { get => dateOutput; set => dateOutput = value; }
		public string EmOut { get => emOut; set => emOut = value; }
		public string DateChange { get => dateChange; set => dateChange = value; }
		public string EmChange { get => emChange; set => emChange = value; }
		public string Note { get => note; set => note = value; }
		public DateTime DateDelivery { get => dateDelivery; set => dateDelivery = value; }
		public int StatusDe { get => statusDe; set => statusDe = value; }
	}
}
