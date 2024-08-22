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

namespace DProS.Datasource
{
    public partial class frmListReason : DevExpress.XtraEditors.XtraForm
    {
        public frmListReason()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            LockControl(true);
            Clentext();
        }

        private void Clentext()
        {
            txtReason.Text = string.Empty;
            txtSupRoom.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtReason.Enabled = false;
                txtSupRoom.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
             
            }
            else
            {
                txtReason.Enabled = true;
                txtSupRoom.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
                
            }
        }
        void Save()
        {
            if (IsInsert)
            {
                string reason = txtReason.Text;
                string room = txtSupRoom.Text;

                int insert = ReasonDAO.Instance.Insert(reason, room);

            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string reason = txtReason.Text;
                string room = txtSupRoom.Text;

                int Update = ReasonDAO.Instance.Update(id,reason, room);

            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = ReasonDAO.Instance.Getlist();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsInsert = true;
            LockControl(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            LockControl(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "THÔNG BÁO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    try
                    {
                        int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        int del = ReasonDAO.Instance.Delete(id);
                    }
                    catch (Exception)
                    {

                    }
                }
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtReason.Text = gridView1.GetFocusedRowCellValue("ReasonDetail").ToString();
                txtSupRoom.Text= gridView1.GetFocusedRowCellValue("Note").ToString();
            }
            catch (Exception)
            {

               
            }
        }
    }
}