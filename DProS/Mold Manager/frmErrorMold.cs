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

namespace DProS.Mold_Manager
{
    public partial class frmErrorMold : DevExpress.XtraEditors.XtraForm
    {
        public frmErrorMold()
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

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }


        private void LoadData()
        {
            gcData.DataSource = MoldDAO.Instance.GetMoldError(1); // 1: Lấy ra bảng Lỗi.
        }




        private void CleanText()
        {
            txtID.Clear();
            txtName.Clear();
           
        }


        void Save()
        {         
            string Name = txtName.Text.Trim();
            int Status = 1;  // 1: Là trạng thái Lỗi.
            string Note = "";          
            if (Insert)
            {
                bool Check = MoldDAO.Instance.CheckErrorNameExist(Name,Status);
                if (Check)
                {
                    MessageBox.Show($"Lỗi phát sinh ' {Name} '  đã tồn tại!", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MoldDAO.Instance.InsertMoldError(Name,Status,Note);
                    MessageBox.Show($"Đã thêm lỗi phát sinh ' {Name} '.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Insert = false;
            }
            else
            {
                int Id = int.Parse(txtID.Text.Trim());
                MoldDAO.Instance.UpdateMoldError(Id,Name, Note);
                MessageBox.Show($"Đã sửa thông tin lỗi phát sinh ' {Name} '.", "THÀNH CÔNG:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gcData_Click(object sender, EventArgs e)
        {
            try
            {                             
                txtID.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtName.Text = gridView1.GetFocusedRowCellValue("Name").ToString();               
            }
            catch
            {
            }
        }


        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
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
                int ID =int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
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
                MessageBox.Show("Chưa chọn lỗi để sửa hoặc chọn quá 1 lỗi.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
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
               
                DialogResult kq = MessageBox.Show($"Bạn muốn xóa {Count} lỗi phát sinh được chọn?", "THÔNG BÁO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    foreach (int item in LsErrorSelected)
                    {
                       MoldDAO.Instance.DeleteMoldError(item);                          
                    }                   
                    MessageBox.Show($"Đã xóa {Count} lỗi phát sinh được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                LoadControl();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn lỗi phát sinh để xóa.", "LỖI:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadControl();
        }
    }
}