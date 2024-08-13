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
using AForge.Video.DirectShow;
using ZXing;

namespace DProS.DeviceManagement
{
	public partial class frmCheckMachineQrCodeCamera : DevExpress.XtraEditors.XtraForm
	{
		FilterInfoCollection filterInfoCollection;
		VideoCaptureDevice captureDevice;
		public frmCheckMachineQrCodeCamera()
		{
			InitializeComponent();
		}
		void LoadControl()
		{
			filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			if (filterInfoCollection.Count > 0)
			{
				foreach (FilterInfo item in filterInfoCollection)
				{
					cbCamera.Items.Add(item.Name);
				}
				cbCamera.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("máy tính không có camera".ToUpper(), "Lối", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbCamera.Enabled = false;
				btnCamera.Enabled = false;
			}
		}
		private void btnCamera_Click(object sender, EventArgs e)
		{
			if (captureDevice != null)
			{
				captureDevice.Stop();
			}
			captureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
			captureDevice.NewFrame += CaptureDevice_NewFrame;
			captureDevice.Start();
			timer1.Start();
		}
		private void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
		{
			picbQrCode.Image = (Bitmap)eventArgs.Frame.Clone();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (picbQrCode.Image != null)
			{
				BarcodeReader barcode = new BarcodeReader();
				Result result = barcode.Decode((Bitmap)picbQrCode.Image);
				if (result != null)
				{
					lblNote.Text = result.ToString();
					//Kun_Static.QrCodeMachine = lblNote.Text;
					timer1.Stop();
					if (captureDevice.IsRunning)
						captureDevice.Stop();
					this.Close();
				}
			}
		}

		private void frmScanCamera_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (captureDevice.IsRunning)
				captureDevice.Stop();
		}
	}
}