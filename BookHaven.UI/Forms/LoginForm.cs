using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library_Management_SystemAD.BookHaven.UI;
using System.Data.SqlClient;
using library_Management_SystemAD.BookHaven.Database;


namespace library_Management_SystemAD
{

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // This method is required for the event handler in the Designer file.
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                using (SqlConnection conn = new SqlConnection(DatabaseHelper.connectionString))
                {
                    conn.Open();
                    string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); // Use hashing in real apps

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string role = result.ToString();
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            if (role == "Admin")
                                new DashboardForm().Show();
                            else
                                new SalesForm().Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
  

    
}
