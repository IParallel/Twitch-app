using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchApp
{
    public partial class Console : Form
    {
        public string colorSchema = Properties.Settings.Default.COLOR;
        public delegate void Log(string message, Color color);
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ConsoleBox.Text = "";
        }
        public Console()
        {
            InitializeComponent();
            ChangeColors();
        }
        public void AppendText(string text, Color? color)
        {
            ConsoleBox.SuspendLayout();
            ConsoleBox.SelectionStart = ConsoleBox.TextLength;
            ConsoleBox.SelectionLength = 0;
            ConsoleBox.SelectionColor = (Color)(color != null ? color : ConsoleBox.ForeColor);
            ConsoleBox.AppendText($"{text}");
            ConsoleBox.SelectionColor = ConsoleBox.ForeColor;
            ConsoleBox.ResumeLayout();
        }
        public void ConsoleLog(string text, Color color)
        {
            if (ConsoleBox.InvokeRequired)
            {
                ConsoleBox.Invoke(new Log(ConsoleLog), new object[] { text, color });
                return;
            }
            if (color.IsEmpty) color = ConsoleBox.ForeColor;
            AppendText($"{text}", color);
            ConsoleBox.SelectionStart = ConsoleBox.Text.Length;
            ConsoleBox.ScrollToCaret();
        }

        private void ChangeColors()
        {
            var color = colorSchema.Split(",");
            var ChangeColor = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
            ConsoleBox.ForeColor = ChangeColor;
            ColorButton.FlatAppearance.BorderColor = ChangeColor;
            ClearButton.FlatAppearance.BorderColor = ChangeColor;
        }
        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.COLOR = $"{dlg.Color.R},{dlg.Color.G},{dlg.Color.B}";
                colorSchema = $"{dlg.Color.R},{dlg.Color.G},{dlg.Color.B}";
                ChangeColors();
                Properties.Settings.Default.Save();
            }
        }

        private void ConsoleBox_VisibleChanged(object sender, EventArgs e)
        {
            ConsoleBox.SelectionStart = ConsoleBox.Text.Length;
            ConsoleBox.ScrollToCaret();
        }
    }
}
