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
    public partial class frmEmployess : DevExpress.XtraEditors.XtraForm
    {
        public frmEmployess()
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

        private void Loadata()
        {
            gridControl1.DataSource = EmployessDAO.Instance.Getlist();
            
        }

        private void Clentext()
        {
            txtEmCode.Text = string.Empty;
            txtEmName.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtRoomCode.Text = string.Empty;
            dtpDateInput.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtRoomCode.Enabled = false;
                txtNote.Enabled = false;
                txtEmName.Enabled = false;
                txtEmCode.Enabled = false;
                dtpDateInput.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtRoomCode.Enabled = true;
                txtNote.Enabled = true;
                txtEmName.Enabled = true;
                txtEmCode.Enabled = true;
                dtpDateInput.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        void Save()
        {
            if(IsInsert)
            {
                string emcode = txtEmCode.Text;
                string emname = txtEmName.Text;
                string roomcode = txtRoomCode.Text;
                DateTime date = dtpDateInput.Value;
                string note = txtNote.Text;
                int insert = EmployessDAO.Instance.Insert(emcode, emname, roomcode, date, note);
            }
            else
            {
                try
                {
                    int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                    string emcode = txtEmCode.Text;
                    string emname = txtEmName.Text;
                    string roomcode = txtRoomCode.Text;
                    DateTime date = dtpDateInput.Value;
                    string note = txtNote.Text;
                    int update = EmployessDAO.Instance.Update(id,emcode, emname, roomcode, date, note);
                }
                catch (Exception)
                {

                }
               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsInsert = true;
            LockControl(false);
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LockControl(false);
            IsInsert = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int del = EmployessDAO.Instance.Delete(id);
                }
                LoadControl();
            }
            catch (Exception)
            {               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmCode.Text =gridView1.GetFocusedRowCellValue("EmCode").ToString();
                txtEmName.Text = gridView1.GetFocusedRowCellValue("EmName").ToString();
                txtNote.Text = gridView1.GetFocusedRowCellValue("Note").ToString();
                txtRoomCode.Text = gridView1.GetFocusedRowCellValue("RoomCode").ToString();
                dtpDateInput.Value = DateTime.Parse(gridView1.GetFocusedRowCellValue("DateInput").ToString());
            }
            catch (Exception)
            {

               
            }
        }
    }
}