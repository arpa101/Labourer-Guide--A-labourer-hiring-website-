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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.construction_image_5_scaled;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8(); f.Show(); this.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9(); f.Show(); this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PROGRESS f = new PROGRESS(); f.Show(); this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Members f = new Members(); f.Show(); this.Visible = false;
        }
    }
}
