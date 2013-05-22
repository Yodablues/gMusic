using System;
using System.Windows.Forms;
using System.Threading;
using GMusic;

namespace GMusic
{
    static class Program
    {
        //static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

        private const string s_help = @"Usage: gmusic.exe [command]
where [command] is optional and can be:
    next/nexttrack - tells existing instance to skip to next track
    prev/previous/prevtrack/previoustrack - tells existing instance to go to the previous track
    playpause - tells existing instance to pause or resume the current track

If no instance is running the player will be launched. 
The default command if an instance is running shows the existing instance.";

        [STAThread]
        static void Main(string[] args)
        {

            string command = (args != null && args.Length > 0 ? args[0] ?? "" : "").Trim().ToLower();

            if (command == "help" || command == "-?" || command == "/?")
            {
                //Console.WriteLine(s_help);
                MessageBox.Show(s_help);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (SingleInstance inst = new SingleInstance())
            {
                inst.Run(command);
            }

        }
    }
}
