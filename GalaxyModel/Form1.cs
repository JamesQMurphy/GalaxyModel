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

            _GeneratePlot((int)this.numResolution.Value);
        }

        protected override void OnShown(EventArgs e)
        {
            _galaxyPlotForm.Show();
            base.OnShown(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _GeneratePlot((int)this.numResolution.Value);
        }

        private void _GeneratePlot(int resolution)
        {
            this.Cursor = Cursors.WaitCursor;
            var boxRadius = resolution / 2.0;

            var newPlot = new PolarPlot(boxRadius);
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);

            newPlot.PlotPolarFunction(r => Math.Log(r/a)/b);

            // Density function
            //newPlot.PlotPolarFunction((r,th) => {
            //    return (byte)(Math.Max(0.0, (boxRadius - r) * 256.0 / boxRadius));
            //});

            //double brightness = 150.0;
            //double ws = 0.3;  // amount of perturbation
            //int m = 2;    // number of spiral arms
            //double p = 20 * 180.0 / Math.PI;  // pitch angle of arms

            //newPlot.PlotPolarFunction((r, th) =>
            //{
            //    return (byte)(
            //        brightness * Math.Exp(-r/boxRadius)
            //        * (1 + ws * Math.Sin(m*Math.Log(r)/Math.Tan(p) - m*th))
            //    );
            //});


            //newPlot.DrawX();

            _galaxyPlotForm.Bitmap = newPlot.GenerateBitmap();
            this.Cursor = Cursors.Default;
        }
    }
}
