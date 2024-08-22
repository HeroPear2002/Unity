using DevExpress.XtraBars;
using DevExpress.XtraBars.FluentDesignSystem;
using DProS.WareHouseMat;
using DProS.Mold_Manager;
using DProS.Production_Manager.Box_Manager;
using DProS.Production_Manager.Oder_Manager;
using DProS.Production_Manager.PO_Manager;
using DProS.DeviceManagement;
using DProS.MachineData;
using DProS.WareHouseMat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DProS.Datasource;

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
            // OpenForm(typeof(frmLayoutWHMat));
            OpenForm(typeof(frmWareHouseMat));


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

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmSuplier));
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmCustomer));
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmMaterialInf));
        }

        private void btnDryMachine_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmDryerList));
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmListReason));
        }

        private void btnMixMaterial_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmMixMaterial));
        }

        private void btnRatioMaterial_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmRecycleRate));
        }

        private void btnMaterialBegin_Click(object sender, EventArgs e)
        {
            OpenForm(typeof(frmMaterialBegin));
        }

        private void btnInventoryMaterial_Click(object sender, EventArgs e)
        {

        }

        private void btnInputMat_Click(object sender, EventArgs e)
        {

        }

        private void btnInputMixMat_Click(object sender, EventArgs e)
        {

        }

        private void btnInputRecycleMat_Click(object sender, EventArgs e)
        {

        }

        private void btnPOInput_Click(object sender, EventArgs e)
        {
			CloseForm(typeof(frmPOInput));
            OpenForm(typeof(frmPOInput));
        }

        private void btnPOOutput_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmPOOutput));
			OpenForm(typeof(frmPOOutput));
        }

        private void btnPOFix_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmPOFix));
			OpenForm(typeof(frmPOFix));
        }

        private void btnDelivery_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmDeliveryRecord));
			OpenForm(typeof(frmDeliveryRecord));
        }

        private void btnDirectiveParoduct_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmDirectiveParoduct));
			OpenForm(typeof(frmDirectiveParoduct));
        }

        private void btnBox_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmBox));
			OpenForm(typeof(frmBox));
        }

        private void btnBoxInf_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmBoxInf));
			OpenForm(typeof(frmBoxInf));
        }

        private void btnResidualBox_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmResidualBox));
			OpenForm(typeof(frmResidualBox));
        }

        private void btnPriceMat_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmPriceMat));
			OpenForm(typeof(frmPriceMat));
        }

        private void btnInventoryMatDate_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmInventoryMatDate));
			OpenForm(typeof(frmInventoryMatDate));
        }

        private void btnPriceChar_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmPriceChar));
			OpenForm(typeof(frmPriceChar));
        }

        private void btnCoupontMat_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCoupontMat));
			OpenForm(typeof(frmCoupontMat));
        }

        private void btnDeliveryMat_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmDeliveryMat));
			OpenForm(typeof(frmDeliveryMat));
        }

        private void btnMatBy_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmMatBy));
			OpenForm(typeof(frmMatBy));
        }

        private void btnMatSupplier_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmMatSupplier));
			OpenForm(typeof(frmMatSupplier));
        }

        private void btnUpdateFC_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmUpdateFC));
			OpenForm(typeof(frmUpdateFC));
        }

        private void btnMatUsing_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmMatUsing));
			OpenForm(typeof(frmMatUsing));
        }

        private void btnTotalMat_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmTotalMat));
			OpenForm(typeof(frmTotalMat));
        }

        private void btnMoldInfor_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmMoldInfor));
			OpenForm(typeof(frmMoldInfor));
        }

        private void btnMoldUsing_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmMoldUsing));
			OpenForm(typeof(frmMoldUsing));
        }

        private void btnHistoryMold_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmHistoryMold));
			OpenForm(typeof(frmHistoryMold));
        }

        private void btnMold1M_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmMold1M));
			OpenForm(typeof(frmMold1M));
        }

        private void btnErrorMold_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmErrorMold));
			OpenForm(typeof(frmErrorMold));
        }

        private void btnRoomMold_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmRoomCheckMold));
			OpenForm(typeof(frmRoomCheckMold));
        }

        private void btnCategoryMold_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCategoryMold));
			OpenForm(typeof(frmCategoryMold));
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
		private void btnCharMachine_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmCharMachine));
			OpenForm(typeof(frmCharMachine));
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

		private void btnFactory_Click(object sender, EventArgs e)
		{
			CloseForm(typeof(frmFactory));
			OpenForm(typeof(frmFactory));
		}
		private void btnPart_Click(object sender, EventArgs e)
		{

			CloseForm(typeof(frmParts));
			OpenForm(typeof(frmParts));
		}
		private void btnTemPart_Click(object sender, EventArgs e)
		{
			OpenForm(typeof(frmTemPart));
		}
	}
}
