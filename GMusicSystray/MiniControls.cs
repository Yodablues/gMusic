using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GMusic
{
    public partial class MiniControls : Form
    {
        private bool repeat = false;
        private Color repeatOnColor = System.Drawing.Color.White;
        private Color repeatOffColor = System.Drawing.Color.Blue;

        private bool shuffle = false;
        private Color shuffleOnColor = System.Drawing.Color.White;
        private Color shuffleOffColor = System.Drawing.Color.Blue;

        private MiniControls()
        {
            InitializeComponent();
        }

        private void btnPrevTrack_Click(object sender, EventArgs e)
        {
            Player.Instance.PrevTrack();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            Player.Instance.PlayPause();
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            Player.Instance.NextTrack();
        }

        private void btnEnlarge_Click(object sender, EventArgs e)
        {
            Player.Instance.Show();
            Player.Instance.WindowState = GMusic.Properties.Settings.Default.FullPlayerState;
            this.Hide();
        }

        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, 
                    NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1.00f;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.70f;
        }

        public static readonly MiniControls Instance = new MiniControls();

        private void MiniControls_Resize(object sender, EventArgs e)
        {
            if (this.Width != 175 || this.Height != 86)
                this.Size = new Size(175, 86);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int xPos = lblNowPlaying.Location.X;
            int yPos = lblNowPlaying.Location.Y;
            int newXPos = 0;

            if ((lblNowPlaying.Location.X + lblNowPlayingBackground.Width) < lblNowPlayingBackground.Location.X)
            {
                newXPos = (lblNowPlayingBackground.Width);
            }
            else
            {
                newXPos = xPos - 2;
            }

            lblNowPlaying.Location = new System.Drawing.Point(newXPos, yPos);
        }

        private void lblShuffle_Click(object sender, EventArgs e)
        {
            Player.Instance.Shuffle();
            shuffle = !shuffle;

            if (shuffle)
                lblShuffle.ForeColor = shuffleOnColor;
            else
                lblShuffle.ForeColor = shuffleOffColor;

        }

        private void lblRepeat_Click(object sender, EventArgs e)
        {
            Player.Instance.Repeat();
            repeat = !repeat;

            if (repeat)
                lblRepeat.ForeColor = repeatOnColor;
            else
                lblRepeat.ForeColor = repeatOffColor;
        }
    }
}
