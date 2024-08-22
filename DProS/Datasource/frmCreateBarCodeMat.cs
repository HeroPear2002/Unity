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
using DProS.Datasource.Report;
using DevExpress.XtraReports.UI;

namespace DProS.Datasource
{
    public partial class frmCreateBarCodeMat : DevExpress.XtraEditors.XtraForm
    {
        public frmCreateBarCodeMat()
        {
            InitializeComponent();
            LoadControl();
        }

        private void LoadControl()
        {
            glMatCode.Properties.DataSource = MaterialDAO.Instance.Getlist();
            glMatCode.Properties.DisplayMember = "MatName";
            glMatCode.Properties.ValueMember = "MatCode";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string matcode = glMatCode.EditValue.ToString();
            string matname= glMatCode.Text.ToString();
            string weight = txtWeight.Text;
            rpCreateBarCodeMat f = new rpCreateBarCodeMat(matcode,matname,weight);
            f.ShowPreview();
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }
    }
}