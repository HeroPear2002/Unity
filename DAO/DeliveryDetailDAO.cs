using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class DeliveryDetailDAO
	{
		private static DeliveryDetailDAO instance;

		public static DeliveryDetailDAO Instance { get { if (instance == null) instance = new DeliveryDetailDAO(); return instance; } set => instance = value; }

		public DeliveryDetailDAO() { }

		public List<DeliveryDetailDTO> GetList()
		{
			string query = "select * from POFix,DeliveryNote,POInput, Part where POFix.IdDe = DeliveryNote.Id and IdPOInput = POInput.Id and IdPart = Part.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<DeliveryDetailDTO> lsv = new List<DeliveryDetailDTO>();
			foreach (DataRow item in data.Rows)
			{
				DeliveryDetailDTO DTO = new DeliveryDetailDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public List<DeliveryDetailDTO> GetList(long id)
		{
			string query = "select * from POFix,DeliveryNote,POInput, Part where POFix.IdDe = DeliveryNote.Id and IdPOInput = POInput.Id and IdPart = Part.Id and POFix.IdDe = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
			List<DeliveryDetailDTO> lsv = new List<DeliveryDetailDTO>();
			foreach (DataRow item in data.Rows)
			{
				DeliveryDetailDTO DTO = new DeliveryDetailDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public DeliveryDetailDTO GetItem(long id)
		{
			return GetList().Find(x => x.Id == id);
		}
	}
}
