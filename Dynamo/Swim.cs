using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _0_proje
{
    public partial class Swim : Form
    {
        public string yazi2;

        public Swim()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");


        int i, a, SwimLevel, SwimCal, cal1, cal2, cal3, cal4;
        private void Swim_Load(object sender, EventArgs e)
        {

            button1.Enabled = false;
            label1.Text = yazi2;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Progress2 from Table_1 where username=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToInt32(dr.GetValue(0));
            }
            dr.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select day1 from Table_1 where username=@p1", conn);
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
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set Progress1=@c1,Progress2=@c2,day1=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c1", progressBar1.Value);
            cmd2.Parameters.AddWithValue("@c2", a);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();
            conn.Open();

            SqlCommand command = new SqlCommand("select SwimLevel from Table_1 where Id=@id ", conn);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int SwimLevel = Convert.ToInt32(data);

            conn.Close();



            if (SwimLevel >= 80 && SwimLevel <= 100)
            {
                int breaststroke = 500; //200cal
                int freestyle = 800;   //300cal
                int backstroke = 500;   //250
                int butterfly = 200;  //450

                checkBox1.Text = Convert.ToString(breaststroke) + " meters breaststroke";
                checkBox2.Text = Convert.ToString(freestyle) + " meters freestyle";
                checkBox3.Text = Convert.ToString(backstroke) + " meters backstroke";
                checkBox4.Text = Convert.ToString(butterfly) + " meters butterfly";

            }
            if (SwimLevel <= 79 && SwimLevel >= 40)
            {
                int breaststroke = 200;
                int freestyle = 500;
                int backstroke = 350;
                int butterfly = 150;

                checkBox1.Text = Convert.ToString(breaststroke) + " meters breaststroke";
                checkBox2.Text = Convert.ToString(freestyle) + " meters freestyle";
                checkBox3.Text = Convert.ToString(backstroke) + " meters backstroke";
                checkBox4.Text = Convert.ToString(butterfly) + " meters butterfly";

            }
            if (SwimLevel <= 39 && SwimLevel >= 0)
            {
                int breaststroke = 100;
                int freestyle = 250;
                int backstroke = 150;
                int butterfly = 75;

                checkBox1.Text = Convert.ToString(breaststroke) + " meters breaststroke";
                checkBox2.Text = Convert.ToString(freestyle) + " meters freestyle";
                checkBox3.Text = Convert.ToString(backstroke) + " meters backstroke";
                checkBox4.Text = Convert.ToString(butterfly) + " meters butterfly";
            }
            conn.Open();

            SqlCommand command2 = new SqlCommand("select SwimCal from Table_1 where Id=@id ", conn);
            command2.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data2 = command2.ExecuteScalar();
            SwimCal = Convert.ToInt32(data2);
            conn.Close();

            label4.Text = "Total Calories Burned: " + SwimCal.ToString() + " cal";


        }
        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();

            SqlCommand command = new SqlCommand("select SwimCal from Table_1 where Id=@id ", conn);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            SwimCal = Convert.ToInt32(data);

            conn.Close();
            SwimCal = SwimCal + cal1 + cal2 + cal3 + cal4;
            label4.Text = "Total Calories Burned: " + SwimCal.ToString() + " cal";

            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set SwimCal=@swimCal where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@swimCal", SwimCal);
            cmd.ExecuteNonQuery();
            conn.Close();

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
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set day1=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            // MessageBox.Show($"{breaststroke}");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1.Checked)
            {
                button1.Enabled = true;
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (SwimLevel >= 80 && SwimLevel <= 100)
                    {
                        cal1 = 200;

                    }
                    if (SwimLevel <= 79 && SwimLevel >= 40)
                    {
                        cal1 = 100;

                    }
                    if (SwimLevel <= 39 && SwimLevel >= 0)
                    {
                        cal1 = 50;
                    }
                    progressBar2.Value++;
                }
            }

            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set Progress1=@a1,Progress2=@a2 where Username=@a3", conn);
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
                button1.Enabled = true;
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (SwimLevel >= 80 && SwimLevel <= 100)
                    {
                        cal2 = 300;

                    }
                    if (SwimLevel <= 79 && SwimLevel >= 40)
                    {
                        cal2 = 200;

                    }
                    if (SwimLevel <= 39 && SwimLevel >= 0)
                    {
                        cal2 = 100;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress1=@a1,Progress2=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox2.Enabled = false;
                //if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                //{
                button1.Enabled = true;
                //}
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                button1.Enabled = true;
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (SwimLevel >= 80 && SwimLevel <= 100)
                    {
                        cal3 = 250;

                    }
                    if (SwimLevel <= 79 && SwimLevel >= 40)
                    {
                        cal3 = 150;

                    }
                    if (SwimLevel <= 39 && SwimLevel >= 0)
                    {
                        cal3 = 50;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress1=@a1,Progress2=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox3.Enabled = false;
                //if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                //{
                button1.Enabled = true;
                //}
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                button1.Enabled = true;
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    if (SwimLevel >= 80 && SwimLevel <= 100)
                    {
                        cal4 = 450;

                    }
                    if (SwimLevel <= 79 && SwimLevel >= 40)
                    {
                        cal4 = 350;

                    }
                    if (SwimLevel <= 39 && SwimLevel >= 0)
                    {
                        cal4 = 250;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress1=@a1,Progress2=@a2 where Username=@a3", conn);
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
        private void label4_Click(object sender, EventArgs e)
        {


        }
    }
}