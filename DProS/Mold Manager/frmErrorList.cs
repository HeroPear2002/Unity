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

namespace DProS.Mold_Manager
{
    public partial class frmErrorList : DevExpress.XtraEditors.XtraForm
    {
        public frmErrorList()
        {
            InitializeComponent();
           

        }
        public frmErrorList(List<string> lsv)
        {
            InitializeComponent();
            LoadControl(lsv);
        }
       
        private void LoadControl(List<string> lsv)
        {
            foreach  (string a in lsv)
            {
                listBox1.Items.Add(a);
            }
        }
    }
}