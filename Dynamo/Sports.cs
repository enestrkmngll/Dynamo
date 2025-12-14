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

namespace _0_proje
{
    public partial class Sports : Form
    {
        public string yazi7;
        public Sports()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-B65PBTL;Initial Catalog=DynamoDataBase;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("Update Table_1 Set SwimLevel=@swimLevel,Progress1=@c1,Progress2=@c2,day1=@c4,SwimCal=@swimCal where Id=@id", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command.Parameters.AddWithValue("@c1", 0);
            command.Parameters.AddWithValue("@c2", 0);
            command.Parameters.AddWithValue("@c4", 1);
            command.Parameters.AddWithValue("@swimLevel", 0);
            command.Parameters.AddWithValue("@swimCal", 0);
            command.ExecuteNonQuery();

            connection.Close();


            SwimmingPage frm = new SwimmingPage();
            frm.yazi9 = label1.Text;
            frm.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("Update Table_1 Set RunLevel=@runLevel,Progress5=@c1,Progress6=@c2,day3=@c4,RunCal=@runCal where Id=@id", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command.Parameters.AddWithValue("@c1", 0);
            command.Parameters.AddWithValue("@c2", 0);
            command.Parameters.AddWithValue("@c4", 1);
            command.Parameters.AddWithValue("@runLevel", 0);
            command.Parameters.AddWithValue("@runCal", 0);
            command.ExecuteNonQuery();

            connection.Close();

            RunningPage frm10 = new RunningPage();
            frm10.yazi10 = label1.Text;
            frm10.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("Update Table_1 Set FitLevel=@fitLevel,Progress7=@c1,Progress8=@c2,day4=@c4,FitCal=@fitCal where Id=@id", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command.Parameters.AddWithValue("@c1", 0);
            command.Parameters.AddWithValue("@c2", 0);
            command.Parameters.AddWithValue("@c4", 1);
            command.Parameters.AddWithValue("@fitLevel", 0);
            command.Parameters.AddWithValue("@fitCal", 0);
            command.ExecuteNonQuery();

            connection.Close();

            FitnessPage frm10 = new FitnessPage();
            frm10.yazi11 = label1.Text;
            frm10.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command = new SqlCommand("Update Table_1 Set BasketLevel=@basketLevel,Progress3=@c1,Progress4=@c2,day2=@c4,BasketCal=@basketCal where Id=@id", connection);
            command.Parameters.AddWithValue("@id", Properties.Settings.Default.Id);
            command.Parameters.AddWithValue("@c1", 0);
            command.Parameters.AddWithValue("@c2", 0);
            command.Parameters.AddWithValue("@c4", 1);
            command.Parameters.AddWithValue("@basketLevel", 0);
            command.Parameters.AddWithValue("@basketCal", 0);
            command.ExecuteNonQuery();

            connection.Close();

            BasketballPage frm10 = new BasketballPage();
            frm10.yazi12 = label1.Text;
            frm10.Show();
            this.Hide();
        }

        private void Sports_Load(object sender, EventArgs e)
        {
            label1.Text = yazi7;
        }
    }
    
}
