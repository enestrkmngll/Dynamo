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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace _0_proje
{
    public partial class FitnessPage : Form
    {
        public string yazi11;
        public FitnessPage()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=FitLevel+10 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=FitLevel+30 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=FitLevel+10 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=FitLevel+10 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox4.SelectedIndex == 2)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=FitLevel+30 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=FitLevel+20 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select FitLevel from Table_1 where Id=@id ", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int FitLevel = Convert.ToInt32(data);

            connection.Close();
            
            connection.Open();
            SqlCommand command2 = new SqlCommand("Update Table_1 Set vis4=@p1 where Id=@id", connection);
            command2.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command2.Parameters.AddWithValue("@p1", 1);
            command2.ExecuteNonQuery();

            connection.Close();
            if (FitLevel >= 80 && FitLevel <= 100)
            {
                int bench = 50;
                int biceps = 30;
                int cable = 50;
                int squat = 80;

                MessageBox.Show("Your Program:\n" + bench + " kg 3 sets 12 repeat bench press\n"
                + biceps + " kg 3 sets 10 repeat biceps curl\n"
                + cable + " kg 3 sets 8 repeat cable row\n"
                + squat + " kg 3 sets 12 repeat squat\n");
            }
            if (FitLevel <= 79 && FitLevel >= 40)
            {
                int bench = 30;
                int biceps = 20;
                int cable = 30;
                int squat = 50;

                MessageBox.Show("Your Program:\n" + bench + " kg 3 sets 12 repeat bench press\n"
                + biceps + " kg 3 sets 10 repeat biceps curl\n"
                + cable + " kg 3 sets 8 repeat cable row\n"
                + squat + " kg 3 sets 12 repeat squat\n");
            }
            if (FitLevel <= 39 && FitLevel >= 0)
            {
                int bench = 15;
                int biceps = 10;
                int cable = 15;
                int squat = 25;

                MessageBox.Show("Your Program:\n" + bench + " kg 3 sets 12 repeat bench press\n"
                + biceps + " kg 3 sets 10 repeat biceps curl\n"
                + cable + " kg 3 sets 8 repeat cable row\n"
                + squat + " kg 3 sets 12 repeat squat\n");
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

        private void FitnessPage_Load(object sender, EventArgs e)
        {
            label7.Text = yazi11;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
