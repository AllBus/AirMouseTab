using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirMouseTab
{
    class Obrabotka
    {
        internal const int BUTTON1_DOWN_MASK = 1;
        internal const int BUTTON2_DOWN_MASK = 2;
        internal const int BUTTON3_DOWN_MASK = 3;
        internal const int MOUSE_BUTTON4 = 4;
        internal const int MOUSE_BUTTON5 = 5;

     //   private byte[] buf;
        private int pin;

        internal const byte DEFAULT = 0;
        internal const byte MOUSE = 1;
        internal const byte MMOVE = 2;

        internal const byte MWHELL = 4;

        internal const byte KEY = 3;
        internal const byte KEYCOM = 6;
        internal const byte MESSAGE = 10;
        internal const byte NONE = 99;
        internal const byte CLOSE = 100;
        internal const byte ERROR = 101;

        float lastx = 0.0f; //остаток от предыдущего движения x

        float lasty = 0.0f; //остаток от предыдущего движения y

        int otmena = 0;//Число раз неправильно присланных котрольных значений
        Robot robot = new Robot();

        private float readFloat(byte[] buf, int start)
        {

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf,start,4); // Convert big endian to little endian
            }

            return BitConverter.ToSingle(buf, start);

        }
        private int readInt(byte[] buf, int start)
        {

          return  (buf[start] << 24) | (buf[start+1] << 16) | (buf[start+2] << 8) | (buf[start+3]);
          //  return BitConverter.ToInt32(buf, start);

        }

        public Obrabotka( int pin)
        {
         //   this.buf = buf;
            this.pin = pin;
        }

        internal byte run(byte[] buf)
        {
            var tip = buf[0];
            var command = buf[1];
            var pinCode = readInt(buf, 28);
            //Console.WriteLine(">" + tip + " > " + command);
            if (pinCode != pin)
            {
                otmena += 1;

                if (otmena > 10)
                    return ERROR;
                else
                    return NONE;
            }
            else
                otmena = 0;

            switch (tip)
            {
                case MMOVE:
                    try
                    {
                        var x = readFloat(buf, 2);

                        var y = readFloat(buf, 6);

                        var velocity = readInt(buf, 10);
                        //println(s"$x $y $velocity")
                        Point b = robot.getLocation();

                        var tekx = b.X + x + lastx;

                        var teky = b.Y + y + lasty;

                        int endx = (int)Math.Round(tekx);

                        int endy = (int)Math.Round(teky);
                        //lastx=tekx-endx
                        //lasty=teky-endy
                        //		println("velocity "+velocity)
                        robot.mouseMove(endx, endy);

                        //	Thread.sleep(10)

                    }
                    catch
                    {


                    }
                    break;
                case MOUSE:
                    try
                    {
                        byte btn = 0;
                        switch (command)
                        {
                            case 1: btn = BUTTON1_DOWN_MASK; break;
                            case 2: btn = BUTTON2_DOWN_MASK; break;
                            case 3: btn = BUTTON3_DOWN_MASK; break;
                            case 4: btn = MOUSE_BUTTON4; break;
                            case 5: btn = MOUSE_BUTTON5; break;


                        }

                        if (btn > 0)
                        {
                            switch (buf[2])
                            {
                                case 1:
                                    robot.mousePress(btn);
                                    break;
                                case 2:
                                    robot.mouseRelease(btn);
                                    break;

                            }
                        }
                    }
                    catch
                    {
                    }
                    break;
                case KEY:
                    {
                
                        int key = 0;
                        if (',' <= command && command <= ']')
                        {
                            key = command;
                        }
                        else {
                            switch (command)
                            {
                                case (byte)'a': key = (int)Keys.Alt; break;

                                case (byte)'c': key = (int)Keys.LControlKey; break;

                                case (byte)'s': key = (int)Keys.LShiftKey; break;

                                case (byte)'w': key = (int)Keys.LWin; break;

                                case (byte)'e': key = (int)Keys.Enter; break;

                                case (byte)'z': key = readInt(buf, 6); break;

                                default:

                                    break;
                            }
                        }

                  //      Console.Out.WriteLine(">>"+key+" >> "+ buf[2]);
                        try
                        {
                            // Simulate a key press
                            switch (buf[2])
                            {

                                case 0:
                                    robot.keyTap(key);
                                 
                                    break;
                                case 1:
                                    robot.keyPress(key);
                                    break;
                                case 2:
                                    robot.keyRelease(key);
                                    break;


                            }
                           
                        }
                        catch(Exception e)
                        {
                           // Console.Out.WriteLine(e.Message);

                        }
                    }
                    break;
                case KEYCOM:
                    {
                        int key = readInt(buf, 6);

                        bool shift = (command & 0x1) > 0;

                        bool control = (command & 0x2) > 0;

                        bool alt = (command & 0x4) > 0;

                        bool win = (command & 0x8) > 0;


                        if (shift) robot.keyPress((int)Keys.LShiftKey);

                        if (control) robot.keyPress((int)Keys.LControlKey);

                        if (alt) robot.keyPress((int)Keys.Alt);

                        if (win) robot.keyPress((int)Keys.LWin);

                        robot.keyPress(key);

                        robot.keyRelease(key);

                        if (win) robot.keyRelease((int)Keys.LWin);

                        if (alt) robot.keyRelease((int)Keys.Alt);

                        if (control) robot.keyRelease((int)Keys.LControlKey);

                        if (shift) robot.keyRelease((int)Keys.LShiftKey);
                        break;
                    }
                case MWHELL:
                    break;
                case MESSAGE:
                    println(command);
                    break;
                default:
                    break;
            }
            return tip;
        }

        private void println(byte command)
        {
            
        }
    }
}
