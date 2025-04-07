namespace Spotify_Analysis
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label totalStreamsLabel;
        private System.Windows.Forms.Label mostPlayedLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.Logout = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.recently_played = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.topPlaylistLabel = new System.Windows.Forms.Label();
            this.Genre = new System.Windows.Forms.Label();
            this.totalStreamsLabel = new System.Windows.Forms.Label();
            this.mostPlayedLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.headerPanel.Controls.Add(this.Logout);
            this.headerPanel.Controls.Add(this.Username);
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1184, 80);
            this.headerPanel.TabIndex = 1;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Red;
            this.Logout.Font = new System.Drawing.Font("Futura Md BT", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.Location = new System.Drawing.Point(1092, 18);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(89, 43);
            this.Logout.TabIndex = 2;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Futura Md BT", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(31, 24);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(202, 36);
            this.Username.TabIndex = 1;
            this.Username.Text = "UserName";
            this.Username.Click += new System.EventHandler(this.Username_Click_1);
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Futura Md BT", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(382, 18);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(498, 42);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Spotify Analysis Dashboard";
            this.headerLabel.Click += new System.EventHandler(this.headerLabel_Click_1);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Black;
            this.contentPanel.Controls.Add(this.label1);
            this.contentPanel.Controls.Add(this.flowLayoutPanel1);
            this.contentPanel.Controls.Add(this.statsPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1184, 711);
            this.contentPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Md BT", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Listening History:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 333);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1123, 353);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint_1);
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.statsPanel.Controls.Add(this.recently_played);
            this.statsPanel.Controls.Add(this.label3);
            this.statsPanel.Controls.Add(this.topPlaylistLabel);
            this.statsPanel.Controls.Add(this.Genre);
            this.statsPanel.Controls.Add(this.totalStreamsLabel);
            this.statsPanel.Controls.Add(this.mostPlayedLabel);
            this.statsPanel.Location = new System.Drawing.Point(36, 103);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(1124, 162);
            this.statsPanel.TabIndex = 1;
            this.statsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.statsPanel_Paint_1);
            // 
            // recently_played
            // 
            this.recently_played.Font = new System.Drawing.Font("Futura Md BT", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recently_played.ForeColor = System.Drawing.Color.White;
            this.recently_played.Location = new System.Drawing.Point(753, 91);
            this.recently_played.Name = "recently_played";
            this.recently_played.Size = new System.Drawing.Size(371, 44);
            this.recently_played.TabIndex = 5;
            this.recently_played.Text = "Recently Played: N/A";
            this.recently_played.Click += new System.EventHandler(this.recently_played_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Futura Md BT", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(753, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(368, 44);
            this.label3.TabIndex = 4;
            this.label3.Text = "Top Artist: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // topPlaylistLabel
            // 
            this.topPlaylistLabel.Font = new System.Drawing.Font("Futura Md BT", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topPlaylistLabel.ForeColor = System.Drawing.Color.White;
            this.topPlaylistLabel.Location = new System.Drawing.Point(427, 91);
            this.topPlaylistLabel.Name = "topPlaylistLabel";
            this.topPlaylistLabel.Size = new System.Drawing.Size(289, 44);
            this.topPlaylistLabel.TabIndex = 3;
            this.topPlaylistLabel.Text = "Top Playlist:";
            this.topPlaylistLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // Genre
            // 
            this.Genre.Font = new System.Drawing.Font("Futura Md BT", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Genre.ForeColor = System.Drawing.Color.White;
            this.Genre.Location = new System.Drawing.Point(427, 24);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(223, 44);
            this.Genre.TabIndex = 2;
            this.Genre.Text = "Genre: ";
            this.Genre.Click += new System.EventHandler(this.Genre_Click);
            // 
            // totalStreamsLabel
            // 
            this.totalStreamsLabel.Font = new System.Drawing.Font("Futura Md BT", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalStreamsLabel.ForeColor = System.Drawing.Color.White;
            this.totalStreamsLabel.Location = new System.Drawing.Point(17, 24);
            this.totalStreamsLabel.Name = "totalStreamsLabel";
            this.totalStreamsLabel.Size = new System.Drawing.Size(313, 44);
            this.totalStreamsLabel.TabIndex = 0;
            this.totalStreamsLabel.Text = "Total Streams: 0";
            // 
            // mostPlayedLabel
            // 
            this.mostPlayedLabel.Font = new System.Drawing.Font("Futura Md BT", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostPlayedLabel.ForeColor = System.Drawing.Color.White;
            this.mostPlayedLabel.Location = new System.Drawing.Point(17, 91);
            this.mostPlayedLabel.Name = "mostPlayedLabel";
            this.mostPlayedLabel.Size = new System.Drawing.Size(391, 44);
            this.mostPlayedLabel.TabIndex = 1;
            this.mostPlayedLabel.Text = "Most Played: N/A";
            this.mostPlayedLabel.Click += new System.EventHandler(this.mostPlayedLabel_Click);
            // 
            // Dashboard
            // 
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.contentPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spotify Analysis Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.headerPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label Username;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Genre;
        private System.Windows.Forms.Label topPlaylistLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label recently_played;
    }
}