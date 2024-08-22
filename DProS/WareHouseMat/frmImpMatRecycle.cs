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
using DProS.Common;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DProS.WareHouseMat
{
    public partial class frmImpMatRecycle : DevExpress.XtraEditors.XtraForm
    {
        public frmImpMatRecycle()
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
            if( v)
            {
                txtBarCode.Enabled = false;
                txtMatCode.Enabled = false;
                txtMatName.Enabled = false;
                cbNameWH.Enabled = false;
                dtpDateInput.Enabled = false;
                txtMaxInput.Enabled = false;
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
                txtMaxInput.Enabled = false;
                txtWeightInput.Enabled = true;
                txtNote.Enabled =true;
                btnSave.Enabled = true;
                btnInput.Enabled = false;
                btnInputNew.Enabled = false;
            }
        }
         void Save()
        {
            if( IsNew==true)
            {
                int idmat = Idmat;
                DateTime dateinput = dtpDateInput.Value;
                float quantityinput = float.Parse(txtWeightInput.Text);
                float quantityMax = float.Parse(txtMaxInput.Text);
                if(quantityMax>=quantityinput)
                {
                    int idwh = int.Parse(cbNameWH.SelectedValue.ToString());
                    int statusinput = 0;
                    float quantityInventory = quantityinput;
                    string styleinput = "rec";
                    int idem = Common.CommonStatic.IdEmStaticRec;
                    string lot = "";
                    string rohs = "";
                    string note = txtNote.Text;
                    int insert = InputMatDAO.Instance.Insert(idmat, dateinput, quantityinput, quantityInventory, idwh, statusinput, styleinput, idem, lot, rohs, note);
                    int update = WareHouseMatDAO.Instance.Update(idwh, 10);
                }
                else
                {
                    MessageBox.Show("Nhập thất bại, bạn nhập quá số lượng cho phép", "THÔNG BÁO");
                }
            }
            else
            {
                long idinput = IdInput;
                float quantity = float.Parse(txtWeightInput.Text);
                float quantityMax = float.Parse(txtMaxInput.Text);
                if(quantityMax>= quantity)
                {
                    int statusrecycle = 0;
                    DateTime daterecycle = dtpDateInput.Value;
                    int idem = Common.CommonStatic.IdEmStaticRec;                  
                    string note = txtNote.Text;
                    int Insert = InputMatRecycleDAO.Instance.Insert(idinput, quantity, quantity, statusrecycle, daterecycle, idem, note);
                }  
                else
                {
                    MessageBox.Show("Nhập thất bại, bạn nhập quá số lượng cho phép", "THÔNG BÁO");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
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
                    txtMaxInput.Text = wareHouseMat.WeightWH.ToString();
                }
                else
                {
                    ComboBox cb = sender as ComboBox;
                    int idWH = int.Parse(cb.SelectedValue.ToString());
                    InputMatDTO inputMat = InputMatDAO.Instance.GetitemMat(idWH);
                    IdInput = inputMat.Id;
                    RatioMaterialDTO ratio = RatioMaterialDAO.Instance.Getitem(txtMatCode.Text);
                    if(ratio==null)
                    {
                        MessageBox.Show("Nguyên liệu chưa được settup tỷ lệ tái chế", "THÔNG BÁO");
                        return;
                    }
                    else
                    {
                        int maxinput = ratio.RatioInput;
                        float maxWeightInput =float.Parse( Math.Round(decimal.Parse((inputMat.QuantityInventory * maxinput / 100).ToString()), 2).ToString());
                        List<InputMatRecycleDTO> Lsvrecycle = InputMatRecycleDAO.Instance.GetlistNonNewByIdInput(IdInput);
                        float weight = 0;
                        foreach (var item in Lsvrecycle)
                        {
                            weight += item.QuantityInventory;
                        }
                        maxWeightInput = maxWeightInput - weight;
                        txtMaxInput.Text = maxWeightInput.ToString();
                    }                    
                }
            }
            catch (Exception)
            {
                txtMaxInput.Text = string.Empty;
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if(key=='_')
            {
                if(IsNew)
                {
                    string code = txtBarCode.Text;
                    string[] ArrCode = code.Split('&');
                    txtMatCode.Text = ArrCode[0];
                    MaterialDTO material = MaterialDAO.Instance.GetItem(txtMatCode.Text);
                    if(material==null)
                    {
                        MessageBox.Show("Sai mã nguyên liệu", "THÔNG BÁO");
                        return;
                    }
                    else
                    {
                        txtMatName.Text = material.MatName;
                        Idmat = material.Id;
                        List<WareHouseMatDTO> lsvWH = WareHouseMatDAO.Instance.GetListSpecialNull();
                        cbNameWH.DataSource = lsvWH;
                        cbNameWH.DisplayMember = "Name";
                        cbNameWH.ValueMember = "Id";
                    }                  
                }
                else
                {
                    string code = txtBarCode.Text;
                    string[] ArrCode = code.Split('&');

                    txtMatCode.Text = ArrCode[0];
                    MaterialDTO material = MaterialDAO.Instance.GetItem(txtMatCode.Text);
                    if(material==null)
                    {
                        MessageBox.Show("Sai mã nguyên liệu", "THÔNG BÁO");
                        return;
                    }
                    else
                    {
                        txtMatName.Text = material.MatName;
                        List<InputMatDTO> lsvmat = InputMatDAO.Instance.GetlistMatByCode(txtMatCode.Text);
                        cbNameWH.DataSource = lsvmat;
                        cbNameWH.DisplayMember = "Name";
                        cbNameWH.ValueMember = "IdWH";
                    }                                        
                }
            }          
        }

        private void btnInput_Click(object sender, EventArgs e)
        {         
            IsNew = false;
            LockControl(false);
        }

        private void btnInputNew_Click(object sender, EventArgs e)
        {
            cbNameWH.DataSource = WareHouseMatDAO.Instance.GetListSpecialNull();
            cbNameWH.DisplayMember = "Name";
            cbNameWH.ValueMember = "Id";
            LockControl(false);
            IsNew = true;
            
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}