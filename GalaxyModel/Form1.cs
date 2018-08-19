using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyModel
{
    public partial class Form1 : Form
    {
        private PlotForm _galaxyPlotForm = new PlotForm();

        public Form1()
        {
            InitializeComponent();

            _GeneratePlot();
        }

        protected override void OnShown(EventArgs e)
        {
            _galaxyPlotForm.Show();
            base.OnShown(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _GeneratePlot();
        }

        private void _GeneratePlot()
        {
            this.Cursor = Cursors.WaitCursor;
            var boxRadius = (double)this.numResolution.Value / 2.0;
            double ws = 0.0;
            double.TryParse(txtWs.Text, out ws);

            var newPlot = new PolarPlot(boxRadius);

            double galaxyRadius = boxRadius / 2.0;
            double galaxyHeight = galaxyRadius / 20.0;
            double bulgeRadius = galaxyRadius * 5.0;
            double Ls = 50.0;
            double Lb = 10.0;
            int m = 2;    // number of spiral arms
            double p = (double)numPitchDegrees.Value * Math.PI / 180.0;  // pitch angle of arms

            // This is the function from the Misiriotis et. al. paper
            Int16 L(double r, double theta, double z)
            {
                double B = Math.Sqrt(r * r + z * z) / bulgeRadius;
                return (Int16)(
                    Ls * Math.Exp((-r / galaxyRadius) - (Math.Abs(z) / galaxyHeight))
                    * (1 + ws * Math.Sin(m * Math.Log(r) / Math.Tan(p) - m * theta))
                    + Lb * Math.Exp(-7.67 * Math.Pow(B, 0.25)) * Math.Pow(B, -0.875) 
                );
            }

            // Here is a "stacked" version of that function in just r and theta
            double increment = galaxyHeight / 0.99;
            Int16 LPlottable(double r, double theta)
            {
                Int16 L0 = L(r, theta, 0.0);
                Int16 retVal = (Int16)Math.Pow(L0, 1.5);
                for (double z = increment; z < galaxyHeight; z += increment)
                {
                    Int16 Li = L(r, theta, z);
                    retVal += (Int16)Math.Pow(Li, 1.5);
                }
                return retVal;
            }

            // Plot it
            newPlot.PlotPolarFunction(LPlottable);

            //newPlot.DrawX();

            _galaxyPlotForm.Bitmap = newPlot.GenerateBitmap();
            this.Cursor = Cursors.Default;
        }

        private void numPitchDegrees_ValueChanged(object sender, EventArgs e)
        {
            _GeneratePlot();
        }

        private void txtWs_TextChanged(object sender, EventArgs e)
        {
            _GeneratePlot();
        }
    }
}
