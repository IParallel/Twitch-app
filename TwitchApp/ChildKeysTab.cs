
using TwitchApp.BDModels;
namespace TwitchApp
{
    public partial class ChildKeysTab : Form
    {
        private List<Tuple<string, string>> Data = new();
        private string? image;
        private string? name;
        private string? key;
        private string? count;
        private string[] color = Properties.Settings.Default.COLOR.Split(",");
        private Color Color;
        private delegate void uwu();
        public ChildKeysTab(string image = "", string name = "", string key = "", string count = null)
        {
            this.Color = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
            this.image = image;
            this.name = name;
            this.key = key;
            this.count = count;
            InitializeComponent();
            TwitchRewardImage.Image = TwitchRewardImage.InitialImage;
            CustomStyle();
            TryToLoadForm();
        }

        private void CustomStyle ()
        {
            this.underLine.BackColor = Color;
            this.underLine2.BackColor = Color;
            this.underLine3.BackColor = Color;
        }
        private void TryToLoadForm()
        {
            if (image != null || name != null || key != null || count != null)
            {
                this.RewardName.Text = name;
                this.KeyName.Text = key;
                this.TwitchRewardImage.ImageLocation = image;
                this.CountTextBox.Text = count;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Ktriggers.Delete(x => x.name == this.RewardName.Text);
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.ChannelRewards.Count; i++)
            {
                var element = Program.ChannelRewards[i];
                if (element.Item1.ToUpper() == RewardName.Text)
                {
                    TwitchRewardImage.ImageLocation = element.Item2;
                    return;
                }
            }
            if (TwitchRewardImage.Image != TwitchRewardImage.InitialImage)
                TwitchRewardImage.Image = TwitchRewardImage.InitialImage;
        }
        private void ShowError(string text, Color color)
        {
            ErrorProvider.Text = text;
            ErrorProvider.ForeColor = color;
            ErrorProvider.Show();
            var t = new System.Windows.Forms.Timer();
            t.Interval = 5000;
            t.Tick += (s, e) =>
            {
                ErrorProvider.Hide();
                done = false;
                t.Stop();
            };
            t.Start();
        }
        private bool done = false;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (done) return;
            if (RewardName.Text == "" || KeyName.Text == "")
            {
                done = true;
                ShowError("Introduce el nombre de la reward o tecla", Color.FromArgb(255, 0, 0));
                return;
            }
            List<ChildKeyModel> check = Program.Ktriggers.Search(x=> x.name == RewardName.Text.ToUpper());
            if (check.Count == 0)
            {
                done = true;
                Program.Ktriggers.Add(new ChildKeyModel(RewardName.Text.ToUpper(), TwitchRewardImage.ImageLocation, KeyName.Text.ToUpper(), CountTextBox.Text));
                ShowError("Guardado Exitosamente", Color.FromArgb(0, 150, 0));
            }
            else
            {
                ChildKeyModel child = check.First();
                child.name = RewardName.Text.ToUpper();
                child.image = TwitchRewardImage.ImageLocation;
                child.key = KeyName.Text.ToUpper();
                child.qty = CountTextBox.Text;
                Program.Ktriggers.Update(x => x.name == child.name, child);
                done = true;
                ShowError("Se ha actualizado este evento", Color.FromArgb(0, 150, 0));
            }
        }
    }
}
