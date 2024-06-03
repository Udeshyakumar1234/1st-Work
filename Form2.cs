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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            // Show or open Form 1 if it was hidden
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Form1))
                {
                    form.Show();
                    return;
                }
            }

            // If Form 1 was not found, create a new instance and show it
            Form1 form1 = new Form1();
            form1.Show();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=112358;database=hostel";
            MySqlConnection con = new MySqlConnection(connstring);
            if (UserIDBox.Text.Length > 5 && PasswordBox.Text.Length > 5)
            {
                try
                {
                    con.Open();

                    // Check if the correct key is entered
                    string enteredKey = KeyBox.Text.Trim();
                    string correctKey = "NewAdmin"; // Change this to your correct key
                    if (enteredKey != correctKey)
                    {
                        MessageBox.Show("Incorrect key entered. Access denied.Try again");
                        return; // Exit the method
                    }

                    // If the correct key is entered, proceed with inserting data into Admins table
                    string username = UserIDBox.Text.Trim();
                    string password = PasswordBox.Text.Trim();

                    // Construct SQL query to insert data into Admins table
                    string sql = "INSERT INTO Admins (UserID, Password) VALUES (@username, @password)";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New admin added successfully!");
                        this.Close();

                        // Show or open Form 1 if it was hidden
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.GetType() == typeof(Form1))
                            {
                                form.Show();
                                return;
                            }
                        }

                        // If Form 1 was not found, create a new instance and show it
                        Form1 form1 = new Form1();
                        form1.Show();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add new admin.Try Again");
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
            else { MessageBox.Show("The Username or Password is too short."); }
        }

        private void UserIDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
