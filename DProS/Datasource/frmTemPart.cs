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

namespace DProS.Datasource
{
    public partial class frmTemPart : DevExpress.XtraEditors.XtraForm
    {
        public frmTemPart()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert;
        private void LoadControl()
        {
            Loadata();
            LockControl(true);
            Loadgl();
            Clentext();
        }

        private void Loadgl()
        {
            glPartCode.Properties.DataSource = PartDAO.Instance.Getlist();
            glPartCode.Properties.DisplayMember = "PartCode";
            glPartCode.Properties.ValueMember = "Id";

            glFacCode.Properties.DataSource = FactoryDAO.Instance.GetList();
            glFacCode.Properties.DisplayMember = "FacName";
            glFacCode.Properties.ValueMember = "Id";

            //chuwa hop nhat code nen chua co ma may va ma khuon
            glMachineCode.Properties.DataSource = FactoryDAO.Instance.GetList();
            glMachineCode.Properties.DisplayMember = "FacName";
            glMachineCode.Properties.ValueMember = "Id";

            glMoldCode.Properties.DataSource = FactoryDAO.Instance.GetList();
            glMoldCode.Properties.DisplayMember = "FacName";
            glMoldCode.Properties.ValueMember = "Id";


        }

        private void Clentext()
        {
            txtDesighCode.Text = string.Empty;
            ckb4m.CheckState = CheckState.Unchecked;
            glMoldCode.Text = string.Empty;
            glMachineCode.Text = string.Empty;
            glFacCode.Text = string.Empty;
            glPartCode.Text = string.Empty;

        }

        private void LockControl(bool v)
        {
            if (v)
            {
                txtDesighCode.Enabled = false;
                ckb4m.Enabled = false;
                glMoldCode.Enabled = false;
                glMachineCode.Enabled = false;
                glFacCode.Enabled = false;
                glPartCode.Enabled = false;

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;

                btnImpExcel.Enabled = true;
                btnExpExcel.Enabled = true;
                btnFormExcel.Enabled = true;
                btnRemoveCavi.Enabled = true;
                btnTemPrint.Enabled = true;
                btnTemPrintNew.Enabled = true;
                btnTemTemMa.Enabled = true;
                btnTemTKG.Enabled = true;

            }
            else
            {
                txtDesighCode.Enabled = true;
                ckb4m.Enabled = true;
                glMoldCode.Enabled = true;
                glMachineCode.Enabled = true;
                glFacCode.Enabled = true;
                glPartCode.Enabled = true;

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;

                btnImpExcel.Enabled = false;
                btnExpExcel.Enabled = false;
                btnFormExcel.Enabled = false;
                btnRemoveCavi.Enabled = true;
                btnTemPrint.Enabled = false;
                btnTemPrintNew.Enabled = false;
                btnTemTemMa.Enabled =false;
                btnTemTKG.Enabled = false;
            }
        }
        void Save()
        {
            if (IsInsert)
            {
               

            }
            else
            {
                try
                {
                    
                }
                catch (Exception)
                {


                }

            }
        }

        private void Loadata()
        {
            gridControl1.DataSource =FactoryDAO.Instance.GetList();
        }
    }
}