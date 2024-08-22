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
using DTO;
using DAO;

namespace DProS.Production_Manager
{
	public partial class frmExportWareHousePart : DevExpress.XtraEditors.XtraForm
	{
		private Timer timer;
		public frmExportWareHousePart()
		{
			InitializeComponent();
			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			dtpkDateOut.Value = DateTime.Now;
		}
		int idem = Common.CommonStatic.IdEmStatic;
		private void btnSave_Click(object sender, EventArgs e)
		{
			string _employess = EmployessDAO.Instance.GetItem(idem).EmCode;
			string barCode = txtBarCode.Text;
			if (barCode.Contains('&'))
			{
				List<DeliveryDetailDTO> listDE = new List<DeliveryDetailDTO>();
				string[] array = barCode.Split('&');
				long id = long.Parse(array[1]);
				DeliveryNoteDTO DTO = DeliveryNoteDAO.Instance.GetItem(id);
				if (DTO == null || DTO.Id == -1)
				{
					MessageBox.Show("Mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if (DTO.StatusDe == 2 || DTO.StatusDe == 3)
				{
					MessageBox.Show("BBGH này đã được Xuất\n\nbạn hãy kiểm tra lại!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if (DTO.StatusDe == 4)
				{
					MessageBox.Show("BBGH này đã được giao\n\nbạn hãy kiểm tra lại!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{
					// Đoạn này đang xuất kho:
					int count = 0;
					listDE = DeliveryDetailDAO.Instance.GetList(id);
					foreach (DeliveryDetailDTO item in listDE)
					{
						long idPOInput = POInputDAO.Instance.GetItem(item.POCode).Id;
						bool update = POFixDAO.Instance.Update(item.Id, 2, item.Quantity);
						// Thay các trường phù hợp vào Insert để thêm vào OutputPart
						POOutputDAO.Instance.Insert(0, dtpkDateOut.Value, idem, item.Quantity, "", id, idPOInput,"");
						if (update)
						{
							POFixDAO.Instance.Update(item.Id, 2, "PO đã xuất");
							count++;
						}
					}
					if (listDE.Count == count)
					{
						DeliveryNoteDAO.Instance.UpdateOut(id, 2, "BB đã xuất", dtpkDateOut.Value, _employess);
						MessageBox.Show("Xuất kho thành công!".ToUpper());
						txtBarCode.Text = string.Empty;
					}
					else
					{
						DeliveryNoteDAO.Instance.UpdateOut(id, 1, "BB đang xuất", dtpkDateOut.Value, _employess);
						MessageBox.Show("Đang trong quá trình xuất kho!".ToUpper());
					}
				}
			}
			else
			{
				MessageBox.Show("Mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}