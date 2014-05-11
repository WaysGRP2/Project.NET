using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Projet_Client.Composant_de_communication
{
    class MessageManager
    {
        public MessageManager()
        {
            //Connection
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Blocking = true;
            IPHostEntry iHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = iHost.AddressList;
            IPEndPoint ipep = new IPEndPoint(addr[4], 8542);
            System.Windows.MessageBox.Show("IP: " + addr[4].ToString());
            sock.Connect(ipep);
            //Récéption
            Byte[] rep = new Byte[32767];
            int count = sock.Receive(rep, rep.Length, 0);
            string srep = Encoding.ASCII.GetString(rep);
            string reponse = srep.Substring(0, count);
            //envoi
            byte[] tbl = new byte[32767];
            tbl = ASCIIEncoding.ASCII.GetBytes("Coucou serveur");
            sock.Send(tbl);

        }
    }
}
