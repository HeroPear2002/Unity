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
using DevExpress.XtraGrid.Views.Grid;

namespace DProS.Production_Manager.Box_Manager
{
    public partial class frmResidualBox : DevExpress.XtraEditors.XtraForm
    {
        public frmResidualBox()
        {
            InitializeComponent();
			LoadControl();
		}
		void LoadControl()
		{
			gcBoxEffic.DataSource = BoxEfficDAO.Instance.GetList();
		}
		private void btnSampleExcel_Click(object sender, EventArgs e)
		{
			frmResidualBoxSample f = new frmResidualBoxSample();
			f.ShowDialog();
		}
		private void btnAddItem_Click(object sender, EventArgs e)
		{
			frmResidualBoxImport f = new frmResidualBoxImport();
			f.ShowDialog();
			LoadControl();
		}
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}
		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvBoxEffic.GetSelectedRows())
				{
					int id = int.Parse(gvBoxEffic.GetRowCellValue(item, "Id").ToString());
					bool delete = BoxEfficDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper(), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			LoadControl();
		}

		private void gvBoxEffic_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;

			if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
			{
				for (int i = -1; i <= e.RowHandle; i++)
				{
					int AVG = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["BoxIventory"]).ToString());
					if (AVG > 0)
					{
						e.Appearance.BackColor = Color.Orange;
						e.Appearance.ForeColor = Color.White;
					}
					else if (AVG == 0)
					{
						e.Appearance.BackColor = Color.White;
						e.Appearance.ForeColor = Color.Black;
					}
					else
					{
						e.Appearance.BackColor = Color.Purple;
						e.Appearance.ForeColor = Color.White;
					}
				}

			}
		}
	}
}