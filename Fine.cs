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

    public partial class Fine : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        public Fine()
        {
            InitializeComponent();
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            con = new MySqlConnection(connstring);
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Construct SQL query to select all rows from Fine table
                string sql = "SELECT * FROM Fine";
                cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(reader);



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

        private void button2_Click(object sender, EventArgs e)
        {
            AddRemoveFine addRemoveStudent = new AddRemoveFine();
            addRemoveStudent.Show();
        }
    }
}
