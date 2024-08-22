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
using DTO;
using DAO;

namespace DProS.WareHouseMat
{
    public partial class frmWareHouseMat : DevExpress.XtraEditors.XtraForm
    {
        public frmWareHouseMat()
        {
            InitializeComponent();
            LoadControl();
        }
        public string matcodeoutput = "";
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
            txtWeightInput.Text = string.Empty;
            cbNameInputMat.Text = string.Empty;

            txtInventory.Text = string.Empty;
            txtOutputCode.Text = string.Empty;
            txtWeightOutput.Text = string.Empty;
            cbNameWH.Text = string.Empty;
            dtpDateOutput.Text = string.Empty;
        }

        private void LockControl()
        {
            LockControlInput(true);
            LockControlOutput(true);
        }

        private void LockControlOutput(bool v)
        {
            if (v)
            {
                txtOutputCode.Enabled = false;
                txtWeightOutput.Enabled = false;
                txtInventory.Enabled = false;
                dtpDateOutput.Enabled = false;
                cbNameWH.Enabled = false;
                btnOutputMat.Enabled = true;
                btnOutputMatMix.Enabled = true;
                btnSaveOutput.Enabled = false;
            }
            else
            {
                txtOutputCode.Enabled = true;
                txtWeightOutput.Enabled = true;
                txtInventory.Enabled = false;
                dtpDateOutput.Enabled = true;
                cbNameWH.Enabled = false;
                btnOutputMat.Enabled = false;
                btnOutputMatMix.Enabled = false;
                btnSaveOutput.Enabled = true;
            }
        }

        private void LockControlInput(bool v)
        {
            if (v)
            {
                txtTemCode.Enabled = false;
                txtWeightInput.Enabled = false;
                txtMatCode.Enabled = false;
                dtpDateInput.Enabled = false;
                cbNameInputMat.Enabled = false;
                btnInputmat.Enabled = true;
                btnInputTry.Enabled = true;
                btnSaveInput.Enabled = false;
            }
            else
            {
                txtTemCode.Enabled = true;
                txtWeightInput.Enabled = false;
                txtMatCode.Enabled = false;
                dtpDateInput.Enabled = true;
                cbNameInputMat.Enabled = true;
                btnInputTry.Enabled = false;
                btnInputmat.Enabled = false;
                btnSaveInput.Enabled = true;
            }

        }

