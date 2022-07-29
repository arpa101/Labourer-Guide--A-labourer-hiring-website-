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
    public partial class Form12 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Form12()
        {
            InitializeComponent();
            bindGrid1();
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        void bindGrid1()
        {

            SqlConnection c = new SqlConnection(cs);
            string query = "select CUSTOMER_DETAILS.NAME,PAYMENT.AMOUNT,PAYMENT.CARD_NO,PAYMENT.PIN_NO,PAYMENT.CUSTOMER_ID,PAYMENT.DATEE AS DATE from CUSTOMER_DETAILS,PAYMENT WHERE CUSTOMER_DETAILS.ID=PAYMENT.CUSTOMER_ID";
            SqlDataAdapter sda = new SqlDataAdapter(query, c);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


            //AutoSize
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //height
            dataGridView1.RowTemplate.Height = 50;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "DELETE from PAYMENT where customer_id=@customer_id";
            SqlCommand co = new SqlCommand(query, c);
            int customer_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            co.Parameters.AddWithValue("@customer_id", customer_id);


            c.Open();
            int a = co.ExecuteNonQuery();
            if (a >= 0)
            {
                MessageBox.Show("Data deleted successfully!");
                bindGrid1();
                //ResetControl();
            }
            else
            {
                MessageBox.Show("Data not deleted!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form7 f = new Form7(); f.Show(); this.Visible = false;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
