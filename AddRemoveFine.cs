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
    public partial class AddRemoveFine : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        public AddRemoveFine()
        {
            InitializeComponent();
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            con = new MySqlConnection(connstring);
            cmd = new MySqlCommand();
            cmd.Connection = con;
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
                    dateTimePicker1.Value == null)
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Construct SQL query to insert data into Fine table
                string sql = "INSERT INTO Fine (FineID, StudentID, Description, Amount, DateIssued) " +
                             "VALUES (@fineID, @studentID, @description, @amount, @dateIssued)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fineID", textBox1.Text);
                cmd.Parameters.AddWithValue("@studentID", textBox2.Text);
                cmd.Parameters.AddWithValue("@description", textBox3.Text);
                cmd.Parameters.AddWithValue("@amount", textBox4.Text);
                cmd.Parameters.AddWithValue("@dateIssued", dateTimePicker1.Value);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Fine added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add fine.");
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

               
                string sql = "DELETE FROM Fine WHERE FineID = @fineID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fineID", textBox1.Text);

                cmd.CommandText = sql;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Fine deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Fine not found!");
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
