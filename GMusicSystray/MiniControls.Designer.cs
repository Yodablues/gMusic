namespace GMusic
{
    partial class MiniControls
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniControls));
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnEnlarge = new System.Windows.Forms.Button();
            this.btnNextTrack = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnPrevTrack = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNowPlayingBackground = new System.Windows.Forms.Label();
            this.lblNowPlaying = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblShuffle = new System.Windows.Forms.Label();
            this.tlpLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 4;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpLayout.Controls.Add(this.btnEnlarge, 3, 0);
            this.tlpLayout.Controls.Add(this.btnNextTrack, 2, 0);
            this.tlpLayout.Controls.Add(this.btnPlayPause, 1, 0);
            this.tlpLayout.Controls.Add(this.btnPrevTrack, 0, 0);
            this.tlpLayout.Location = new System.Drawing.Point(-4, 49);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 1;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLayout.Size = new System.Drawing.Size(174, 28);
            this.tlpLayout.TabIndex = 4;
            // 
            // btnEnlarge
            // 
            this.btnEnlarge.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnEnlarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnlarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnlarge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnEnlarge.Image = global::GMusic.Properties.Resources.Enlarge;
            this.btnEnlarge.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnlarge.Location = new System.Drawing.Point(150, 0);
            this.btnEnlarge.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnlarge.Name = "btnEnlarge";
            this.btnEnlarge.Size = new System.Drawing.Size(24, 28);
            this.btnEnlarge.TabIndex = 4;
            this.btnEnlarge.UseVisualStyleBackColor = false;
            this.btnEnlarge.Click += new System.EventHandler(this.btnEnlarge_Click);
            this.btnEnlarge.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.btnEnlarge.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnNextTrack
            // 
            this.btnNextTrack.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNextTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnNextTrack.Image = global::GMusic.Properties.Resources.NextTrack;
            this.btnNextTrack.Location = new System.Drawing.Point(100, 0);
            this.btnNextTrack.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextTrack.Name = "btnNextTrack";
            this.btnNextTrack.Size = new System.Drawing.Size(50, 28);
            this.btnNextTrack.TabIndex = 3;
            this.btnNextTrack.UseVisualStyleBackColor = false;
            this.btnNextTrack.Click += new System.EventHandler(this.btnNextTrack_Click);
            this.btnNextTrack.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.btnNextTrack.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayPause.Image")));
            this.btnPlayPause.Location = new System.Drawing.Point(50, 0);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(50, 28);
            this.btnPlayPause.TabIndex = 2;
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            this.btnPlayPause.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.btnPlayPause.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnPrevTrack
            // 
            this.btnPrevTrack.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrevTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnPrevTrack.Image = global::GMusic.Properties.Resources.PrevTrack;
            this.btnPrevTrack.Location = new System.Drawing.Point(0, 0);
            this.btnPrevTrack.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrevTrack.Name = "btnPrevTrack";
            this.btnPrevTrack.Size = new System.Drawing.Size(50, 28);
            this.btnPrevTrack.TabIndex = 1;
            this.btnPrevTrack.UseVisualStyleBackColor = false;
            this.btnPrevTrack.Click += new System.EventHandler(this.btnPrevTrack_Click);
            this.btnPrevTrack.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.btnPrevTrack.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblNowPlayingBackground
            // 
            this.lblNowPlayingBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNowPlayingBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNowPlayingBackground.CausesValidation = false;
            this.lblNowPlayingBackground.Enabled = false;
            this.lblNowPlayingBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowPlayingBackground.Location = new System.Drawing.Point(-4, 25);
            this.lblNowPlayingBackground.Name = "lblNowPlayingBackground";
            this.lblNowPlayingBackground.Size = new System.Drawing.Size(181, 21);
            this.lblNowPlayingBackground.TabIndex = 5;
            // 
            // lblNowPlaying
            // 
            this.lblNowPlaying.AutoSize = true;
            this.lblNowPlaying.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNowPlaying.Enabled = false;
            this.lblNowPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowPlaying.Location = new System.Drawing.Point(4, 28);
            this.lblNowPlaying.Name = "lblNowPlaying";
            this.lblNowPlaying.Size = new System.Drawing.Size(45, 16);
            this.lblNowPlaying.TabIndex = 6;
            this.lblNowPlaying.Text = "label1";
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeat.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRepeat.Location = new System.Drawing.Point(15, 3);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(59, 16);
            this.lblRepeat.TabIndex = 7;
            this.lblRepeat.Text = "Repeat";
            this.lblRepeat.Click += new System.EventHandler(this.lblRepeat_Click);
            // 
            // lblShuffle
            // 
            this.lblShuffle.AutoSize = true;
            this.lblShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShuffle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblShuffle.Location = new System.Drawing.Point(96, 3);
            this.lblShuffle.Name = "lblShuffle";
            this.lblShuffle.Size = new System.Drawing.Size(55, 16);
            this.lblShuffle.TabIndex = 8;
            this.lblShuffle.Text = "Shuffle";
            this.lblShuffle.Click += new System.EventHandler(this.lblShuffle_Click);
            // 
            // MiniControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(175, 86);
            this.ControlBox = false;
            this.Controls.Add(this.lblShuffle);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.lblNowPlaying);
            this.Controls.Add(this.tlpLayout);
            this.Controls.Add(this.lblNowPlayingBackground);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::GMusic.Properties.Settings.Default, "MiniPlayerLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = global::GMusic.Properties.Settings.Default.MiniPlayerLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiniControls";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MiniControls";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.Resize += new System.EventHandler(this.MiniControls_Resize);
            this.tlpLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Button btnEnlarge;
        private System.Windows.Forms.Button btnNextTrack;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnPrevTrack;
        public System.Windows.Forms.Label lblNowPlayingBackground;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblNowPlaying;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblShuffle;


    }
}