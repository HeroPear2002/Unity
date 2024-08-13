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

namespace DProS.DeviceManagement
{
	public partial class frmErrorList : DevExpress.XtraEditors.XtraForm
	{
		List<string> Error = new List<string>();
		public frmErrorList()
		{
			InitializeComponent();
		}
		public frmErrorList(List<string> listError)
		{
			Error = listError;
			InitializeComponent();
		}

		private void frmErrorList_Load(object sender, EventArgs e)
		{
			foreach (var item in Error)
			{
				listBox.Items.Add(item);
			}
		}
	}
}