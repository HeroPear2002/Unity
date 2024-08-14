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

namespace DProS.MachineData
{
	public partial class frmWeather : DevExpress.XtraEditors.XtraForm
	{
		List<WeatherDTO> listWeather = new List<WeatherDTO>();
		List<LocationDTO> listLocation = new List<LocationDTO>();
		bool Insert = true;
		public frmWeather()
		{
			InitializeComponent();
			LoadComboBox();
			LoadControl();
		}

		private void LoadComboBox()
		{
			listLocation = LocationDAO.Instance.GetList();
			cbLocation.DataSource = listLocation;
			cbLocation.DisplayMember = "Name";
			cbLocation.ValueMember = "Id";
		}

		private void LoadControl()
		{
			LoadData();
			LockControl(true);
			CleanText();

		}

		private void CleanText()
		{
			cbLocation.Text = string.Empty;
			txtTemperature.Text = string.Empty;
			txtHumidity.Text = string.Empty;
		}

		private void LockControl(bool lockcontrol)
		{
			if (lockcontrol)
			{
				cbLocation.Enabled = false;
				txtTemperature.Enabled = false;
				txtHumidity.Enabled = false;
				btnInsert.Enabled = true;
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
				btnSave.Enabled = false;
			}
			else
			{
				cbLocation.Enabled = true;
				txtTemperature.Enabled = true;
				txtHumidity.Enabled = true;
				btnInsert.Enabled = false;
				btnEdit.Enabled = false;
				btnDelete.Enabled = false;
				btnSave.Enabled = true;
			}
		}

		private void LoadData()
		{
			listWeather = WeatherDAO.Instance.GetList();
			gcWeather.DataSource = listWeather;
		}
		private void Save()
		{
			int idLocation = 0;
			float temperature = 0;
			float humidity = 0;
			if (cbLocation.Text == "")
			{
				MessageBox.Show("BẠN PHẢI CHỌN VỊ TRÍ.");
				return;
			}
			else if(txtTemperature.Text == "")
			{
				MessageBox.Show("BẠN PHẢI ĐIỀN NHIỆT ĐỘ");
				return;
			}
			else if (txtHumidity.Text == "" && (float.Parse(txtHumidity.Text) < 0 || float.Parse(txtHumidity.Text) >100))
			{
				MessageBox.Show("BẠN PHẢI ĐIỀN ĐỘ ẨM");
				return;
			}
			else
			{
				idLocation = int.Parse(cbLocation.SelectedValue.ToString());
				temperature = float.Parse(txtTemperature.Text);
				humidity = float.Parse(txtHumidity.Text);
			}
			if (Insert)
			{
				bool insert = WeatherDAO.Instance.Insert(idLocation, temperature, humidity, DateTime.Now, 1);
				if (insert)
				{
					MessageBox.Show("Bạn đã thêm thành công.".ToUpper());
					return;
				}
				MessageBox.Show("Bạn thêm bị thất bại.".ToUpper());
			}
			else
			{
				int id = int.Parse(gvWeather.GetFocusedRowCellValue("Id").ToString());
				bool update = WeatherDAO.Instance.Update(id, idLocation, temperature, humidity);
				if (update)
				{
					MessageBox.Show("Bạn đã sửa thành công.".ToUpper());
					return;
				}
				MessageBox.Show("Bạn sửa bị thất bại.".ToUpper());
			}
		}
		private void btnInsert_Click(object sender, EventArgs e)
		{
			Insert = true;
			LockControl(false);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Insert = false;
			LockControl(false);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?".ToUpper(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				int countid = 0;
				foreach (var item in gvWeather.GetSelectedRows())
				{
					int id = int.Parse(gvWeather.GetRowCellValue(item, "Id").ToString());
					bool delete = WeatherDAO.Instance.Delete(id);
					if (delete) countid++;
				}
				if (countid > 0) MessageBox.Show("Bạn đã xóa thành công.".ToUpper());
				else MessageBox.Show("XÓA KHÔNG THÀNH CÔNG, BẠN PHẢI CHỌN HÀNG TRƯỚC KHI XÓA");
			}
			LoadControl();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Save();
			LoadControl();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadControl();
		}

		private void gvWeather_Click(object sender, EventArgs e)
		{
			try
			{
				cbLocation.Text = gvWeather.GetFocusedRowCellValue("Name").ToString();
				txtTemperature.Text = gvWeather.GetFocusedRowCellValue("Temperature").ToString();
				txtHumidity.Text = gvWeather.GetFocusedRowCellValue("Humidity").ToString();
			}
			catch (Exception)
			{


			}
		}
	}
}