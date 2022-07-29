using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckStatus = checkBox1.Checked;
            switch (CheckStatus)
            {

                case true: textBox2.UseSystemPasswordChar = false; break;

                case false: textBox2.UseSystemPasswordChar = true; break;


                default: break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {

                MessageBox.Show("Admin Log In Successful", "Admin Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form5 f = new Form5(); f.Show(); this.Visible = false;

            }
            else if (textBox1.Text == "manager" && textBox2.Text == "1234")
            {

                MessageBox.Show("Admin Log In Successful", "Manager Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form7 f = new Form7(); f.Show(); this.Visible = false;

            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection c = new SqlConnection(cs);
                string query = "select * from CUSTOMER_DETAILS  where name=@name and passwords=@password";
                SqlCommand co = new SqlCommand(query, c);
                co.Parameters.AddWithValue("@name", textBox1.Text);
                co.Parameters.AddWithValue("@password", textBox2.Text);
                c.Open();



                SqlDataReader re = co.ExecuteReader();

                if (re.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form6 f = new Form6(); f.Show(); this.Visible = false;
                }









            }
            else
            {
                MessageBox.Show("Enter Your Username and Password", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          

         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
