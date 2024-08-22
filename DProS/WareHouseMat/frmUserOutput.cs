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

namespace DProS.WareHouseMat
{
    public partial class frmUserOutput : DevExpress.XtraEditors.XtraForm
    {
        public frmUserOutput()
        {
            InitializeComponent();
        }
        public string matcode;
        public string matname;
        public string partcode;
        public float weightmat;
        public float weightmix;
        public float weightre;
        public DateTime dateoutput;
        public string name;
        public int idwh;
        public int status;
        public string machinecode;
        public frmUserOutput(string[] Arr)
        {
            InitializeComponent();
            matcode = Arr[0];
            matname = Arr[1];
            partcode = Arr[2];
            weightmat = float.Parse(Arr[3]);
            weightmix = float.Parse(Arr[4]);
            weightre = float.Parse(Arr[5]);
            dateoutput = DateTime.Parse(Arr[6]);
            name = Arr[7];
            idwh = int.Parse(Arr[8]);
            machinecode = Arr[9];
            status = int.Parse(Arr[10]);

            txtMaterialCode.Text = matcode;
            txtMaterialName.Text = matname;
            txtName.Text = name;
            txtPartCode.Text = partcode;
            txtMachineCode.Text = machinecode;

            float remax = 0;
            float mixmax = 0;
            float matmax = 0;
            InputMatDTO inputmat = InputMatDAO.Instance.GetitemMat(idwh);
            if (inputmat != null)
            {
                matmax = inputmat.QuantityInventory;
                List<InputMatRecycleDTO> Lsvre = InputMatRecycleDAO.Instance.GetListByIdInput(inputmat.Id);
                List<InputMatMixDTO> Lsvmix = InputMatMixDAO.Instance.GetListLive(inputmat.Id);
                foreach (InputMatRecycleDTO item in Lsvre)
                {
                    remax += item.QuantityInventory;

                }

                foreach (InputMatMixDTO item in Lsvmix)
                {
                    mixmax += item.QuantityInventory;

                }
            }
            else
            {
                InputMatDTO inputmatmix = InputMatDAO.Instance.GetitemAllMat(idwh);
                mixmax = inputmatmix.QuantityInventory;
            }

            txtQuantityMax.Text = matmax.ToString();
            txtQuantityCycleMax.Text = remax.ToString();
            txtQuantityMixMax.Text = mixmax.ToString();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (key == '_')
            {
                // mã nl& vị trí _
                string[] code = txtBarCode.Text.Split('_');
                string[] barcode = code[0].Split('&');
                if (barcode.Length != 2)
                {
                    MessageBox.Show("Mã vạch không đúng.");
                    return;
                }

                if (barcode[0] != matcode)
                {
                    MessageBox.Show("Sai mã nguyên liệu");
                    return;
                }
                if (barcode[1] != name)
                {
                    MessageBox.Show("Sai vị trí");
                    return;
                }

                txtQuantityMixPlan.Text = weightmix.ToString();
                txtQuantityCyclePlan.Text = weightre.ToString();
                txtQuantityPlan.Text = weightmat.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmImpEmCode f = new frmImpEmCode();
            f.ShowDialog();
            int idem = Common.CommonStatic.IdEmstaticOutput;

            InputMatDTO inputmat = InputMatDAO.Instance.GetitemMat(idwh);
            List<InputMatRecycleDTO> Lsvre = InputMatRecycleDAO.Instance.GetListByIdInput(inputmat.Id);
            List<InputMatMixDTO> Lsvmix = InputMatMixDAO.Instance.GetListLive(inputmat.Id);

            PartDTO part = PartDAO.Instance.GetItem(partcode);
            float weightoutmat = float.Parse(txtQuantity.Text);
            float weightoutMix = float.Parse(txtQuantityMix.Text);
            float weightoutre = float.Parse(txtQuantityCycle.Text);

            float maxrec = float.Parse(txtQuantityCycleMax.Text);
            float maxmix = float.Parse(txtQuantityMixMax.Text);
            float maxmat = float.Parse(txtQuantityMax.Text);

            if (status == 10)
            {
                int insertOutMix = OutputMatDAO.Instance.Insert(inputmat.Id, dateoutput, weightoutMix, "mix", idem, part.Id, 1, "", "");
                if (maxmix > weightoutMix)
                {
                    int updateInput = InputMatDAO.Instance.UpdateStatus(inputmat.Id, 0, maxmix - weightoutMix);

                }
                else
                {
                    int updateInput = InputMatDAO.Instance.UpdateStatus(inputmat.Id, 1, 0);
                    int updatewh = WareHouseMatDAO.Instance.Update(idwh, 11);
                }
            }
            else
            {
                int insertOutMat = OutputMatDAO.Instance.Insert(inputmat.Id, dateoutput, weightoutmat, "new", idem, part.Id, 1, "", "");
                if (weightmat == maxmat)
                {
                    int updateInput = InputMatDAO.Instance.UpdateStatus(inputmat.Id, 1, 0);
                    int updatewh = WareHouseMatDAO.Instance.Update(idwh, 0);
                }
                else
                {
                    int updateInput = InputMatDAO.Instance.UpdateStatus(inputmat.Id, 0, maxmat - weightoutmat);
                }

                if (Lsvmix.Count != 0)
                {
                    if (weightoutMix <= weightmix)
                    {
                        //xuat có slxuat là weightoutMix

                        foreach (var item in Lsvmix)
                        {

                        }
                        
                    }
                    else
                    {
                        // them reason
                        // xuat
                    }



                }
                if (Lsvre.Count != 0)
                {

                }
            }
        }

        private void txtQuantityMix_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }

        }

