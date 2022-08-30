using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;
using Newtonsoft.Json;
using System.Reflection;
using TwitchApp.BDModels;
namespace TwitchApp
{
    internal class PubSub
    {
        private TwitchPubSub client = new TwitchPubSub();
        private Console.Log? ConsoleLog = Program.ConsoleLog;
        private KeyDict KeyDict = new KeyDict();

        public void PressKey(string key, string qty)
        {
            KeyboardInputs input = new KeyboardInputs();
            string[] keys = key.Split("+");
            if (keys.Length > 1)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    int K = KeyDict.Keys(keys[i]);
                    if (K == 0) return;
                    input.addKey(K);
                }
                for (int i = 0; i < keys.Length; i++)
                {
                    int K = KeyDict.Keys(keys[i]);
                    if (K == 0) return;
                    input.addKey(K, false);
                }
            }
            else
            {
                int K = KeyDict.Keys(keys[0]);
                if (K == 0) return;
                input.addKey(K);
                input.addKey(K, false);
            }
            int Times = int.Parse(qty);
            WindowsAPI.SendKeys(input.inputs, Times);
        }
        public void Run()
        {
            client.OnPubSubServiceConnected += onPubService;
            client.OnChannelPointsRewardRedeemed += onChannelPoints;
            client.OnListenResponse += ListenResponse;
            client.OnPubSubServiceConnected += onConnect;
            client.OnFollow += onFollow;
            //client.OnLog += onLog;
            client.ListenToChannelPoints(Globals.TwichChannelId);
            client.ListenToFollows(Globals.TwichChannelId);
            client.Connect();
        }

        private void onFollow(object sender, OnFollowArgs e)
        {
            ConsoleLog("[PUBSUB] ", Color.FromArgb(150, 0, 150));
            ConsoleLog($"{e.DisplayName} Te Esta siguiendo ahora{Environment.NewLine}", Color.Empty);
        }

        private void onLog(object sender, OnLogArgs e)
        {
            ConsoleLog("[PUBSUB] ", Color.FromArgb(150, 0, 150));
            ConsoleLog($"{e.Data.ToString()}{Environment.NewLine}", Color.Empty);
        }

        private void onConnect(object sender, EventArgs e)
        {
            ConsoleLog("[PUBSUB] ", Color.FromArgb(150, 0, 150));
            ConsoleLog($"Sistema de Eventos Cargado Correctamente{Environment.NewLine}", Color.Empty);
        }
        private void onChannelPoints(object sender, OnChannelPointsRewardRedeemedArgs e)
        {
            string rewardName = e.RewardRedeemed.Redemption.Reward.Title;
            ConsoleLog("[PUBSUB] ", Color.FromArgb(150, 0, 150));
            ConsoleLog($"{DateTime.Now.ToString()} ", Color.FromArgb(0, 155, 0));
            ConsoleLog($"{e.RewardRedeemed.Redemption.User.DisplayName} ", Color.Red);
            ConsoleLog($"Reclamó {rewardName}{Environment.NewLine}", Color.Empty);
            ChildKeyModel uwu = Program.Ktriggers.Search(x => x.name == rewardName.ToUpper()).First();
            if (uwu == null) return;
            if (uwu.key != string.Empty)
            {
                if (uwu.qty == null || uwu.qty == string.Empty) uwu.qty = "1";
                PressKey(uwu.key, uwu.qty);
            }
        }

        private void ListenResponse(object sender, OnListenResponseArgs e)
        {
            ConsoleLog("[PUBSUB] ", Color.FromArgb(150, 0, 150));
            ConsoleLog($"{(e.Successful ? $" Conectado {e.Topic}" : $"No Se Pudo conectar {e.Topic}")}{Environment.NewLine}", Color.Empty);
        }
        private void onPubService(object sender, EventArgs e)
        {
            client.SendTopics(oauth: Globals.TwichToken);
        }
    }
}
