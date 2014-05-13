using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MessageSerializable;

namespace Projet_Client.Composant_de_communication
{
    class MessageManager
    {
        public static Message SendMessageToServer(Message msg)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the message into a byte array.
                    byte[] msgBytes = msg.ToByteArray();

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msgBytes);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    Message reponse = Message.GetMessageFromByteArray(bytes);

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    return reponse;
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : " + ane.ToString());
                    System.Windows.MessageBox.Show("ArgumentNullException : " + ane.ToString());
                    msg.Statut = false;
                    return msg;
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    System.Windows.MessageBox.Show("SocketException : " + se.ToString());
                    msg.Statut = false;
                    return msg;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    System.Windows.MessageBox.Show("Unexpected exception : " + e.ToString());
                    msg.Statut = false;
                    return msg;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                System.Windows.MessageBox.Show(e.ToString());
                msg.Statut = false;
                return msg;
            }
        }
    }
}
