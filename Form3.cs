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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are sure you want to Exit ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudents viewStudents = new ViewStudents();
            viewStudents.Show();
        }

        private void addOrRemoveStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRemoveStudent student = new AddRemoveStudent();
            student.Show();
        }

        private void fineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fine fine = new Fine();
            fine.Show();
        }

        private void addRemoveFineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewRoomDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRoom room = new ViewRoom(); 
            room.Show();
        }

        private void addRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewStaffDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStaff staff = new ViewStaff();
            staff.Show();
        }

        private void addRemoveStaffDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRemoveStaff staff = new AddRemoveStaff();
            staff.Show();
        }

        private void maintenanceRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintenanceRequest main=new MaintenanceRequest();
            main.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {


        }

        private void staffAssinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffAssignment staffAssignment = new StaffAssignment();    
            staffAssignment.Show();
        }

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintainaceExpense maintainaceExpense = new MaintainaceExpense();   
            maintainaceExpense.Show();  
        }
    }
}
