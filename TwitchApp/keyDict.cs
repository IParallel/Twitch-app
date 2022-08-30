
using System.Text.RegularExpressions;

namespace TwitchApp
{
    public class KeyDict
    {
        public string BACKSPACE = "0x8";
        public string TAB = "0x9";
        public string CLEAR = "0xc";
        public string ENTER = "0xd";
        public string SHIFT = "0x10";
        public string CTRL = "0x11";
        public string ALT = "0x12";
        public string PAUSE = "0x13";
        public string CAPS_LOCK = "0x14";
        public string ESC = "0x1b";
        public string SPACEBAR = "0x20";
        public string PAGE_UP = "0x21";
        public string PAGE_DOWN = "0x22";
        public string END = "0x23";
        public string HOME = "0x24";
        public string LEFT_ARROW = "0x25";
        public string UP_ARROW = "0x26";
        public string RIGHT_ARROW = "0x27";
        public string DOWN_ARROW = "0x28";
        public string SELECT = "0x29";
        public string PRINT = "0x2a";
        public string EXECUTE = "0x2b";
        public string PRINT_SCREEN = "0x2c";
        public string INS = "0x2d";
        public string DEL = "0x2e";
        public string HELP = "0x2f";
        public string K0 = "0x30";
        public string K1 = "0x31";
        public string K2 = "0x32";
        public string K3 = "0x33";
        public string K4 = "0x34";
        public string K5 = "0x35";
        public string K6 = "0x36";
        public string K7 = "0x37";
        public string K8 = "0x38";
        public string K9 = "0x39";
        public string A = "0x41";
        public string B = "0x42";
        public string C = "0x43";
        public string D = "0x44";
        public string E = "0x45";
        public string F = "0x46";
        public string G = "0x47";
        public string H = "0x48";
        public string I = "0x49";
        public string J = "0x4a";
        public string K = "0x4b";
        public string L = "0x4c";
        public string M = "0x4d";
        public string N = "0x4e";
        public string O = "0x4f";
        public string P = "0x50";
        public string Q = "0x51";
        public string R = "0x52";
        public string S = "0x53";
        public string T = "0x54";
        public string U = "0x55";
        public string V = "0x56";
        public string W = "0x57";
        public string X = "0x58";
        public string Y = "0x59";
        public string Z = "0x5a";
        public string NUMPAD_0 = "0x60";
        public string NUMPAD_1 = "0x61";
        public string NUMPAD_2 = "0x62";
        public string NUMPAD_3 = "0x63";
        public string NUMPAD_4 = "0x64";
        public string NUMPAD_5 = "0x65";
        public string NUMPAD_6 = "0x66";
        public string NUMPAD_7 = "0x67";
        public string NUMPAD_8 = "0x68";
        public string NUMPAD_9 = "0x69";
        public string MULTIPLY_KEY = "0x6a";
        public string ADD_KEY = "0x6b";
        public string SEPARATOR_KEY = "0x6c";
        public string SUBTRACT_KEY = "0x6d";
        public string DECIMAL_KEY = "0x6e";
        public string DIVIDE_KEY = "0x6f";
        public string F1 = "0x70";
        public string F2 = "0x71";
        public string F3 = "0x72";
        public string F4 = "0x73";
        public string F5 = "0x74";
        public string F6 = "0x75";
        public string F7 = "0x76";
        public string F8 = "0x77";
        public string F9 = "0x78";
        public string F10 = "0x79";
        public string F11 = "0x7a";
        public string F12 = "0x7b";
        public string F13 = "0x7c";
        public string F14 = "0x7d";
        public string F15 = "0x7e";
        public string F16 = "0x7f";
        public string F17 = "0x80";
        public string F18 = "0x81";
        public string F19 = "0x82";
        public string F20 = "0x83";
        public string F21 = "0x84";
        public string F22 = "0x85";
        public string F23 = "0x86";
        public string F24 = "0x87";
        public string NUM_LOCK = "0x90";
        public string SCROLL_LOCK = "0x91";
        public string LEFT_SHIFT = "0xa0";
        public string RIGHT_SHIFT = "0xa1";
        public string LEFT_CONTROL = "0xa2";
        public string RIGHT_CONTROL = "0xa3";
        public string LEFT_MENU = "0xa4";
        public string RIGHT_MENU = "0xa5";
        public string BROWSER_BACK = "0xa6";
        public string BROWSER_FORWARD = "0xa7";
        public string BROWSER_REFRESH = "0xa8";
        public string BROWSER_STOP = "0xa9";
        public string BROWSER_SEARCH = "0xaa";
        public string BROWSER_FAVORITES = "0xab";
        public string BROWSER_START_AND_HOME = "0xac";
        public string VOLUME_MUTE = "0xad";
        public string VOLUME_DOWN = "0xae";
        public string VOLUME_UP = "0xaf";
        public string NEXT_TRACK = "0xb0";
        public string PREVIOUS_TRACK = "0xb1";
        public string STOP_MEDIA = "0xb2";
        public string PLAY_PAUSE_MEDIA = "0xb3";
        public string START_MAIL = "0xb4";
        public string SELECT_MEDIA = "0xb5";
        public string START_APPLICATION_1 = "0xb6";
        public string START_APPLICATION_2 = "0xb7";
        public string ATTN_KEY = "0xf6";
        public string CRSEL_KEY = "0xf7";
        public string EXSEL_KEY = "0xf8";
        public string PLAY_KEY = "0xfa";
        public string ZOOM_KEY = "0xfb";
        public string CLEAR_KEY = "0xfe";

        public int Keys(string fieldName)
        {
            try
            {
                if (Regex.IsMatch(fieldName, @"^\d+$")) fieldName = $"K{fieldName}";

                int keyCode = int.Parse(this.GetType().GetField(fieldName).GetValue(this).ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
                //int uwu = int.Parse("44", System.Globalization.NumberStyles.HexNumber);
                return keyCode;
            } catch
            {
                return 0;
            }
        }

    }
}
