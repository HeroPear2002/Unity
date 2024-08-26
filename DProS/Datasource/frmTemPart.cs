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
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace DProS.Datasource
{
    public partial class frmTemPart : DevExpress.XtraEditors.XtraForm
    {
        public frmTemPart()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            LockControl(true);
            Loadgl();
            Clentext();
        }

        private void Loadgl()
        {
            glPartCode.Properties.DataSource = PartDAO.Instance.Getlist();
            glPartCode.Properties.DisplayMember = "PartCode";
            glPartCode.Properties.ValueMember = "Id";

            glFacCode.Properties.DataSource = FactoryDAO.Instance.GetListFac();
            glFacCode.Properties.DisplayMember = "FacCode";
            glFacCode.Properties.ValueMember = "Id";
			
            glMachineCode.Properties.DataSource = MachineDAO.Instance.GetList().Where(x => x.IdDevice == 1).ToList();
            glMachineCode.Properties.DisplayMember = "MachineCode";
            glMachineCode.Properties.ValueMember = "Id";

			glMoldCode.Properties.DataSource = MoldDAO.Instance.GetListMold();
            glMoldCode.Properties.DisplayMember = "MoldCode";
            glMoldCode.Properties.ValueMember = "Id";


        }

        private void Clentext()
        {
            txtDesighCode.Text = string.Empty;
            ckb4m.CheckState = CheckState.Unchecked;
            glMoldCode.Text = string.Empty;
            glMachineCode.Text = string.Empty;
            glFacCode.Text = string.Empty;
            glPartCode.Text = string.Empty;

        }
		void AddText()
		{
			try
			{
				int id = int.Parse(gvTemInfor.GetRowCellValue(gvTemInfor.FocusedRowHandle, gvTemInfor.Columns["Id"]).ToString());
				TemInforDTO DTO = TemInforDAO.Instance.GetItem(id);
				glPartCode.EditValue = DTO.IdPart;
				glMachineCode.EditValue = DTO.IdMachine;
				glMoldCode.EditValue = DTO.IdMold;
				glFacCode.EditValue = FactoryDAO.Instance.GetList().FirstOrDefault(x => x.FacCode == DTO.FacCode).Id;
				txtDesighCode.Text = gvTemInfor.GetRowCellValue(gvTemInfor.FocusedRowHandle, gvTemInfor.Columns["Rev"]).ToString();
				string a = gvTemInfor.GetRowCellValue(gvTemInfor.FocusedRowHandle, gvTemInfor.Columns["Standard"]).ToString();
				if (a == "OK")
				{
					ckb4m.Checked = true;
				}
				else
				{
					ckb4m.Checked = false;
				}
			}
			catch
			{

			}
		}
		private void LockControl(bool v)
        {
            if (v)
            {
                txtDesighCode.Enabled = false;
                ckb4m.Enabled = false;
                glMoldCode.Enabled = false;
                glMachineCode.Enabled = false;
                glFacCode.Enabled = false;
                glPartCode.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;

                btnImpExcel.Enabled = true;
                btnExpExcel.Enabled = true;
                btnFormExcel.Enabled = true;
                btnRemoveCavi.Enabled = true;
                btnTemPrint.Enabled = true;
                btnTemPrintNew.Enabled = true;
                btnTemTemMa.Enabled = true;
                btnTemTKG.Enabled = true;

            }
            else
            {
                txtDesighCode.Enabled = true;
                ckb4m.Enabled = true;
                glMoldCode.Enabled = true;
                glMachineCode.Enabled = true;
                glFacCode.Enabled = true;
                glPartCode.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;

                btnImpExcel.Enabled = false;
                btnExpExcel.Enabled = false;
                btnFormExcel.Enabled = false;
                btnRemoveCavi.Enabled = true;
                btnTemPrint.Enabled = false;
                btnTemPrintNew.Enabled = false;
                btnTemTemMa.Enabled =false;
                btnTemTKG.Enabled = false;
            }
        }
        void Save()
        {
			int idPart = int.Parse(glPartCode.EditValue.ToString());
			int idMachine = int.Parse(glMachineCode.EditValue.ToString());
			string Rev = txtDesighCode.Text;
			int idMold = int.Parse(glMoldCode.EditValue.ToString());
			string factoryCode = glFacCode.Text;
			string standard = "NOT";
			if (ckb4m.Checked == true)
			{
				standard = "OK";
			}
			//string stylePart = PartDAO.Instance.GetItem(idPart).;
			if (IsInsert == true)
			{
				//if (stylePart.Length < 6)
				//{
				//	MessageBox.Show("linh kiện chưa được phê duyệt ! \n\nbạn hãy liên lạc với cấp trên".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//}
				//else
				//{
					TemInforDTO test = TemInforDAO.Instance.GetItem(idPart, idMachine, idMold);
					if (test == null)
					{
						TemInforDAO.Instance.Insert(idPart, idMachine, idMold, Rev, factoryCode, standard);
						MessageBox.Show("thêm thông tin thành công !".ToUpper());
						LoadControl();
					}
				//}

			}
			else
			{
				int id = int.Parse(gvTemInfor.GetRowCellValue(gvTemInfor.FocusedRowHandle, gvTemInfor.Columns["Id"]).ToString());
				TemInforDAO.Instance.Update(id, idPart, idMachine, idMold, Rev, factoryCode, standard);
				MessageBox.Show("sửa thông tin thành công !".ToUpper());
				LoadControl();
			}
		}

        private void Loadata()
        {
            gcTemInfor.DataSource =TemInforDAO.Instance.GetList();
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
			Save();
			LoadControl();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = true;
			Clentext();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			LockControl(false);
			IsInsert = false;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvTemInfor.GetSelectedRows())
				{
					int id = int.Parse(gvTemInfor.GetRowCellValue(item, "Id").ToString());
					POFixDAO.Instance.DeleteWherePOInput(id);
					int delete = TemInforDAO.Instance.Delete(id);
					if (delete > 0) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void btnExpExcel_Click(object sender, EventArgs e)
		{
			GridView view = gcTemInfor.FocusedView as GridView;
			if (view == null) return;
			view.OptionsSelection.EnableAppearanceHideSelection = false;
			view.BestFitColumns();
			ExportWithSaveFileDialog(view, exportSelected: false, exportFiltered: true);
			LoadControl();
		}
		private void ExportWithSaveFileDialog(GridView view, bool exportSelected, bool exportFiltered)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", Title = "Export File" })
			{
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;
					string extension = System.IO.Path.GetExtension(filePath);

					XlsxExportOptionsEx options = new XlsxExportOptionsEx
					{
						ExportType = ExportType.WYSIWYG
					};
					bool hasSelectedRows = view.GetSelectedRows().Length > 0;
					if (hasSelectedRows) view.OptionsPrint.PrintSelectedRowsOnly = true;
					else
					{
						view.OptionsPrint.PrintSelectedRowsOnly = false;
						view.OptionsPrint.PrintFilterInfo = false;
					}
					view.ExportToXlsx(filePath, options);
					MessageBox.Show("Export successful!".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void btnTemPrint_Click(object sender, EventArgs e)
		{
			frmTemPrint from = new frmTemPrint();
			from.ShowDialog();
		}

		private void btnTemPrintNew_Click(object sender, EventArgs e)
		{
			frmTemPrintNew from = new frmTemPrintNew();
			from.ShowDialog();
		}

		private void btnTemTKG_Click(object sender, EventArgs e)
		{
			frmTemTKG from = new frmTemTKG();
			from.ShowDialog();
		}

		private void btnTemTemMa_Click(object sender, EventArgs e)
		{
			frmTemTemMaPrint from = new frmTemTemMaPrint();
			from.ShowDialog();
		}

		private void btnRemoveCavi_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("bạn muốn thay đổi thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gvTemInfor.GetSelectedRows())
				{
					string partCode = gvTemInfor.GetRowCellValue(item, "PartCode").ToString();
					int idPart = PartDAO.Instance.GetItem(partCode).Id;
					TemInforDAO.Instance.UpdateImport(idPart, 0);
				}
				LoadControl();
			}
		}

		private void btnDivCavi_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("linh kiện này sẽ phải thêm số CAV khi in mác !".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in gvTemInfor.GetSelectedRows())
				{
					string partCode = gvTemInfor.GetRowCellValue(item, "PartCode").ToString();
					int idPart = PartDAO.Instance.GetItem(partCode).Id;
					TemInforDAO.Instance.UpdateImport(idPart, 1);
				}
				LoadControl();
			}
		}

		private void btnFormExcel_Click(object sender, EventArgs e)
		{
			frmTemPartSampleForm form = new frmTemPartSampleForm();
			form.ShowDialog();
			LoadControl();
		}

		private void btnImpExcel_Click(object sender, EventArgs e)
		{
			frmTemPartImportFile form = new frmTemPartImportFile();
			form.ShowDialog();
			LoadControl();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void gvTemInfor_Click(object sender, EventArgs e)
		{
			AddText();
		}

		private void gvTemInfor_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
			{

				string PartCode = view.GetRowCellValue(e.RowHandle, view.Columns["PartCode"]).ToString();
				int idPart = PartDAO.Instance.GetItemByPartCode(PartCode).Id;
				int akun = TemInforDAO.Instance.ImportantMac(idPart);
				if (akun == 1)
				{
					e.Appearance.BackColor = Color.Orange;
					e.Appearance.ForeColor = Color.White;
				}

			}
		}
	}
}