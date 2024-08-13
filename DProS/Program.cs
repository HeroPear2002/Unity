using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DProS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>	
        [STAThread]
        static void Main()
        {
			Application.EnableVisualStyles();
			WindowsFormsSettings.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmLogin());
        }
    }
}
