using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0_proje
{
    public partial class basketball : Form
    {
        int a, i = 0,BasketType,BasketCal,cal1,cal2,cal3,cal4;
        public string yazi3;
        public basketball()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");
        private void basketball_Load(object sender, EventArgs e)
        {
            label1.Text = yazi3;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Progress4 from Table_1 where username=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToInt32(dr.GetValue(0));
            }
            dr.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select day2 from Table_1 where username=@p1", conn);
            cmd3.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr2 = cmd3.ExecuteReader();
            if (dr2.Read())
            {
                i = Convert.ToInt32(dr2.GetValue(0));
            }
            dr2.Close();
            conn.Close();
            label2.Text = i.ToString();
            progressBar2.Value = a;
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set Progress3=@c1,Progress4=@c2,day2=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c1", progressBar1.Value);
            cmd2.Parameters.AddWithValue("@c2", a);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            SqlCommand command = new SqlCommand("select BasketLevel from Table_1 where Id=@id ", conn);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int BasketLevel = Convert.ToInt32(data);

            conn.Close();
            conn.Open();

            SqlCommand command2 = new SqlCommand("select BasketType from Table_1 where Id=@id1 ", conn);
            command2.Parameters.AddWithValue("@id1", Properties.Settings.Default.Id);
            object data2 = command2.ExecuteScalar();
            int BasketType = Convert.ToInt32(data2);

            conn.Close();

            int basketing = 0;
            string basket = "0";
            switch (BasketType)
            {
                case 0: basketing =30; basket = "Backward Shoot"; break; //50
                case 1: basketing = 30; basket = "Pas"; break; //30
                case 2: basketing = 30; basket = "Dribling"; break; //100
            }


            if (true)
            {
                int three = 40; //200 
                int middle = 30; //200
                int layup = 30; //300

                checkBox1.Text = Convert.ToString(three) + " minutes three point shoot";
                checkBox2.Text = Convert.ToString(middle) + " minutes middle distance shoot";
                checkBox3.Text = Convert.ToString(layup) + " minutes lay-up ";
                checkBox4.Text = basketing + " minutes " + basket  ;
                
            }
            conn.Open();

            SqlCommand command3 = new SqlCommand("select BasketCal from Table_1 where Id=@id ", conn);
            command3.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data3 = command3.ExecuteScalar();
            BasketCal = Convert.ToInt32(data3);

            conn.Close();

            label4.Text = "Total Calories Burned: " + BasketCal.ToString() + " cal";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    cal1 = 200;
                    progressBar2.Value++;
                }
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set Progress3=@a1,Progress4=@a2 where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
            cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            checkBox1.Enabled = false;
            button1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    cal2= 200;
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress3=@a1,Progress4=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox2.Enabled = false;
                button1.Enabled = true;
                
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    cal3 = 300;
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress3=@a1,Progress4=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox3.Enabled = false;
                    button1.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    switch (BasketType)
                    {
                        case 0: cal4 = 50; break;
                        case 1: cal4 = 30; break;
                        case 2: cal4 = 100; break;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress3=@a1,Progress4=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox4.Enabled = false;
                    button1.Enabled = true;
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main frm = new main();
            frm.yazi = label1.Text;
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            i++;
            button1.Enabled = false;
            checkBox1.Checked = false;
            checkBox1.Enabled = true;
            checkBox2.Checked = false;
            checkBox2.Enabled = true;
            checkBox3.Checked = false;
            checkBox3.Enabled = true;
            checkBox4.Checked = false;
            checkBox4.Enabled = true;
            if (i == 8)
            {
                i = 7;
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
                checkBox2.Checked = true;
                checkBox2.Enabled = false;
                checkBox3.Checked = true;
                checkBox3.Enabled = false;
                checkBox4.Checked = true;
                checkBox4.Enabled = false;
                button1.Enabled = false;
                MessageBox.Show("YOU COMPLETED THE PROGRAM");
                //progressBar2.Value = 0;
                button1.Enabled = false;
            }
            label2.Text = i.ToString();
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set day2=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            SqlCommand command3 = new SqlCommand("select BasketCal from Table_1 where Id=@id ", conn);
            command3.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data3 = command3.ExecuteScalar();
            BasketCal = Convert.ToInt32(data3);

            conn.Close();
            BasketCal = BasketCal + cal1 + cal2 + cal3 + cal4;
            label4.Text = "Total Calories Burned: " + BasketCal.ToString() + " cal";

            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set BasketCal=@basketCal where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@basketCal", BasketCal);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
