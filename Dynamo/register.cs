using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Security.Cryptography;

namespace _0_proje
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox4.UseSystemPasswordChar == false)
            {
                textBox4.UseSystemPasswordChar = true;
            }
            else
            {
                textBox4.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.UseSystemPasswordChar == false)
            {
                textBox5.UseSystemPasswordChar = true;
            }
            else
            {
                textBox5.UseSystemPasswordChar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" 
                && textBox5.Text != "" && maskedTextBox1.Text != "" &&  maskedTextBox2.Text != "") 
            {
                label9.Visible = false;
                if(textBox4.Text == textBox5.Text)
                {
                    label8.Visible = false;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select Username from Table_1 where Username=@a1", conn);
                    cmd.Parameters.AddWithValue("@a1", textBox3.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("USERNAME ALREADY TAKEN");
                    }
                    else
                    {
                        MessageBox.Show("REGISTERING");
                        SqlCommand cmd2 = new SqlCommand("insert into Table_1 (Name,Lastname,Age,Phone,Username,Password,Progress1,Progress2," +
                            "Progress3,Progress4,Progress5,Progress6,Progress7,Progress8,day1,day2,day3,day4,Weight,Height,SwimCal,RunCal,FitCal," +
                            "BasketCal,vis1,vis2,vis3,vis4) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18," +
                            "@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28)", conn);
                        cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
                        cmd2.Parameters.AddWithValue("@p2", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                        cmd2.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
                        cmd2.Parameters.AddWithValue("@p5", textBox3.Text);
                        cmd2.Parameters.AddWithValue("@p6", textBox4.Text);
                        cmd2.Parameters.AddWithValue("@p7", 0);
                        cmd2.Parameters.AddWithValue("@p8", 0);
                        cmd2.Parameters.AddWithValue("@p9", 0);
                        cmd2.Parameters.AddWithValue("@p10", 0);
                        cmd2.Parameters.AddWithValue("@p11", 0);
                        cmd2.Parameters.AddWithValue("@p12", 0);
                        cmd2.Parameters.AddWithValue("@p13", 0);
                        cmd2.Parameters.AddWithValue("@p14", 0);
                        cmd2.Parameters.AddWithValue("@p15", 1);
                        cmd2.Parameters.AddWithValue("@p16", 1);
                        cmd2.Parameters.AddWithValue("@p17", 1);
                        cmd2.Parameters.AddWithValue("@p18", 1);
                        cmd2.Parameters.AddWithValue("@p19", 0);
                        cmd2.Parameters.AddWithValue("@p20", 0);
                        cmd2.Parameters.AddWithValue("@p21", 0);
                        cmd2.Parameters.AddWithValue("@p22", 0);
                        cmd2.Parameters.AddWithValue("@p23", 0);
                        cmd2.Parameters.AddWithValue("@p24", 0);
                        cmd2.Parameters.AddWithValue("@p25", 0);
                        cmd2.Parameters.AddWithValue("@p26", 0);
                        cmd2.Parameters.AddWithValue("@p27", 0);
                        cmd2.Parameters.AddWithValue("@p28", 0);
                        dr.Close();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("REGISTER COMPLETED");
                        this.Close();
                        Form1 back = new Form1();
                        back.Show();
                    }
                    conn.Close();
                }
                else
                {
                    label8.Visible = true;
                }
            }
            else
            {
                label9.Visible = true;
            }
        }
    }
}
