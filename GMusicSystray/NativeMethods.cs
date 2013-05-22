using System;
using System.Runtime.InteropServices;

namespace GMusic
{
    internal class NativeMethods
    {
        //public const int HWND_BROADCAST = 0xffff;
        //public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");

        //public const int SW_RESTORE = 9;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        
        //[DllImport("user32")]
        //public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImportAttribute("user32")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        ////[DllImport("user32")]
        ////public static extern int RegisterWindowMessage(string message);

        [DllImportAttribute("user32")]
        public static extern bool ReleaseCapture();

        [DllImport("GMusicHooks.dll")]
        public static extern int RegisterMediaHooks(IntPtr hWnd, bool captureBrowserCommands);

        [DllImport("GMusicHooks.dll")]
        public static extern int UnregisterMediaHooks();


        //[DllImport("user32")]
        //public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        //[DllImport("user32")]
        //public static extern int SetForegroundWindow(IntPtr hWnd);

        //[DllImport("user32")]
        //public static extern int IsIconic(IntPtr hWnd);
    }
}
