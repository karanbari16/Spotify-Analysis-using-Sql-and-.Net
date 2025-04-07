using System;
using System.Windows.Forms;

namespace Spotify_Analysis
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login()); // Make sure the correct form is being launched here
        }
    }
}
