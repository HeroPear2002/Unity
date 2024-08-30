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


		#region MoldUsing: Quản lý quá trình vận hành của Khuôn

		public List<MoldUsingDTO> GetTableMoldUsing()
		{
			string query = "select * from MoldUsing,Mold WHERE IdMold = Mold.Id";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<MoldUsingDTO> list = new List<MoldUsingDTO>();
			foreach (DataRow item in data.Rows)
			{
				MoldUsingDTO m = new MoldUsingDTO(item);
				list.Add(m);
			}
			return list;
		}

		public List<MoldUsingDTO> GetTableMoldUsing1M()
		{
			string query = "select * from MoldUsing,Mold WHERE ((IdMold = Mold.Id) and (TotalShot>1000000))";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<MoldUsingDTO> list = new List<MoldUsingDTO>();
			foreach (DataRow item in data.Rows)
			{
				MoldUsingDTO m = new MoldUsingDTO(item);
				list.Add(m);
			}
			return list;
		}

		public int UpdateShotRealMoldUsing(int IdMoldUsing, int ShotReal)
		{
			string query = " update MoldUsing set ShotReality= @shotTT where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ShotReal, IdMoldUsing });
			return data;
		}

		public int UpdateWarnMoldUsing(int IdMoldUsing, int Warn)
		{
			string query = " update MoldUsing set Warn= @Warn where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Warn, IdMoldUsing });
			return data;
		}

		public int UpdateTotalShotMoldUsing(int IdMoldUsing, int TotalShot)
		{
			string query = " update MoldUsing set TotalShot= @shotTT where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { TotalShot, IdMoldUsing });
			return data;
		}

		public int UpdatePlanMoldUsing(int IdMoldUsing, string PlanMold)
		{
			string query = " update MoldUsing set PlanMold= @Plan where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { PlanMold, IdMoldUsing });
			return data;
		}

		public int UpdateCategoryMoldUsing(int IdMoldUsing, string Category)
		{
			string query = " update MoldUsing set Category= @Category where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Category, IdMoldUsing });
			return data;
		}

		public int UpdateConfirmMoldUsing(int IdMold, int Confirm)
		{
			string query = " update MoldUsing set ConfirmMold= @ConFirm where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Confirm, IdMold });
			return data;
		}

		//  MoldDAO.Instance.DeleteMoldConfirm(MoldCode);
		// Xóa trong bảng Confirm thì chưa thực hiện được.
		public bool DeleteMoldConfirm(string MoldCode)
		{
			string query = string.Format("DELETE dbo.MoldConfirm WHERE MoldCode = N'{0}'", MoldCode);
			int result = DataProvider.Instance.ExecuteNonQuery(query);
			return result > 0;
		}


		public int UpdateNoteMoldUsing(int IdMoldUsing, string Note)
		{
			string query = " update MoldUsing set Note= @Note where  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Note, IdMoldUsing });
			return data;
		}


		public MoldUsingDTO GetMoldUsingDTO(int IdMold)
		{
			string query = "select * from MoldUsing,Mold where IdMold=Mold.Id and IdMold = @id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMold });
			MoldUsingDTO a = new MoldUsingDTO(data.Rows[0]);
			return a;
		}

		public MoldUsingDTO GetMoldUsingDTObyCode(string MoldCode)
		{
			string query = "select * from MoldUsing,Mold where IdMold=Mold.Id and MoldCode= @moldCode ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MoldCode });
			MoldUsingDTO a = new MoldUsingDTO(data.Rows[0]);
			return a;
		}

		public bool CheckMoldUsingExist(int IdMoldUsing)
		{
			string query = "select * from MoldUsing where IdMold= @mold ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMoldUsing });
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


		public bool CheckMoldUsingExistByCode(string MoldCode)
		{
			string query = "select * from MoldUsing,Mold where IdMold=Mold.Id and IdMold= @mold ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MoldCode });
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

		// insert MoldUsing(IdMold, StatusMold, Cav, CavNG, ShotPlan, ShotReality, TotalShot, ConfirmMold, Category, DateCheck, PlanMold, Warn, Note)

		public int InsertMoldUsing(int IdMold, string StatusMold, int Cav, int CavNG, int ShotPlan, int ShotReality, int TotalShot, int ConfirmMold, string Category,
			string DateCheck, string PlanMold, int Warn, string Note)
		{
			string query = " insert MoldUsing(IdMold, StatusMold, Cav, CavNG, ShotPlan, ShotReality, TotalShot, ConfirmMold, Category, DateCheck, PlanMold, Warn, Note)" +
								" values( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 , @12 , @13 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdMold, StatusMold,Cav, CavNG,  ShotPlan,ShotReality,TotalShot,ConfirmMold, Category,
			DateCheck,  PlanMold,  Warn, Note});
			return data;
		}




		public int UpdateMoldUsing(int IdMold, string StatusMold, int Cav, int CavNG, int ShotPlan, int ShotReality, int TotalShot, int ConfirmMold, string Category,
			string DateCheck, string PlanMold, int Warn, string Note)
		{
			string query = "UPDATE MoldUsing set StatusMold= @1 , Cav= @2 , CavNG= @3 , ShotPlan= @4 , ShotReality= @5 , TotalShot= @6 , ConfirmMold= @7 , Category= @8 ," +
				" DateCheck= @9 , PlanMold= @10 , Warn= @11 , Note= @12 where IdMold= @13 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { StatusMold,Cav, CavNG,  ShotPlan,ShotReality,TotalShot,ConfirmMold, Category,
			DateCheck,  PlanMold,  Warn, Note, IdMold });
			return data;
		}

		// moldCode, shotTC, shotTT, totalShot, category, cav, 0
		public int UpdateMoldUsingQRcode(int IdMold, int ShotPlan, int ShotReality, int TotalShot, int ConfirmMold, string Category, int Cav)
		{
			string query = "UPDATE MoldUsing set ShotPlan= @4 , ShotReality= @5 , TotalShot= @6 , ConfirmMold= @7 , Category= @8 ,Cav= @9  where IdMold= @13 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query,
				new object[] { ShotPlan, ShotReality, TotalShot, ConfirmMold, Category, Cav, IdMold });
			return data;
		}

		public int DeleteMoldUsing(int IdMoldUsing)
		{
			string query = " DELETE MoldUsing WHERE  IdMold= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdMoldUsing });
			return data;
		}

		#endregion


		#region MoldError : Quản lý lỗi của Khuôn.

		// STATUS LỖI:  1-Show Lỗi , 2-Bộ Phận kiểm tra, 3-Hạng mục bảo dưỡng ( Bảo dưỡng không thay đổi số Shot Ghi chú 1, có thay đổi số Shot ghi chú NULL)


		public DataTable GetMoldError(int Status) // Lấy ra bảng Lỗi, bảng bộ phận kiểm tra hay bảng Hạng mục bảo dưỡng
		{
			string query = "SELECT * FROM MoldError WHERE Status = @status ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { Status });
			return data;
		}



		public List<MoldErrorDTO> GetListMoldError()
		{
			string query = " SELECT * FROM MoldError WHERE Status = 1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<MoldErrorDTO> Ls = new List<MoldErrorDTO>();
			foreach (DataRow item in data.Rows)
			{
				MoldErrorDTO a = new MoldErrorDTO(item);
				Ls.Add(a);
			}
			return Ls;
		}

		// LoadTribeMold

		public List<MoldErrorDTO> GetListMoldTribe()
		{
			string query = " SELECT * FROM MoldError WHERE Status = 2 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<MoldErrorDTO> Ls = new List<MoldErrorDTO>();
			foreach (DataRow item in data.Rows)
			{
				MoldErrorDTO a = new MoldErrorDTO(item);
				Ls.Add(a);
			}
			return Ls;
		}

		public List<MoldErrorDTO> GetListMoldCategory()
		{
			string query = " SELECT * FROM MoldError WHERE Status = 3 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<MoldErrorDTO> Ls = new List<MoldErrorDTO>();
			foreach (DataRow item in data.Rows)
			{
				MoldErrorDTO a = new MoldErrorDTO(item);
				Ls.Add(a);
			}
			return Ls;
		}




		public bool CheckErrorNameExist(string ErrorName, int Status)
		{
			string query = "select * from MoldError where Name= @Name and Status= @status ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ErrorName, Status });
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



		public MoldErrorDTO GetItemMoldErrorDTO(int Id)
		{
			string query = "SELECT * FROM MoldError WHERE Id = @id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { Id });
			MoldErrorDTO a = new MoldErrorDTO(data.Rows[0]);
			return a;
		}

		public MoldErrorDTO GetMoldErrorDTObyCode(string NameError)
		{
			string query = "SELECT * FROM MoldError WHERE Name = @name ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { NameError });
			MoldErrorDTO a = new MoldErrorDTO(data.Rows[0]);
			return a;
		}


		//  insert MoldError(Name, Status, Note)

		public int InsertMoldError(string Name, int Status, string Note)
		{
			string query = " insert MoldError(Name, Status, Note) values( @1 , @2 , @3 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Name, Status, Note });
			return data;
		}

		public int UpdateMoldError(int Id, string Name, string Note)
		{
			string query = "UPDATE MoldError set Name= @Name , Note= @note where Id= @id ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Name, Note, Id });
			return data;
		}

		public int DeleteMoldError(int Id)
		{
			string query = " DELETE MoldError WHERE  Id= @ID ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Id });
			return data;
		}



		#endregion


		#region Mold History: Lý lịch sửa chữa khuôn.


		public DataTable GetTableMoldHistory()
		{
			string query = "select * from MoldHistory";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			return data;
		}



		public List<MoldHistoryDTO> GetHistoryOfMold(int IdMold)
		{
			string query = "select * from MoldHistory,Machine WHERE ((IdMachine = Machine.Id) and (IdMold= @id ))";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMold });
			List<MoldHistoryDTO> Ls = new List<MoldHistoryDTO>();
			foreach (DataRow item in data.Rows)
			{
				MoldHistoryDTO a = new MoldHistoryDTO(item);
				Ls.Add(a);
			}
			return Ls;
		}

		public List<MoldDTO> GetLsMoldHistoryDTO()
		{
			string query = "select * from MoldHistory";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<int> LsIdMold = new List<int>();
			foreach (DataRow item in data.Rows)
			{
				MoldHistoryDTO a = new MoldHistoryDTO(item);
				if (!LsIdMold.Contains(a.IdMold))
				{
					LsIdMold.Add(a.IdMold);
				}

			}
			List<MoldDTO> LsMoldDTO = new List<MoldDTO>();
			foreach (int item1 in LsIdMold)
			{
				MoldDTO b = MoldDAO.instance.GetMoldDTO(item1);
				LsMoldDTO.Add(b);
			}
			return LsMoldDTO;
		}


		public MoldHistoryDTO GetMoldHistoryDTO(int IdHistory)
		{
			string query = "select * from MoldHistory where Id= @id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdHistory });
			MoldHistoryDTO a = new MoldHistoryDTO(data.Rows[0]);
			return a;
		}


		public bool CheckMoldHistoryExist(int IdMoldUsing)
		{
			string query = "select * from MoldUsing where IdMold= @mold ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMoldUsing });
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

		// insert MoldHistory(IdMachine,IdMold,DateError,CountShort,TotalShort,Category,Error,TribeError,Detail,DateStart,DateEnd,TotalTime,Detail1,Detail2,Detail3,Detail4,Detail5,Detail6)

		public int InsertMoldHistory(int IdMachine, int IdMold, DateTime DateError, int CountShort, int TotalShort, string Category, string Error, string TribeError, string Detail,
		   DateTime DateStart, DateTime DateEnd, int TotalTime, string Detail1, string Detail2, string Detail3, string Detail4, string Detail5, string Detail6)
		{
			string query = " insert MoldHistory(IdMachine,IdMold,DateError,CountShort,TotalShort,Category,Error,TribeError,Detail," +
											   "DateStart,DateEnd,TotalTime,Detail1,Detail2,Detail3,Detail4,Detail5,Detail6)" +
								   " values( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 , @12 , @13 , @14 , @15 , @16 , @17 , @18 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {IdMachine,IdMold,DateError,CountShort,TotalShort,Category,Error,TribeError,Detail,DateStart,DateEnd,TotalTime,Detail1
				,Detail2,Detail3,Detail4,Detail5,Detail6 });
			return data;
		}

		public int UpdateMoldHistory(int Id, int IdMachine, DateTime DateError, int CountShort, int TotalShort, string Category, string Error, string TribeError, string Detail,
		   DateTime DateStart, DateTime DateEnd, int TotalTime, string Detail1, string Detail2, string Detail3, string Detail4, string Detail5, string Detail6)
		{
			string query = "UPDATE MoldHistory set IdMachine= @1 ,DateError= @3 ,CountShort= @4 ,TotalShort= @5 ,Category= @6 ,Error= @7 ,TribeError= @8 ,Detail= @9 ," +
						   "DateStart= @10 ,DateEnd= @11 ,TotalTime= @12 ,Detail1= @13 ,Detail2= @14 ,Detail3= @15 ,Detail4= @16 ,Detail5= @17 ,Detail6= @18 where Id= @19 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {IdMachine,DateError,CountShort,TotalShort,Category,Error,TribeError,Detail,DateStart,DateEnd,TotalTime,Detail1
				,Detail2,Detail3,Detail4,Detail5,Detail6,Id });
			return data;
		}

		public int DeleteMoldHistory(int Id)
		{
			string query = " DELETE MoldHistory WHERE  Id= @Id ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Id });
			return data;
		}



		#endregion

		#region Xác nhận khuôn.


		// insert MoldConFirm(IdMold, IdEmPC, TimePC, IdEmQC, TimeQC, IdEmTool, TimeTool)


		public int InsertMoldConfirm(int IdMold, int IdEmPC, DateTime TimePC, int IdEmQC, DateTime TimeQC, int IdEmTool, DateTime TimeTool)
		{
			string query = "insert MoldConFirm(IdMold, IdEmPC, TimePC, IdEmQC, TimeQC, IdEmTool, TimeTool)" +
								" values( @1 , @2 , @3 , @4 , @5 , @6 , @7 )";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdMold, IdEmPC, TimePC, IdEmQC, TimeQC, IdEmTool, TimeTool });
			return data;
		}

		// Check khuôn có đang xác nhận hay không
		// Đang xác nhận thì Update.
		// Không đang xác nhận thì Insert.

		public bool CheckConfirming(int IdMold)
		{
			string query = " select * from MoldConFirm where IdMold= @mold and (IdEmPC=0 or IdEmQC=0 or IdEmTool=0 )";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMold });
			int Count = data.Rows.Count;
			if (Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		public MoldConFirmDTO GetConfirmingDTO(int IdMold)
		{
			string query = " select * from MoldConFirm where IdMold= @mold and (IdEmPC=0 or IdEmQC=0 or IdEmTool=0 )";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IdMold });
			MoldConFirmDTO a = new MoldConFirmDTO(data.Rows[0]);
			return a;
		}

		public MoldConFirmDTO GetConfirmingDTObyId(int Id)
		{
			string query = " select * from MoldConFirm where Id= @id ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { Id });
			MoldConFirmDTO a = new MoldConFirmDTO(data.Rows[0]);
			return a;
		}


		public int UpdateConFirmPC(int Id, int IdEmPC, DateTime TimePC)
		{
			string query = "Update MoldConFirm set IdEmPC= @idEm ,TimePC= @TimePC WHERE Id= @Id ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdEmPC, TimePC, Id });
			return data;
		}

		public int UpdateConFirmQC(int Id, int IdEmQC, DateTime TimeQC)
		{
			string query = "Update MoldConFirm set IdEmQC= @idEm ,TimeQC= @TimeQC WHERE Id= @Id ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdEmQC, TimeQC, Id });
			return data;
		}


		// insert MoldConFirm(IdMold, IdEmPC, TimePC, IdEmQC, TimeQC, IdEmTool, TimeTool)

		public int UpdateConFirmTool(int Id, int IdEmTool, DateTime TimeTool)
		{
			string query = "Update MoldConFirm set IdEmTool= @idEm ,TimeTool= @TimeTool WHERE Id= @Id ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IdEmTool, TimeTool, Id });
			return data;
		}



		#endregion
	}
}