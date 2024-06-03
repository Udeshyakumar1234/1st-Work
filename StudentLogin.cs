using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management
{
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Student ID")
            { textBox1.Clear(); }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Mobile Number")
            { textBox2.Clear();
                textBox2.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            MySqlConnection con = new MySqlConnection(connstring);

            try
            {
                con.Open();
                string username = textBox1.Text;
                string password = textBox2.Text;

                // Construct SQL query to check if the provided username and password exist in the database
                string sql = "SELECT COUNT(*) FROM Student WHERE StudentID = @username AND ContactNumber = @password";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Login successful!");
                    // Redirect to the next form or perform any other action upon successful login
                    StudentDashboard dashboard = new StudentDashboard();
                    this.Hide();
                    dashboard.Show();

                }
                else
                {
                    MessageBox.Show("Student info given does not exist in the database!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            // Show or open Form 1 if it was hidden
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Form1))
                {
                    form.Show();
                    return;
                }
            }

            // If Form 1 was not found, create a new instance and show it
            Form1 form1 = new Form1();
            form1.Show();

        }
    }
}
