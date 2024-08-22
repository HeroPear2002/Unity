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
using DProS.Common;
using DAO;
using DTO;

namespace DProS
{
	public partial class frmImpEmCode : DevExpress.XtraEditors.XtraForm
	{
		public frmImpEmCode()
		{
			InitializeComponent();
		}
		public string _type;
		public frmImpEmCode(string type)
		{
			InitializeComponent();
			_type = type;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			#region Chưa có nhân viên , tạm thời để ai cung nhập dượcf. Sau này làm kiểm tra nhân viên vào đây

			#endregion
			if (_type == "new")
			{
				string emcode = txtEmCode.Text;
				EmployessDTO em = EmployessDAO.Instance.GetItem(emcode);
				if (em == null)
				{
					MessageBox.Show("Mã nhân viên không đúng.", "THÔNG BÁO");
					return;
				}
				Common.CommonStatic.IdEmStatic = em.Id;
			}
			if (_type == "rec")
			{
				string emcode = txtEmCode.Text;
				EmployessDTO em = EmployessDAO.Instance.GetItem(emcode);
				if (em == null)
				{
					MessageBox.Show("Mã nhân viên không đúng.", "THÔNG BÁO");
					return;
				}
				Common.CommonStatic.IdEmStaticRec = em.Id;
			}
			if (_type == "mix")
			{
				string emcode = txtEmCode.Text;
				EmployessDTO em = EmployessDAO.Instance.GetItem(emcode);
				if (em == null)
				{
					MessageBox.Show("Mã nhân viên không đúng.", "THÔNG BÁO");
					return;
				}
				Common.CommonStatic.IdEmStaticMix = em.Id;
			}
			this.Close();
		}
	}
}