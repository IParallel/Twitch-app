using TwitchApp.BDModels;
namespace TwitchApp
{
    public static class Program
    {

        public static TwitchApp main = new TwitchApp();
        public static Config<ChildKeyModel>? Ktriggers;
        public static Console.Log? ConsoleLog;
        public static List<Tuple<string, string>>? ChannelRewards;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(main);

        }
    }
}