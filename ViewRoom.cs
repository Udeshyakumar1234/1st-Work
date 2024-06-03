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
    public partial class ViewRoom : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;

        public ViewRoom()
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

                // Check if room number is provided
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a room number.");
                    return;
                }

                // Construct SQL query to select data from Room table based on RoomID
                
                string sql = "SELECT * FROM Room WHERE RoomID = @roomID";
                cmd.Parameters.AddWithValue("@roomID", textBox1.Text);

                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Display data in text boxes
                    textBox2.Text = reader["RoomID"].ToString();
                    textBox3.Text = reader["Capacity"].ToString();
                    textBox4.Text = reader["Facilities"].ToString();
                }
                else
                {
                    MessageBox.Show("Room not found!");
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
