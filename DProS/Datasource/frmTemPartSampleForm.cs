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

namespace DProS.Datasource
{
	public partial class frmTemPartSampleForm : DevExpress.XtraEditors.XtraForm
	{
		public frmTemPartSampleForm()
		{
			InitializeComponent();
		}

		private void btnGetFormSample_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", Title = "Save SampleFile", FileName = "SampleForm"})
			{
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;
					string extension = System.IO.Path.GetExtension(filePath);
					gridControl1.ExportToXlsx(filePath);	
				}
			}
		}
	}
}