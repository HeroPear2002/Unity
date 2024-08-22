using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAO;
using DTO;

namespace DProS.Production_Manager
{
	public partial class frmApproveDelivery : DevExpress.XtraEditors.XtraForm
	{
		public frmApproveDelivery()
		{
			InitializeComponent();
		}
		int idem = Common.CommonStatic.IdEmStatic;
		private void btnApprove_Click(object sender, EventArgs e)
		{
			string _employess = EmployessDAO.Instance.GetItem(idem).EmCode;
			string barCode = txtBarCode.Text;
			if (barCode.Contains('&'))
			{
				List<DeliveryDetailDTO> listDE = new List<DeliveryDetailDTO>();
				string[] array = barCode.Split('&');
				long id = long.Parse(array[1]);
				DeliveryNoteDTO DTO = DeliveryNoteDAO.Instance.GetItem(id);
				if (DTO.Id == -1)
				{
					MessageBox.Show("Mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (DTO.StatusDe == 0 || DTO.StatusDe == 1)
				{
					MessageBox.Show("BBGH này chưa xuất hàng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (DTO.StatusDe == 4)
				{
					MessageBox.Show("BBGH này đã được giao\n\nbạn hãy kiểm tra lại!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				DeliveryNoteDAO.Instance.Update(id, DateTime.Now, _employess);
				DeliveryNoteDAO.Instance.Update(id, 4, "Đã giao");
				listDE = DeliveryDetailDAO.Instance.GetList(id);
				foreach (DeliveryDetailDTO item in listDE)
				{
					long idPOInput = POFixDAO.Instance.GetItem(item.Id).IdPOInput;
					POInputDTO pOInput= POInputDAO.Instance.GetItem(idPOInput);
					int sum = pOInput.QuantityOut;
					int quantityIn = pOInput.QuantityIn;
					POFixDAO.Instance.Update(item.Id, 3, "PO đã giao");
					POFixDAO.Instance.Update(item.Id, 3, item.QuantityOut);
					if ((sum + item.Quantity) <= quantityIn)
					{
						POInputDAO.Instance.Update(idPOInput, (sum + item.Quantity));
						if ((sum + item.Quantity) == quantityIn)
						{
							POInputDAO.Instance.UpdateStatusPO(idPOInput, 1);
						}
					}
				}
				MessageBox.Show("Xác nhận thành công!".ToUpper());
				txtBarCode.Text = string.Empty;
			}
			else
			{
				MessageBox.Show("Mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}