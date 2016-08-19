using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AirMouseTab
{
    class ServerDataMain
    {
       // int PORT = 7875;

        int bufSize = 32;

        bool continueReceive = true;

        private bool bRunServer = false; //Сервер запущен

        private void startReceive()
        {
            bRunServer = true;
            //	DForm.changeStartBtn()
        }

        private void endReceive()
        {
            bRunServer = false;
            //DForm.changeStartBtn()
        }

        public bool isRunServer()
        {
            return bRunServer;
        }

        public void serverStop()
        {
            //	println("otmena")
            continueReceive = false;
        }

       public void start(ConnectProp connectProp)
        {
            byte[] buf = new byte[bufSize];

            try
            {
                startReceive();
                IPAddress serverAddr = IPAddress.Parse(connectProp.ip);

                IPEndPoint endPoint = new IPEndPoint(serverAddr, connectProp.port);
                using (Socket socket = new Socket(AddressFamily.InterNetwork,
                         SocketType.Dgram,
                         ProtocolType.Udp))
                {
                    
                    var obrabotka = new Obrabotka( connectProp.pin);
                    while (continueReceive)
                    {
                        try
                        {
                            socket.Receive(buf);

                            byte ret = obrabotka.run(buf);

                            if (ret >= Obrabotka.CLOSE)
                                continueReceive = false;

                        }
                        catch(SocketException e)
                        {

                        }
                    }
                }
            }
            catch
            {
               
            }
            finally
            {
                endReceive();
            }
            

        }
    }

}
