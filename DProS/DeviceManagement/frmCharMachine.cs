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
using DevExpress.XtraCharts;

namespace DProS.DeviceManagement
{
	public partial class frmCharMachine : DevExpress.XtraEditors.XtraForm
	{
		public frmCharMachine()
		{
			InitializeComponent();
			LoadControl();
		}
		void LoadControl()
		{
			LoadMachine();
		}
		void LoadMachine()
		{
			cbMachineCode.DataSource = MachineDAO.Instance.GetList();
			cbMachineCode.DisplayMember = "MachineCode";
			cbMachineCode.ValueMember = "Id";
		}
		void LoadChartShort(DateTime date1, DateTime date2, int idMachine)
		{
			List<HistoryDeviceDTO> listC = new List<HistoryDeviceDTO>();
			List<CateTestMachineDTO>  listCa = new List<CateTestMachineDTO>();
			listCa = CateTestMachineDAO.Instance.GetListCateHis(date1, date2, idMachine).Where(x => x.Timer == 24 && x.StatusCate == 1).ToList();
			string machineCode = MachineDAO.Instance.GetItem(idMachine).MachineCode;
			listC = HistoryDeviceDAO.Instance.GetList().Where(x => x.DateCheck > date1 && x.DateCheck < date2 && x.MachineCode == machineCode && x.Timer == 24).OrderBy(x => x.DateCheck).ToList();
			flpMain.Controls.Clear();
			int a = 100 * (listCa.Count) + 100;
			int height = this.Height - 45;
			if (a < height)
			{
				flpMain.Height = height;
			}
			else
			{
				flpMain.Height = a;
			}
			int i = 0;
			foreach (CateTestMachineDTO item in listCa)
			{
				i++;
				string detailString = item.Detail;
				string[] array = detailString.Split('~');
				float down = (float)Convert.ToDouble(array[0].Trim());
				float up = (float)Convert.ToDouble(array[1].Trim());
				if (item.Limit != "")
				{
					up += (float)Convert.ToDouble(item.Limit);
					down -= (float)Convert.ToDouble(item.Limit);
				}
				ChartControl chartSaleHistory = new ChartControl() { Width = flpMain.Width - 200, Height = 200 };
				Series saleSeries = new Series(item.NameCategory, ViewType.Line);
				((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
				((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 5;
				switch (i)
				{
					case 1:
						((LineSeriesView)saleSeries.View).Color = Color.Green;
						break;
					case 2:
						((LineSeriesView)saleSeries.View).Color = Color.Blue;
						break;
					case 3:
						((LineSeriesView)saleSeries.View).Color = Color.Orange;
						break;
					case 4:
						((LineSeriesView)saleSeries.View).Color = Color.Purple;
						break;
					case 5:
						((LineSeriesView)saleSeries.View).Color = Color.Pink;
						break;
					case 6:
						((LineSeriesView)saleSeries.View).Color = Color.Aqua;
						break;
					default:
						((LineSeriesView)saleSeries.View).Color = Color.LightSalmon;
						break;
				}
				foreach (HistoryDeviceDTO item1 in listC.Where(x => x.NameCategory == item.NameCategory))
				{
					saleSeries.Points.Add(new SeriesPoint(item1.DateCheck.Day, Math.Round(double.Parse(item1.DataCount), 2)));
				}
				chartSaleHistory.Series.Add(saleSeries);
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Text = "Ngày";
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Alignment = AxisAlignment.Near;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Text = "Giá Trị";
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Alignment = AxisAlignment.Near;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
				((XYDiagram)chartSaleHistory.Diagram).EnableAxisXZooming = true;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MaxValue = up + (up / 100) * 30;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MinValue = down - (down / 2);
				int dem = 0;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Clear();
				if (dem <= 2)
				{
					#region Constant Line
					// Create a constant line.              
					ConstantLine constantLine1 = new ConstantLine("Giới hạn trên");
					((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Add(constantLine1);
					dem++;
					// Define its axis value.
					constantLine1.AxisValue = up;
					// Customize the behavior of the constant line.
					constantLine1.Visible = true;
					constantLine1.ShowInLegend = false;
					constantLine1.LegendText = "Giới hạn trên";
					constantLine1.ShowBehind = false;

					constantLine1.Color = Color.Red;
					constantLine1.LineStyle.DashStyle = DashStyle.Dash;
					constantLine1.LineStyle.Thickness = 2;

					ConstantLine constantLine2 = new ConstantLine("Giới hạn dưới");
					((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Add(constantLine2);
					dem++;
					// Define its axis value.
					constantLine2.AxisValue = down;

					// Customize the behavior of the constant line.
					constantLine2.Visible = true;
					constantLine2.ShowInLegend = false;
					constantLine2.LegendText = "Giới hạn dưới";
					constantLine2.ShowBehind = false;
					constantLine2.Color = Color.Yellow;
					constantLine2.LineStyle.DashStyle = DashStyle.Dash;
					constantLine2.LineStyle.Thickness = 2;
					#endregion
				}
				else
				{
					((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Clear();
				}
				flpMain.Controls.Add(chartSaleHistory);
			}

		}
		void LoadChartLong(DateTime date1, DateTime date2, int idMachine)
		{
			List<HistoryDeviceDTO> listC = new List<HistoryDeviceDTO>();
			List<CateTestMachineDTO> listCa = new List<CateTestMachineDTO>();
			listCa = CateTestMachineDAO.Instance.GetListCateHis(date1, date2, idMachine).Where(x => x.Timer > 24 && x.StatusCate == 1).ToList();
			string machineCode = MachineDAO.Instance.GetItem(idMachine).MachineCode;
			listC = HistoryDeviceDAO.Instance.GetList().Where(x => x.DateCheck > date1 && x.DateCheck < date2 && x.MachineCode == machineCode && x.Timer > 24).OrderBy(x => x.DateCheck).ToList();
			flpMain.Controls.Clear();
			int a = 100 * (listCa.Count) + 100;
			int height = this.Height - 45;
			if (a < height)
			{
				flpMain.Height = height;
			}
			else
			{
				flpMain.Height = a;
			}
			int i = 0;
			foreach (CateTestMachineDTO item in listCa)
			{
				i++;
				string detailString = item.Detail;
				string[] array = detailString.Split('~');
				float down = (float)Convert.ToDouble(array[0].Trim());
				float up = (float)Convert.ToDouble(array[1].Trim());
				if (item.Limit != "")
				{
					up += (float)Convert.ToDouble(item.Limit);
					down -= (float)Convert.ToDouble(item.Limit);
				}
				ChartControl chartSaleHistory = new ChartControl() { Width = flpMain.Width - 200, Height = 300 };
				Series saleSeries = new Series(item.NameCategory, ViewType.Line);
				((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
				((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 5;
				((LineSeriesView)saleSeries.View).Color = Color.Green;
				switch (i)
				{
					case 1:
						((LineSeriesView)saleSeries.View).Color = Color.Green;
						break;
					case 2:
						((LineSeriesView)saleSeries.View).Color = Color.Blue;
						break;
					case 3:
						((LineSeriesView)saleSeries.View).Color = Color.Orange;
						break;
					case 4:
						((LineSeriesView)saleSeries.View).Color = Color.Purple;
						break;
					case 5:
						((LineSeriesView)saleSeries.View).Color = Color.Pink;
						break;
					case 6:
						((LineSeriesView)saleSeries.View).Color = Color.Aqua;
						break;
					default:
						((LineSeriesView)saleSeries.View).Color = Color.LightSalmon;
						break;
				}
				foreach (HistoryDeviceDTO item1 in listC.Where(x => x.NameCategory == item.NameCategory))
				{
					saleSeries.Points.Add(new SeriesPoint(item1.DateCheck, Math.Round(double.Parse(item1.DataCount), 2)));
				}
				chartSaleHistory.Series.Add(saleSeries);
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Text = "Ngày";
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Text = "Giá Trị";
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Alignment = AxisAlignment.Near;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
				((XYDiagram)chartSaleHistory.Diagram).EnableAxisXZooming = true;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MaxValue = up + (up / 100) * 30;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MinValue = down - (down / 2);
				int dem = 0;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Clear();
				if (dem <= 2)
				{
					#region Constant Line
					// Create a constant line.              
					ConstantLine constantLine1 = new ConstantLine("Giới hạn trên");
					((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Add(constantLine1);
					dem++;
					// Define its axis value.
					constantLine1.AxisValue = up;
					// Customize the behavior of the constant line.
					constantLine1.Visible = true;
					constantLine1.ShowInLegend = false;
					constantLine1.LegendText = "Giới hạn trên";
					constantLine1.ShowBehind = false;

					constantLine1.Color = Color.Red;
					constantLine1.LineStyle.DashStyle = DashStyle.Dash;
					constantLine1.LineStyle.Thickness = 2;

					ConstantLine constantLine2 = new ConstantLine("Giới hạn dưới");
					((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Add(constantLine2);
					dem++;
					// Define its axis value.
					constantLine2.AxisValue = down;

					// Customize the behavior of the constant line.
					constantLine2.Visible = true;
					constantLine2.ShowInLegend = false;
					constantLine2.LegendText = "Giới hạn dưới";
					constantLine2.ShowBehind = false;
					constantLine2.Color = Color.Yellow;
					constantLine2.LineStyle.DashStyle = DashStyle.Dash;
					constantLine2.LineStyle.Thickness = 2;
					#endregion
				}
				else
				{
					((XYDiagram)chartSaleHistory.Diagram).AxisY.ConstantLines.Clear();
				}
				flpMain.Controls.Add(chartSaleHistory);
			}

		}

		private void btnHMChartEveryday_Click(object sender, EventArgs e)
		{
			DateTime today = dtpMonthYear.Value.Date;
			DateTime date1 = today.AddDays(-(today.Day - 1));
			DateTime date2 = date1.AddMonths(1).AddMinutes(-1);
			LoadChartShort(date1, date2, int.Parse(cbMachineCode.SelectedValue.ToString()));
		}

		private void btnHMChartMainten_Click(object sender, EventArgs e)
		{
			DateTime today = dtpMonthYear.Value.Date;
			DateTime date1 = today.AddDays(-(today.Day - 1));
			DateTime date2 = date1.AddMonths(1).AddMinutes(-1);
			LoadChartLong(date1, date2, int.Parse(cbMachineCode.SelectedValue.ToString()));
		}
	}
}