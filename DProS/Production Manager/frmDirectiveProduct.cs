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
using DevExpress.XtraGrid.Views.Grid;
using DProS.Report;
using DevExpress.XtraReports.UI;

namespace DProS.Production_Manager
{
	public partial class frmDirectiveProduct : DevExpress.XtraEditors.XtraForm
	{
		List<TemInforDTO> listTem = new List<TemInforDTO>();
		public frmDirectiveProduct()
		{
			InitializeComponent();
			LoadControl();
		}

		public bool Insert;
		int id = 0;


		#region Control()
		void LoadControl()
		{
			Insert = false;
			LockControl(true);
			LoadPartCode();
			LoadDate();
			CleanText();
			gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
		}
		void LoadDate()
		{
			DateTime today = DateTime.Now;
			string thu = today.DayOfWeek.ToString();
			if (thu == "Saturday")
			{
				dtpkDateto.Value = today.AddDays(2);
			}
			else
			{
				dtpkDateto.Value = today.AddDays(1); // Hôm nay làm chỉ thị cho ngày mai
			}
		}
		
		void LoadDataMonth()
		{
			DateTime today = dtpkDateto.Value.Date;
			DateTime date1 = today.AddDays(1 - today.Day);
			DateTime date2 = date1.AddMonths(1).AddSeconds(-2);
			GCData.DataSource = DirectiveProductDAO.Instance.GetTable(date1, date2);
		}

		void LoadData()
		{
			GCData.DataSource = DirectiveProductDAO.Instance.GetTable();
		}

