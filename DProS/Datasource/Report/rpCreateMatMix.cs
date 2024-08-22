using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DProS.Datasource.Report
{
    public partial class rpCreateMatMix : DevExpress.XtraReports.UI.XtraReport
    {
        public rpCreateMatMix()
        {
            InitializeComponent();
            LoadControl();
        }

        private void LoadControl()
        {
            lMatCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            lNameMat.DataBindings.Add("Text", DataSource, "MaterialName");
            txtMatCode.DataBindings.Add("Text", DataSource, "Name");
            qrMatCode.DataBindings.Add("Text", DataSource, "Name");
            lCount.DataBindings.Add("Text", DataSource, "Count");
        }

    }
}
