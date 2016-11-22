using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ISP.Presentation.Forms
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();

            label1.Text = "Loading";

            timer1.Interval = 500; // specify interval time as you want
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (label1.Text == "Loading...")
            {
                label1.Text = "Loading";
            }
            else
            {
                label1.Text = label1.Text + ".";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
