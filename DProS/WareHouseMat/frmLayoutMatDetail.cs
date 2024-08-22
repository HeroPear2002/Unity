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

namespace DProS.WareHouseMat
{
    public partial class frmLayoutMatDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmLayoutMatDetail()
        {
            InitializeComponent();
            LoadControl();
        }

        private void LoadControl()
        {
            LoadData();
            LockControl(true);
        
        }

        private void LockControl(bool v)
        {
            if (v)
            {
                nudWeight.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                nudWeight.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void LoadData()
        {
            gridControl1.DataSource = WareHouseMatDAO.Instance.GetList();
        }

        private void btnEditWeight_Click(object sender, EventArgs e)
        {
            LockControl(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                try
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int status = int.Parse(gridView1.GetRowCellValue(item, "StatusWH").ToString());
                    int weight = int.Parse(nudWeight.Value.ToString());
                    int update = WareHouseMatDAO.Instance.Update(id, status, weight);
                }
                catch (Exception)
                {

                }
                
            }
            LoadControl();
        }

        private void btnLockUnLock_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                try
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int statusOld = int.Parse(gridView1.GetRowCellValue(item, "StatusWH").ToString());
                    int status = 9;
                    if(statusOld !=0 )
                    {
                        status = 8;
                    }

                    int weight = int.Parse(gridView1.GetRowCellValue(item, "WeightWH").ToString());
                    int update = WareHouseMatDAO.Instance.Update(id, status, weight);
                }
                catch (Exception)
                {

                }

            }
            LoadControl();
        }


        private void btnNomar_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                try
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int statusOld = int.Parse(gridView1.GetRowCellValue(item, "StatusWH").ToString());
                    if(statusOld == 10 || statusOld == 11)
                    {
                                            int status = 0;
                    if (statusOld == 10)
                    {
                        status = 1;
                    }

                    int weight = int.Parse(gridView1.GetRowCellValue(item, "WeightWH").ToString());
                    int update = WareHouseMatDAO.Instance.Update(id, status, weight);
                    }

                }
                catch (Exception)
                {

                }

            }
            LoadControl();
        }

        private void btnChangeLoca_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                try
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int statusOld = int.Parse(gridView1.GetRowCellValue(item, "StatusWH").ToString());
                    if(statusOld !=10 || statusOld !=11)
                    {
                        int status = 10;
                        if (statusOld == 0)
                        {
                            status = 11;
                        }

                        int weight = int.Parse(gridView1.GetRowCellValue(item, "WeightWH").ToString());
                        int update = WareHouseMatDAO.Instance.Update(id, status, weight);
                    }
                }

                catch (Exception)
                {

                }

            }
            LoadControl();
        }
    }
}