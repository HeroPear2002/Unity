using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class MachineDAO
	{
		private static MachineDAO instance;

		public static MachineDAO Instance
		{
			get { if (instance == null) instance = new MachineDAO(); return instance; }
			set => instance = value;
		}
		public MachineDAO() { }
		public List<MachineDTO> GetList()
		{
			string query = "select * from Machine ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			List<MachineDTO> lsv = new List<MachineDTO>();
			foreach (DataRow item in data.Rows)
			{
				MachineDTO DTO = new MachineDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}

		public List<MachineDTO> GetList(int idDevice)
		{
			string query = "select * from Machine where IdDevice = @1 ";
			DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idDevice });
			List<MachineDTO> lsv = new List<MachineDTO>();
			foreach (DataRow item in data.Rows)
			{
				MachineDTO DTO = new MachineDTO(item);
				lsv.Add(DTO);
			}
			return lsv;
		}
		public MachineDTO GetItem(int Id)
		{
			return GetList().Find(x => x.Id == Id);
		}
		public MachineDTO GetItem(string code)
		{
			return GetList().Find(x => x.MachineCode == code);
		}
		public bool Insert(string machineCode, string machineName, string manufacturer, string serialNumber, DateTime dateInput, string codeAsset, string vender, DateTime dateProduct, int idDevice, DateTime dateMaker)
		{
			string query;
			int data;
			if (dateMaker == DateTime.MaxValue && dateProduct == DateTime.MaxValue)
			{
				query = "INSERT Machine (MachineCode ,MachineName, MachineInfor, Manufacturer, SerialNumber, DateInput, CodeAsset, Vender, DateProduct, IdDevice, StatusMachine, Note, DateMaker) VALUES ( @1 , @2 , NULL , @4 , @5 , @6 , @7 , @8 , NULL , @10 , NULL , NULL , NULL )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, idDevice });
			}
			else if (dateMaker == DateTime.MaxValue)
			{
				query = "INSERT Machine (MachineCode ,MachineName, MachineInfor, Manufacturer, SerialNumber, DateInput, CodeAsset, Vender, DateProduct, IdDevice, StatusMachine, Note, DateMaker) VALUES ( @1 , @2 , NULL , @4 , @5 , @6 , @7 , @8 , @9 , @10 , NULL , NULL , NULL )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, idDevice });
			}
			else if (dateProduct == DateTime.MaxValue)
			{
				query = "INSERT Machine (MachineCode ,MachineName, MachineInfor, Manufacturer, SerialNumber, DateInput, CodeAsset, Vender, DateProduct, IdDevice, StatusMachine, Note, DateMaker) VALUES ( @1 , @2 , NULL , @4 , @5 , @6 , @7 , @8 , NULL , @10 , NULL , NULL , @13 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, idDevice, dateMaker });
			}
			else
			{
				query = "INSERT Machine (MachineCode ,MachineName, MachineInfor, Manufacturer, SerialNumber, DateInput, CodeAsset, Vender, DateProduct, IdDevice, StatusMachine, Note, DateMaker) VALUES ( @1 , @2 , NULL , @4 , @5 , @6 , @7 , @8 , @9 , @10 , NULL , NULL , @13 )";
				data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, idDevice, dateMaker });
			}
			return data > 0;
		}
		public bool Update(int id, string machineCode, string machineName, string manufacturer, string serialNumber, DateTime dateInput, string codeAsset, string vender, DateTime dateProduct, DateTime dateMaker)
		{
			string query = "update Machine set MachineCode = @1 ,MachineName = @2 , Manufacturer = @3 , SerialNumber = @4 , DateInput = @5 , CodeAsset = @6 , Vender = @7 , DateProduct = @8 , DateMaker = @9  where Id = @10 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineCode, machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, dateMaker, id });
			return data > 0;
		}
		public bool Update(int id, int iddevice)
		{
			string query = "update Machine set IdDevice = @1  where Id = @2 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { iddevice, id });
			return data > 0;
		}
		public bool Update(int id, string machineCode)
		{
			string query = "update Machine set MachineCode = @1  where Id = @2 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineCode, id });
			return data > 0;
		}
		public bool UpdateStatusMachine(int id, int status)
		{
			string query = "update Machine set StatusMachine = @1  where Id = @2 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { status, id });
			return data > 0;
		}
		public bool Update(string machineCode, string machineName, string manufacturer, string serialNumber, DateTime dateInput, string codeAsset, string vender, DateTime dateProduct, DateTime dateMaker)
		{
			string query = "update Machine set MachineName = @1 , Manufacturer = @2 , SerialNumber = @3 , DateInput = @4 , CodeAsset = @5 , Vender = @6 , DateProduct = @7 , DateMaker = @8  where MachineCode = @9 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { machineName, manufacturer, serialNumber, dateInput, codeAsset, vender, dateProduct, dateMaker, machineCode });
			return data > 0;
		}
		public bool Delete(int id)
		{
			string query = "delete Machine where Id = @1 ";
			int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
			return data > 0;
		}
	}
}
