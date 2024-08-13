using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
	public class MoldDAO
	{
		private static MoldDAO instance;

		public static MoldDAO Instance
		{
			get
			{
				if (instance == null) instance = new MoldDAO();
				return instance;
			}
			set => instance = value;
		}

		#region Mold: Thiết lập thông tin khuôn.


		public List<MoldDTO> GetListMold()
		{
			List<MoldDTO> listM = new List<MoldDTO>();
			DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Mold");
			foreach (DataRow item in data.Rows)
			{
				MoldDTO m = new MoldDTO(item);
				listM.Add(m);
			}
			return listM;
		}

		public MoldDTO GetMoldDTO(int IdMold)
		{
			string query = "select * from Mold where Id= @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMold });
			MoldDTO a = new MoldDTO(data.Rows[0]);
			return a;
		}

		public MoldDTO GetMoldDTO1(string MoldCode)
		{
			string query = "select * from Mold where MoldCode= @mold ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MoldCode });
			MoldDTO a = new MoldDTO(data.Rows[0]);
			return a;
		}

		public bool CheckMoldExist(string MaKhuon)
		{
			string query = "select * from Mold where MoldCode= @mold ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaKhuon });
			int dem = data.Rows.Count;
			if (dem > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		public int InsertMold(string MaKhuon, string TenKhuon, string ModelKhuon, string NhaSX, DateTime NgayNhan, string NoiNhap, string NgaySXLuotDau, string NguoiNhan, int SoShotBD, string SoKhuon, string ghichu)
		{
			string query = "insert Mold(MoldCode,MoldName,Model,Maker,DateInput,[Where],DateProduct,EmCode,ShotCount,NumberMold,Note)" +
								" values( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaKhuon, TenKhuon, ModelKhuon, NhaSX, NgayNhan, NoiNhap, NgaySXLuotDau, NguoiNhan, SoShotBD, SoKhuon, ghichu });
			return data;
		}

		public int UpdateMold(string MaKhuon, string TenKhuon, string ModelKhuon, string NhaSX, DateTime NgayNhan, string NoiNhap, string NgaySXLuotDau, string NguoiNhan, int SoShotBD, string SoKhuon, string ghichu)
		{
			string query = "UPDATE Mold SET MoldName= @1 ,Model= @2 ,Maker= @3 ,DateInput= @4 ,[Where]= @5 ,DateProduct= @6 ,EmCode= @7 ," +
				"ShotCount= @8 ,NumberMold= @9 ,Note= @10  WHERE MoldCode= @12 ";

			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {TenKhuon, ModelKhuon, NhaSX, NgayNhan, NoiNhap, NgaySXLuotDau, NguoiNhan, SoShotBD, SoKhuon,
				ghichu,MaKhuon});
			return data;

		}

		public int DeleteMold(int Id)
		{
			string query = " DELETE Mold WHERE Id= @Id ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Id });
			return data;
		}

		public int DeleteMoldCode(string MoldCode)
		{
			string query = " DELETE Mold WHERE MoldCode= @moldcode ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MoldCode });
			return data;
		}



		#endregion


	}
}
