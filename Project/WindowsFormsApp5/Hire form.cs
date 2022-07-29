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
    public partial class Form10 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Form10()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection c = new SqlConnection(cs);
                string query = "insert into HIRE  values(@type_of_work,@time_date,@no_of_labor,@location,@salary,@customer_id,@statuss)";
                SqlCommand co = new SqlCommand(query, c);
                co.Parameters.AddWithValue("@type_of_work", textBox1.Text);
                co.Parameters.AddWithValue("@time_date", textBox2.Text);
                co.Parameters.AddWithValue("@no_of_labor", numericUpDown1.Value);
                co.Parameters.AddWithValue("@location", comboBox1.SelectedItem);

                co.Parameters.AddWithValue("@salary", textBox3.Text);
                co.Parameters.AddWithValue("@customer_id", textBox3.Text);
                co.Parameters.AddWithValue("@statuss", " ");

                c.Open();
                int a = co.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data inserted successfully!");
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data not inserted!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(); f.Show(); this.Visible = false;
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex=0;
            numericUpDown1.Value = 0;
            
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
