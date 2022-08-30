using TwitchApp.BDModels;
using Newtonsoft.Json.Linq;
using NHttp;
using System.Diagnostics;
using System.Net;
using TwitchLib.Api;
using System.Runtime.InteropServices;
namespace TwitchApp
{
    public partial class TwitchApp : Form
    {
        private readonly string updateUrl = "https://pastebin.com/raw/7QjMDj55";
        public readonly string clientId = Properties.Settings.Default.CLIENTID;
        public readonly string secret = Properties.Settings.Default.SECRET;
        public Console console = new Console();
        public Console.Log ConsoleLog;
        public TwitchAPI? twitchApi;
        public delegate void d();
        private HttpServer? WebServer;
        private readonly string scopes = "analytics:read:extensions+user:edit+user:read:email+clips:edit+bits:read+analytics:read:games+user:edit:broadcast+user:read:broadcast+chat:read+chat:edit+channel:moderate+channel:read:subscriptions+whispers:read+whispers:edit+moderation:read+channel:read:redemptions+channel:edit:commercial+channel:read:hype_train+channel:read:stream_key+channel:manage:extensions+channel:manage:broadcast+user:edit:follows+channel:manage:redemptions+channel:read:editors+channel:manage:videos+user:read:blocked_users+user:manage:blocked_users+user:read:subscriptions+user:read:follows+channel:manage:polls+channel:manage:predictions+channel:read:polls+channel:read:predictions+moderator:manage:automod+channel:manage:schedule+channel:read:goals+moderator:read:automod_settings+moderator:manage:automod_settings+moderator:manage:banned_users+moderator:read:blocked_terms+moderator:manage:blocked_terms+moderator:read:chat_settings+moderator:manage:chat_settings+channel:manage:raids";
        private readonly string redirectUri = "http://localhost";
        private FormWindowState lastState;
        private string version = "1.0.0";
        private System.Timers.Timer timer = new();
        private System.Drawing.Size lastWindowSize;
        private Point lastWindowLocation;
        public TwitchApp()
        {
            InitializeComponent();
#if DEBUG
            AllocConsole();
#endif
            Task.Run(CheckUpdates).Wait();
            customizeDesign();
            DisableMenus();
            Program.Ktriggers = new Config<ChildKeyModel>("Ktriggers");
            Program.Ktriggers.Load();
            Program.ConsoleLog = console.ConsoleLog;
            Program.ChannelRewards = new();
            ConsoleLog = Program.ConsoleLog;
        }
        private bool mouseDown;
        private Point lastLocation;


