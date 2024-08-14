using DevExpress.XtraBars;
using DevExpress.XtraBars.FluentDesignSystem;
using DProS.DeviceManagement;
using DProS.MachineData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DProS
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            InitializeComponent();
		}
    
        public void OpenForm(Type typeform)
        {
            foreach (var frm in MdiChildren.Where(frm => frm.GetType() == typeform))
            {
                frm.Activate();
                return;
            }

            var form = (Form)(Activator.CreateInstance(typeform));
            BeginInvoke(new Action(() =>
            {
                form.MdiParent = this;
                form.Show();
            }));
        }
        public void CloseForm(Type typeform)
        {
            foreach (var frm in MdiChildren.Where(frm => frm.GetType() == typeform))
            {
                frm.Close();
                return;
            }
        }
        private void btnLogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLayoutMaterial_Click(object sender, EventArgs e)
        {
            
        }
        private void btnProgress_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmLogin));
            //if (_uCProgress == null)
            //{
            //    _uCProgress = new uCProgress();
            //    _uCProgress.Dock = DockStyle.Fill;
            //    mainContainer.Controls.Add(_uCProgress);
            //    _uCProgress.BringToFront();
            //}
            //else
            //{
            //    _uCProgress.BringToFront();
            //}
        }

		private void btnCategoryDevice_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCategoryDevice));
			OpenForm(typeof(frmCategoryDevice));
		}

		private void btnListDevice_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmListDevice));
			OpenForm(typeof(frmListDevice));
		}

		private void btnLayoutMachine_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmLayoutMachine));
			OpenForm(typeof(frmLayoutMachine));
		}

		private void btnCategoryMainten_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCategoryMainten));
			Common.CommonConstant.checkCate = 1;
			OpenForm(typeof(frmCategoryMainten));
		}

		private void btnCatagoryEveryday_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCategoryMainten));
			Common.CommonConstant.checkCate = 0;
			OpenForm(typeof(frmCategoryMainten));
		}

		private void btnSetupMainten_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmSetupMainten));
			Common.CommonConstant.checkSetupDevice = 1;
			OpenForm(typeof(frmSetupMainten));
		}

		private void btnSetupEveryday_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmSetupMainten));
			Common.CommonConstant.checkSetupDevice = 0;
			OpenForm(typeof(frmSetupMainten));
		}

		private void btnHistoryMainten_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmHistoryMainten));
			Common.CommonConstant.checkHistoryDevice = 1;
			OpenForm(typeof(frmHistoryMainten));
		}

		private void btnHistoryEveryday_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmHistoryMainten));
			Common.CommonConstant.checkHistoryDevice = 0;
			OpenForm(typeof(frmHistoryMainten));
		}

		private void btnCategoryTest_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCategoryTest));
			OpenForm(typeof(frmCategoryTest));
		}

		private void btnSetupMachine_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmSetupMachine));
			OpenForm(typeof(frmSetupMachine));
		}

		private void btnTableCheckData_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmTableCheckData));
			OpenForm(typeof(frmTableCheckData));
		}

		private void btnHistoryCheckData_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmHistoryCheckData));
			OpenForm(typeof(frmHistoryCheckData));
		}

		private void btnCharCheckData_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCharCheckData));
			OpenForm(typeof(frmCharCheckData));
		}

		private void btnLocation_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmLocation));
			OpenForm(typeof(frmLocation));
		}

		private void btnWeather_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmWeather));
			OpenForm(typeof(frmWeather));
		}

		private void btnCharWeather_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCharWeather));
			OpenForm(typeof(frmCharWeather));
		}
	}
}
