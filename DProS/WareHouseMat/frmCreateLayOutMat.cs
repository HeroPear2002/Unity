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

namespace DProS.WareHouseMat
{
    public partial class frmCreateLayOutMat : DevExpress.XtraEditors.XtraForm
    {
        public frmCreateLayOutMat()
        {
            InitializeComponent();
            LockControl(true);
            LoadMaxRow();
           
        }
       private void LoadMaxRow()
        {
            txtMaxRow.Text = WareHouseMatDAO.Instance.GetMaxRow().ToString();
        }

        private void LockControl(bool v)
        {
            if(v)
            {
                btnOpen.Enabled = true;
                txtMaxRow.Enabled = false;
                btnConfirm.Enabled = false;
               
            }
            else
            {
                btnOpen.Enabled = false;
                txtMaxRow.Enabled = true;
                btnConfirm.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int minint = int.Parse(txtMinValue.Text);
            int maxint = int.Parse(txtMaxValue.Text);
            if(txtNameRow.Text !="")
            {
                for (int i = minint; i <= maxint; i++)
                {
                    string name = txtNameRow.Text + "-" + i.ToString();
                    int check = WareHouseMatDAO.Instance.CheckNameExit(name);
                    if (check == 0)
                    {
                        int them = WareHouseMatDAO.Instance.Insert(name, 0, "", 0, "", int.Parse(txtMaxRow.Text), txtNameRow.Text, i);
                    }
                }
                this.Close();
            }
           else
            {
                MessageBox.Show("Bạn chưa đặt tên dãy.","THÔNG BÁO");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            LockControl(false);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            LockControl(true);
            int kt = WareHouseMatDAO.Instance.SetupMaxLayOut(int.Parse(txtMaxRow.Text));
            this.Close();
        }
    }
}