using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Spotify_Analysis
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required!", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please confirm your password.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username already exists
            string connectionString = "server=DURVESH\\SQLEXPRESS;database=spotify;integrated Security=SSPI;";
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                try
                {
                    _con.Open();

                    // Check if username exists
                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username)";
                    using (SqlCommand _cmd = new SqlCommand(checkUserQuery, _con))
                    {
                        _cmd.Parameters.AddWithValue("@username", username);

                        int userExists = (int)_cmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.", "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Stop execution if username already exists
                        }
                    }

                    // Create random data for favorite_genre, favorite_artist_id, and other columns
                    string[] genres = { "Pop", "Rock", "Jazz", "Classical", "Hip Hop" };
                    Random random = new Random();
                    string favoriteGenre = genres[random.Next(genres.Length)];
                    int favoriteArtistId = random.Next(1, 100); // Random artist ID between 1 and 100
                    DateTime currentDateTime = DateTime.Now;

                    // Insert new user into the 'users' table
                    string queryStatement = "INSERT INTO users (username, email, password, created_on, modified_on, isactive, total_streams, favorite_genre, favorite_artist_id) " +
                                            "VALUES (@username, @email, @password, @created_on, @modified_on, @isactive, @total_streams, @favorite_genre, @favorite_artist_id)" +
                                            "SELECT SCOPE_IDENTITY()";  // Get the new user_id

                    int newUserId;
                    using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                    {
                        _cmd.Parameters.AddWithValue("@username", username);
                        _cmd.Parameters.AddWithValue("@email", email);
                        _cmd.Parameters.AddWithValue("@password", password);
                        _cmd.Parameters.AddWithValue("@created_on", currentDateTime);
                        _cmd.Parameters.AddWithValue("@modified_on", currentDateTime);
                        _cmd.Parameters.AddWithValue("@isactive", 1); // Assume the user is active by default
                        _cmd.Parameters.AddWithValue("@total_streams", 0); // Set initial streams to 0
                        _cmd.Parameters.AddWithValue("@favorite_genre", favoriteGenre);
                        _cmd.Parameters.AddWithValue("@favorite_artist_id", favoriteArtistId);

                        // Execute the query and get the newly inserted user_id
                        newUserId = Convert.ToInt32(_cmd.ExecuteScalar());
                    }

                    // After successful user sign-up, insert into Listening_History table
                    Random trackRandom = new Random();
                    int trackId = trackRandom.Next(1, 111);  // track_id between 1 and 110
                    int playlistId = trackRandom.Next(1, 151);  // playlist_id between 1 and 150
                    int listeningDuration = trackRandom.Next(60, 300);  // Random duration in seconds
                    int playDuration = trackRandom.Next(30, 300);  // Random play duration

                    // Insert into Listening_History table where listening_id is auto-generated by the database
                    string insertListeningHistoryQuery = "INSERT INTO Listening_History (user_id, track_id, listened_on, created_on, modified_on, listening_duration, play_duration, playlist_id) " +
                                                         "VALUES (@user_id, @track_id, @listened_on, @created_on, @modified_on, @listening_duration, @play_duration, @playlist_id)";

                    using (SqlCommand _cmd = new SqlCommand(insertListeningHistoryQuery, _con))
                    {
                        _cmd.Parameters.AddWithValue("@user_id", newUserId); // user_id is assigned from the users table
                        _cmd.Parameters.AddWithValue("@track_id", trackId);
                        _cmd.Parameters.AddWithValue("@listened_on", currentDateTime);
                        _cmd.Parameters.AddWithValue("@created_on", currentDateTime);
                        _cmd.Parameters.AddWithValue("@modified_on", currentDateTime);
                        _cmd.Parameters.AddWithValue("@listening_duration", listeningDuration);
                        _cmd.Parameters.AddWithValue("@play_duration", playDuration);
                        _cmd.Parameters.AddWithValue("@playlist_id", playlistId);

                        int rowsAffected = _cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Signup successful and listening history added!", "Signup Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Login loginForm = new Login();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error inserting listening history.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    _con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Signup error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void SignUp_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
