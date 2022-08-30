
using TwitchLib.Api;

namespace TwitchApp
{
    internal class Globals
    {
        public static TwitchAPI? TwitchAPI;

        private static string twichChannelId = "";
        public static string TwichChannelId
        {
            get { return twichChannelId; }
            set { twichChannelId = value; }
        }

        private static string twichChannelName = "";
        public static string TwichChannelName
        {
            get { return twichChannelName; }
            set { twichChannelName = value; }
        }

        private static string twichToken = "";
        public static string TwichToken
        {
            get { return twichToken; }
            set { twichToken = value; }
        }
    }
}
