using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AirMouseTab
{
    class UdpState
    {
        public UdpClient client;
        public IPEndPoint ep;
        public Obrabotka obrabotka;
    }
}
