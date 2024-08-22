using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class POOutputDAO
	{
		private static POOutputDAO instance;

		public static POOutputDAO Instance
		{
			get { if (instance == null) instance = new POOutputDAO(); return instance; }
			set => instance = value;
		}
		public POOutputDAO() { }
		public List<POOutputDTO> GetList()
		{
			List<POOutputDTO> list = new List<POOutputDTO>();
			string query = "SELECT * FROM OutputPart,POInput,InputPart,WarehousePart,DeliveryNote WHERE IdPOInput = POInput.Id and IdInput = InputPart.Id and IdWareHouse = WarehousePart.Id and IdDe = DeliveryNote.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				POOutputDTO DTO = new POOutputDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public List<DateTime> GetListOnlyDateOut(long IdPOInput)
		{
			List<DateTime> listDt = new List<DateTime>();
			string query = "SELECT Distinct(DateOutput) FROM OutputPart WHERE IdPOInput = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdPOInput });
			foreach (DataRow item in data.Rows)
			{
				listDt.Add(DateTime.Parse(item.ToString()));
			}
			return listDt;
		}
		public int SumQuantityOut(long IdPOInput)
		{
			string query = "SELECT SUM(QuantityOut) FROM OutputPart WHERE IdPOInput = @1 ";
			object data = DataProvider.Instance.ExecuteScalar(query, new object[] { IdPOInput });
			if (data.ToString() != "") return int.Parse(data.ToString());
			else return 0;
		}
		public bool Insert(long idInput, DateTime dataOutput, int idEm, int quantityOut, string styleOutput, long idDe, long idPOInput, string note )
		{
			string query = "Insert OutputPart(IdInput,DateOutput,IdEm,QuantityOut,StyleOutput,IdDe,IdPOInput,Note) Values ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idInput, dataOutput, idEm, quantityOut, styleOutput, idDe, idPOInput, note });
			return data > 0;
		}
	}
}