        int widthbtn = 0;
        private void LoadLayout()
        {
            pContainerLayout.Controls.Clear();
            object MaxRow = WareHouseMatDAO.Instance.GetMaxRow();
            int MaxRowint = 0;
            if (MaxRow.ToString() != "")
            {
                MaxRowint = int.Parse(MaxRow.ToString());
                widthbtn = (pContainerLayout.Width - 10) / (MaxRowint + 1);
                for (int i = 0; i < MaxRowint; i++)
                {
                    Button bt = new Button();
                    bt.Text = (i + 1).ToString();
                    bt.Name = (i + 1).ToString();
                    bt.BackColor = Color.White;
                    bt.Location = new Point((i + 1) * widthbtn + 10, 0);
                    bt.Width = widthbtn;
                    bt.Height = widthbtn;
                    pContainerLayout.Controls.Add(bt);
                }
                List<string> NameRow = WareHouseMatDAO.Instance.GetHeader();
                int height = widthbtn;
                foreach (string item in NameRow)
                {
                    Button bt = new Button();
                    bt.Text = item;
                    bt.Name = item;
                    bt.Location = new Point(0, height + 10);
                    bt.Width = widthbtn;
                    bt.Height = widthbtn;
                    bt.BackColor = Color.White;
                    pContainerLayout.Controls.Add(bt);
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
                        btcon.Location = new Point(locaX * widthbtn + 10, height + 10);
                        btcon.Width = widthbtn;
                        btcon.Height = widthbtn;
                        int status = itemWH.StatusWH;
                        switch (status)
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
                                btcon.BackColor = Color.FromArgb(255, 192, 192);
                                break;
                            case 6://NL qua 2 nam
                                btcon.BackColor = Color.Black;
                                break;
                            case 7://NL chan sang
                                btcon.BackColor = Color.Purple;
                                break;
                            case 8://NL dang khoa cso hang
                                btcon.BackColor = Color.FromArgb(255, 128, 0);
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
                        //    btcon.Click += Btcon_Click;
                        pContainerLayout.Controls.Add(btcon);
                        if (int.Parse(vitri[1]) % MaxRowint == 0 || int.Parse(vitri[1]) == int.Parse((vitrimx[1])))
                        {
                            height += (widthbtn);
                        }
                    }
                    height += 5;
                }
            }
        }

        private void frmWareHouseMat_SizeChanged(object sender, EventArgs e)
        {
            pContainerLayout.Width = this.Width - pContainerInput.Width - 10;
            pContainerLayout.Height = this.Height - pEnvent.Height - 10;
            pEnvent.Width = this.Width - pContainerInput.Width - 10;

        }

        private void pContainerLayout_SizeChanged(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnLayoutMatDetail_Click(object sender, EventArgs e)
        {
            frmLayoutMatDetail f = new frmLayoutMatDetail();
            f.ShowDialog();
            LoadControl();
        }

        private void btnPCCheck_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnReMat_Click(object sender, EventArgs e)
        {
            frmImpEmCode f = new frmImpEmCode("rec");
            f.ShowDialog();
            int idem = Common.CommonStatic.IdEmStaticRec;
            EmployessDTO em = EmployessDAO.Instance.GetItem(idem);
            if (em != null)
            {
                frmImpMatRecycle frm = new frmImpMatRecycle();
                frm.ShowDialog();
            }


        }

        private void btnMixMat_Click(object sender, EventArgs e)
        {
            frmImpEmCode f = new frmImpEmCode("mix");
            f.ShowDialog();
            int idem = Common.CommonStatic.IdEmStaticMix;
            EmployessDTO em = EmployessDAO.Instance.GetItem(idem);
            if (em != null)
            {
                frmImpMixMat frm = new frmImpMixMat();
                frm.ShowDialog();
            }

        }

        private void btnSettup_Click(object sender, EventArgs e)
        {
            frmCreateLayOutMat f = new frmCreateLayOutMat();
            f.ShowDialog();
            LoadLayout();
        }

        private void btnInputmat_Click(object sender, EventArgs e)
        {
            frmImpEmCode f = new frmImpEmCode("new");
            f.ShowDialog();
            int idem = Common.CommonStatic.IdEmStatic;
            EmployessDTO em = EmployessDAO.Instance.GetItem(idem);
            if (em != null)
            {
                LockControlInput(false);
            }
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            #region Nhập mới nhựa tinh    
            #region Kiem tra ma nhuwa
            MaterialDTO material = MaterialDAO.Instance.GetItem(txtMatCode.Text);
            if (material == null)
            {
                MessageBox.Show("Sai mã nguyên liệu.", "THÔNG BÁO");
                return;
            }
            int idmat = material.Id;
            #endregion

            DateTime dateinput = dtpDateInput.Value;
            float quantityinput;
            try
            {
                quantityinput = (float.Parse(txtWeightInput.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Sai định dạng số lượng nhập.", "THÔNG BÁO");
                return;
            }
            RatioMaterialDTO ratio = RatioMaterialDAO.Instance.Getitem(txtMatCode.Text);
            float wetghtRe = float.Parse(ratio.RatioInput.ToString()) * quantityinput / 100;
            if (wetghtRe % 1 != 0)
            {
                wetghtRe = wetghtRe - wetghtRe % 1 + 1;
            }
            int idwh = int.Parse(cbNameInputMat.SelectedValue.ToString());
            WareHouseMatDTO whDTO = WareHouseMatDAO.Instance.GetItem(idwh);
            string namewh = whDTO.Name;
            int statusinput = 0;
            string styleinput = "new";
            int idem = Common.CommonStatic.IdEmStatic;
            string lot = "";
            string rohs = "";
            string note = "";
            string thongbao = "";
            int insert = InputMatDAO.Instance.Insert(idmat, dateinput, quantityinput, quantityinput, idwh, statusinput, styleinput, idem, lot, rohs, note);
            if (insert > 0)
            {
                #region Kieemr tra vi tri dac biet con hang tai che hay khong
                List<InputMatDTO> LsvInputMat = InputMatDAO.Instance.GetlistMatByCodeByStyle(txtMatCode.Text, "rec");
                if (LsvInputMat != null)
                {
                    foreach (InputMatDTO item in LsvInputMat)
                    {
                        wetghtRe = wetghtRe - item.QuantityInventory;
                        if (wetghtRe >= 0)
                        {
                            InputMatDTO inputMatDTO = InputMatDAO.Instance.GetitemMat(idwh);
                            int InsertMatre = InputMatRecycleDAO.Instance.Insert(inputMatDTO.Id, item.QuantityInventory, item.QuantityInventory, 0, dateinput, idem, "");
                            int InsertOutMatRe = InputMatDAO.Instance.UpdateStatus(item.Id, 1, 0);
                            int updateMatRe = WareHouseMatDAO.Instance.Update(item.IdWH, 11);
                            int outputMatRe = OutputMatDAO.Instance.Insert(item.Id, dateinput, item.QuantityInventory, "rec", idem, 0, 0, "", "rec");
                            WareHouseMatDTO wareHouseMatDTO = WareHouseMatDAO.Instance.GetItem(item.IdWH);
                            thongbao += "Lấy ở vị trí :  " + wareHouseMatDTO.Name + ".  Số lượng:  " + item.QuantityInventory + "(kg).  Mang tới  vị trí :  " + namewh + "\n";
                            if (wetghtRe == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            InputMatDTO inputMatDTO = InputMatDAO.Instance.GetitemMat(idwh);
                            float inventory = item.QuantityInventory + wetghtRe;
                            int InsertMatre = InputMatRecycleDAO.Instance.Insert(inputMatDTO.Id, inventory, inventory, 0, dateinput, idem, "");
                            int InsertOutMatRe = InputMatDAO.Instance.UpdateStatus(item.Id, 0, -wetghtRe);
                            int outputMatRe = OutputMatDAO.Instance.Insert(item.Id, dateinput, inventory, "rec", idem, 0, 0, "", "rec");
                            WareHouseMatDTO wareHouseMatDTO = WareHouseMatDAO.Instance.GetItem(item.IdWH);
                            thongbao += "Lấy ở vị trí :  " + wareHouseMatDTO.Name + ".  Số lượng:  " + inventory + "(kg).  Mang tới  vị trí :  " + namewh + "\n";
                            break;
                        }
                    }
                    MessageBox.Show(thongbao);
                }
                #endregion
                int update = WareHouseMatDAO.Instance.Update(idwh, 1);
            }
            LoadControl();
            #endregion
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
                txtWeightInput.Text = quantity[0].ToString();
                try
                {
                    List<WareHouseMatDTO> lsv = WareHouseMatDAO.Instance.GetList();
                    List<WareHouseMatDTO> lsvut = lsv.Where(x => x.WeightWH >= int.Parse(quantity[0]) && x.StatusWH == 0).ToList();
                    cbNameInputMat.DataSource = lsvut;
                    cbNameInputMat.DisplayMember = "Name";
                    cbNameInputMat.ValueMember = "Id";
                }
                catch (Exception)
                {
                }
            }
        }
        // MaterialCode + "&" + PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + CountBox + "&" + FactoryCode +"&"+id;
        private void btnOutputMat_Click(object sender, EventArgs e)
        {
            LockControlOutput(false);
        }

        private void btnOutputMatMix_Click(object sender, EventArgs e)
        {
            LockControlOutput(false);
        }

        private void txtOutputCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //DD220601011 & 30C0D17220 & M20 & 1 & 4 & D1 & 168430// Mã nl-mã lk- mã máy-""-""-mã nhà máy- mã chỉ thị
            char key = e.KeyChar;

            matcodeoutput = "";
            if (key == '_')
            {
                #region Kiểm tra trong vị trí đặc biệt
                string[] arrcode = txtOutputCode.Text.Split('&');
                string matcode = arrcode[0];
                matcodeoutput = matcode;
                InputMatDTO MatMix = InputMatDAO.Instance.GetItemMatByCodeByStyle(matcode, "mix");
                if (MatMix != null)
                {
                    WareHouseMatDTO wareHouseMatDTO = WareHouseMatDAO.Instance.GetItem(MatMix.IdWH);
                    List<WareHouseMatDTO> Lsvware = new List<WareHouseMatDTO>();
                    Lsvware.Add(wareHouseMatDTO);
                    cbNameWH.DataSource = Lsvware;
                    cbNameWH.DisplayMember = "Name";
                    cbNameWH.ValueMember = "Id";
                    txtInventory.Text = MatMix.QuantityInventory.ToString();
                    return;
                }
                #endregion
                #region Vị trí đặc biệt không có hàng mới qua vị trị nhựa tinh

                InputMatDTO inputmat = InputMatDAO.Instance.GetItemMatByCodeByStyle(matcode, "new");
                if (inputmat == null)
                {
                    MessageBox.Show("Mã nguyên liệu không đúng hoặc nguyên liệu đã hết", "CẢNH BÁO");
                    return;
                }
                float weight = inputmat.QuantityInventory;
                List<InputMatRecycleDTO> Lsvre = InputMatRecycleDAO.Instance.GetListByIdInput(inputmat.Id);
                foreach (InputMatRecycleDTO item in Lsvre)
                {
                    weight += item.QuantityInventory;
                }
                List<InputMatMixDTO> LsvMix = InputMatMixDAO.Instance.GetListLive(inputmat.Id);
                foreach (InputMatMixDTO item in LsvMix)
                {
                    weight += item.QuantityInventory;
                }
                WareHouseMatDTO wareHouseMat = WareHouseMatDAO.Instance.GetItem(inputmat.IdWH);
                List<WareHouseMatDTO> LsvwareDTO = new List<WareHouseMatDTO>();
                LsvwareDTO.Add(wareHouseMat);
                cbNameWH.DataSource = LsvwareDTO;
                cbNameWH.DisplayMember = "Name";
                cbNameWH.ValueMember = "Id";
                txtInventory.Text = weight.ToString();
                #endregion



            }
        }

        private void txtWeightOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            // Kiểm tra xem ký tự có phải là số hay không
            if (!Char.IsDigit(keyChar) && keyChar != ' ' && keyChar != 8)
            {
                // Ngăn không cho ký tự đó được nhập vào textbox
                e.Handled = true;
            }
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            //DD220601011 & 30C0D17220 & M20 & 1 & 4 & D1 & 168430// Mã nl-mã lk- mã máy-""-""-mã nhà máy- mã chỉ thị
            string[] ArrCode = txtOutputCode.Text.Split('&');
            float Weight = float.Parse(txtWeightOutput.Text);
            int idem = Common.CommonStatic.IdEmStatic;
            string matcode = ArrCode[0];
            MaterialDTO material = MaterialDAO.Instance.GetItem(matcode);
            string partCode = ArrCode[1];
            PartDTO part = PartDAO.Instance.GetItemByPartCode(partCode);
            string machineCode= ArrCode[2];
            int idmachine = 1;
            string name = "";
            float weightmat = 0;
            float weightmix = 0;
            float weightre = 0;
            
            float weightmatre = Weight;
            if (float.Parse(txtInventory.Text) >= Weight)
            {
                int idwh = int.Parse(cbNameWH.SelectedValue.ToString());
                WareHouseMatDTO whMat = WareHouseMatDAO.Instance.GetItem(idwh);
                name = whMat.Name;
                InputMatDTO input = InputMatDAO.Instance.GetitemAllMat(idwh);
                float inventory = float.Parse(txtInventory.Text) - Weight;
                int status = whMat.StatusWH;
                if (status == 10)
                {
                    if (inventory == 0)
                    {
                        weightmix = Weight;                      
                    }
                    else
                    {
                        weightmix = Weight;
                        int updateInput = InputMatDAO.Instance.UpdateStatus(input.Id, 0, inventory);
                    }
                }
                else
                {
                    List<InputMatMixDTO> Lsvmix = InputMatMixDAO.Instance.GetListLive(input.Id);
                    List<InputMatRecycleDTO> LsvRe = InputMatRecycleDAO.Instance.GetListByIdInput(input.Id);
                    RatioMaterialDTO ratio = RatioMaterialDAO.Instance.Getitem(matcode);

                    if (inventory == 0)
                    {
                        if (Lsvmix.Count != 0)
                        {
                            foreach (InputMatMixDTO item in Lsvmix)
                            {
                                weightmix += item.QuantityInventory;
                            }
                            weightmatre = weightmatre - weightmix;
                        }
                        if (LsvRe.Count != 0)
                        {
                            foreach (InputMatRecycleDTO item in LsvRe)
                            {
                                weightre += item.QuantityInventory;
                            }
                            weightmat = weightmatre - weightre;
                        }
                        else
                        {
                            weightmat = weightmatre;
                        }

                    }
                    else
                    {
                        if (Lsvmix.Count > 0)
                        {
                            float weightcontru = 0;
                            float weightConvert = Weight;
                            foreach (InputMatMixDTO item in Lsvmix)
                            {
                                if (weightConvert - item.QuantityInventory >= 0)
                                {
                                    weightcontru += item.QuantityInventory;
                                    weightConvert = weightConvert - item.QuantityInventory;
                                    if (weightConvert == 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    weightcontru += weightConvert;
                                }
                            }
                            weightmix = weightcontru;
                            weightmatre = Weight - weightmix;
                        }

                        if (LsvRe.Count != 0)
                        {
                            float weightcontru = 0;
                            float weightConvert = weightmatre;
                            foreach (InputMatRecycleDTO item in LsvRe)
                            {
                                if (weightConvert - item.QuantityInventory >= 0)
                                {
                                    weightcontru += item.QuantityInventory;
                                    weightConvert = weightConvert - item.QuantityInventory;
                                    if (weightConvert == 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    weightcontru += weightConvert;
                                }
                            }
                            weightre = weightcontru;
                        }
                        weightmat = weightmatre - weightre;
                    }
                }
                string msg1 = string.Format(" Mã Nguyên liệu : {0}\n\n tên nguyên liệu : {1}\n\n số lượng xuất : {2} kg nhựa hỗn hợp \n\n số lượng xuất : {3} kg nhựa tái chế \n\n số lượng xuất : {4} kg nhựa tinh \n\n ngày xuất : {5}\n\n Vị trí : {6}", matcode, material.MatName, weightmix, weightre, weightmat, dtpDateOutput.Value, name);
                MessageBox.Show(msg1);
                string[] ArrOutput = new string[] {matcode,material.MatCode, partCode, weightmix.ToString(), weightre.ToString(), weightmat.ToString(), dtpDateOutput.Value.ToString(), name,idwh.ToString(),machineCode,status.ToString() };
                frmUserOutput f = new frmUserOutput(ArrOutput);
                f.ShowDialog();
                LoadControl();
            }
            else
            {
                MessageBox.Show("Số lượng xuất quá lớn, kiểm tra lại");
            }

        }
    }
}