using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;


namespace FourierLab2
{
    public partial class Form1 : Form
    {

        private int N = 32;

        public Form1()
        {
            InitializeComponent();
            SetChartType();
            var seqX = FourierLab1.SequenceGen.Generate(N, 1, x => Math.Sin(3 * x.Real));
            var seqY = FourierLab1.SequenceGen.Generate(N, 1, x => Math.Cos(x.Real));

            var convolution = Convolution.Convolute(seqX, seqY).Select(n => n.Magnitude).ToArray();
            DrawGraph(convolution, chart1);

            var convolutionDFT = Convolution.ConvoluteDFT(seqX, seqY).Select(n => n.Magnitude).ToArray();
            DrawGraph(convolutionDFT, chart2);

            var correlationDFT = Correlation.CorrelateDFT(seqX, seqY).Select(n => n.Magnitude).ToArray();
            DrawGraph(correlationDFT, chart3);

            var correlation = Correlation.Correlate(seqX, seqY).Select(n => n.Magnitude).ToArray();
            DrawGraph(correlation, chart4);

        }

        private void SetChartType()
        {
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart2.Series[0].ChartType = SeriesChartType.Line;
            this.chart3.Series[0].ChartType = SeriesChartType.Line;
            this.chart4.Series[0].ChartType = SeriesChartType.Line;
   //         this.chart5.Series[0].ChartType = SeriesChartType.Line;
   //         this.chart6.Series[0].ChartType = SeriesChartType.Line;
        }

        private void DrawGraph(double[] arr, Chart chart)
        {
            for (int i = 0; i < N; i++)
            {
                chart.Series[0].Points.AddXY(i, arr[i]);
            }
        }
    }
}
