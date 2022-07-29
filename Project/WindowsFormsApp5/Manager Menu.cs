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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.construction_image_5_scaled;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recruit f = new Recruit(); f.Show(); this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(); f.Show(); this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12(); f.Show(); this.Visible = false;
        }
    }
}
