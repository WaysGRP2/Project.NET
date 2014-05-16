﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MessageSerializable;

namespace Projet_Middleware.Composant_Serveur
{
    class MessageManager
    {
        // Incoming data from the client.
        public static string data = null;

        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            Message message;

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        bytes = new byte[16384];
                        Program.Debug("Reception d'un message... Réception.");
                        handler.Receive(bytes);
                        Program.Debug("Reception d'un message... Désérilalization.");
                        message = Message.GetMessageFromByteArray(bytes);
                        Program.Debug("Reception d'un message... Désérilalization terminée.");
                        break;
                    }

                    // Show the data on the console.
                    Console.WriteLine("Task requested : " + message.Invoke);
                    
                    Message reponse = EntreePlateforme.Check(message);

                    // Send the reponse to the client.
                    if (reponse != null)
                    {
                        Program.Debug("Envoi d'un message... Sérilalization.");
                        byte[] toSend = reponse.ToByteArray();
                        Program.Debug("Envoi d'un message... Sérilalization terminée.");
                        handler.Send(toSend); // reponse
                        Program.Debug("Envoi d'un message... Envoi terminé.");
                    }
                    else
                    {
                        Program.Debug("Envoi d'un message... Reponse nulle");
                    }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }
    }
}
