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
    public partial class Rating : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Rating()
        {
            InitializeComponent();
            bindGrid();
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void bindGrid()
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "select * from LABOR";
            SqlDataAdapter sda = new SqlDataAdapter(query, c);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AutoSize
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //height
            dataGridView1.RowTemplate.Height = 50;

            //dataGridView1.Columns[5].Visible = false;
        }
        void bindGrid1()
        {
            SqlConnection c = new SqlConnection(cs);
            string query = " select LABOR.*, RATINGG.RATING from LABOR,RATINGG where LABOR.ID=RATINGG.LABOR_ID";
            SqlDataAdapter sda = new SqlDataAdapter(query, c);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AutoSize
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //height
            dataGridView1.RowTemplate.Height = 50;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection c = new SqlConnection(cs);
            string query = "insert into RATINGG values(@labor_id,@rating)";
            SqlCommand co = new SqlCommand(query, c);
            co.Parameters.AddWithValue("@labor_id", textBox1.Text);
            
            co.Parameters.AddWithValue("@rating", numericUpDown1.Value);

           
            c.Open();
            int a = co.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data inserted successfully!");
                bindGrid1();
                ResetControl();
               // ResetControl();
            }
            else
            {
                MessageBox.Show("Data not inserted!");
            }
        }
        void ResetControl()
        {
            textBox1.Clear();
          
            numericUpDown1.Value = 0;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(); f.Show(); this.Visible = false;
        }
    }
}
