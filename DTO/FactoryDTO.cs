using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class FactoryDTO
	{
		public FactoryDTO(int id, string facCode, string facName, string codeCus, int idCus, string nameBillVN, string nameBillEN, string address, string phone, string fax, string taxCode, string cuscode)
		{
			Id = id;
			FacCode = facCode;
			FacName = facName;
			CodeCus = codeCus;
			IdCus = idCus;
			NameBillVN = nameBillVN;
			NameBillEN = nameBillEN;
			Address = address;
			Phone = phone;
			Fax = fax;
			TaxCode = taxCode;
			CusCode = cuscode;
		}
		public FactoryDTO(DataRow row)
		{
			Id = int.Parse(row["Id"].ToString());
			FacCode = row["FacCode"].ToString();
			FacName = row["FacName"].ToString(); ;
			CodeCus = row["CodeCus"].ToString(); ;
			IdCus = int.Parse(row["IdCus"].ToString());
			NameBillVN = row["NameBillVN"].ToString(); ;
			NameBillEN = row["NameBillEN"].ToString(); ;
			Address = row["Address"].ToString(); ;
			Phone = row["Phone"].ToString(); ;
			Fax = row["Fax"].ToString(); ;
			TaxCode = row["TaxCode"].ToString(); ;
			CusCode = row["CusCode"].ToString(); ;
		}

		private int id;
		private string facCode;
		private string facName;
		private string codeCus;
		private int idCus;
		private string nameBillVN;
		private string nameBillEN;
		private string address;
		private string phone;
		private string fax;
		private string taxCode;
		private string cusCode;



		public int Id { get => id; set => id = value; }
		public string FacCode { get => facCode; set => facCode = value; }
		public string FacName { get => facName; set => facName = value; }
		public string CodeCus { get => codeCus; set => codeCus = value; }
		public int IdCus { get => idCus; set => idCus = value; }
		public string NameBillVN { get => nameBillVN; set => nameBillVN = value; }
		public string NameBillEN { get => nameBillEN; set => nameBillEN = value; }
		public string Address { get => address; set => address = value; }
		public string Phone { get => phone; set => phone = value; }
		public string Fax { get => fax; set => fax = value; }
		public string TaxCode { get => taxCode; set => taxCode = value; }
		public string CusCode { get => cusCode; set => cusCode = value; }
	}
}