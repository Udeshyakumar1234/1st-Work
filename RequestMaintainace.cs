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
    public partial class RequestMaintainace : Form
    {
        private const string connectionString = "server=localhost;uid=root;pwd=112358;database=hostel";
        public RequestMaintainace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int requestID = random.Next(3004, 4000);

            // Retrieve data from textboxes and datetimepicker
            string studentID = textBox2.Text;
            string roomID = textBox1.Text;
            string description = textBox3.Text;
            string status = "Pending"; // Status is set to "Pending"
            string createdDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Insert data into maintenancerequest table
            string query = "INSERT INTO maintenancerequest (RequestID, StudentID, RoomID, Description, Status, CreatedDate) " +
                           "VALUES (@RequestID, @StudentID, @RoomID, @Description, @Status, @CreatedDate)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RequestID", requestID);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Maintenance request submitted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit maintenance request.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
