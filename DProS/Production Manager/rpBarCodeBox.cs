﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DProS.Production_Manager
{
	public partial class rpBarCodeBox : DevExpress.XtraReports.UI.XtraReport
	{
		public rpBarCodeBox()
		{
			InitializeComponent();
			LoadData();
		}
		public void LoadData()
		{
			txtBarCode.DataBindings.Add("Text", DataSource, "BoxCode");
		}

	}
}
