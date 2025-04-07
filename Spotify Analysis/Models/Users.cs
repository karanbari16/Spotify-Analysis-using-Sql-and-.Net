using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Analysis.Models
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor
        public Users(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
