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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _0_proje
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void Regbut_Click(object sender, EventArgs e)
        {
            var a = new register();
            a.Show();
            this.Hide();

        }

        private void Logbut_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Username,Password From Table_1 where Username=@p1 and Password=@p2", conn);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            bool x = dr.Read();
            conn.Close();

            if (x)
            {
                conn.Open();
                using (SqlCommand command2 = new SqlCommand("select Id from Table_1 where Username='" + textBox1.Text + "'", conn))
                {
                    
                    object data = command2.ExecuteScalar(); 
                    Properties.Settings.Default.Id = Convert.ToInt32(data); 
                    Properties.Settings.Default.Save();
                    
                }
                conn.Close();

                MessageBox.Show("Login succesful");
                main frm = new main();
                frm.yazi = textBox1.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
            conn.Close();
        }

        private void Pasbut_Click(object sender, EventArgs e)
        {
            var a = new password();
            a.Show();
            this.Hide();
        }
    }
}
