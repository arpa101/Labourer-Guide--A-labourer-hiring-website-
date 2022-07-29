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
    public partial class Registration : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Registration()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckStatus = checkBox1.Checked;
            switch (CheckStatus)
            {

                case true: textBox5.UseSystemPasswordChar = false; textBox5.UseSystemPasswordChar = false; break;

                case false: textBox5.UseSystemPasswordChar = true; textBox5.UseSystemPasswordChar = true; break;


                default: break;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection c = new SqlConnection(cs);
                string query = "insert into CUSTOMER_DETAILS  values(@name,@id,@mobile_no,@age,@passwords,@picture)";
                SqlCommand co = new SqlCommand(query, c);
                co.Parameters.AddWithValue("@name", textBox1.Text);
                co.Parameters.AddWithValue("@id", textBox2.Text);
                co.Parameters.AddWithValue("@mobile_no", textBox3.Text);
                co.Parameters.AddWithValue("@age", numericUpDown1.Value);
              
                co.Parameters.AddWithValue("@passwords", textBox5.Text);
                co.Parameters.AddWithValue("@picture", SavePhoto());
                c.Open();
                int a = co.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data inserted successfully!");
                    Form3 f = new Form3(); f.Show(); this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Data not inserted!");
                }
            }
            
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
