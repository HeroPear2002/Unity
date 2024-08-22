using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class CustomerDTO
	{
		public CustomerDTO(int id, string cuscode, string cusname, string add, string phone, string email, string note, int warnpo, int warnpofix, int warncus)
		{
			this.Id = id;
			this.CusCode = cuscode;
			this.CusName = cusname;
			this.Address = add;
			this.Phone = phone;
			this.Email = email;
			this.Note = note;
			this.WarnInputPO = warnpo;
			this.WarnPOFix = warnpofix;
			this.WarnCus = warncus;
		}
		public CustomerDTO(DataRow row)
		{
			this.Id = int.Parse(row["Id"].ToString());
			this.CusCode = row["CusCode"].ToString();
			this.CusName = row["CusName"].ToString();
			this.Address = row["Address"].ToString();
			this.Phone = row["Phone"].ToString();
			this.Email = row["Email"].ToString();
			this.Note = row["Note"].ToString();
			this.WarnInputPO = int.Parse(row["WarnInputPO"].ToString());
			this.WarnPOFix = int.Parse(row["WarnPOFix"].ToString());
			this.WarnCus = int.Parse(row["WarnCus"].ToString());
		}
		private int id;
		private string cusCode;
		private string cusName;
		private string address;
		private string phone;
		private string email;
		private int warnInputPO;
		private int warnPOFix;
		private int warnCus;
		private string note;

		public int Id { get => id; set => id = value; }
		public string CusCode { get => cusCode; set => cusCode = value; }
		public string CusName { get => cusName; set => cusName = value; }
		public string Address { get => address; set => address = value; }
		public string Phone { get => phone; set => phone = value; }
		public string Email { get => email; set => email = value; }
		public string Note { get => note; set => note = value; }
		public int WarnInputPO { get => warnInputPO; set => warnInputPO = value; }
		public int WarnPOFix { get => warnPOFix; set => warnPOFix = value; }
		public int WarnCus { get => warnCus; set => warnCus = value; }
	}
}
