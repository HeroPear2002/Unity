using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAO;
using DTO;

namespace DProS.Mold_Manager
{
    public partial class frmHistoryMold : DevExpress.XtraEditors.XtraForm
    {
        public frmHistoryMold()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Insert;
        void LoadControl()
        {
            LoadMoldCode();
            LoadMachine();
            LoadMoldCategory();
            LoadMoldError();
            LoadMoldTribe();          
            LockControl(true);
            CleanText();
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        }

        void LoadMoldCode()
        {
            // Lọc ra danh sách khuôn có lý lịch sửa chữa
              List<MoldDTO> listM = MoldDAO.Instance.GetLsMoldHistoryDTO();         
            cbMoldCode.DataSource = listM;
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "Id";

           
        }


        void LoadData()
        {
            try
            {
                int IdMold = int.Parse(cbMoldCode.SelectedValue.ToString());

                // Lấy lịch sử của Khuôn đang chọn.
                 gcData.DataSource = MoldDAO.Instance.GetHistoryOfMold(IdMold);
            }
            catch
            {
            }

        }

        void LockControl(bool kt)
        {
            if(kt)
            {
                txtId.Enabled = false;
                cbMachine.Enabled = false;
                cbCategory.Enabled = false;
                cbErrorM.Enabled = false;
                cbTribeError.Enabled = false;
                txtDetail.Enabled = false;
                dtpDateStart.Enabled = false;
                dtpDateEnd.Enabled = false;
                dtpDateError.Enabled = false;
                txtTime.Enabled = false;
                txtDetail1.Enabled = false;
                txtDetail2.Enabled = false;
                txtDetail3.Enabled = false;
                txtDetail4.Enabled = false;
                txtDetail5.Enabled = false;
                txtDetail6.Enabled = false;

                btnEdit.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                cbMachine.Enabled = true;
                cbCategory.Enabled = true;
                cbErrorM.Enabled = true;
                cbTribeError.Enabled = true;
                txtDetail.Enabled = true;
                dtpDateStart.Enabled = true;
                dtpDateEnd.Enabled = true;
                dtpDateError.Enabled = true;
                txtTime.Enabled = true;
                txtDetail1.Enabled = true;
                txtDetail2.Enabled = true;
                txtDetail3.Enabled = true;
                txtDetail4.Enabled = true;
                txtDetail5.Enabled = true;
                txtDetail6.Enabled = true;

                btnEdit.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
        }
        void AddText()
        {
            try
            {
                txtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                cbMachine.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                cbCategory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Category"]).ToString();
                cbErrorM.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Error"]).ToString();
                cbTribeError.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TribeError"]).ToString();
                txtDetail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail"]).ToString();
                dtpDateStart.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateStart"]).ToString();
                dtpDateEnd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateEnd"]).ToString();
                dtpDateError.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateError"]).ToString();
                txtTime.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TotalTime"]).ToString();
                txtDetail1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail1"]).ToString();
                txtDetail2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail2"]).ToString();
                txtDetail3.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail3"]).ToString();
                txtDetail4.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail4"]).ToString();
                txtDetail5.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail5"]).ToString();
                txtDetail6.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail6"]).ToString();
            }
            catch
            {

            }

        }
        void CleanText()
        {
            txtId.Text = String.Empty;
          //  cbMachine.Text = String.Empty;
            cbCategory.Text = String.Empty;
            cbErrorM.Text = String.Empty;
            cbTribeError.Text = String.Empty;
            txtDetail.Text = String.Empty;
            dtpDateStart.Text = String.Empty;
            dtpDateEnd.Text = String.Empty;
            dtpDateError.Text = String.Empty;
            txtTime.Text = String.Empty;
            txtDetail1.Text = String.Empty;
            txtDetail2.Text = String.Empty;
            txtDetail3.Text = String.Empty;
            txtDetail4.Text = String.Empty;
            txtDetail5.Text = String.Empty;
            txtDetail6.Text = String.Empty;
        }

        void LoadMachine()
        {
            List<MachineDTO> listM = MachineDAO.Instance.GetList(1);
            cbMachine.DataSource = listM;
            cbMachine.DisplayMember = "MachineCode";
            cbMachine.ValueMember = "Id";
        }

        void LoadMoldError() 
        {
            cbErrorM.DataSource = MoldDAO.Instance.GetListMoldError();
            cbErrorM.DisplayMember = "Name";
            cbErrorM.ValueMember = "Id";
        }

        void LoadMoldCategory()
        {
            cbCategory.DataSource = MoldDAO.Instance.GetListMoldCategory(); 
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }


        void LoadMoldTribe()
        {
            cbTribeError.DataSource = MoldDAO.Instance.GetListMoldTribe() ;
            cbTribeError.DisplayMember = "Name";
            cbTribeError.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LockControl(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Xóa đi thì phải Update lại.
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int Id = int.Parse(txtId.Text);
            //string MachineCode = cbMachine.Text;
            //DateTime DateError = dtpkDateError.Value;
            //string Category = cbCategory.Text;
            //string Error = cbErrorM.Text;
            //string Tribe = cbTribe.Text;
            //string Detail = txtDetail.Text;
            //DateTime DateStart = dtpkDateStart.Value;
            //DateTime DateEnd = dtpkDateEnd.Value;
            //float totalTime = (float)Convert.ToDouble(nudTime.Text);
            //string Detail1 = txtDetail1.Text;
            //string Detail2 = txtDetail2.Text;
            //string Detail3 = txtDetail3.Text;
            //string Detail4 = txtDetail4.Text;
            //string Detail5 = txtDetail5.Text;
            //string Detail6 = txtDetail6.Text;
            //MoldDAO.Instance.UpdateHistoryMold(Id, MachineCode, DateError, Category, Error, Tribe, Detail, DateStart, DateEnd, totalTime, Detail1, Detail2, Detail3, Detail4, Detail5, Detail6);
            //int countShot = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountShort"]).ToString());  // Dựa vào lần lịch sử vừa xong.
            //int totalShot = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TotalShort"]).ToString()); 
            //MoldDAO.Instance.UpdateHistoryCountMold(Id, countShot, totalShot);
            //MessageBox.Show("sửa thông tin thành công !".ToUpper());
            //LoadControl();
        }

       
        private void gcData_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    ComboBox cb = sender as ComboBox;
            //    int id = int.Parse(cb.SelectedValue.ToString());
            //    LoadData(id);
            //}
            //catch (Exception)
            //{


            //}
            LoadData();
           
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }
    }
}