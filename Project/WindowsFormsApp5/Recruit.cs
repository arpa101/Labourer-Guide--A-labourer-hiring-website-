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
    public partial class Recruit : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;

        public Image Image { get; private set; }

        public Recruit()
        {
            InitializeComponent();

            bindGrid();
            bindGrid1();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox5.Text != "")
            {
                SqlConnection c = new SqlConnection(cs);
                string query = "insert into RECRUITED_LABOR values(@customer_id,@name,@id,@mobile_no,@age,@picture)";
                SqlCommand co = new SqlCommand(query, c);
                co.Parameters.AddWithValue("@customer_id", textBox1.Text);
                co.Parameters.AddWithValue("@name", textBox5.Text);
                co.Parameters.AddWithValue("@id", textBox4.Text);
                co.Parameters.AddWithValue("@mobile_no", textBox3.Text);
                co.Parameters.AddWithValue("@age", numericUpDown1.Value);

                co.Parameters.AddWithValue("@picture", SavePhoto()); 
                c.Open();
                int a = co.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data inserted successfully!");
                    bindGrid1();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data not inserted!");
                }
            }
            byte[] SavePhoto()
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                return ms.GetBuffer();
            }
            void ResetControl()
            {
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                numericUpDown1.Value = 0;
                pictureBox1.Image = Properties.Resources.unnamed;
            }


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "DELETE from RECRUITED_LABOR where id=@id";
            SqlCommand co = new SqlCommand(query, c);
            string n = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
           string n1 = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            int n2 = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[2].Value.ToString());
           string n3 = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            int n4 = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[4].Value.ToString());
            string n6 = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            int n5 = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[6].Value.ToString());
            Image = GetPhoto((byte[])dataGridView2.SelectedRows[0].Cells[7].Value);

            co.Parameters.AddWithValue("@id", n4);


            c.Open();
            int a = co.ExecuteNonQuery();
            if (a >= 0)
            {
                MessageBox.Show("Data deleted successfully!");
                bindGrid1();
                
            }
            else
            {
                MessageBox.Show("Data not deleted!");
            }
        }
        void bindGrid1()
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "select CUSTOMER_DETAILS.NAME AS CUSTOMER_NAME,CUSTOMER_DETAILS.MOBILE_NO AS CUSTOMER_MOBILE,RECRUITED_LABOR.* from CUSTOMER_DETAILS, RECRUITED_LABOR WHERE CUSTOMER_DETAILS.ID=RECRUITED_LABOR.CUSTOMER_ID";
            SqlDataAdapter sda = new SqlDataAdapter(query, c);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;

            //Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView2.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AutoSize
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //height
            dataGridView2.RowTemplate.Height = 50;

          
        }
        Image GetPhoto1(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
       private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(); f.Show(); this.Visible = false;
        }

        private void Recruit_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
