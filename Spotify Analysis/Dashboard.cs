using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Spotify_Analysis
{
    public partial class Dashboard : Form
    {
        private int _userId;
        private string _username; // Private field to store the username
        private SqlConnection _con; // Class-level SqlConnection

        // Constructor accepting the userId and username
        public Dashboard(int userId, string username)
        {
            InitializeComponent();
            _userId = userId;
            _username = username; // Assign the username passed from the Login form
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Display the username in the label
            Username.Text = _username;

            // Open the connection once when the form loads
            string connectionString = "server=KARAN-BARI\\SQLEXPRESS;database=spotify;integrated Security=SSPI;MultipleActiveResultSets=True;";
            _con = new SqlConnection(connectionString);

            try
            {
                _con.Open(); // Open the connection once

                // Fetch and display the data
                FetchTotalStreams();
                FetchFavoriteGenre();
                FetchTopArtist();
                FetchMostPlayedTrack();
                FetchTopPlaylist();
                PopulateFlowLayoutPanel();
                FetchRecentlyPlayedTrack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchTotalStreams()
        {
            try
            {
                string query = @"SELECT COUNT(*) AS total_streams FROM listening_history WHERE user_id = @userId";

                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.Parameters.AddWithValue("@userId", _userId);

                    object result = _cmd.ExecuteScalar(); // Fetch the single value (total streams)
                    int totalStreams = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    totalStreamsLabel.Text = $"Total streams: {totalStreams}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total streams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchFavoriteGenre()
        {
            try
            {
                string query = @"
                    SELECT TOP 1 t.genre, COUNT(*) AS streams
                    FROM listening_history lh
                    JOIN tracks t ON lh.track_id = t.track_id
                    WHERE lh.user_id = @userId
                    GROUP BY t.genre
                    ORDER BY streams DESC;";

                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.Parameters.AddWithValue("@userId", _userId);

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string favoriteGenre = reader["genre"].ToString();
                            Genre.Text = $"Genre: {favoriteGenre}";
                        }
                        else
                        {
                            Genre.Text = "Genre: N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching favorite genre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchTopArtist()
        {
            try
            {
                string query = @"
                    SELECT TOP 1 a.artist_name, COUNT(*) AS streams
                    FROM listening_history lh
                    JOIN tracks t ON lh.track_id = t.track_id
                    JOIN artists a ON t.artist_id = a.artist_id
                    WHERE lh.user_id = @userId
                    GROUP BY a.artist_name
                    ORDER BY streams DESC;";

                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.Parameters.AddWithValue("@userId", _userId);

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string topArtist = reader["artist_name"].ToString();
                            label3.Text = $"Top Artist: {topArtist}";
                        }
                        else
                        {
                            label3.Text = "Top Artist: N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching top artist: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchMostPlayedTrack()
        {
            try
            {
                string query = @"
                    SELECT TOP 1 t.track_name, COUNT(*) AS streams
                    FROM listening_history lh
                    JOIN tracks t ON lh.track_id = t.track_id
                    WHERE lh.user_id = @userId
                    GROUP BY t.track_name
                    ORDER BY streams DESC;";

                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.Parameters.AddWithValue("@userId", _userId);

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string mostPlayedTrack = reader["track_name"].ToString();
                            mostPlayedLabel.Text = $"Most Played: {mostPlayedTrack}";
                        }
                        else
                        {
                            mostPlayedLabel.Text = "Most Played: N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching most played track: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchTopPlaylist()
        {
            try
            {
                string query = @"
                    SELECT TOP 1 p.playlist_name, COUNT(*) AS streams
                    FROM listening_history lh
                    JOIN playlists p ON lh.playlist_id = p.playlist_id
                    WHERE lh.user_id = @userId
                    GROUP BY p.playlist_name
                    ORDER BY streams DESC;";

                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _cmd.Parameters.AddWithValue("@userId", _userId);

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string topPlaylist = reader["playlist_name"].ToString();
                            topPlaylistLabel.Text = $"Top Playlist: {topPlaylist}";
                        }
                        else
                        {
                            topPlaylistLabel.Text = "Top Playlist: N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching top playlist: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void FetchRecentlyPlayedTrack()
        {
            try
            {
                string query = @"
            SELECT TOP 1
                t.track_name
            FROM listening_history lh
            LEFT JOIN tracks t ON lh.track_id = t.track_id
            WHERE lh.user_id = @userId
            ORDER BY lh.listened_on DESC;";

                using (SqlCommand cmd = new SqlCommand(query, _con))
                {
                    cmd.Parameters.AddWithValue("@userId", _userId); // Use the user's ID dynamically

                    object result = cmd.ExecuteScalar(); // Fetch the first value (track_name)

                    if (result != null)
                    {
                        string trackName = result.ToString();
                        recently_played.Text = $"Recently Played: {trackName}";
                    }
                    else
                    {
                        recently_played.Text = "Recently Played: N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching recently played track: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void PopulateFlowLayoutPanel()
        {
            flowLayoutPanel1.AutoScroll = true; // Enable scrolling
            flowLayoutPanel1.WrapContents = false; // Stack controls vertically
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown; // Ensure vertical stacking
            flowLayoutPanel1.Controls.Clear(); // Clear existing items

            string query = @"
WITH UserHistory AS (
    SELECT 
        t.track_name,
        t.genre,
        a.artist_name,
        CAST(lh.listening_duration AS INT) AS listening_duration,
        ROW_NUMBER() OVER (PARTITION BY t.track_name ORDER BY lh.listened_on DESC) AS RowNum
    FROM listening_history lh
    LEFT JOIN tracks t ON lh.track_id = t.track_id
    LEFT JOIN artists a ON t.artist_id = a.artist_id
    WHERE lh.user_id = @userId
),
FallbackTracks AS (
    SELECT 
        t.track_name,
        t.genre,
        a.artist_name,
        CAST((RAND() * 300) + 60 AS INT) AS listening_duration, -- Random duration between 60 and 360 seconds
        ROW_NUMBER() OVER (PARTITION BY t.track_name ORDER BY t.total_streams DESC) AS RowNum
    FROM tracks t
    LEFT JOIN artists a ON t.artist_id = a.artist_id
    WHERE t.genre = (
        SELECT favorite_genre 
        FROM users 
        WHERE user_id = @userId
    )
)
SELECT track_name, genre, artist_name, listening_duration
FROM (
    SELECT DISTINCT
        track_name,
        genre,
        artist_name,
        listening_duration,
        RowNum
    FROM UserHistory
    WHERE RowNum <= 4

    UNION ALL

    SELECT DISTINCT
        track_name,
        genre,
        artist_name,
        listening_duration,
        RowNum
    FROM FallbackTracks
    WHERE RowNum <= 4
) AS CombinedResults
ORDER BY RowNum;";

            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@userId", _userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Create a new panel for each track
                        Panel panel = new Panel
                        {
                            Width = flowLayoutPanel1.ClientSize.Width - 20, // Ensure the width fits within the FlowLayoutPanel width
                            Height = 120, // Fixed height for consistency
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(5),
                            BackColor = Color.LightGray
                        };

                        // Add labels to the panel
                        Label trackLabel = new Label
                        {
                            Text = $"Track: {reader["track_name"]}",
                            AutoSize = false,
                            Width = panel.Width - 20, // Set width explicitly to avoid stretching
                            Height = 20, // Fixed height
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            Location = new Point(10, 10)
                        };

                        Label genreLabel = new Label
                        {
                            Text = $"Genre: {reader["genre"]}",
                            AutoSize = false,
                            Width = panel.Width - 20, // Same width as panel
                            Height = 20,
                            Location = new Point(10, 30)
                        };

                        Label artistLabel = new Label
                        {
                            Text = $"Artist: {reader["artist_name"]}",
                            AutoSize = false,
                            Width = panel.Width - 20,
                            Height = 20,
                            Location = new Point(10, 50)
                        };

                        Label durationLabel = new Label
                        {
                            Text = $"Duration: {reader["listening_duration"]} minutes",
                            AutoSize = false,
                            Width = panel.Width - 20,
                            Height = 20,
                            Location = new Point(10, 70)
                        };

                        // Add controls to the panel
                        panel.Controls.Add(trackLabel);
                        panel.Controls.Add(genreLabel);
                        panel.Controls.Add(artistLabel);
                        panel.Controls.Add(durationLabel);

                        // Add panel to the FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }
        }








        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_con != null && _con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void contentPanel_Paint(object sender, PaintEventArgs e) { }

        private void headerLabel_Click(object sender, EventArgs e) { }

        private void headerPanel_Paint(object sender, PaintEventArgs e) { }

        private void sideMenuPanel_Paint(object sender, PaintEventArgs e) { }

        private void statsPanel_Paint(object sender, PaintEventArgs e) { }

        private void Username_Click(object sender, EventArgs e) { }

        private void homeButton_Click(object sender, EventArgs e) { }

        private void tablesButton_Click(object sender, EventArgs e) { }

        private void visualizeButton_Click(object sender, EventArgs e) { }

        private void analyticsButton_Click(object sender, EventArgs e) { }

        private void mostPlayedLabel_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void Username_Click_1(object sender, EventArgs e)
        {

        }

        private void sideMenuPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            // Close the current Dashboard form
            this.Hide(); // Hides the Dashboard form

            // Open the Login form
            Login loginForm = new Login();
            loginForm.Show();

            // Optional: If you want to completely close the Dashboard form after logout
            this.Close();
        }

        private void Genre_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void recently_played_Click(object sender, EventArgs e)
        {

        }

        private void statsPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void headerLabel_Click_1(object sender, EventArgs e)
        {

        }
    }
}