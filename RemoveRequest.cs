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
    public partial class RemoveRequest : Form
    {
        private const string connectionString = "server=localhost;uid=root;pwd=112358;database=hostel";

        public RemoveRequest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string requestID = RequestID.Text;

            // Delete from maintenancerequest table
            string deleteMaintenanceRequestQuery = "DELETE FROM maintenancerequest WHERE RequestID = @RequestID";

            // Delete from staffassignment table
            string deleteStaffAssignmentQuery = "DELETE FROM staffassignment WHERE RequestID = @RequestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Delete from maintenancerequest table
                    SqlCommand deleteMaintenanceRequestCommand = new SqlCommand(deleteMaintenanceRequestQuery, connection);
                    deleteMaintenanceRequestCommand.Parameters.AddWithValue("@RequestID", requestID);
                    deleteMaintenanceRequestCommand.ExecuteNonQuery();

                    // Delete from staffassignment table
                    SqlCommand deleteStaffAssignmentCommand = new SqlCommand(deleteStaffAssignmentQuery, connection);
                    deleteStaffAssignmentCommand.Parameters.AddWithValue("@RequestID", requestID);
                    deleteStaffAssignmentCommand.ExecuteNonQuery();

                    MessageBox.Show("Request removed successfully!");
                } catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
            }
        }

        private void RequestID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
