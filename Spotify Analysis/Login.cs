using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Spotify_Analysis
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
                
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If checkbox is checked, password is visible, else it's hidden.
            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';  // Show password
            }
            else
            {
                txtPass.PasswordChar = '*';  // Hide password
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Username and password cannot be empty", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "server=KARAN-BARI\\SQLEXPRESS;database=spotify;integrated Security=SSPI;";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    _con.Open();

                    // Query with case-insensitive comparison
                    string queryStatement = "SELECT user_id FROM users WHERE LOWER(username) = LOWER(@username) AND password = @password";

                    using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                    {
                        _cmd.Parameters.AddWithValue("@username", user);
                        _cmd.Parameters.AddWithValue("@password", pass);

                        DataTable loginTable = new DataTable();

                        SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                        _dap.Fill(loginTable);
                        _con.Close();

                        if (loginTable.Rows.Count > 0)
                        {
                            int userId = Convert.ToInt32(loginTable.Rows[0]["user_id"]);
                            string loggedInUsername = user;

                            MessageBox.Show("Login successful!");
                            Dashboard dashboard = new Dashboard(userId, loggedInUsername);
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
 






        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            // Create an instance of the SignUp form
            SignUp signUpForm = new SignUp();

            // Optionally, hide the current form if you want it to disappear
            this.Hide();

            // Show the SignUp form
            signUpForm.Show();
        }
    }
}
