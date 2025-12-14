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
    public partial class BasketballPage : Form
    {
        public string yazi12;
        //BasketballPage
        public BasketballPage()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+10 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+30 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+10 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+10 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox4.SelectedIndex == 2)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+30 where Id=@id", connection);
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

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketType=0 where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox5.SelectedIndex == 1)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+10,BasketType=@basketType where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.Parameters.AddWithValue("@basketType", 1);
                command.ExecuteNonQuery();

                connection.Close();
            }
            if (comboBox5.SelectedIndex == 2)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=BasketLevel+20,BasketType=@basketType where Id=@id", connection);
                command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
                command.Parameters.AddWithValue("@basketType", 2);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select BasketLevel from Table_1 where Id=@id ", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            object data = command.ExecuteScalar();
            int BasketLevel = Convert.ToInt32(data);

            connection.Close();
            connection.Open();

            SqlCommand command2 = new SqlCommand("select BasketType from Table_1 where Id=@id1 ", connection);
            command2.Parameters.AddWithValue("@id1", Properties.Settings.Default.Id);
            object data2 = command2.ExecuteScalar();
            int BasketType = Convert.ToInt32(data2);

            connection.Close();
            connection.Open();
            SqlCommand command3 = new SqlCommand("Update Table_1 Set vis2=@p1 where Id=@id", connection);
            command3.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command3.Parameters.AddWithValue("@p1", 1);
            command3.ExecuteNonQuery();

            connection.Close();

            int basketing = 0;
            string basket = "0";
            switch (BasketType)
            {
                case 0: basketing = 30; basket = "Backward Shoot"; break;
                case 1: basketing = 30; basket = "Pas"; break;
                case 2: basketing = 30; basket = "Dribling"; break;
            }


            if (BasketLevel >= 0 && BasketLevel <= 100)
            {
                int three = 40;
                int middle = 30;
                int layup = 30; 

                MessageBox.Show("Your Program:\n" + three + " minutes three point shoot\n"
                + middle + " minutes middle distance shoot\n"
                + layup + " minutes lay-up \n" 
                + basketing + " minutes "+basket+" \n");
            }
            
            

            main frm10 = new main();
            frm10.yazi= label7.Text;
            frm10.Show();
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

        private void BasketballPage_Load(object sender, EventArgs e)
        {
            label7.Text = yazi12;
        }
    }
}
