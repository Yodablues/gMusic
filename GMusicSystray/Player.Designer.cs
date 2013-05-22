namespace GMusic
{
    partial class Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureBrowserKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMiniplayerWhenHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSystemTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gecko = new Skybound.Gecko.GeckoWebBrowser();
            this.mnuIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // nIcon
            // 
            this.nIcon.ContextMenuStrip = this.mnuIcon;
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "Google Music";
            this.nIcon.Visible = true;
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // mnuIcon
            // 
            this.mnuIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mnuIcon.Name = "contextMenuStrip1";
            this.mnuIcon.Size = new System.Drawing.Size(114, 48);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureBrowserKeysToolStripMenuItem,
            this.showMiniplayerWhenHiddenToolStripMenuItem,
            this.minimizeToSystemTrayToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // captureBrowserKeysToolStripMenuItem
            // 
            this.captureBrowserKeysToolStripMenuItem.Name = "captureBrowserKeysToolStripMenuItem";
            this.captureBrowserKeysToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.captureBrowserKeysToolStripMenuItem.Text = "Capture Browser Keys";
            this.captureBrowserKeysToolStripMenuItem.Click += new System.EventHandler(this.captureBrowserKeysToolStripMenuItem_Click);
            // 
            // showMiniplayerWhenHiddenToolStripMenuItem
            // 
            this.showMiniplayerWhenHiddenToolStripMenuItem.Checked = global::GMusic.Properties.Settings.Default.ShowMiniplayer;
            this.showMiniplayerWhenHiddenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMiniplayerWhenHiddenToolStripMenuItem.Name = "showMiniplayerWhenHiddenToolStripMenuItem";
            this.showMiniplayerWhenHiddenToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.showMiniplayerWhenHiddenToolStripMenuItem.Text = "Show Miniplayer When Hidden";
            this.showMiniplayerWhenHiddenToolStripMenuItem.Click += new System.EventHandler(this.showMiniplayerWhenHiddenToolStripMenuItem_Click);
            // 
            // minimizeToSystemTrayToolStripMenuItem
            // 
            this.minimizeToSystemTrayToolStripMenuItem.Checked = true;
            this.minimizeToSystemTrayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeToSystemTrayToolStripMenuItem.Name = "minimizeToSystemTrayToolStripMenuItem";
            this.minimizeToSystemTrayToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.minimizeToSystemTrayToolStripMenuItem.Text = "Minimize To System Tray";
            this.minimizeToSystemTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToSystemTrayToolStripMenuItem_Click);
            // 
            // gecko
            // 
            this.gecko.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gecko.Location = new System.Drawing.Point(0, 0);
            this.gecko.Name = "gecko";
            this.gecko.NoDefaultContextMenu = true;
            this.gecko.Size = new System.Drawing.Size(872, 573);
            this.gecko.TabIndex = 6;
            this.gecko.Navigated += new Skybound.Gecko.GeckoNavigatedEventHandler(this.gecko_Navigated);
            this.gecko.DocumentCompleted += new System.EventHandler(this.gecko_DocumentCompleted);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(872, 573);
            this.Controls.Add(this.gecko);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "Player";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Google Music";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Player_FormClosing);
            this.Load += new System.EventHandler(this.Player_Load);
            this.LocationChanged += new System.EventHandler(this.Player_LocationChanged);
            this.Resize += new System.EventHandler(this.OnResize);
            this.mnuIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.ContextMenuStrip mnuIcon;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private Skybound.Gecko.GeckoWebBrowser gecko;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureBrowserKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMiniplayerWhenHiddenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystemTrayToolStripMenuItem;
    }
}

