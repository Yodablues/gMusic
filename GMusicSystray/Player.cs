using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GMusic;
using System.Runtime.InteropServices;
using Skybound.Gecko;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics;
using GMusic.Properties;
using System.Net;
using System.Threading;

namespace GMusic
{
    internal delegate void PlayerAction();

    public partial class Player : Form
    {
        private static GMusic.Properties.Settings Settings = GMusic.Properties.Settings.Default;

        private int lastTickCount = 0;
        private string currentTitle = "";

        private Player()
        {
            Xpcom.Initialize(Path.GetDirectoryName(Application.ExecutablePath) + "\\xulrunner");

            InitializeComponent();

            bool fits = false;
            foreach (Screen sc in Screen.AllScreens)
            {
                if (sc.Bounds.Contains(Settings.FullPlayerLocation))
                {
                    fits = true;
                    break;
                }
            }

            if (!fits)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Settings.FullPlayerLocation;
                this.Size = Settings.FullPlayerSize;
            }

            this.WindowState = Settings.FullPlayerState;
        }

        protected override void WndProc(ref Message msg)
        {
            //if (msg.Msg == NativeMethods.WM_SHOWME)
            //{
            //    ShowMe();
            //}

            /*
            #define APPCOMMAND_BROWSER_BACKWARD       1
            #define APPCOMMAND_BROWSER_REFRESH        3
            #define APPCOMMAND_BROWSER_STOP           4
            #define APPCOMMAND_BROWSER_FORWARD        2
            #define APPCOMMAND_MEDIA_NEXTTRACK        11
            #define APPCOMMAND_MEDIA_PREVIOUSTRACK    12
            #define APPCOMMAND_MEDIA_STOP             13
            #define APPCOMMAND_MEDIA_PLAY_PAUSE       14
            #define APPCOMMAND_LAUNCH_MEDIA_SELECT    16
             */

            if (msg.Msg == 0x319)   // WM_APPCOMMAND message  
            {
                //Debug.WriteLine(msg.LParam);
                // extract cmd from LPARAM (as GET_APPCOMMAND_LPARAM macro does)  
                int cmd = (int)((uint)msg.LParam >> 16 & ~0xf000);
                //Debug.WriteLine("Cmd: " + cmd.ToString());
                int curTicks = Environment.TickCount;

                if (curTicks - lastTickCount > 200)
                {
                    switch (cmd)
                    {
                        case 13:  // APPCOMMAND_MEDIA_STOP constant  
                            //MessageBox.Show("Stop");
                            break;
                        case 14:  // APPCOMMAND_MEDIA_PLAY_PAUSE  
                        case 4:
                            PlayPause();
                            break;
                        case 11:  // APPCOMMAND_MEDIA_NEXTTRACK  
                        case 2:
                            NextTrack();
                            break;
                        case 12:  // APPCOMMAND_MEDIA_PREVIOUSTRACK  
                        case 1:
                            PrevTrack();
                            break;
                        case 16:
                        case 7: //BROWSER_HOME
                            //ShowMe();
                            break;
                        default:
                            Debug.WriteLine("Cmd: " + cmd.ToString());
                            //MessageBox.Show("cmd = " + cmd.ToString());
                            return; 
                            //this command was not intercepted by the hook so it will still be 
                            //processed as normal; no reason to pass this message to the base
                    }

                    lastTickCount = curTicks;
                }
            }
            base.WndProc(ref msg);
        }

        //private void ShowMe()
        //{
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        this.Show();
        //        this.WindowState = Settings.FullPlayerState;
        //    }
        //    this.BringToFront();
        //}

