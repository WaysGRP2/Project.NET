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
    class MessageReceiver
    {
        private Socket client;
        private volatile Boolean _shouldStop = false;

        public void DoWork()
        {
            TcpListener srv = new TcpListener(IPAddress.Any, 34562);
            srv.Start();
            while (_shouldStop)
            {
                client = srv.AcceptSocket();
                if (client.Connected)
                {
                    Thread thr = new Thread(new ThreadStart(ListenThread));
                    thr.Start();
                    Console.WriteLine("Client connecté.");
                }
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        void ListenThread()
        {
            Socket sock = client;
            while (sock.Connected)
            {
                Byte[] rep = new Byte[32767];
                int count = sock.Receive(rep, rep.Length, 0);
                string srep = Encoding.ASCII.GetString(rep);
                string reponse = srep.Substring(0, count);
                switch (reponse)
                {
                    case "deconnexion":
                        sock.Shutdown(SocketShutdown.Both);
                        sock.Close();
                        break;
                }
            }
            Thread.CurrentThread.Abort();
        }
    }
}
