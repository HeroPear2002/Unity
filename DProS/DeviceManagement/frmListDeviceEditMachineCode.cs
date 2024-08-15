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
using DevExpress.XtraGrid.Columns;

namespace DProS.DeviceManagement
{
	public partial class frmListDeviceEditMachineCode : DevExpress.XtraEditors.XtraForm
	{
		List<MachineDTO> lisMachine = new List<MachineDTO>();
		public frmListDeviceEditMachineCode()
		{
			InitializeComponent();
			LoadGridLookUp();
		}
		private void LoadGridLookUp()
		{
			lisMachine = MachineDAO.Instance.GetList();
			glMachineCode.Properties.DataSource = lisMachine;
			glMachineCode.Properties.DisplayMember = "MachineCode";
			glMachineCode.Properties.ValueMember = "Id";
			glMachineCode.Properties.Popup += (sender, e) =>
			{
				var view = glMachineCode.Properties.View;
				foreach (GridColumn column in view.Columns)
				{
					if (column.FieldName == "MachineCode" || column.FieldName == "MachineName")
					{
						column.Visible = true;
					} 
					else column.Visible = false;
				}
			};
			glMachineCode.EditValue = lisMachine[0].Id;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("BẠN MUỐN LƯU BẢN GHI NÀY?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				string machineCode = txtMachineCodeNew.Text;
				int id = int.Parse(glMachineCode.EditValue.ToString());
				if (lisMachine.Find(x => x.MachineCode == machineCode) == null)
				{
					bool updateMachineCode = MachineDAO.Instance.Update(id, machineCode);
					if (updateMachineCode) MessageBox.Show("BẠN ĐÃ LƯU THÀNH CÔNG.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else MessageBox.Show("BẠN LƯU THẤT BẠI.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
					LoadGridLookUp();
				}
			}
			
		}

		private void txtMachineCodeNew_TextChanged(object sender, EventArgs e)
		{
			if (txtMachineCodeNew.Text == "") btnSave.Enabled = false;
			else btnSave.Enabled = true;
		}
	}
}