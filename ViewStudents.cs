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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hostel_Management
{
    public partial class ViewStudents : Form
    {
        private MySqlConnection con; // Declare MySqlConnection at the class level
        private MySqlCommand cmd;
        public ViewStudents()
        {
            InitializeComponent();
            // Initialize MySQL connection
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
             con = new MySqlConnection(connstring);
           cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Access con variable here

                // Construct SQL query to retrieve data based on student ID
                string studentID = textBox1.Text;
                string sql = "SELECT * FROM Student WHERE StudentID = @studentID";
                cmd.Parameters.AddWithValue("@studentID", studentID);

                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Display corresponding data in separate TextBoxes
                    textBox2.Text = reader["StudentID"].ToString();
                    textBox3.Text = reader["Name"].ToString();
                    textBox4.Text = reader["RoomID"].ToString();
                    textBox7.Text = reader["Address"].ToString();
                    textBox5.Text = reader["ContactNumber"].ToString();
                    textBox6.Text = reader["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Student not found!");
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

        private void button1_Click(object sender, EventArgs e)
        {
            ViewAllStudent viewAllStudent = new ViewAllStudent();
            viewAllStudent.Show();
        }
    }
}
