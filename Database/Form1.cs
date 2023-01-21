using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string CustomerName = textBox2.Text;
            string ContactName = textBox3.Text;
            string Phone = textBox4.Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\VP Programs\\Database\\Database\\Database1.mdf\";Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
           
            string query = "INSERT INTO Customer(CustomerName,ContactName,Phone) VALUES('"+CustomerName+"','"+ContactName+"','"+Phone+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();


            int i = cmd.ExecuteNonQuery();
            if(i>0)
            {
                MessageBox.Show("Data Inserted");
            }
            else if(i==0)
            {
                MessageBox.Show("Sorry! No Insertion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\VP Programs\\Database\\Database\\Database1.mdf\";Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from Customer",con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
        }
    }
}
