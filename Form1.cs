using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hostel_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserNameBox_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void UserNameBox_MouseClick(object sender, MouseEventArgs e)
        {

            if (UserNameBox.Text == "UserID")
            { UserNameBox.Clear(); }
        }

        private void PasswordBox_MouseClick(object sender, MouseEventArgs e)
        {
               if(PasswordBox.Text=="Password")
            { PasswordBox.Clear();
                PasswordBox.PasswordChar = '*';            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            MySqlConnection con = new MySqlConnection(connstring);

            try
            {
                con.Open();
                string username=UserNameBox.Text;
                string password=PasswordBox.Text;

                // Construct SQL query to check if the provided username and password exist in the database
                string sql = "SELECT COUNT(*) FROM Admins WHERE UserID = @username AND Password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Login successful!");
                    // Redirect to the next form or perform any other action upon successful login
                    Dashboard dashboard = new Dashboard();
                    this.Hide();
                    dashboard.Show();
                    
                }
                else
                {
                    MessageBox.Show("Invalid username or password! Try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentLogin form = new StudentLogin();
            form.Show();
            this.Hide();
        }

        private void UserNameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
