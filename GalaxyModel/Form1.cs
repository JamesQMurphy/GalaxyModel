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

            var newPlot = new PolarPlot(resolution / 2.0);
            //newPlot.DrawX();

            // This draws a circle, starting at zero intensity and getting brighter
            //for (double theta = 0.0; theta < 6.29; theta = theta + 0.01)
            //{
            //    newPlot.Plot(resolution / 2.0, theta, theta/6.29);
            //}

            // Function for circle of radius resolution/4
            var thisRadius = resolution / 4.0;
            double circ(double r, double theta)
            {
                if ((r > (thisRadius - 1.0)) && (r < (thisRadius + 1.0)))
                {
                    return 1.0 - Math.Abs(thisRadius - r);
                }
                return 0.0;
            }
            //newPlot.PlotFunction(circ);


            // Density function
            var boxRadius = resolution / 2.0;
            double density(double r, double theta)
            {
                return (boxRadius - r) / boxRadius;
            }
            newPlot.PlotPolarFunction(density);

            newPlot.DrawX();

            _galaxyPlotForm.PolarPlot = newPlot;
            this.Cursor = Cursors.Default;
        }
    }
}
