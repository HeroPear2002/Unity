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
using DevExpress.XtraCharts;

namespace DProS.MachineData
{
	public partial class frmCharCheckData : DevExpress.XtraEditors.XtraForm
	{
		public frmCharCheckData()
		{
			InitializeComponent();
			LoadControl();
		}
		void LoadControl()
		{
			LoadMold();
		}
		void LoadMold()
		{
			cbMoldCode.DataSource = MoldDAO.Instance.GetListMold();
			cbMoldCode.DisplayMember = "MoldCode";
			cbMoldCode.ValueMember = "Id";
		}
		private void cbMoldCode_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			string moldcode = cbMoldCode.Text;
			cbMachineCode.DataSource = SetupDefaultDAO.Instance.GetItem(moldcode);
			cbMachineCode.DisplayMember = "MachineCode";
		}
		private void btnView_Click(object sender, EventArgs e)
		{
			LoadChartMain();
		}
		void LoadChartMain()
		{
			DateTime date1 = dtpkDate.Value.Date.AddSeconds(5);
			DateTime date2 = date1.AddDays(1).AddSeconds(-5);
			string moldcode = cbMoldCode.Text;
			string machinecode = cbMachineCode.Text;
			int idmold = int.Parse(cbMoldCode.SelectedValue.ToString());
			int idmachine = MachineDAO.Instance.GetItem(machinecode).Id;
			List<CateDataDefaultDTO> listD = CateDataDefaultDAO.Instance.GetList(idmold, idmachine).OrderByDescending(x => x.Id).ToList();
			List<ChartMachineDataDTO> listChart = new List<ChartMachineDataDTO>();
			List<HistoryCheckDataDTO> listC = DataCheckDAO.Instance.GetList().Where(x => x.DateCheck >= date1 && x.DateCheck <= date2 && x.MoldCode == moldcode && x.MachineCode == machinecode).ToList();
			foreach (HistoryCheckDataDTO item in listC)
			{
				float hour = (float)Math.Round((double)(item.DateCheck.Hour + (item.DateCheck.Minute / 60)), 2);
				listChart.Add(new ChartMachineDataDTO(item.Name, "Giờ : " + hour.ToString(), Math.Round(item.ValueReal, 2).ToString()));
			}
			flpMain.Controls.Clear();
			flpMain.Height = 100 * (listD.Count) + 100;
			foreach (CateDataDefaultDTO item in listD)
			{
				SetupDefaultDTO DTO = SetupDefaultDAO.Instance.GetItem(moldcode, machinecode).Find(x => x.Name == item.Name);
				long idSetup = DTO.Id;
				float valueDefault = DTO.ValueDefault;
				float up = valueDefault + item.UpperLimit;
				float down = valueDefault - item.LowerLimit;
				ChartControl chartSaleHistory = new ChartControl() { Width = flpMain.Width - 200, Height = 200 };
				Series saleSeries = new Series(item.Name, ViewType.Line);
				((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
				((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 3;
				((LineSeriesView)saleSeries.View).Color = Color.DarkGreen;
				foreach (ChartMachineDataDTO item1 in listChart.Where(x => x.Name == item.Name))
				{
					saleSeries.Points.Add(new SeriesPoint(item1.HourMachine, item1.Count));
				}
				chartSaleHistory.Series.Add(saleSeries);
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Text = "Thời Gian(Ngày)";
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Text = "Giá Trị";
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Alignment = AxisAlignment.Zero;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
				((XYDiagram)chartSaleHistory.Diagram).EnableAxisXZooming = true;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MaxValue = up + 3;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MinValue = down - 3;
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

		private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			//GridView view = sender as GridView;
			//if (e.RowHandle >=0)
			//{
			//    string name = view.GetRowCellValue(e.RowHandle, view.Columns["Name"]).ToString();
			//    ChartControl chartSaleHistory = new ChartControl();
			//    Series saleSeries = new Series(name, ViewType.Line);
			//    ((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
			//    ((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 3;
			//    ((LineSeriesView)saleSeries.View).Color = Color.DarkGreen;
			//    //saleSeries.ArgumentDataMember = "DetailData.ReportDate";
			//    //saleSeries.ValueDataMembers.AddRange("DetailData.Sales");
			//    List<DataCheckDTO> listC = DataMachineDAO.Instance.GetListALLDataCheck();
			//    foreach (DataCheckDTO item1 in listC.Where(x => x.Name == name && x.DateCheck >= dtpkDate.Value && x.DateCheck <= dtpkdate2.Value).ToList())
			//    {
			//        saleSeries.Points.Add(new SeriesPoint(item1.DateCheck, Math.Round(item1.ValueReal, 2)));
			//    }
			//    chartSaleHistory.Series.Add(saleSeries);
			//    RepositoryItemAnyControl chartRepositoryItem =
			//       new RepositoryItemAnyControl();
			//    chartRepositoryItem.Control = chartSaleHistory;
			//    GCData.RepositoryItems.Add(chartRepositoryItem);
			//    colSalesHistory.ColumnEdit = chartRepositoryItem;

			//    XYDiagram diag = (XYDiagram)chartSaleHistory.Diagram;
			//    diag.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Manual;
			//    diag.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Hour;
			//    diag.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;
			//    diag.AxisX.DateTimeScaleOptions.AutoGrid = false;
			//    diag.AxisX.DateTimeScaleOptions.GridSpacing = 1;
			//    diag.AxisX.Label.TextPattern = "{Vi:dd/MM HH:mm}";

			//    gridView1.CustomUnboundColumnData += OnCustomUnboundColumnData;
		}

		private void btnViewMonth_Click(object sender, EventArgs e)
		{
			DateTime today = dtpkDate.Value.Date;
			DateTime date1 = today.AddDays(-today.Day - 1);
			DateTime date2 = date1.AddMonths(1).AddSeconds(-5);
			string moldcode = cbMoldCode.Text;
			string machinecode = cbMachineCode.Text;
			int idmold = int.Parse(cbMoldCode.SelectedValue.ToString());
			int idmachine = MachineDAO.Instance.GetItem(machinecode).Id;
			List<CateDataDefaultDTO> listD = CateDataDefaultDAO.Instance.GetList(idmold, idmachine).OrderByDescending(x => x.Id).ToList();
			List<ChartMachineDataDTO> listChart = new List<ChartMachineDataDTO>();
			List<HistoryCheckDataDTO> listC = DataCheckDAO.Instance.GetList().Where(x => x.DateCheck >= date1 && x.DateCheck <= date2 && x.MoldCode == moldcode && x.MachineCode == machinecode).ToList();
			foreach (HistoryCheckDataDTO item in listC)
			{
				float hour = (float)Math.Round((double)(item.DateCheck.Hour + (item.DateCheck.Minute / 60)), 2);
				string hourn = "Ngày:" + item.DateCheck.Day + "-Giờ :" + hour.ToString();
				listChart.Add(new ChartMachineDataDTO(item.Name, hourn, Math.Round(item.ValueReal, 2).ToString()));
			}
			flpMain.Controls.Clear();
			flpMain.Height = 100 * (listD.Count) + 100;
			foreach (CateDataDefaultDTO item in listD)
			{
				SetupDefaultDTO DTO = SetupDefaultDAO.Instance.GetItem(moldcode, machinecode).Find(x => x.Name == item.Name);
				long idSetup = DTO.Id;
				float valueDefault = DTO.ValueDefault;
				float up = valueDefault + item.UpperLimit;
				float down = valueDefault - item.LowerLimit;
				ChartControl chartSaleHistory = new ChartControl() { Width = (flpMain.Width) - 100, Height = 250 };
				Series saleSeries = new Series(item.Name, ViewType.Line);
				saleSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
				((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
				((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 3;
				saleSeries.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
				saleSeries.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
				saleSeries.Label.BackColor = Color.Transparent;
				saleSeries.NumericSummaryOptions.MeasureUnit = 1;
				((LineSeriesView)saleSeries.View).Color = Color.Purple;

				foreach (ChartMachineDataDTO item1 in listChart.Where(x => x.Name == item.Name))
				{
					saleSeries.Points.Add(new SeriesPoint(item1.HourMachine, item1.Count));
				}
				chartSaleHistory.Controls.Clear();
				chartSaleHistory.Series.Add(saleSeries);
				//((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Title.Text = "Thời Gian(Ngày)";
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.Title.Text = "Giá Trị";
				((XYDiagram)chartSaleHistory.Diagram).AxisX.Alignment = AxisAlignment.Zero;
				((XYDiagram)chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
				((XYDiagram)chartSaleHistory.Diagram).EnableAxisXZooming = true;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MaxValue = up;
				((XYDiagram)chartSaleHistory.Diagram).AxisY.WholeRange.MinValue = down;
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

		
	}
}