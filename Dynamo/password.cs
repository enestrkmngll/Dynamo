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

namespace _0_proje
{
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.UseSystemPasswordChar == false)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Username From Table_1 where Username=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() && (textBox2.Text == textBox3.Text))
            {
                SqlCommand cmd2 = new SqlCommand("Update Table_1 set Password=@a1 where Username=@a2", conn);
                cmd2.Parameters.AddWithValue("@a1", textBox2.Text);
                cmd2.Parameters.AddWithValue("@a2", textBox1.Text);
                dr.Close();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Change succesfull");
                this.Close();
                Form1 back = new Form1();
                back.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or different passwords");
            }
            
            conn.Close();
        }
    }
}
