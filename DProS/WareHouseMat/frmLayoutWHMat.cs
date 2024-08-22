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

namespace DProS.WareHouseMat
{
    public partial class frmLayoutWHMat : DevExpress.XtraEditors.XtraForm
    {
        public frmLayoutWHMat()
        {
            InitializeComponent();
            LoadControl();           
        }

        private void LoadControl()
        {
            LockControl();
            CleanText();
            LoadLayout();
        }

        private void CleanText()
        {
            CleanTextInput();
        }

        private void CleanTextInput()
        {
            txtTemCode.Text = string.Empty;
            txtMatCode.Text = string.Empty;
            txtQuantityInput.Text = string.Empty;
            cbLocationInput.Text = string.Empty;
        }

        private void LockControl()
        {
            LockControlInput(true);
        }

        private void LockControlInput(bool v)
        {
            if(v)
            {
                txtTemCode.Enabled = false;
                txtQuantityInput.Enabled = false;
                txtMatCode.Enabled = false;
                dtpDateInput.Enabled = false;
                cbLocationInput.Enabled = false;
                btnInputMaterial.Enabled = true;
                btnInputTry.Enabled = true;
                btnSaveInput.Enabled = false;
            }
            else
            {
                txtTemCode.Enabled = true;
                txtQuantityInput.Enabled = false;
                txtMatCode.Enabled = false;
                dtpDateInput.Enabled = true;
                cbLocationInput.Enabled = true;
                btnInputMaterial.Enabled = false;
                btnInputTry.Enabled = false;
                btnSaveInput.Enabled = true;
            }

        }

        int widthbtn = 0;
        private void LoadLayout()
        {
            pLayout.Controls.Clear();
            object MaxRow = WareHouseMatDAO.Instance.GetMaxRow();
            int MaxRowint = 0;
            if (MaxRow.ToString() != "")
            {
                MaxRowint = int.Parse(MaxRow.ToString());
                widthbtn = (pLayout.Width-10) / (MaxRowint + 1);
                for (int i = 0; i < MaxRowint; i++)
                {
                    Button bt = new Button();
                    bt.Text = (i + 1).ToString();
                    bt.Name = (i + 1).ToString();
                    bt.BackColor = Color.White;
                    bt.Location = new Point((i + 1) * widthbtn+10, 0);
                    bt.Width = widthbtn;
                    bt.Height = widthbtn;
                    pLayout.Controls.Add(bt);
                }
                List<string> NameRow = WareHouseMatDAO.Instance.GetHeader();
                int height = widthbtn;
                foreach (string item in NameRow)
                {
                    Button bt = new Button();
                    bt.Text = item;
                    bt.Name = item;
                    bt.Location = new Point(0, height+10);
                    bt.Width = widthbtn;
                    bt.Height = widthbtn;
                    bt.BackColor = Color.White;
                    pLayout.Controls.Add(bt);
                    List<WareHouseMatDTO> LsvCon = WareHouseMatDAO.Instance.GetListByRowName(item);
                    WareHouseMatDTO ConMax = LsvCon[LsvCon.Count - 1];
                    string[] vitrimx = ConMax.Name.Split('-');
                    foreach (WareHouseMatDTO itemWH in LsvCon)
                    {                        
                        Button btcon = new Button();
                        btcon.Text = itemWH.Name;
                        btcon.Name = itemWH.Name;
                        string[] vitri = itemWH.Name.Split('-');
                        int Num = int.Parse(vitri[1]) / MaxRowint;
                        int locaX = int.Parse(vitri[1]) - (Num) * MaxRowint;
                        if (locaX == 0)
                        { locaX = MaxRowint; }
                        btcon.Location = new Point(locaX * widthbtn+10, height+10);
                        btcon.Width = widthbtn;
                        btcon.Height = widthbtn;
                        int status = itemWH.StatusWH;
                       switch(status)
                        {
                            case 0://vi tri trong
                                btcon.BackColor = Color.White;
                                break;
                            case 1:// vi tri co hang
                                btcon.BackColor = Color.DeepSkyBlue;
                                break;
                            case 2://vi tri canh bao vang
                                btcon.BackColor = Color.Yellow;
                                break;
                            case 3://canh bao do
                                btcon.BackColor = Color.Red;
                                break;
                            case 4://PC xac nhan sl
                                btcon.BackColor = Color.FromArgb(0, 192, 0);
                                break;
                            case 5://PC xac cl
                                btcon.BackColor = Color.FromArgb(255,192,192);
                                break;
                            case 6://NL qua 2 nam
                                btcon.BackColor = Color.Black;
                                break;
                            case 7://NL chan sang
                                btcon.BackColor = Color.Purple;
                                break;
                            case 8://NL dang khoa cso hang
                                btcon.BackColor = Color.FromArgb(255,128,0);
                                break;
                            case 9://NL dang khoa
                                btcon.BackColor = Color.FromArgb(255, 128, 0);
                                break;
                            case 10://vi tri dac biet co hang
                                btcon.BackColor = Color.Gold;
                                break;
                            case 11://vi tri dac biet trong
                                btcon.BackColor = Color.Gold;
                                break;
                        }
                        btcon.Click += Btcon_Click;
                        pLayout.Controls.Add(btcon);
                        if (int.Parse(vitri[1]) % MaxRowint == 0 || int.Parse(vitri[1]) == int.Parse((vitrimx[1])))
                        {
                            height += (widthbtn);
                        }
                    }
                    height += 5;
                }             
            }
        }

