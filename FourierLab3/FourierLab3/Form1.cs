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



namespace FourierLab3
{
    public partial class Form1 : Form
    {

        private int N = 32;

        public Form1()
        {
            InitializeComponent();
            SetChartType();

            var seq = FourierLab1.SequenceGen.Generate(N, 1, x => Math.Sin(2 * x.Real) + Math.Cos(3 *x.Real)).Select(x => x.Real).ToList();
            DrawGraph(seq.ToArray(), chart1);

            var fwt = new FWT(N);
            var seqT = fwt.Transform(seq);
            DrawGraph(seqT.ToArray(), chart2);
        }

        private void SetChartType()
        {
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart2.Series[0].ChartType = SeriesChartType.Line;
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
