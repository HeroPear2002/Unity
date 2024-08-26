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
using DTO;
using DAO;

namespace DProS.Datasource
{
    public partial class frmHistoryTem : DevExpress.XtraEditors.XtraForm
    {
		List<HistoryTemDTO> listHistory = new List<HistoryTemDTO>();
        public frmHistoryTem()
        {
            InitializeComponent();
			LoadControl();
        }

		private void LoadControl()
		{
			SetDateTimePickers();
			LoadData(dtpDateStart.Value, dtpDateEnd.Value);
		}

		private void LoadData(DateTime Start, DateTime End)
		{
			listHistory = HistoryTemDAO.Instance.GetList().Where(x => x.DatePrint >= Start && x.DatePrint <= End).ToList();
			gcHistoryTem.DataSource = listHistory;
		}
		private void SetDateTimePickers()
		{
			DateTime today = DateTime.Now;
			dtpDateStart.Value = new DateTime(today.Year, today.Month, 1);
			DateTime lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
			dtpDateEnd.Value = lastDayOfMonth;
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			LoadData(dtpDateStart.Value, dtpDateEnd.Value);
		}
	}
}