namespace TwitchApp
{
    partial class TwitchApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitchApp));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.EventsTab = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.KeyTrigger = new System.Windows.Forms.Button();
            this.EventsButton = new System.Windows.Forms.Button();
            this.ConsoleButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BannerImage = new System.Windows.Forms.PictureBox();
            this.ShowWindow = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.EventsTab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).BeginInit();
            this.ShowWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Twitch App is running in background";
            this.notifyIcon1.BalloonTipTitle = "Twitch App";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TwitchApp";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.EventsTab);
            this.panel1.Controls.Add(this.EventsButton);
            this.panel1.Controls.Add(this.ConsoleButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 591);
            this.panel1.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(6)))), ((int)(((byte)(17)))));
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(0, 551);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(228, 40);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "LogIn";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click_1);
            // 
            // EventsTab
            // 
            this.EventsTab.AutoSize = true;
            this.EventsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(7)))), ((int)(((byte)(12)))));
            this.EventsTab.Controls.Add(this.button4);
            this.EventsTab.Controls.Add(this.button3);
            this.EventsTab.Controls.Add(this.button2);
            this.EventsTab.Controls.Add(this.KeyTrigger);
            this.EventsTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.EventsTab.Location = new System.Drawing.Point(0, 174);
            this.EventsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventsTab.Name = "EventsTab";
            this.EventsTab.Size = new System.Drawing.Size(228, 160);
            this.EventsTab.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(5)))), ((int)(((byte)(12)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(24)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 120);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(228, 40);
            this.button4.TabIndex = 7;
            this.button4.Text = "Coming soon...";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(5)))), ((int)(((byte)(12)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(24)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 80);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(228, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "Coming soon...";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(5)))), ((int)(((byte)(12)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(24)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 40);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(228, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "Coming soon...";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // KeyTrigger
            // 
            this.KeyTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(5)))), ((int)(((byte)(12)))));
            this.KeyTrigger.Dock = System.Windows.Forms.DockStyle.Top;
            this.KeyTrigger.FlatAppearance.BorderSize = 0;
            this.KeyTrigger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(24)))));
            this.KeyTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeyTrigger.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyTrigger.ForeColor = System.Drawing.Color.White;
            this.KeyTrigger.Location = new System.Drawing.Point(0, 0);
            this.KeyTrigger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KeyTrigger.Name = "KeyTrigger";
            this.KeyTrigger.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.KeyTrigger.Size = new System.Drawing.Size(228, 40);
            this.KeyTrigger.TabIndex = 4;
            this.KeyTrigger.Text = "KeyTrigger";
            this.KeyTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KeyTrigger.UseVisualStyleBackColor = false;
            this.KeyTrigger.Click += new System.EventHandler(this.KeyTrigger_Click);
            // 
            // EventsButton
            // 
            this.EventsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(6)))), ((int)(((byte)(17)))));
            this.EventsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EventsButton.FlatAppearance.BorderSize = 0;
            this.EventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventsButton.ForeColor = System.Drawing.Color.White;
            this.EventsButton.Location = new System.Drawing.Point(0, 134);
            this.EventsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventsButton.Name = "EventsButton";
            this.EventsButton.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.EventsButton.Size = new System.Drawing.Size(228, 40);
            this.EventsButton.TabIndex = 3;
            this.EventsButton.Text = "Events";
            this.EventsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EventsButton.UseVisualStyleBackColor = false;
            this.EventsButton.Click += new System.EventHandler(this.EventsButton_Click);
            // 
            // ConsoleButton
            // 
            this.ConsoleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(6)))), ((int)(((byte)(17)))));
            this.ConsoleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsoleButton.FlatAppearance.BorderSize = 0;
            this.ConsoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsoleButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleButton.ForeColor = System.Drawing.Color.White;
            this.ConsoleButton.Location = new System.Drawing.Point(0, 94);
            this.ConsoleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConsoleButton.Name = "ConsoleButton";
            this.ConsoleButton.Size = new System.Drawing.Size(228, 40);
            this.ConsoleButton.TabIndex = 2;
            this.ConsoleButton.Text = "Console";
            this.ConsoleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConsoleButton.UseVisualStyleBackColor = false;
            this.ConsoleButton.Click += new System.EventHandler(this.ConsoleButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.panel2.Controls.Add(this.BannerImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 94);
            this.panel2.TabIndex = 1;
            // 
            // BannerImage
            // 
            this.BannerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BannerImage.Image = global::TwitchApp.Properties.Resources.ApoBotIcon;
            this.BannerImage.Location = new System.Drawing.Point(0, 0);
            this.BannerImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BannerImage.Name = "BannerImage";
            this.BannerImage.Size = new System.Drawing.Size(228, 94);
            this.BannerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BannerImage.TabIndex = 0;
            this.BannerImage.TabStop = false;
            // 
            // ShowWindow
            // 
            this.ShowWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ShowWindow.Controls.Add(this.pictureBox2);
            this.ShowWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowWindow.Location = new System.Drawing.Point(228, 0);
            this.ShowWindow.Margin = new System.Windows.Forms.Padding(0);
            this.ShowWindow.Name = "ShowWindow";
            this.ShowWindow.Size = new System.Drawing.Size(1032, 591);
            this.ShowWindow.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(305, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(469, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // TwitchApp
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1260, 591);
            this.Controls.Add(this.ShowWindow);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimumSize = new System.Drawing.Size(1084, 630);
            this.Name = "TwitchApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch App";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.EventsTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).EndInit();
            this.ShowWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private NotifyIcon notifyIcon1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox BannerImage;
        private Panel EventsTab;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button KeyTrigger;
        private Button EventsButton;
        private Button ConsoleButton;
        private Panel ShowWindow;
        private Button StartButton;
        private PictureBox pictureBox2;
    }
}