        private void OnResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (Settings.ShowMiniplayer) MiniControls.Instance.Show();
                this.Hide();
            }
            else
            {
                Settings.FullPlayerState = this.WindowState;

                if (this.WindowState == FormWindowState.Normal)
                {
                    Settings.FullPlayerSize = this.ClientSize;
                    Settings.FullPlayerLocation = this.Location;
                }

                Settings.Save();
                MiniControls.Instance.Hide();

                if (!this.Visible) this.Show();
            }
        }

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowPlayer();
        }

        public void ShowPlayer()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerAction(ShowPlayer));
                return;
            }

            this.Show();
            this.TopMost = true;

            this.WindowState = Settings.FullPlayerState;
            this.Location = Settings.FullPlayerLocation;
            this.Size = Settings.FullPlayerSize;

            this.TopMost = false;
            this.BringToFront();
            this.Focus();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeToSystemTrayToolStripMenuItem.Checked = false;
            MiniControls.Instance.Close();
            Player.Instance.Close();
            Application.Exit();
        }

        private void Player_Load(object sender, EventArgs e)
        {
            Settings.Default.Upgrade();
            nIcon.Visible = true;
            gecko.Navigate("http://music.google.com/");
            gecko.DocumentTitleChanged += new EventHandler(songChanged);

            NativeMethods.RegisterMediaHooks(this.Handle, Settings.Default.CaptureBrowserCommands);

            try
            {
                CheckForUpdates();

            }
            catch (Exception ex)
            {
                this.nIcon.ShowBalloonTip(500, 
                    "Unable to check for updates. Error: " + ex.GetType().Name + ": " + ex.Message, 
                    "Update Check Failed", 
                    ToolTipIcon.Error);
            }
        }

        private void CheckForUpdates()
        {
            HttpWebRequest ver = WebRequest.Create("https://gmusic.svn.codeplex.com/svn/VersionInfo/version.txt") as HttpWebRequest;
            string myVer = Application.ProductVersion;

            using (WebResponse resp = ver.GetResponse())
            {
                using (Stream s = resp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        string curVer = sr.ReadLine();

                        if (!myVer.Equals(curVer))
                        {
                            if (MessageBox.Show(this, "Updates are available, it is recommended you download the latest version. Would you like to go to the site now?", "Updates Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo.UseShellExecute = true;
                                process.StartInfo.FileName = "http://gmusic.codeplex.com/";
                                process.Start();
                            }
                        }
                    }
                }
            }
        }

        private void btnPrevTrack_Click(object sender, EventArgs e)
        {
            PrevTrack();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            NextTrack();
        }

        public void PrevTrack()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerAction(PrevTrack));
                return;
            }

            gecko.runJS("SJBpost( 'prevSong'); void 0");
        }

        public void PlayPause()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerAction(PlayPause));
                return;
            }

            gecko.runJS("SJBpost('playPause'); void 0");            
        }

        public void NextTrack()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerAction(NextTrack));
                return;
            }

            gecko.runJS("SJBpost( 'nextSong'); void 0");
        }

        public void Repeat()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerAction(Repeat));
                return;
            }

            gecko.runJS("SJBpost( 'toggleRepeat'); void 0");
        }

        public void Shuffle()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PlayerAction(Repeat));
                return;
            }

            gecko.runJS("SJBpost( 'toggleShuffle'); void 0");
        }

        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (minimizeToSystemTrayToolStripMenuItem.Checked)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                nIcon.Visible = false;
                if (this.WindowState != FormWindowState.Minimized)
                {
                    Settings.FullPlayerState = this.WindowState;
                    Settings.FullPlayerSize = this.Size;
                    Settings.FullPlayerLocation = this.Location;
                    Settings.Save();
                }

                NativeMethods.UnregisterMediaHooks();
            }
        }

        private void captureBrowserCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private static Player s_instance;
        public static Player Instance
        {
            get
            {
                if (s_instance == null) s_instance = new Player();
                return s_instance;
            }
        }

        private void Player_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.FullPlayerLocation = this.Location;
                Settings.Save();
            }
        }
        private void gecko_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            GeckoElement gaia_loginbox = gecko.Document.GetElementById("gaia_loginbox");
            if (gaia_loginbox == null)
            {

                GeckoElement header = gecko.Document.GetElementById("header");
                if (header != null)
                {
                    header.SetAttribute("style", "display:none;");
                }

                GeckoElement oneGoogleWrapper = gecko.Document.GetElementById("oneGoogleWrapper");
                if (oneGoogleWrapper != null)
                {
                    oneGoogleWrapper.SetAttribute("style", "display:none;");
                }

                GeckoElement coloredBar = gecko.Document.GetElementById("coloredBar");
                if (coloredBar != null)
                {
                    coloredBar.SetAttribute("style", "display:none;");
                }

                GeckoElement headerBar = gecko.Document.GetElementById("headerBar");
                if (headerBar != null)
                {
                    headerBar.SetAttribute("style", "padding-top:0px;");
                    GeckoElement gUser = gecko.Document.GetElementById("guser");

                    GeckoElement username = (GeckoElement)gUser.FirstChild.ChildNodes[2];
                    username.SetAttribute("style", "display:none;");

                    foreach (GeckoNode el in gUser.FirstChild.ChildNodes) 
                    {
                        if ((el.HasAttributes) && (el.Attributes["id"] != null))
                        {
                            {
                                GeckoElement element = (GeckoElement)el;
                                if (element.Id != "gb_71")
                                {
                                    element.SetAttribute("style", "display:none;");
                                }
                            }
                        }
                        if (el.TextContent.Contains("|")) {
                            el.TextContent="";
                        }
                    }
                    
                    GeckoElement breadcrumbs = gecko.Document.GetElementById("breadcrumbs");
                    breadcrumbs.SetAttribute("style", "margin-left:176px;");

                    GeckoElement parentEl = breadcrumbs.Parent;
                    parentEl.InsertBefore((GeckoNode)gUser, (GeckoNode)breadcrumbs);
                    
                    GeckoNode navtab = (GeckoNode)headerBar.LastChild.FirstChild;
                    if (navtab != null)
                    {
                        GeckoElement navtabEl = (GeckoElement)navtab;
                        navtabEl.SetAttribute("style", "width:171px;margin-top:25px;");
                    }
                }

                GeckoElement nav = gecko.Document.GetElementById("nav");
                if (nav != null)
                {
                    nav.SetAttribute("style", "width:151px;");
                }

            }

        }
        private void gecko_DocumentCompleted(object sender, EventArgs e)
        {
                gecko.Visible = true;
            gecko.Document.GetElementById("repeat_mode_button");
            
        }

        private void captureBrowserKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            captureBrowserKeysToolStripMenuItem.Checked =
               Settings.Default.CaptureBrowserCommands =
               !captureBrowserKeysToolStripMenuItem.Checked;
            Settings.Default.Save();
            
            nIcon.ShowBalloonTip(500, "Notice", 
                "The application must be restarted for this change to take effect.", 
                ToolTipIcon.Info);
        }

        private void showMiniplayerWhenHiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMiniplayerWhenHiddenToolStripMenuItem.Checked =
              Settings.Default.ShowMiniplayer =
              !showMiniplayerWhenHiddenToolStripMenuItem.Checked;
            Settings.Default.Save();

            if (this.WindowState == FormWindowState.Minimized)
            {
                MiniControls.Instance.Visible = Settings.ShowMiniplayer;
            }
        }

        private void minimizeToSystemTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeToSystemTrayToolStripMenuItem.Checked =
                !minimizeToSystemTrayToolStripMenuItem.Checked;

            /*if (this.WindowState == FormWindowState.Minimized)
            {
                MiniControls.Instance.Visible = Settings.ShowMiniplayer;
            }*/
        }
        private void songChanged(object sender, EventArgs e)
        {
            string[] titleArray = gecko.DocumentTitle.Split('-');

            currentTitle = titleArray[0] + " - " + titleArray[1];
            MiniControls.Instance.lblNowPlaying.Text = currentTitle;
            MiniControls.Instance.timer1.Start();          
        }
    }

}
