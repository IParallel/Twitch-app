namespace TwitchApp
{
    partial class KeyTriggerTab
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KeyTriggerContent = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(12)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 40);
            this.panel1.TabIndex = 2;
            // 
            // KeyTriggerContent
            // 
            this.KeyTriggerContent.AutoScroll = true;
            this.KeyTriggerContent.AutoSize = true;
            this.KeyTriggerContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.KeyTriggerContent.ColumnCount = 1;
            this.KeyTriggerContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.KeyTriggerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyTriggerContent.Location = new System.Drawing.Point(0, 0);
            this.KeyTriggerContent.Margin = new System.Windows.Forms.Padding(0);
            this.KeyTriggerContent.Name = "KeyTriggerContent";
            this.KeyTriggerContent.Padding = new System.Windows.Forms.Padding(10);
            this.KeyTriggerContent.RowCount = 1;
            this.KeyTriggerContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyTriggerContent.Size = new System.Drawing.Size(800, 410);
            this.KeyTriggerContent.TabIndex = 3;
            // 
            // KeyTriggerTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.KeyTriggerContent);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeyTriggerTab";
            this.Text = "KeyTriggerTab";
            this.Load += new System.EventHandler(this.on_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Panel panel1;
        private TableLayoutPanel KeyTriggerContent;
    }
}