		void LockControl(bool kt)
		{
			if (kt)
			{
				cbPartCode.Enabled = false;
				cbMachine.Enabled = false;
				cbMoldCode.Enabled = false;
				nudQuantity.Enabled = false;
				dtpkDateto.Enabled = true;
				txtNoteSX.Enabled = false;
				txtNoteNL.Enabled = false;
				cbFactory.Enabled = false;
				btnAdd.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				cbPartCode.Enabled = true;
				cbMachine.Enabled = true;
				cbMoldCode.Enabled = true;
				nudQuantity.Enabled = true;
				dtpkDateto.Enabled = true;
				txtNoteSX.Enabled = true;
				txtNoteNL.Enabled = true;
				cbFactory.Enabled = true;
				btnAdd.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}
		void CleanText()
		{
			cbPartCode.Text = String.Empty;
			cbMachine.Text = String.Empty;
			cbMoldCode.Text = String.Empty;
			nudQuantity.Text = String.Empty;
			txtNoteSX.Text = String.Empty;
			txtNoteNL.Text = String.Empty;
		}
		void LoadPartCode()
		{
			listTem = TemInforDAO.Instance.GetList();
			cbPartCode.ValueMember = "IdPart";
			cbPartCode.DataSource = listTem;
			cbPartCode.DisplayMember = "PartCode";
		}
		#endregion

		private void btnSave_Click(object sender, EventArgs e)
		{
			DateTime date = dtpkDateto.Value;
			int IdPart = (int)cbPartCode.SelectedValue;
			int quantity = (int)nudQuantity.Value;
			int IdMachine = (int)cbMachine.SelectedValue;
			int IdMold = (int)cbMoldCode.SelectedValue;
			string NoteSx = txtNoteSX.Text;
			string NoteNl = txtNoteNL.Text;
			string facCode = cbFactory.Text;
			PartDTO part = PartDAO.Instance.GetItem(IdPart);
			float weight = part.WeightPart;
			float weightrunner = part.WeightRunner;
			MoldUsingDTO mold = MoldDAO.Instance.GetMoldUsingDTO(IdMold);

			int confirm = mold.ConfirmMold;
			float shotTT = mold.ShotReality;
			float shotTC = mold.ShotPlan;
			int shot = quantity / part.Cav;
			float test = (float)(shotTT + shot) / shotTC;
			string MaterialCode = part.MatCode;
			
			string StylePart = part.StylePart;
			TemInforDTO testM = TemInforDAO.Instance.GetItem(IdPart, IdMachine, IdMold);
			string MaterialName = part.MatName;
			float percent = PartInforDAO.Instance.GetItemPart(IdPart).Percentage;
			int TotalWeight = (int)Math.Ceiling((quantity * (weight + weightrunner) + (percent * quantity * (weight + weightrunner)) / 100) / 1000);

			if (FactoryDAO.Instance.GetItemFac(facCode) == null)
			{
				MessageBox.Show("mã nhà máy không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (testM == null)
			{
				MessageBox.Show("bạn chưa Setup thông tin Mac sản phẩm !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (test > 1)
			{
				MessageBox.Show("Khuôn không được phép sản xuất vì quá số shot bảo dưỡng!".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (Insert == true)
			{
				if (confirm == 3 || confirm == -5)
				{
					MessageBox.Show("khuôn không được phép sản xuất vì chưa bảo dưỡng! hoặc đăng bị Block".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (StylePart.Length < 6)
				{
					MessageBox.Show("linh kiện chưa được phê duyệt ! \n\nbạn hãy liên lạc với cấp trên".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					DirectiveProductDAO.Instance.Insert(date, IdPart, quantity, IdMachine, IdMold, NoteSx, NoteNl, facCode, TotalWeight, 0, 0," ");
					EditHistoryDAO.Instance.Insert(DateTime.Now, "UserName O Day", "Chỉ thị sản xuất với mã nguyên liệu : " + MaterialCode, "");
					MessageBox.Show("thêm thông tin thành công!".ToUpper());
					LoadControl();
				}
			}
			else
			{
				long Id = long.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
				DirectiveProductDAO.Instance.Update(Id, date, IdPart, quantity, IdMachine, IdMold, NoteSx, NoteNl, facCode, TotalWeight, 0, 0, "");
				EditHistoryDAO.Instance.Insert(DateTime.Now, "UserName O Day", "Chỉ thị sản xuất với mã nguyên liệu : " + MaterialCode, "");
				MessageBox.Show("sửa thông tin thành công!".ToUpper());
				LoadControl();
			}

		}

		private void cbPartCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			int IdPart = (int)cbPartCode.SelectedValue;
			listTem = listTem.Where(x => x.IdPart == IdPart).ToList();
			cbMoldCode.ValueMember = "IdMold";
			cbMoldCode.DataSource = listTem;
			cbMoldCode.DisplayMember = "MoldCode";
		}

		private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			int IdMold = (int)cbMoldCode.SelectedValue;
			listTem = listTem.Where(x => x.IdMold == IdMold).ToList();
			cbMachine.ValueMember = "IdMachine";
			cbMachine.DataSource = listTem;
			cbMachine.DisplayMember = "MachineCode";
			
		}

		private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
		{
			int IdMachine = (int)cbMachine.SelectedValue;
			listTem = listTem.Where(x => x.IdMachine == IdMachine).ToList();
			cbFactory.ValueMember = "FacCode";
			cbFactory.DataSource = listTem;
			cbFactory.DisplayMember = "FacCode";
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			LockControl(false);
			Insert = true;
		}
		private void btnEdit_Click(object sender, EventArgs e)
		{
			Insert = false;
			LockControl(false);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gridView1.GetSelectedRows())
				{
					long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
					int delete = DirectiveProductDAO.Instance.Delete(id);
					if (delete > 0) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void btnPrinter_Click(object sender, EventArgs e)
		{
			//Làm report

			List<ReportCTSX> listC = new List<ReportCTSX>();
			string Employess = "";
			string statusMold = "OK";

			// string account = Kun_Static.accountDTO.DisplayName;
			//string[] array = account.Split(' ');
			//if (array.Count() > 0)
			//{
			//	Employess = array[array.Count() - 1];
			//}
			//else
			//{
			//	Employess = account;
			//}

			foreach (var item in gridView1.GetSelectedRows())
			{
				DateTime date = DateTime.Parse(gridView1.GetRowCellValue(item, "DateInput").ToString());
				string MachineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
				string MoldNumber = gridView1.GetRowCellValue(item, "NumberMold").ToString();
				string PartCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
				string FactoryCode = gridView1.GetRowCellValue(item, "FactoryCode").ToString();
				int quantity = int.Parse(gridView1.GetRowCellValue(item, "Quantity").ToString());
				long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
				string moldCode = gridView1.GetRowCellValue(item, "MoldCode").ToString();
				int totalShot = MoldDAO.Instance.GetMoldUsingDTObyCode(moldCode).TotalShot;

				if (totalShot > 1000000)
				{
					statusMold = "OVER SHOT";
				}
				else
				{
					statusMold = "OK";
				}
				string noteSX = " ";
				string noteNL = " ";
				try
				{
					noteSX = gridView1.GetRowCellValue(item, "NoteSX").ToString();
					noteNL = gridView1.GetRowCellValue(item, "NoteNL").ToString();
				}
				catch
				{

				}
				PartDTO part = PartDAO.Instance.GetItemByPartCode(PartCode);
				
				MoldUsingDTO mold = MoldDAO.Instance.GetMoldUsingDTObyCode(moldCode);

				int confirm = mold.ConfirmMold;
				float shotTT = mold.ShotReality;
				float shotTC = mold.ShotPlan;
				int shot = quantity / part.Cav;
				float test = (float)(shotTT + shot) / shotTC;
				string MaterialCode = part.MatCode;

				string StylePart = part.StylePart;
				string MaterialName = part.MatName;
				float percent = PartInforDAO.Instance.GetItemPart(PartCode).Percentage;
				string PartName = part.PartName; // Lấy từ bảng linh kiện.

				string customer = part.CusCode;
				
				float quantityPart = part.CountPart;  // Lấy từ bảng linh kiện.

				float quantityBox = part.CountBox; // Lấy từ bảng linh kiện.

				int CountBox = (int)Math.Ceiling(quantity / quantityPart);

				int Cav = part.Cav;
				float CycleTime = part.CycleTime;
				float hour = (float)Math.Ceiling(((quantity * CycleTime) / Cav) / 3600);
				int idMat = MaterialDAO.Instance.GetItem(MaterialCode).Id;
				string weightMin = MaterialBeginDAO.Instance.GetItemMat(idMat).WeightMin; // Bảng nguyên liệu
				string timeMin = MaterialBeginDAO.Instance.GetItemMat(idMat).TimeMin;
				float weight = part.WeightPart;
				float weightrunner = part.WeightRunner;
				int TotalWeight = (int)Math.Ceiling((quantity * (weight + weightrunner) + (percent * quantity * (weight + weightrunner)) / 100) / 1000);
				string barCode = MaterialCode + "&" + PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + CountBox + "&" + FactoryCode + "&" + id;

				listC.Add(new ReportCTSX(PartCode, PartName, MaterialCode, MaterialName, MoldNumber, MachineCode, (int)quantity, (int)quantityPart, CountBox, hour, date, TotalWeight, Employess, barCode.ToUpper(), "Ghi chú : " + noteSX, "Ghi chú : " + noteNL, customer, statusMold, timeMin, weightMin));
			}

			rpDirectiveProduct report = new rpDirectiveProduct();
			report.DataSource = listC;
			report.Print();
			LoadControl();

		}



		private void btnMonth_Click_1(object sender, EventArgs e)
		{
			LoadDataMonth();
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnLock_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn khóa chỉ thị sản xuất này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gridView1.GetSelectedRows())
				{
					long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
					DirectiveProductDAO.Instance.UpdateStatusCTSX(id, 2, "");
				}
				LoadData();
			}
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn xác nhận chỉ thị sản xuất này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gridView1.GetSelectedRows())
				{
					long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
					DirectiveProductDAO.Instance.UpdateStatusCTSX(id, 0, "");
				}
				LoadData();
			}

		}

		private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.RowHandle >= 0)
			{
				int statusCheck = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Status"]).ToString());
				if (statusCheck == 1)
				{
					e.Appearance.BackColor = Color.Yellow;
				}
				else if (statusCheck == 2)
				{
					e.Appearance.BackColor = Color.Orange;
				}
			}
		}

		private void gridView1_Click(object sender, EventArgs e)
		{
			try
			{
				cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
				cbMachine.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
				cbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
				nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Quantity"]).ToString();
				dtpkDateto.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
				txtNoteSX.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NoteSX"]).ToString();
				txtNoteNL.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NoteNL"]).ToString();
				cbFactory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCode"]).ToString();
			}
			catch
			{
			}
		}
	}
}