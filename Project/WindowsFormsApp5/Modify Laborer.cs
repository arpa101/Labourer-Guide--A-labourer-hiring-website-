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
    public partial class Form9 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        public Form9()
        {
            InitializeComponent();
            bindGrid();
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection c = new SqlConnection(cs);
                string query = " UPDATE LABOR set name=@name,id=@id,mobile_no=@mobile_no,age=@age,picture=@picture where id=@id";
                SqlCommand co = new SqlCommand(query, c);
                co.Parameters.AddWithValue("@name", textBox1.Text);
                co.Parameters.AddWithValue("@id", textBox2.Text);
                co.Parameters.AddWithValue("@mobile_no", textBox3.Text);
                co.Parameters.AddWithValue("@age", numericUpDown1.Value);

                co.Parameters.AddWithValue("@picture", SavePhoto());
                c.Open();
                int a = co.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data updated successfully!");
                    bindGrid();
                    ResetControl();
                }
                else
                {
                    MessageBox.Show("Data not updated!");
                }
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.Value = 0;
            pictureBox1.Image = Properties.Resources.unnamed;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "DELETE from LABOR where id=@id";
            SqlCommand co = new SqlCommand(query, c);

            co.Parameters.AddWithValue("@id", textBox2.Text);


            c.Open();
            int a = co.ExecuteNonQuery();
            if (a >= 0)
            {
                MessageBox.Show("Data deleted successfully!");
                bindGrid();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not deleted!");
            }

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(); f.Show(); this.Visible = false;
        }

       

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
