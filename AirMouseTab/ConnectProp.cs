using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AirMouseTab
{
    class ConnectProp
    {
        public const int DEFAULT_PORT = 7875;

        public int pin=0;
        public int port=DEFAULT_PORT;
        public string ip;


        public List<String> myIps()
        {
            List< String > list = new List<String>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {

                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    var hostAddress = ip.ToString();

                    if (hostAddress.IndexOf(':') < 0 && hostAddress != "127.0.0.1")
                    {

                        //     list.Insert(0, ip.ToString());
                        //  else
                        list.Add(ip.ToString());
                    }
                }
               // if (ip.AddressFamily == AddressFamily.InterNetwork)
              //  {
               //     return ip.ToString();
               // }
            }
            return list;
      
        }
    }
}
