using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAO;
using DTO;

namespace DProS.Production_Manager
{
	public partial class rpDeliveryNote : DevExpress.XtraReports.UI.XtraReport
	{
		long IdDe;
		public rpDeliveryNote()
		{
			InitializeComponent();
			LoadData();
			LoadControl();
		}
		public rpDeliveryNote(long idDe)
		{
			InitializeComponent();
			IdDe = idDe;
			LoadData();
			LoadControl();
		}
		public void LoadData()
		{
			LoadTable();
			LoadCompany();
		}
		POFixDTO pOFixDTO = null;
		FactoryDTO factoryDTO = null;
		void LoadControl()
		{
			//txtTotalBox.Text = Kun_Static.TotalBox.ToString();
		}
		void LoadCompany()
		{
			long idDe = IdDe;
			pOFixDTO = POFixDAO.Instance.GetItemDe(idDe);
			string factCode = pOFixDTO.FacCode;
			long idInput = pOFixDTO.IdPOInput;
			string customer = POInputDAO.Instance.GetItem(idInput).CusCode;
			string cusName = CustomerDAO.Instance.GetItem(customer).CusName;
			factoryDTO = FactoryDAO.Instance.GetItem(factCode, customer);
			string nameVN = factoryDTO.NameBillVN;
			string nameENG = factoryDTO.NameBillEN;
			string address = factoryDTO.Address;
			string phone = factoryDTO.Phone;
			string fax = factoryDTO.Fax;
			txtAddress.Text = factoryDTO.Address;
			txtNameBillVN.Text = nameVN;
			txtNameENG.Text = nameENG;
			txtNameCustomer.Text = cusName;
		}
		void LoadTable()
		{
			txtAutoNumber.DataBindings.Add("Text", DataSource, "Id");
			txtBarCode.DataBindings.Add("Text", DataSource, "DeCode");
			txtQrcode.DataBindings.Add("Text", DataSource, "DeCode");
			txtFactory.DataBindings.Add("Text", DataSource, "Factory");
			txtDateOut.DataBindings.Add("Text", DataSource, "DateOut");
			txtTime.DataBindings.Add("Text", DataSource, "Time");
			txtCarNumber.DataBindings.Add("Text", DataSource, "CarNumber");
			txtPOCode.DataBindings.Add("Text", DataSource, "POCode");
			txtQuantity.DataBindings.Add("Text", DataSource, "Quantity");
			txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
			txtPartName.DataBindings.Add("Text", DataSource, "PartName");
			txtCountPart.DataBindings.Add("Text", DataSource, "CountPart");
			txtCountBox.DataBindings.Add("Text", DataSource, "CountBox");
			txtPartName.DataBindings.Add("Text", DataSource, "PartName");
		}
	}
}
