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
    public partial class AddRemoveStudent : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        public AddRemoveStudent()
        {
            InitializeComponent();

            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            con = new MySqlConnection(connstring);
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Construct SQL query to insert data into Student table
                string sql = "INSERT INTO Student (StudentID, Name, Email, RoomID, ContactNumber, Address) VALUES (@studentID, @name, @email, @roomID, @contactNumber, @address)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@studentID", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@roomID", textBox5.Text);
                cmd.Parameters.AddWithValue("@contactNumber", textBox6.Text);
                cmd.Parameters.AddWithValue("@address", textBox7.Text);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add student.");
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Construct SQL query to update data in Student table
                string sql = "UPDATE Student SET Name = @name, Email = @email, RoomID = @roomID, "
                           + "ContactNumber = @contactNumber, Address = @address WHERE StudentID = @studentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@studentID", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@roomID", textBox5.Text);
                cmd.Parameters.AddWithValue("@contactNumber", textBox6.Text);
                cmd.Parameters.AddWithValue("@address", textBox7.Text);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update student.");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Construct SQL query to remove data from Student table based on StudentID
                string sql = "DELETE FROM Student WHERE StudentID = @studentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@studentID", textBox2.Text);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student removed successfully!");
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
