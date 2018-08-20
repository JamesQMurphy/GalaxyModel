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
        private double ws = 0.0;
        private double boxRadius = 0.0;
        private double galaxyRadius = 0.0;
        private double galaxyHeight = 0.0;
        private double bulgeRadius = 0.0;
        private double Ls = 50.0;
        private double Lb = 10.0;
        int m = 2;    // number of spiral arms
        double p = 0.0;  // pitch angle of arms


        public Form1()
        {
            InitializeComponent();

            Anyvalue_changed(null, null);
        }

        // This is the function from the Misiriotis et. al. paper
        public Int16 L(double r, double theta, double z)
        {
            double B = Math.Sqrt(r * r + z * z) / bulgeRadius;
            return (Int16)(
                Ls * Math.Exp((-r / galaxyRadius) - (Math.Abs(z) / galaxyHeight))
                * (1 + ws * Math.Sin(m * Math.Log(r) / Math.Tan(p) - m * theta))
                + Lb * Math.Exp(-7.67 * Math.Pow(B, 0.25)) * Math.Pow(B, -0.875)
            );
        }


        protected override void OnShown(EventArgs e)
        {
            _galaxyPlotForm.Show();
            base.OnShown(e);
        }

        private void Anyvalue_changed(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (((Control)sender).Capture)
                    return;
            }
            // Glean values from form
            boxRadius = (double)this.numResolution.Value / 2.0;
            double.TryParse(txtWs.Text, out ws);
            galaxyRadius = (double)tbSpiralRadius.Value;
            galaxyHeight = galaxyRadius / 10.0;
            bulgeRadius = (double)tbBulgeRadius.Value;
            Ls = (double)tbSpiralBrightness.Value;
            Lb = (double)tbBulgeBrightness.Value;
            m = (int)numArms.Value;
            p = (double)numPitchDegrees.Value * Math.PI / 180.0;

            _GeneratePlot();
        }

        private void tbSpiralRadius_MouseUp(object sender, MouseEventArgs e)
        {
            Anyvalue_changed(sender, e);
        }



        private void _GeneratePlot()
        {
            this.Cursor = Cursors.WaitCursor;
            var newPlot = new PolarPlot(boxRadius);

            // Here is a "stacked" version of the Misiriotis function in just r and theta
            double increment = galaxyHeight / 0.99;
            Int16 LPlottable(double r, double theta)
            {
                Int16 L0 = L(r, theta, 0.0);
                Int16 retVal = (Int16)Math.Pow(L0, 1.5);
                for (double z = increment; z < galaxyHeight; z += increment)
                {
                    Int16 Li = L(r, theta, z);
                    retVal += (Int16)(2 * Math.Pow(Li, 1.5));
                }
                return retVal;
            }

            // Plot it
            newPlot.PlotPolarFunction(LPlottable);

            //newPlot.DrawX();

            _galaxyPlotForm.Bitmap = newPlot.GenerateBitmap();
            this.Cursor = Cursors.Default;
        }

    }
}
