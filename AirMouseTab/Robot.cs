using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AirMouseTab
{
    class Robot
    {


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);



        internal Point getLocation()
        {
            return System.Windows.Forms.Cursor.Position;
            
        }

        internal void mouseMove(int endx, int endy)
        {
            System.Windows.Forms.Cursor.Position=new Point(endx, endy);
        }

        internal void mousePress(byte btn)
        {
            int flag = 0;
            int xbtn = 0;
            if (btn >= 4)
            {
                xbtn = (int)(btn - 3);
            }

            switch (btn)
            {
                case 1:
                    flag = (int)MouseEventFlags.LeftDown;
                    break;
                case 3:
                    flag = (int)MouseEventFlags.RightDown;
                    break;
               case 2: 
                    flag = (int)MouseEventFlags.MiddleDown;
                    break;
                case 4:
                    flag = (int)MouseEventFlags.FourDown;
                    break;
                case 5:
                    flag = (int)MouseEventFlags.FiveDown;
                    break;
            }

            var pos = System.Windows.Forms.Cursor.Position;

            mouse_event(flag, (pos.X), (pos.Y), xbtn, 0);
        }

        internal void mouseRelease(byte btn)
        {
            int flag = 0;
            int xbtn = 0;
            if (btn >= 4)
            {
                xbtn = (int)(btn - 3);
            }

            switch (btn)
            {
                case 1:
                    flag = (int)MouseEventFlags.LeftUp;
                    break;
                case 3:
                    flag = (int)MouseEventFlags.RightUp;
                    break;
                case 2:
                    flag = (int)MouseEventFlags.MiddleUp;
                    break;
                case 4:
                    flag = (int)MouseEventFlags.FourUp;
                    break;
                case 5:
                    flag = (int)MouseEventFlags.FiveUp;
                    break;
            }

            var pos = System.Windows.Forms.Cursor.Position;

            mouse_event(flag, (pos.X), (pos.Y), xbtn, 0);
        }
        internal void keyTap(int key)
        {
            WindowsInput.InputSimulator.SimulateKeyPress((WindowsInput.VirtualKeyCode)(key));
      //      keyPress(key);
      //      keyRelease(key);

        }
        internal void keyPress(int key)
        {
            INPUT[] Inputs = new INPUT[1];
            INPUT Input = new INPUT();

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wVk =   (VirtualKeyShort)key;//ScanCodeShort.KEY_W;
            Input.U.ki.dwFlags = KEYEVENTF.KEYDOWN;
            Input.U.ki.wScan = 0;
            Inputs[0] = Input;

            SendInput(1, Inputs, INPUT.Size);
        }

       

        internal void keyRelease(int key)
        {
            INPUT[] Inputs = new INPUT[1];
            INPUT Input = new INPUT();

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wVk = (VirtualKeyShort)key;//ScanCodeShort.KEY_W;
            Input.U.ki.dwFlags = KEYEVENTF.KEYUP;
            Input.U.ki.wScan = 0;
            Inputs[0] = Input;
            
            SendInput(1, Inputs, INPUT.Size);
        }
    }
}
