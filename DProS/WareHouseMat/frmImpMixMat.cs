using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAO;
using DTO;


namespace DProS.WareHouseMat
{
    public partial class frmImpMixMat : DevExpress.XtraEditors.XtraForm
    {
        public frmImpMixMat()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsNew = false;

        private void LoadControl()
        {
            LockControl(true);

        }
        public long IdInput;
        public int Idmat;
        private void LockControl(bool v)
        {
            if (v)
            {
                txtBarCode.Enabled = false;
                txtMatCode.Enabled = false;
                txtMatName.Enabled = false;
                cbNameWH.Enabled = false;
                dtpDateInput.Enabled = false;
                txtMachineCode.Enabled = false;
                txtWeightInput.Enabled = false;
                txtNote.Enabled = false;
                btnSave.Enabled = false;
                btnInput.Enabled = true;
                btnInputNew.Enabled = true;

            }
            else
            {
                txtBarCode.Enabled = true;
                txtMatCode.Enabled = false;
                txtMatName.Enabled = false;
                cbNameWH.Enabled = true;
                dtpDateInput.Enabled = true;
                txtMachineCode.Enabled = true;
                txtWeightInput.Enabled = true;
                txtNote.Enabled = true;
                btnSave.Enabled = true;
                btnInput.Enabled = false;
                btnInputNew.Enabled = false;

            }
        }
        void Save()
        {
            if (IsNew == true)
            {
                int idmat = Idmat;
                DateTime dateinput = dtpDateInput.Value;
                float quantityinput = float.Parse(txtWeightInput.Text);
                int idwh = int.Parse(cbNameWH.SelectedValue.ToString());
                int statusinput = 0;
                float quantityInventory = quantityinput;
                string styleinput = "mix";
                int idem = Common.CommonStatic.IdEmStaticMix;
                string lot = "";
                string rohs = "";
                string note = txtNote.Text;
                int insert = InputMatDAO.Instance.Insert(idmat, dateinput, quantityinput, quantityInventory, idwh, statusinput, styleinput, idem, lot, rohs, note);
                int update = WareHouseMatDAO.Instance.Update(idwh, 10);
            }
            else
            {
                long idinput = IdInput;
                float quantity = float.Parse(txtWeightInput.Text);
                int status = 0;
                DateTime date = dtpDateInput.Value;
                int idem = Common.CommonStatic.IdEmStaticMix;
                float inventory = quantity;
                string note = txtMachineCode + "&" + txtNote.Text;
                string name = cbNameWH.Text;
                int insert = InputMatMixDAO.Instance.Insert(idinput, quantity, status, date, idem, note, inventory, name);
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            LockControl(false);
            IsNew = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (key == '_')
            {
                if (IsNew)
                {
                    string code = txtBarCode.Text;
                    string[] ArrCode = code.Split('&');
                    txtMatCode.Text = ArrCode[0];
                    MaterialDTO material = MaterialDAO.Instance.GetItem(txtMatCode.Text);
                    if(material==null)
                    {
                        MessageBox.Show("Sai mã nguyên liệu.", "THÔNG BÁO");
                        return;
                    }
                    txtMatName.Text = material.MatName;
                    Idmat = material.Id;
                    List<WareHouseMatDTO> lsvWH = WareHouseMatDAO.Instance.GetListSpecialNull();
                    cbNameWH.DataSource = lsvWH;
                    cbNameWH.DisplayMember = "Name";
                    cbNameWH.ValueMember = "Id";
                }
                else
                {
                    string code = txtBarCode.Text;
                    string[] ArrCode = code.Split('&');
                    txtMatCode.Text = ArrCode[0];
                    MaterialDTO material = MaterialDAO.Instance.GetItem(txtMatCode.Text);
                    if(material==null)
                    {
                        MessageBox.Show("Sai mã nguyên liệu.", "THÔNG BÁO");
                        return;
                    }
                    txtMatName.Text = material.MatName;
                    List<InputMatDTO> lsvmat = InputMatDAO.Instance.GetlistMatByCode(txtMatCode.Text);
                    cbNameWH.DataSource = lsvmat;
                    cbNameWH.DisplayMember = "Name";
                    cbNameWH.ValueMember = "IdWH";

                }

            }
        }

        private void cbNameWH_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNew)
                {
                   ComboBox cb = sender as ComboBox;
                    int id = int.Parse(cb.SelectedValue.ToString());
                    WareHouseMatDTO wareHouseMat = WareHouseMatDAO.Instance.GetItem(id);
                 //   txtMaxInput.Text = wareHouseMat.WeightWH.ToString();

                }
                else
                {
                    ComboBox cb = sender as ComboBox;
                    int idWH = int.Parse(cb.SelectedValue.ToString());
                    InputMatDTO inputMat = InputMatDAO.Instance.GetitemMat(idWH);
                    IdInput = inputMat.Id;
                    
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnInputNew_Click(object sender, EventArgs e)
        {
            LockControl(false);
            IsNew = true;
            cbNameWH.DataSource = WareHouseMatDAO.Instance.GetListSpecialNull();
            cbNameWH.DisplayMember = "Name";
            cbNameWH.ValueMember = "Id";
        }

        private void txtWeightInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }

        private void txtNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }
    }
}