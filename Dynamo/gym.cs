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
    
    public partial class gym : Form
    {
        public string yazi5;
        public gym()
        {
            InitializeComponent();
        }
        int i , a,FitLevel,FitCal,cal1,cal2,cal3,cal4;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");

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
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set day4=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            SqlCommand command = new SqlCommand("select FitCal from Table_1 where Id=@id ", conn);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            FitCal = Convert.ToInt32(data);

            conn.Close();
            FitCal = FitCal + cal1 + cal2 + cal3 + cal4;
            label4.Text = "Total Calories Burned: " + FitCal.ToString() + " cal";

            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set FitCal=@fitCal where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@fitCal", FitCal);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (FitLevel >= 80 && FitLevel <= 100)
                    {
                        cal1 = 450;

                    }
                    if (FitLevel <= 79 && FitLevel >= 40)
                    {
                        cal1 = 350;

                    }
                    if (FitLevel <= 39 && FitLevel >= 0)
                    {
                        cal1 = 220;
                    }
                    progressBar2.Value++;
                }
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set Progress7=@a1,Progress8=@a2 where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
            cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            checkBox1.Enabled = false;
           // if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
           // {
                button1.Enabled = true;
            //}
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (FitLevel >= 80 && FitLevel <= 100)
                    {
                        cal2 = 400;

                    }
                    if (FitLevel <= 79 && FitLevel >= 40)
                    {
                        cal2 = 300;

                    }
                    if (FitLevel <= 39 && FitLevel >= 0)
                    {
                        cal2 = 220;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress7=@a1,Progress8=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox2.Enabled = false;
               // if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                //{
                    button1.Enabled = true;
               // }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (FitLevel >= 80 && FitLevel <= 100)
                    {
                        cal3 = 300;

                    }
                    if (FitLevel <= 79 && FitLevel >= 40)
                    {
                        cal3 = 250;

                    }
                    if (FitLevel <= 39 && FitLevel >= 0)
                    {
                        cal3 = 150;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress7=@a1,Progress8=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox3.Enabled = false;
               // if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
               // {
                    button1.Enabled = true;
                //}
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (FitLevel >= 80 && FitLevel <= 100)
                    {
                        cal3 = 300;

                    }
                    if (FitLevel <= 79 && FitLevel >= 40)
                    {
                        cal3 = 200;

                    }
                    if (FitLevel <= 39 && FitLevel >= 0)
                    {
                        cal3 = 100;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress7=@a1,Progress8=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox4.Enabled = false;
                //if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                //{
                    button1.Enabled = true;
                //}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main frm = new main();
            frm.yazi = label1.Text;
            frm.Show();
            this.Hide();
        }

        private void gym_Load(object sender, EventArgs e)
        {
            label1.Text = yazi5;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Progress8 from Table_1 where username=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToInt32(dr.GetValue(0));
            }
            dr.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select day4 from Table_1 where username=@p1", conn);
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
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set Progress7=@c1,Progress8=@c2,day4=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c1", progressBar1.Value);
            cmd2.Parameters.AddWithValue("@c2", a);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            SqlCommand command = new SqlCommand("select FitLevel from Table_1 where Id=@id ", conn);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int FitLevel = Convert.ToInt32(data);

            conn.Close();

            if (FitLevel >= 80 && FitLevel <= 100)
            {
                int bench = 50;  //450
                int biceps = 30; //400
                int cable = 50; //300
                int squat = 80; //300

                checkBox1.Text = Convert.ToString(bench) + " kg 3 sets 12 repeat bench press";
                checkBox2.Text = Convert.ToString(biceps) + " kg 3 sets 10 repeat biceps curl";
                checkBox3.Text = Convert.ToString(cable) + " kg 3 sets 8 repeat cable row";
                checkBox4.Text = Convert.ToString(squat) + " kg 3 sets 12 repeat squat"; ;
            }
            if (FitLevel <= 79 && FitLevel >= 40)
            {
                int bench = 30; //350
                int biceps = 20; //300
                int cable = 30; //250
                int squat = 50; //200

                checkBox1.Text = Convert.ToString(bench) + " kg 3 sets 12 repeat bench press";
                checkBox2.Text = Convert.ToString(biceps) + " kg 3 sets 10 repeat biceps curl";
                checkBox3.Text = Convert.ToString(cable) + " kg 3 sets 8 repeat cable row";
                checkBox4.Text = Convert.ToString(squat) + " kg 3 sets 12 repeat squat"; ;
            }
            if (FitLevel <= 39 && FitLevel >= 0)
            {
                int bench = 15; //220
                int biceps = 10; //220
                int cable = 15;  //150
                int squat = 25;  //100

                checkBox1.Text = Convert.ToString(bench) + " kg 3 sets 12 repeat bench press";
                checkBox2.Text = Convert.ToString(biceps) + " kg 3 sets 10 repeat biceps curl";
                checkBox3.Text = Convert.ToString(cable) + " kg 3 sets 8 repeat cable row";
                checkBox4.Text = Convert.ToString(squat) + " kg 3 sets 12 repeat squat"; ;
            }
            conn.Open();

            SqlCommand command2 = new SqlCommand("select FitCal from Table_1 where Id=@id ", conn);
            command2.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data2 = command2.ExecuteScalar();
            FitCal = Convert.ToInt32(data2);

            conn.Close();

            label4.Text = "Total Calories Burned: " + FitCal.ToString() + " cal";
        }
    }
}