        private void txtQuantityCycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }

        private void txtQuantityMix_KeyUp(object sender, KeyEventArgs e)
        {
            float weightneed = 0;
            float weightmixmax = float.Parse(txtQuantityMixMax.Text);
            try
            {
                weightneed = float.Parse(txtQuantityMix.Text);

            }
            catch (Exception)
            {


            }
            if (weightneed > weightmixmax)
            {
                MessageBox.Show("Không thể xuất quá số lượng tối đa. ");
                txtQuantityMix.Text = "0";
            }
        }

        private void txtQuantityCycle_KeyUp(object sender, KeyEventArgs e)
        {
            float weightneed = 0;
            float weightremax = float.Parse(txtQuantityCycleMax.Text);
            float weightmixneed = 0;
            try
            {
                weightneed = float.Parse(txtQuantityCycle.Text);

            }
            catch (Exception)
            {
            }
            try
            {
                weightmixneed = float.Parse(txtQuantityMix.Text);

            }
            catch (Exception)
            {
            }
            if (weightneed > weightremax)
            {
                MessageBox.Show("Không thể xuất quá số lượng tối đa. ");
                txtQuantityCycle.Text = "0";
            }

            float inventorymat = float.Parse(txtQuantityMax.Text) - float.Parse(txtQuantity.Text);
            float inventoryre = float.Parse(txtQuantityCycleMax.Text) - weightneed;
            float inventorymix = float.Parse(txtQuantityCycleMax.Text) - weightmixneed;
            if (status != 10)
            {
                if (inventorymat == 0)
                {
                    if (inventorymix != 0 || inventoryre != 0)
                    {
                        MessageBox.Show("Vị trí hết nhưa tinh, bạn cần xuất hết nhựa hỗn hợp và nhựa tái chế", "THÔNG BÁO");
                        txtQuantityMix.Text = "0";
                        txtQuantityCycle.Text = "0";
                    }
                }
                else
                {
                    RatioMaterialDTO ratio = RatioMaterialDAO.Instance.Getitem(matcode);
                    if ((inventoryre / inventorymat * 100) > (ratio.RatioInput))
                    {
                        MessageBox.Show("Tỷ lệ tồn nhựa tái chế vượt quá mức cho phép", "THÔNG BÁO");
                        txtQuantityMix.Text = "0";
                        txtQuantityCycle.Text = "0";
                    }
                }
            }



        }
    }
}