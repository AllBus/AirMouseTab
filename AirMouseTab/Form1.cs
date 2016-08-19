using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace AirMouseTab
{
    public partial class AirMouseTabForm : Form
    {
        ConnectProp prop = new ConnectProp();
        UdpState stateUdpServer = null;
        ResourceManager LocRM;

        public AirMouseTabForm()
        {


            switch (Properties.Settings.Default.language)
            {
                case "русский":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    LocRM = new ResourceManager("AirMouseTab.ResourceLanguageRu", typeof(AirMouseTabForm).Assembly);
                    break;
                case "english":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                    LocRM = new ResourceManager("AirMouseTab.ResourceLanguages", typeof(AirMouseTabForm).Assembly);
                    break;
                default:
                    LocRM = new ResourceManager("AirMouseTab.ResourceLanguages", typeof(AirMouseTabForm).Assembly);
                    break;
            }
            
            InitializeComponent();

            foreach (var s in prop.myIps()) {
                listIp.Items.Add(s);
            }

            
            loadProperty(prop);
            

            if (prop.pin<100)
                prop.pin = generateRandom();
            editPort.Text = prop.port.ToString();
            editPIN.Text = prop.pin.ToString();
            changeConnectState(0);
            startConnect();

            labelVersion.Text ="Version "+System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            
        }
        //===================================
        int getPort()
        {
            int i = 0;
            int.TryParse(editPort.Text, out i);
            return i;
        }

        int getControlNumber()
        {
            int i = 0;
            int.TryParse(editPIN.Text, out i);

            return i;
        }

        private void message(string textID)
        {
             MessageBox.Show(this, LocRM.GetString(textID));
        }

        int generateRandom()
        {
            Random random = new Random();
            return (int)(random.NextDouble() * 900000000.0);
        }
        private string getSelectIp()
        {
            var it = listIp.SelectedItem;
            if (it == null)
            {
                return "127.0.0.1";
            }
            else
            {
                return it.ToString();
            }
        }
        //=======================
        private void button1_Click(object sender, EventArgs e)
        {
            startConnect();
        }

        private void startConnect()
        {
            if (stateUdpServer != null)
            {
                stopServer();
                return;
            }
            var connectProp = new ConnectProp();
            connectProp.port = getPort();
            connectProp.pin = getControlNumber();
            connectProp.ip = getSelectIp();
            if (connectProp.port >= 1024 && connectProp.port < 65536)
            {
                if (connectProp.pin >= 100000)
                {
                    saveProperty(connectProp);
                    //  ServerDataMain.start(port, control);

                    startConnect(connectProp);

                }
                else {
                    message("messageErrorPin" );
                }
            }
            else {
                message("messageErrorPort");
            }
        }

        private void stopServer()
        {
            try
            {
                if (stateUdpServer != null)
                {
                    stateUdpServer.client.Close();
                    stateUdpServer = null;
                    changeConnectState(0);
                }
            }
            catch
            {

            }
        }

        private void startConnect(ConnectProp connectProp)
        {
            buttonConnect.Enabled = false;
            try {
                if (stateUdpServer != null)
                {
                    stopServer();
                }
                else {

                    changeConnectState(11);

                    stateUdpServer = new UdpState();
                    //This specifies that the UdpClient should listen on EVERY adapter
                    //on the specified port, not just on one adapter.
                    stateUdpServer.ep = new IPEndPoint(IPAddress.Any, connectProp.port);
                    //This will call bind() using the above IP endpoint information. 
                    stateUdpServer.client = new UdpClient(stateUdpServer.ep);
                    
                    stateUdpServer.obrabotka = new Obrabotka(connectProp.pin);
                    //This starts waiting for an incoming datagram and returns immediately.
                    stateUdpServer.client.BeginReceive(new AsyncCallback(bytesReceived), stateUdpServer);

                }

            }
            catch
            {

            }
            finally
            {
                buttonConnect.Enabled = true;
            }

         }

        private void bytesReceived(IAsyncResult async)
        {
            try {
                UdpState state = async.AsyncState as UdpState;
                if (state != null)
                {
                    IPEndPoint ep = state.ep;


                    byte[] buf = state.client.EndReceive(async, ref ep);
                    state.obrabotka.run(buf);
                    //StringBuilder sb = new StringBuilder();

                    //foreach (var c in buf)
                    //{
                    //    sb.Append(c);
                    //    sb.Append(" ");
                    //}
                    //Text = sb.ToString();
                    state.client.BeginReceive(new AsyncCallback(bytesReceived), state);
                    //either close the client or call BeginReceive to wait for next datagram here.
                }
            }
            catch
            {
                
            }
        }
        private void changeConnectState(int state)
        {
            switch (state)
            {
                case 1:
                    buttonConnect.Text = LocRM.GetString("stateWait");
                    buttonConnect.BackColor = Color.LemonChiffon;
                    break;
                case 2:
                    buttonConnect.Text = "Listed";
                    buttonConnect.BackColor = Color.PaleGreen;
                    break;
                case 11:
                    buttonConnect.Text = LocRM.GetString("stateStop");
                    buttonConnect.BackColor = Color.PaleGreen;
                    break;
                default:
                    buttonConnect.Text = LocRM.GetString("stateConnect");
                    buttonConnect.BackColor = Color.LemonChiffon;
                    break;
            }
        }

        private void buttonGeneratePIN_Click(object sender, EventArgs e)
        {
            editPIN.Text = generateRandom().ToString();
        }

        private void buttonDefaultPort_Click(object sender, EventArgs e)
        {
            editPort.Text = ConnectProp.DEFAULT_PORT.ToString();
        }

     

        private void saveProperty(ConnectProp connectProp)
        {
            Properties.Settings.Default.PortNumber = connectProp.port;
            Properties.Settings.Default.PinCode = connectProp.pin;
            Properties.Settings.Default.Save();
        }
        private void loadProperty(ConnectProp connectProp)
        {
            connectProp.port = Properties.Settings.Default.PortNumber;
            connectProp.pin = Properties.Settings.Default.PinCode;
         
        }

  
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeLanguage(comboBoxLanguage.Text);
        }

        private void changeLanguage(string text)
        {
            if (text.ToLower().Contains("русский") || text.ToLower().Contains("ru"))
            {
                Properties.Settings.Default.language = "русский";
                LocRM = new ResourceManager("AirMouseTab.ResourceLanguageRu", typeof(AirMouseTabForm).Assembly);
            }
            else
            {
                Properties.Settings.Default.language = "english";
                LocRM = new ResourceManager("AirMouseTab.ResourceLanguages", typeof(AirMouseTabForm).Assembly);
            }
            Properties.Settings.Default.Save();
            message("messageChangeLanguage");
        }

        private void editPort_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}
