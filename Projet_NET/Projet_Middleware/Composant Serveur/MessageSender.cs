using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Projet_Middleware.Composant_Serveur
{
    class MessageSender
    {
        private Socket client;
        private Socket sock;

        public MessageSender(Socket client)
        {
            this.client = client;
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Blocking = true;
            IPHostEntry iHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = iHost.AddressList;
            IPEndPoint ipep = new IPEndPoint(addr[0], 8542);
            client.Connect(ipep);
        }

        public void Send(String text)
        {
            byte[] tbl = new byte[32767];
            tbl = ASCIIEncoding.ASCII.GetBytes(text);
            sock.Send(tbl);
            Console.WriteLine("Message envoyé : " + text);
        }
    }
}