        #region updater
        public async Task CheckUpdates()
        {
            HttpClient webClient = new();
            try
            {
                var response = await webClient.GetStringAsync(updateUrl);
                System.Console.WriteLine(response);
                if (!response.Contains(this.version))
                {
                    if (MessageBox.Show("Parece que hay una actualización disponible, ¿Quieres actualizar?", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(@".\Update.exe");
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }
        #endregion
        #region MouseEvents
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;
            this.Location = new Point(
            (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

            this.Update();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion
        #region WebServer
        private void InitializeWebServer()
        {
            WebServer = new HttpServer();
            WebServer.EndPoint = new IPEndPoint(IPAddress.Loopback, 80);
            WebServer.RequestReceived += async (s, e) =>
            {
                using (var writer = new StreamWriter(e.Response.OutputStream))
                {
                    if (e.Request.QueryString.AllKeys.Any("code".Contains))
                    {
                        string? code = e.Request.QueryString["code"];
#pragma warning disable CS8604 // Posible argumento de referencia nulo
                        var ownerOfChannelAccessAndRefresh = await getAccessAndRefresTokens(code: code);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
                        Globals.TwichToken = ownerOfChannelAccessAndRefresh.Item1;
                        TwitchApi tw = new TwitchApi();
                        Globals.TwitchAPI = tw.api;
                        twitchApi = tw.api;
                        var oauthUser = await twitchApi.Helix.Users.GetUsersAsync();
                        Globals.TwichChannelName = oauthUser.Users[0].Login;
                        Globals.TwichChannelId = oauthUser.Users[0].Id;
                        this.timer.Interval = 5000;
                        this.timer.Elapsed += this.getRewards_Tick;
                        this.timer.Start();
                        this.BannerImage.ImageLocation = oauthUser.Users[0].ProfileImageUrl;
                        new Twitch().Bot();
                        new PubSub().Run();
                        EnableMenus();
                    }
                }
            };
            WebServer.Start();
            console.ConsoleLog("[WEBSERVER] ", Color.FromArgb(0, 150, 0));
            console.ConsoleLog($"Web Server started on: {WebServer.EndPoint}{Environment.NewLine}", Color.Empty);
        }

        private async Task<Tuple<string, string>> getAccessAndRefresTokens(string code)
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "client_secret", secret },
                { "code", code },
                { "grant_type", "authorization_code" },
                { "redirect_uri", redirectUri }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://id.twitch.tv/oauth2/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseString);
            return new Tuple<string, string>(json["access_token"].ToString(), json["refresh_token"].ToString());
        }
        #endregion WebServer
        #region Form Events
        private void Form1_Load(object sender, EventArgs e)
        {
            //
            bool TopMost = this.TopMost;
            this.TopMost = true;

            this.TopMost = TopMost;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private void Main_FormClosing(object sender, FormClosedEventArgs e)
        {
            if (WebServer != null)
            {
                WebServer.Stop();
                WebServer.Dispose();
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState.Equals(FormWindowState.Minimized))
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                return;
            }
            lastState = this.WindowState;
            lastWindowSize = this.Size;
            lastWindowLocation = this.Location;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            this.WindowState = lastState;
            this.Size = lastWindowSize;
            this.Location = lastWindowLocation;
        }
        private void EventsButton_Click(object sender, EventArgs e)
        {
            showMenu(EventsTab);
        }
        private void StartButton_Click_1(object sender, EventArgs e)
        {
            if (WebServer != null)
            {
                console.ConsoleLog("[WARNING] ", Color.FromArgb(255, 255, 0));
                console.ConsoleLog($"Parece que ya está corriendo una sesión{Environment.NewLine}", Color.Empty);
                return;
            }
            InitializeWebServer();
            var authUrl = $"https://id.twitch.tv/oauth2/authorize?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope={scopes}";
            System.Diagnostics.Process.Start(new ProcessStartInfo(authUrl) { UseShellExecute = true });
        }
        private void KeyTrigger_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KeyTriggerTab());
        }
#endregion
        #region customfunctions
        private void customizeDesign()
        {
            EventsTab.Visible = false;
        }
        private bool ConsoleAttached = false;
        private void ConsoleButton_Click(object sender, EventArgs e)
        {
            if (ConsoleAttached == false)
            {
                console.TopLevel = false;
                console.FormBorderStyle = FormBorderStyle.None;
                console.Dock = DockStyle.Fill;
                ShowWindow.Controls.Add(console);
                ShowWindow.Tag = console;
                console.BringToFront();
                console.Show();
                ConsoleAttached = true;
                return;
            }
            if (lastChildOpened)
            {
                console.BringToFront();
                console.Visible = true;
                lastChildOpened = false;
                return;
            }
            console.Visible = !console.Visible;

        }
#endregion
        #region MenuUtils
        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }else
                subMenu.Visible = false;
        }

        private Form? lastChild;
        private bool lastChildOpened = false;
        private void OpenChildForm(Form childForm)
        {
            lastChildOpened = true;
            if (console.Visible && lastChild != null) lastChild.BringToFront();
            if (lastChild != null && lastChild.Name == childForm.Name) return;
            if (lastChild != null)
            {
                lastChild.Dispose();
                lastChild = null;
            }
            lastChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ShowWindow.Controls.Add(childForm);
            ShowWindow.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            console.Visible = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        private void HideSubMenu()
        {
            if (EventsTab.Visible == true)
                EventsTab.Visible = false;
        }

        private void DisableMenus()
        {
            EventsButton.Enabled = false;
        }

        private void EnableMenus()
        {
            if (EventsButton.InvokeRequired)
            {
                EventsButton.Invoke(new d(EnableMenus));
                return;
            }
            EventsButton.Enabled = true;
        }
        #endregion

        private async void getRewards_Tick(object sender, EventArgs e)
        {
            try
            {
                //System.Console.WriteLine(Program.ChannelRewards.Count);
                var data = await twitchApi.Helix.ChannelPoints.GetCustomReward(Globals.TwichChannelId);
                List<Tuple<string, string>> a = new();
                for (int i = 0; i < data.Data.Length; i++)
                {
                    a.Add(new Tuple<string, string>(data.Data[i].Title, data.Data[i].Image.Url2x));
                }
                Program.ChannelRewards = a;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                Program.ConsoleLog("[WARNING] ", Color.FromArgb(255, 255, 0));
                Program.ConsoleLog($"Tu canal no tiene recompensas{Environment.NewLine}", Color.Empty);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display.Orientations[] things = new Display.Orientations[]
            {
                Display.Orientations.DEGREES_CW_90,
                Display.Orientations.DEGREES_CW_180,
                Display.Orientations.DEGREES_CW_270
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < things.Length; j++)
                {
                    //Random random = new Random();
                    Display.Orientations orientation = things[j];
                    Display.Rotate(1, orientation);
                    Task.Delay(1000).Wait();
                    //Display.Rotate(1, Display.Orientations.DEGREES_CW_0);
                }
            }

            Display.Rotate(1, Display.Orientations.DEGREES_CW_0);

        }
    }
}