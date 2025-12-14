using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _0_proje
{
    public partial class atletizm : Form
    {
        public string yazi4;
        int i = 1, a, RunLevel, RunType,RunCal, cal1,cal2,cal3,cal4;
        public atletizm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

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
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set day3=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            
            
            conn.Open();

            SqlCommand command3 = new SqlCommand("select RunCal from Table_1 where Id=@id ", conn);
            command3.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data3 = command3.ExecuteScalar();
            RunCal = Convert.ToInt32(data3);

            conn.Close();
            RunCal = RunCal + cal1 + cal2 + cal3 + cal4;
            label4.Text = "Total Calories Burned: " + RunCal.ToString()+" cal";

            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set RunCal=@runCal where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@runCal", RunCal);
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
                    
                     cal1 = 200;

                   
                    progressBar2.Value++;
                }
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Table_1 set Progress5=@a1,Progress6=@a2 where Username=@a3", conn);
            cmd.Parameters.AddWithValue("@a3", label1.Text);
            cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
            cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            checkBox1.Enabled = false;
           // if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
            //{
                button1.Enabled = true;
           // }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    cal2 = 500;
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress5=@a1,Progress6=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox2.Enabled = false;
               // if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
               // {
                    button1.Enabled = true;
                //}
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    switch (RunType)
                    {
                        case 0: cal3 = 200; break;
                        case 1: cal3 = 400; break;
                        case 2: cal3 = 600; break;
                    }
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress5=@a1,Progress6=@a2 where Username=@a3", conn);
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
                progressBar1.Value++;
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    cal4 = 50;
                    progressBar2.Value++;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Table_1 set Progress5=@a1,Progress6=@a2 where Username=@a3", conn);
                cmd.Parameters.AddWithValue("@a3", label1.Text);
                cmd.Parameters.AddWithValue("@a1", progressBar1.Value);
                cmd.Parameters.AddWithValue("@a2", progressBar2.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                checkBox4.Enabled = false;
                //if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                //{
                    button1.Enabled = true;
               // }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main frm = new main();
            frm.yazi = label1.Text;
            frm.Show();
            this.Hide();
        }

        private void atletizm_Load(object sender, EventArgs e)
        {
            label1.Text = yazi4;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Progress6 from Table_1 where username=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToInt32(dr.GetValue(0));
            }
            dr.Close();
            conn.Close();
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select day3 from Table_1 where username=@p1", conn);
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
            SqlCommand cmd2 = new SqlCommand("Update Table_1 set Progress5=@c1,Progress2=@c2,day3=@c4 where username=@c3", conn);
            cmd2.Parameters.AddWithValue("@c3", label1.Text);
            cmd2.Parameters.AddWithValue("@c1", progressBar1.Value);
            cmd2.Parameters.AddWithValue("@c2", a);
            cmd2.Parameters.AddWithValue("@c4", i);
            cmd2.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            SqlCommand command2 = new SqlCommand("select RunType from Table_1 where Id=@id1 ", conn);
            command2.Parameters.AddWithValue("@id1", Properties.Settings.Default.Id);
            object data2 = command2.ExecuteScalar();
            int RunType = Convert.ToInt32(data2);

            conn.Close();

            int running = 0;
            string run = "0";
            switch (RunType)
            {
                case 0: running = 200; run = "Short"; break; //200
                case 1: running = 1000; run = "Middle"; break; //400
                case 2: running = 7000; run = "Marathon"; break; //600
            }


            if (RunLevel >= 0 && RunLevel <= 100)
            {
                int walk = 30; //200
                int normal = 45; //500
                int stretch = 10; //esneme //50

                checkBox1.Text = Convert.ToString(walk) + " minutes walk";
                checkBox2.Text = Convert.ToString(normal) + " minutes normal running";
                checkBox3.Text = running + " meters " + run + " distance run";
                checkBox4.Text = Convert.ToString(stretch) + " minutes stretching"; ;
            }

            conn.Open();

            SqlCommand command3 = new SqlCommand("select RunCal from Table_1 where Id=@id ", conn);
            command3.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data3 = command3.ExecuteScalar();
            RunCal = Convert.ToInt32(data3);

            conn.Close();

            label4.Text = "Total Calories Burned: " + RunCal.ToString() + " cal";
        }
        
    }
}
