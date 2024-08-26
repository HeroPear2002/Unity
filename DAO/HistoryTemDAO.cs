using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class HistoryTemDAO
	{
		private static HistoryTemDAO instance;

		public static HistoryTemDAO Instance { get { if (instance == null) instance = new HistoryTemDAO(); return instance; } set => instance = value; }

		public HistoryTemDAO() { }

		public List<HistoryTemDTO> GetList()
		{
			string query = "SELECT * FROM HistoryTem, Part, Machine, Mold WHERE IdPart = Part.Id and IdMachine = Machine.Id and IdMold = Mold.Id";
			List<HistoryTemDTO> list = new List<HistoryTemDTO>();
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				HistoryTemDTO DTO = new HistoryTemDTO(item);
				list.Add(DTO);
			}
			return list;
		}
		public bool Insert(int idPart, int idMachine, int idMold, DateTime DatePrint, string EmCode, int NumberTo, int NumberFrom, DateTime Lot)
		{
			string query = string.Format("INSERT INTO dbo.HistoryTem (IdPart, IdMachine, IdMold,DatePrint,EmCode,NumberTo,NumberFrom,Lot) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 )");
			int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idPart, idMachine, idMold, DatePrint, EmCode, NumberTo, NumberFrom, Lot });
			return result > 0;
		}
	}
}
