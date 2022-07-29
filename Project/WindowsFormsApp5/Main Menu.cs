﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.construction_image_5_scaled;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration f = new Registration(); f.Show(); this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
              Form3 f= new Form3(); f.Show();   this.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkTurquoise;
            button1.ForeColor = Color.Black;
            
             

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
            button1.ForeColor = Color.Black;

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Orange;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkTurquoise;
            button2.ForeColor = Color.Black;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Orange;
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkTurquoise;
            button3.ForeColor = Color.Black;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkTurquoise;
            button4.ForeColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Orange;
            button4.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(); f.Show(); this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
