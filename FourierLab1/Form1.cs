using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace FourierLab1
{
    public partial class Form1 : Form
    {

        private int N = (int)Math.Pow(2, 10);

        public Form1()
        {
            InitializeComponent();
            SetChartType();

            var X = SequenceGen.Generate(N, 0.1, x => Math.Sin(3 * x.Real) + Math.Cos(x.Real));
            DrawGraph(X.Select(x => x.Real).ToArray(), chart1);

            var startTimeDFT = DateTime.Now;
            var directDFT = DFT.Direct(X);
            this.textBox1.Text = (DateTime.Now - startTimeDFT).ToString();

            DrawGraph(directDFT.Select(x => x.Magnitude).ToArray(), chart2);
            DrawGraph(directDFT.Select(x => x.Phase).ToArray(), chart3);
            DrawGraph(DFT.Inverse(directDFT).Select(n => n.Real).ToArray(), chart4);


            var startTimeFFT = DateTime.Now;
            var directFFT = FFT.DecimationInTime(X);
            this.textBox2.Text = (DateTime.Now - startTimeFFT).ToString();


            DrawGraph(directFFT.Select(x => x.Magnitude).ToArray(), chart5);
            DrawGraph(directFFT.Select(x => x.Phase).ToArray(), chart6);

                        
        }

        private void SetChartType()
        {
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart2.Series[0].ChartType = SeriesChartType.Line;
            this.chart3.Series[0].ChartType = SeriesChartType.Line;
            this.chart4.Series[0].ChartType = SeriesChartType.Line;
            this.chart5.Series[0].ChartType = SeriesChartType.Line;
            this.chart6.Series[0].ChartType = SeriesChartType.Line;
        }

        private void DrawGraph(double[] arr, Chart chart)
        {
            for(int i = 0; i < N; i++)
            {
                chart.Series[0].Points.AddXY(i, arr[i]);
            }
        }
    }
}
