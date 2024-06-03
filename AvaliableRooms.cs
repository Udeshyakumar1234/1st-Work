using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management
{
    public partial class AvaliableRooms : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;


        public AvaliableRooms()
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

                // Construct SQL query to select all rows from Fine table
                string sql = "SELECT * FROM room WHERE Facilities LIKE @Facilities AND IsFull = 'No'";
                adapter = new MySqlDataAdapter(sql, con);
                adapter.SelectCommand.Parameters.AddWithValue("@Facilities", "%" + textBox1.Text.Trim() + "%");

                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind DataGridView to DataTable
                dataGridView1.DataSource = dataTable;
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
