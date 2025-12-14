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
    public partial class RunningPage : Form
    {
        public string yazi10;
        public RunningPage()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+10 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+30 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+10 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 1)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+10 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox4.SelectedIndex == 2)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+30 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunType=0 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox5.SelectedIndex == 1)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+10,RunType=@runType where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.Parameters.AddWithValue("@runType", 1);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox5.SelectedIndex == 2)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=RunLevel+20,RunType=@runType where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.Parameters.AddWithValue("@runType", 2);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select RunLevel from Table_1 where Id=@id ", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int RunLevel = Convert.ToInt32(data);
            
            connection.Close();
            connection.Open();

            SqlCommand command2 = new SqlCommand("select RunType from Table_1 where Id=@id1 ", connection);
            command2.Parameters.AddWithValue("@id1", Properties.Settings.Default.Id);
            object data2 = command2.ExecuteScalar();
            int RunType = Convert.ToInt32(data2);

            connection.Close();

            connection.Open();
            SqlCommand command4 = new SqlCommand("Update Table_1 Set vis3=@p1 where Id=@id", connection);
            command4.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command4.Parameters.AddWithValue("@p1", 1);
            command4.ExecuteNonQuery();

            connection.Close();
            int running=0;
            string run="0";
            switch (RunType)
            {
                case 0:  running = 200; run="Short"; break;
                case 1:  running = 1000; run = "Middle"; break;
                case 2:  running = 7000; run = "Marathon"; break;
            }


            if (RunLevel >= 0 && RunLevel <= 100)
            {
                int walk = 30;
                int normal = 45;
                int stretch = 10; //esneme

                MessageBox.Show("Your Program:\n" + walk + " minutes walk\n"
                + normal + " minutes normal running\n"
                + running + " meters "+run +" distance run\n"
                + stretch + " minutes stretching\n");
            }


            main frm11 = new main();
            frm11.yazi = label7.Text;
            frm11.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("Update Table_1 Set Weight=@weight where Id=@id", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command.Parameters.AddWithValue("@weight", textBox1.Text);
            command.ExecuteNonQuery();

            connection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("Update Table_1 Set Height=@height where Id=@id", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command.Parameters.AddWithValue("@height", textBox2.Text);
            command.ExecuteNonQuery();

            connection.Close();
        }

        private void RunningPage_Load(object sender, EventArgs e)
        {
            label7.Text = yazi10;
        }
    }
}