        private void Btcon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            frmCreateLayOutMat f = new frmCreateLayOutMat();
            f.ShowDialog();
            LoadLayout();
        }
        private void pLayout_SizeChanged(object sender, EventArgs e)
        {
            LoadLayout();
        }
        private void frmLayoutWHMat_SizeChanged(object sender, EventArgs e)
        {      
            pbtn.Width= this.Width / 2 - 20;
            layoutbtn.Width= this.Width / 2 - 20;
            pLayout.Width = this.Width / 2-20;
            pLayout.Height = this.Height - 20;
        }

        private void btnLayoutMatDetail_Click(object sender, EventArgs e)
        {
            frmLayoutMatDetail f = new frmLayoutMatDetail();
            f.ShowDialog();
            LoadControl();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnInputMaterial_Click(object sender, EventArgs e)
        {
            frmImpEmCode f = new frmImpEmCode();
            f.ShowDialog();
            LockControlInput(false);
        }

        
        private void txtTemCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            char key = e.KeyChar;
            
            if (Char.IsWhiteSpace(key) || key == 8)
            {
                e.Handled = true;
            }

            if (key.ToString() == "_")
            {
                string code = txtTemCode.Text;
                string[] matcode = code.Split('&');
                txtMatCode.Text = matcode[0].ToString();

                string[] quantity = matcode[1].Split('_');
                txtQuantityInput.Text = quantity[0].ToString();
                try
                {
                    List<WareHouseMatDTO> lsv = WareHouseMatDAO.Instance.GetList();
                    List<WareHouseMatDTO> lsvut = lsv.Where(x => x.WeightWH >= int.Parse(quantity[0]) && x.StatusWH==0).ToList();
                    cbLocationInput.DataSource = lsvut;
                    cbLocationInput.DisplayMember = "Name";
                    cbLocationInput.ValueMember = "Id";
                }
                catch (Exception)
                {
                }


            }
        

    }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            MaterialDTO material = MaterialDAO.Instance.GetItem(txtMatCode.Text);
            int idmat = material.Id;
            DateTime dateinput = dtpDateInput.Value;
            float quantityinput =(float.Parse( txtQuantityInput.Text));
            int idwh = int.Parse(cbLocationInput.SelectedValue.ToString());
            int statusinput = 0;
            string styleinput = "new";
            int idem = 1;
            string lot = "";
            string rohs = "";
            string note = "";
            int insert = InputMatDAO.Instance.Insert(idmat, dateinput, quantityinput, idwh, statusinput, styleinput, idem, lot, rohs, note);
            if( insert>0)
            {
                int update = WareHouseMatDAO.Instance.Update(idwh, 1);
            }
            LoadControl();
        }
    }
}