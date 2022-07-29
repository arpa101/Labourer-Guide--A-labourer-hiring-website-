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
    public partial class Members : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;

        public Image Image { get; private set; }

        public Members()
        {
            InitializeComponent();
            bindGrid();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Members_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        void bindGrid()
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "select * from CUSTOMER_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(query, c);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AutoSize
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(); f.Show(); this.Visible = false;
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "DELETE from CUSTOMER_DETAILS where id=@id ";
            SqlCommand co = new SqlCommand(query, c);
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            string mobile_no = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            int age = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            string password = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            

            Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
            co.Parameters.AddWithValue("@id", id);


            c.Open();
            int a = co.ExecuteNonQuery();
            if (a >= 0)
            {
                MessageBox.Show("Data deleted successfully!");
                bindGrid();

            }
            else
            {
                MessageBox.Show("Data not deleted!");
            }
        }
    }
    }

