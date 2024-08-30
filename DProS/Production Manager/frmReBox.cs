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
using DTO;

namespace DProS.Production_Manager
{
	public partial class frmReBox : DevExpress.XtraEditors.XtraForm
	{
		public frmReBox()
		{
			InitializeComponent();
		}
		public EventHandler LamMoi;
		void XoaText(object sender, EventArgs e)
		{
			this.Invoke(
			new MethodInvoker(() =>
			{

				txtBoxCode1.Text = String.Empty;
			}));

		}


		private void frmReBox_FormClosing(object sender, FormClosingEventArgs e)
		{
			LamMoi?.Invoke(sender, e);
		}

		private void txtBoxCode1_EditValueChanged(object sender, EventArgs e)
		{
			DateTime today = DateTime.Now;
			string BoxCode = txtBoxCode1.Text;
			BoxListDTO Test = BoxListDAO.Instance.GetItem(BoxCode);
			if (Test != null)
			{
				int Iventory = Test.BoxIventory;
				BoxListDAO.Instance.Update(Test.Id, (Iventory + 1));
				ReBoxDAO.Instance.Insert(Test.Id, today);
				LamMoi?.Invoke(sender, e);
			}
			else
			{

			}
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			txtBoxCode1.Text = String.Empty;
			timer1.Stop();
		}
	}
}