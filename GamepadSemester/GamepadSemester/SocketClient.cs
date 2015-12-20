using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace GamepadClientNamespace
{
    class GamepadClient
    {
        static private StreamSocket clientSocket;
        static private HostName serverHost;
        static private string serverHostnameString = "";
        static private string serverPort = "";
        static private bool connected = false;

        static public async void Connect(string address, string port)
        {
            clientSocket = new StreamSocket();

            try
            {
                serverHost = new HostName(address);
                serverPort = port;
                serverHostnameString = address;

                await clientSocket.ConnectAsync(serverHost, serverPort);
                connected = true;

            }
            catch (Exception)
            {                
                clientSocket.Dispose();
                clientSocket = null;
                
                throw new ConnectionErrorException();
            }
        }

        static public async void Send(int number)
        {
            if (connected)
            {
                try
                {
                    DataWriter writer = new DataWriter(clientSocket.OutputStream);
                    writer.WriteString(number.ToString());

                    await writer.StoreAsync();

                    writer.DetachStream();
                    writer.Dispose();
                }
                catch (Exception)
                {
                    throw new SendingErrorException();
                }
            }
        }

        static public void getCurrentIPAdressAndPort(out string IPAddress, out string port)
        {
            IPAddress = serverHostnameString;
            port = serverPort;
        }
    }
}
