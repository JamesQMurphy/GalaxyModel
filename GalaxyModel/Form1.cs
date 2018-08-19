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
            double brightness = 1500.0;
            int m = 2;    // number of spiral arms
            double p = (double)numPitchDegrees.Value * Math.PI / 180.0;  // pitch angle of arms

            newPlot.PlotPolarFunction((r, th) =>
            {
                return (Int16)(
                    brightness * Math.Exp(-r / galaxyRadius)
                    * (1 + ws * Math.Sin(m * Math.Log(r) / Math.Tan(p) - m * th))
                );
            });

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
