using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.construction_image_5_scaled;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(); f.Show(); this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Payment f = new Payment(); f.Show(); this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rating f = new Rating(); f.Show(); this.Visible = false;
        }
    }
}
