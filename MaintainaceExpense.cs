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
    public partial class MaintainaceExpense : Form
    {
        private const string connectionString = "server=localhost;uid=root;pwd=112358;database=hostel";
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        public MaintainaceExpense()
        {
            InitializeComponent();
            con = new MySqlConnection(connectionString);
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Construct SQL query to select rows where Type column is "Maintenance"
                string sql = "SELECT * FROM expense WHERE Type = 'Maintenance'";
                adapter = new MySqlDataAdapter(sql, con);
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
