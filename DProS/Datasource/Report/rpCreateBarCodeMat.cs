using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DProS.Datasource.Report
{
    public partial class rpCreateBarCodeMat : DevExpress.XtraReports.UI.XtraReport
    {
        public rpCreateBarCodeMat()
        {
            InitializeComponent();
        }
        public rpCreateBarCodeMat(string matcode, string matname,string weight)
        {
            InitializeComponent();
            lMatCode.Text = matcode;
            lMatname.Text = matname;
            lWeight.Text = weight;
            string code = matcode + "&" + weight+"_";
            BarCo.Text = code;
        }

    }
}
