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

namespace DProS.Mold_Manager
{
    public partial class frmCategoryMold : DevExpress.XtraEditors.XtraForm
    {
        public frmCategoryMold()
        {
            InitializeComponent();
            LoadControl();
        }

        bool Insert;
        private void LoadControl()
        {
            Insert = false;
            LoadData();
            LockControl(true);
            CleanText();
        }


        private void LockControl(bool kt)
        {
            if (kt)
            {
                txtID.Enabled = false;
                txtName.Enabled = false;
                chkNoChangeShot.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
            }
            else
            {
                txtID.Enabled = false;
                txtName.Enabled = true;
                chkNoChangeShot.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }


        private void LoadData()
        {
            gcData.DataSource = MoldDAO.Instance.GetMoldError(3); // 3: Hạng mục bảo dưỡng
        }

        private void CleanText()
        {
            txtID.Clear();
            txtName.Clear();
            chkNoChangeShot.Checked = false;
        }

        void Save()
        {
            string Name = txtName.Text.Trim();
            int Status = 3;  // 3: Hạng mục bảo dưỡng
            string Note = "";
            if (chkNoChangeShot.Checked == true)
            {
                Note = "1";
            }
            
            if (Insert)
            {
                bool Check = MoldDAO.Instance.CheckErrorNameExist(Name, Status);
                if (Check)
                {
                    MessageBox.Show($"Hạng mục bảo dưỡng: ' {Name} ' đã tồn tại!", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MoldDAO.Instance.InsertMoldError(Name, Status, Note);
                    MessageBox.Show($"Hạng mục bảo dưỡng: ' {Name} '.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Insert = false;
            }
            else
            {
                int Id = int.Parse(txtID.Text.Trim());
                MoldDAO.Instance.UpdateMoldError(Id, Name, Note);
                MessageBox.Show($"Đã sửa thông tin hạng mục : ' {Name} '.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gcData_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"]).ToString();
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                if (a == "1")
                {
                    chkNoChangeShot.Checked = true;
                }
                else
                {
                    chkNoChangeShot.Checked = false;
                }
            }
            catch
            {
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LockControl(false);
            Insert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int Count = 0;

            List<int> LsErrorSelected = new List<int>();

            foreach (var item in gridView1.GetSelectedRows())
            {
                int ID = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                LsErrorSelected.Add(ID);
                Count++;
            }

            if (Count == 1)
            {
                LockControl(false);
                txtID.Enabled = false;
            }
            else
            {
                MessageBox.Show("Chưa chọn bộ phận để sửa hoặc chọn quá 1 lỗi.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LockControl(false);

            int Count = 0;

            List<int> LsErrorSelected = new List<int>();

            foreach (var item in gridView1.GetSelectedRows())
            {
                int ID = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                LsErrorSelected.Add(ID);
                Count++;
            }

            if (Count > 0)
            {

                DialogResult kq = MessageBox.Show($"Bạn muốn xóa {Count} hạng mục được chọn?", "THÔNG BÁO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    foreach (int item in LsErrorSelected)
                    {
                        MoldDAO.Instance.DeleteMoldError(item);
                    }
                    MessageBox.Show($"Đã xóa {Count} hạng mục được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hạng mục để xóa.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadControl();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            try
            {
                GridView view = sender as GridView;
                string Note = view.GetRowCellValue(e.RowHandle, view.Columns["Note"]).ToString();

                if (Note =="1")
                {
                    e.Appearance.BackColor = chkNoChange.BackColor;
                }

            }
            catch
            {


            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }
    }
}