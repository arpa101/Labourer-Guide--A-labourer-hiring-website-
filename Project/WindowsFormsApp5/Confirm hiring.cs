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
    public partial class Form11 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Form11()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            bindGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void bindGrid()
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "select * from HIRE";
            SqlDataAdapter sda = new SqlDataAdapter(query, c);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

           
            //AutoSize
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "Update HIRE set statuss=@statuss  ";
            SqlCommand co = new SqlCommand(query, c);
            string type_of_work = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String time_date = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int no_of_labor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            string location = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            int salary = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            int customer_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            string STATUSS = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            co.Parameters.AddWithValue("@customer_id", customer_id);
            co.Parameters.AddWithValue("@statuss", "Confirmed");

          c.Open();
            int a = co.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Confirmed successfully!");
                bindGrid();
               
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(); f.Show(); this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "DELETE from HIRE where customer_id=@customer_id";
            SqlCommand co = new SqlCommand(query, c);
            int customer_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            co.Parameters.AddWithValue("@customer_id",customer_id);


            c.Open();
            int a = co.ExecuteNonQuery();
            if (a >= 0)
            {
                MessageBox.Show("Data deleted successfully!");
                bindGrid();
                //ResetControl();
            }
            else
            {
                MessageBox.Show("Data not deleted!");
            }

        }
    }
}
