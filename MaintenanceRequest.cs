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
    public partial class MaintenanceRequest : Form
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        public MaintenanceRequest()
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
                string sql = "Select * from Maintenancerequest";
                adapter =new MySqlDataAdapter(sql,con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

            }catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }finally { con.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveRequest request = new RemoveRequest();
            request.Show();
        }
    }
}
