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
    public partial class AddRemoveStaff : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        public AddRemoveStaff()
        {
            InitializeComponent();
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            con = new MySqlConnection(connstring);
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Check if all fields are filled
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Construct SQL query to insert data into maintenancestaff table
                string sql = "INSERT INTO maintenancestaff (StaffID, Name, Designation, ContactNumber, Email) " +
                             "VALUES (@staffID, @name, @designation, @contactNumber, @email)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@staffID", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@designation", textBox3.Text);
                cmd.Parameters.AddWithValue("@contactNumber", textBox4.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Staff added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add staff.");
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
            try
            {
                con.Open();

                // Check if StaffID is provided
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a StaffID.");
                    return;
                }

                // Construct SQL query to delete data from maintenancestaff table based on StaffID
                string sql = "DELETE FROM maintenancestaff WHERE StaffID = @staffID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@staffID", textBox1.Text);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Staff removed successfully");
                }
                else
                {
                    MessageBox.Show("Staff not found!");
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
    }
}
