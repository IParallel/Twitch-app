using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace TwitchApp
{
    internal class WindowsAPI
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, KeyboardInputs.Input[] pInputs, int cbSize);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetMessageExtraInfo();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern ushort MapVirtualKey(int vScanCode, uint vMapType);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool BlockInput(bool fBlockIt);
        #region structs
        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }
        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }
        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }
        public enum MouseEventF
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }
        public struct Input
        {
            public int type;
            public InputUnion u;
        }
        #endregion

        public static void SendKeys(List<KeyboardInputs.Input> inputs, int times)
        {
            if (inputs.Count == 0) return;
            for (int i = 0; i < times; i++)
            {
                Task.Run(() => {
                    BlockInput(true);
                    SendInput((uint)inputs.Count, inputs.ToArray(), Marshal.SizeOf(typeof(KeyboardInputs.Input)));
                    BlockInput(false);
                }).Wait(50);
                /*
                Task uwu = new Task(() => 
                {

                });
                uwu.Wait(50);
                uwu.Start();
                */
            }
            return;
        }
    }
}
