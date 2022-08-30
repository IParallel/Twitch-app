using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
namespace TwitchApp
{
    public class Twitch
    {
        TwitchClient? client;
        Console.Log? ConsoleLog = Program.ConsoleLog;
        public void Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials(Globals.TwichChannelName, Globals.TwichToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, Globals.TwichChannelName);
            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnWhisperReceived += Client_OnWhisperReceived;
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.OnChatCommandReceived += Client_Command;
            client.Connect();
        }
        private void Client_Command(object sender, OnChatCommandReceivedArgs args)
        {
            string cmdArgs = args.Command.ArgumentsAsString;
            string user = args.Command.ChatMessage.Username;
            string cmd = args.Command.CommandText;
            ConsoleLog("[LOG] ", Color.FromArgb(0, 255, 255));
            ConsoleLog($"{DateTime.Now.ToString()} ", Color.FromArgb(0, 155, 0));
            ConsoleLog($"[{user}]", args.Command.ChatMessage.Color);
            ConsoleLog($"Usó el comando -> {cmd} {(cmdArgs == String.Empty ? "No Arguments" : cmdArgs)}{Environment.NewLine}", Color.Empty);
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            if (e.Data.Contains("PRIVMSG")) return;
            ConsoleLog("[LOG] ", Color.FromArgb(0, 255, 255));
            ConsoleLog($"{e.DateTime.ToString()} ", Color.FromArgb(0, 155, 0));
            ConsoleLog($"{e.BotUsername.ToUpper()} -> {e.Data.Replace("=", " ").Replace(";", " ").Replace("Received:", String.Empty).Replace(":", "").Trim()}{Environment.NewLine}", Color.Empty);
        }
        private async void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            //client.SendMessage(e.Channel, "UwU");
            await Task.Delay(3000);
            ConsoleLog("[BOT] ", Color.FromArgb(150, 0, 50));
            ConsoleLog($"Estoy Conectado como {e.BotUsername}{Environment.NewLine}", Color.Empty);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
            ConsoleLog("[LOG] ", Color.FromArgb(0, 255, 255));
            ConsoleLog($"{DateTime.Now.ToString()} ", Color.FromArgb(0, 155, 0));
            ConsoleLog($"[{e.ChatMessage.DisplayName}] ", e.ChatMessage.Color);
            ConsoleLog($"Envió -> {e.ChatMessage.Message}{Environment.NewLine}", Color.Empty);
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "shaunafurry")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }

    }
}
