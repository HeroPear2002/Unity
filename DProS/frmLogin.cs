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

namespace DProS
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        bool showPass = true;
        private void ptbHidePass_Click(object sender, EventArgs e)
        {
            if(showPass)
            {     
                txtPass.UseSystemPasswordChar = false;
                showPass = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                showPass = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            // Chưa lưu lại User đăng nhập
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}