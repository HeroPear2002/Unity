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

namespace DProS.Datasource
{
    public partial class frmDryerList : DevExpress.XtraEditors.XtraForm
    {
        public frmDryerList()
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
            txtGhiChu.Text = string.Empty;
            txtMachineCode.Text = string.Empty;
            txtMachineName.Text = string.Empty;
            txtWeight.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtGhiChu.Enabled = false;
                txtMachineCode.Enabled = false;
                txtMachineName.Enabled = false;
                txtWeight.Enabled = false;


                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtGhiChu.Enabled = true;
                txtMachineCode.Enabled = true;
                txtMachineName.Enabled = true;
                txtWeight.Enabled = true;

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
                string note = txtGhiChu.Text;
                string MacCo = txtMachineCode.Text;
                string macNa = txtMachineName.Text;
                int weight = int.Parse(txtWeight.Text);
                int insert = MachineDryDAO.Instance.Insert(MacCo, macNa, weight, note);

            }
            else
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                string note = txtGhiChu.Text;
                string MacCo = txtMachineCode.Text;
                string macNa = txtMachineName.Text;
                int weight = int.Parse(txtWeight.Text);
                int Update = MachineDryDAO.Instance.Update(id, MacCo, macNa, weight, note);
            }
        }

        private void Loadata()
        {
            gridControl1.DataSource = MachineDryDAO.Instance.Getlist();
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
            if (MessageBox.Show("Bạn có chắc chắn sẽ xóa. ", "THÔNG BÁO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int del = MachineDryDAO.Instance.Delete(id);
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
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("Note").ToString();
                txtMachineCode.Text= gridView1.GetFocusedRowCellValue("DryCode").ToString();
                txtMachineName.Text= gridView1.GetFocusedRowCellValue("DryName").ToString();
                txtWeight.Text= gridView1.GetFocusedRowCellValue("WeightTray").ToString();
            }
            catch (Exception)
            {

               
            }
        }
    }
}