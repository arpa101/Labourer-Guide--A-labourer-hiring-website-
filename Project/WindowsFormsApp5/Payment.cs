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
    public partial class Payment : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Payment()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "insert into PAYMENT  values(@amount,@card_no,@pin_no,@customer_id,@date)";
            SqlCommand co = new SqlCommand(query, c);
            co.Parameters.AddWithValue("@amount", textBox1.Text);
            co.Parameters.AddWithValue("@card_no", textBox2.Text);
            co.Parameters.AddWithValue("@pin_no", textBox3.Text);
            co.Parameters.AddWithValue("@customer_id", textBox4.Text);
            co.Parameters.AddWithValue("@date", textBox5.Text);
            c.Open();
            int a = co.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Payment successfull !");
                ResetControl();

            }
            else
            {
                MessageBox.Show("Try Again");
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
            textBox5.Clear();


        }

    }
}
