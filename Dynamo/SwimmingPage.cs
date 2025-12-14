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
    public partial class SwimmingPage : Form
    {

        public string yazi9;
        public SwimmingPage()
        {
            InitializeComponent();
              
        }


        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=SwimLevel+10 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=SwimLevel+30 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=SwimLevel+10 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=SwimLevel+10 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox4.SelectedIndex == 2)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=SwimLevel+30 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 1)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=SwimLevel+20 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            connection.Open();

            SqlCommand command = new SqlCommand("select SwimLevel from Table_1 where Id=@id ", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int SwimLevel = Convert.ToInt32(data);

            connection.Close();

            connection.Open();

            SqlCommand command2 = new SqlCommand("Update Table_1 Set vis1=@p1 where Id=@id", connection);
            command2.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command2.Parameters.AddWithValue("@p1",1);
            command2.ExecuteNonQuery();

            connection.Close();




            if (SwimLevel >= 80 && SwimLevel <= 100)
            {
                 int breaststroke = 500;
                int freestyle = 800;
                int backstroke = 500;
                int butterfly = 200;

                MessageBox.Show("Your Program:\n" + breaststroke + " meters breaststroke\n"
                + freestyle + " meters freestyle\n"
                + backstroke + " meters backstroke\n"
                + butterfly + " meter butterfly\n");
            }
            if (SwimLevel <= 79 && SwimLevel >= 40)
            {
                int breaststroke = 200;
                int freestyle = 500;
                int backstroke = 350;
                int butterfly = 150;

                MessageBox.Show("Your Program:\n" + breaststroke + " meters breaststroke\n"
                + freestyle + " meters freestyle\n"
                + backstroke + " meters backstroke\n"
                + butterfly + " meter butterfly\n");
            }
            if (SwimLevel <= 39 && SwimLevel >= 0)
            {
                int breaststroke = 100;
                int freestyle = 250;
                int backstroke = 150;
                int butterfly = 75;

                MessageBox.Show("Your Program:\n" + breaststroke + " meters breaststroke\n"
                + freestyle + " meters freestyle\n"
                + backstroke + " meters backstroke\n"
                + butterfly + " meter butterfly\n");
            }


            main frm7 = new main();
            frm7.yazi = label7.Text;
            frm7.Show();
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

        private void SwimmingPage_Load(object sender, EventArgs e)
        {
            label7.Text = yazi9;
        }
    }
}
