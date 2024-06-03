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
    public partial class SearchStaff : Form
    {
        private MySqlConnection con; 
        private MySqlCommand cmd;
        public SearchStaff()
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

                
                string staffID = textBox1.Text;
                string sql = "SELECT * FROM Maintenancestaff WHERE staffID = @staffID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@staffID", staffID);

                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Display corresponding data in separate TextBoxes
                    textBox2.Text = reader["staffID"].ToString();
                    textBox3.Text = reader["Name"].ToString();
                    textBox4.Text = reader["Designation"].ToString();
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
    }
}
