using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _0_proje
{
    public partial class main : Form
    {
        int a,b,c,d;
        public string yazi;
        public main()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");
        private void main_Load(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand command3 = new SqlCommand("select vis1 from Table_1 where Id=@id ", conn);
            command3.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command3.ExecuteScalar();
            int vis1 = Convert.ToInt32(data);

            conn.Close();
            if (vis1 == 1)
            {
                button2.Enabled = true;
                button2.Visible = true;
                
                progressBar1.Visible = true;
            }
            else
            {
                progressBar1.Visible = false;
            }
            
            conn.Open();
            SqlCommand command4 = new SqlCommand("select vis2 from Table_1 where Id=@id ", conn);
            command4.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data2 = command4.ExecuteScalar();
            int vis2 = Convert.ToInt32(data2);
            conn.Close();
            if (vis2 == 1)
            {
                basketball.Enabled = true;
                basketball.Visible = true;
                progressBar2.Visible = true;
            }
            else
            {
                progressBar2.Visible = false;
            }

            conn.Open();
            SqlCommand command5 = new SqlCommand("select vis3 from Table_1 where Id=@id ", conn);
            command5.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data3 = command5.ExecuteScalar();
            int vis3 = Convert.ToInt32(data3);
            conn.Close();
            if (vis3 == 1)
            {
                button4.Enabled = true;
                button4.Visible = true;
                progressBar3.Visible = true;
            }
            else
            {
                progressBar3.Visible = false;
            }

            conn.Open();
            SqlCommand command6 = new SqlCommand("select vis4 from Table_1 where Id=@id ", conn);
            command6.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data4 = command6.ExecuteScalar();
            int vis4 = Convert.ToInt32(data4);
            conn.Close();
            if (vis4 == 1)
            {
                button5.Enabled = true;
                button5.Visible = true;
                progressBar4.Visible = true;
            }
            else
            {
                progressBar4.Visible = false;
            }
            label1.Text = yazi;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Password from Table_1 where Username=@p1",conn);
            cmd.Parameters.AddWithValue("@p1",label1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label2.Text = dr.GetValue(0).ToString();
            }
            conn.Close();
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select Progress2 from Table_1 where Username=@p1", conn);
            cmd2.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                a = Convert.ToInt32(dr2.GetValue(0));
            }
            dr2.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select Progress4 from Table_1 where Username=@p1", conn);
            cmd3.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                b = Convert.ToInt32(dr3.GetValue(0));
            }
            dr3.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd4 = new SqlCommand("Select Progress6 from Table_1 where Username=@p1", conn);
            cmd4.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
            {
                c = Convert.ToInt32(dr4.GetValue(0));
            }
            dr4.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd5 = new SqlCommand("Select Progress8 from Table_1 where Username=@p1", conn);
            cmd5.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            if (dr5.Read())
            {
                d = Convert.ToInt32(dr5.GetValue(0));
            }
            dr5.Close();
            conn.Close();
            progressBar1.Value = a;
            progressBar2.Value = b;
            progressBar3.Value = c;
            progressBar4.Value = d;
            if(a == 28)
            {
                button2.Enabled = true;
                button2.Text = "COMPLETED";
            }
            if(b == 28) 
            {
                basketball.Enabled = false;
                basketball.Text = "COMPLETED";
            }
            if(c == 28)
            {
                button4.Enabled = false;
                button4.Text = "COMPLETED";
            }
            if(d == 28)
            {
                button5.Enabled = false;
                button5.Text = "COMPLETED";
            }
            conn.Open();
            

            SqlCommand command = new SqlCommand("select Weight,Height from Table_1 where Id=@id", conn);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            float weight/* = Convert.ToSingle(reader["Weight"])*/;
            float height = Convert.ToSingle(reader["Height"]);
            float bmi /*= weight / (height * height)*/;
            if (height != 0)
            {
                weight = Convert.ToSingle(reader["Weight"]);
                height = Convert.ToSingle(reader["Height"]);
                bmi = 10000*(weight / (height * height));
                label3.Text ="Your body mass index: "+ bmi.ToString("F2") + " kg/m²";
                if(bmi>=30 || bmi <= 18)
                {
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = false;
                    
                }
                if(bmi>18 && bmi < 30)
                {
                    pictureBox3.Visible = true;
                    pictureBox2.Visible = false;
                    
                }
        }
            else
            {
                label3.Visible = false;
                pictureBox2.Visible=false;
                pictureBox3.Visible=false;
            }

             reader.Close();
            conn.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            atletizm frm4 = new atletizm();
            frm4.yazi4 = label1.Text;
            frm4.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gym frm5 = new gym();
            frm5.yazi5 = label1.Text;
            frm5.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sports frm7 = new Sports();
            frm7.yazi7 = label1.Text;
            frm7.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Swim frm2 = new Swim();
            frm2.yazi2 = label1.Text;
            frm2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }

        private void basketball_Click(object sender, EventArgs e)
        {
            basketball frm3 = new basketball();
            frm3.yazi3 = label1.Text;
            frm3.Show();
            this.Close();
        }
    }
}
