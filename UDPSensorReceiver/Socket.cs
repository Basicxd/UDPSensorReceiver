using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPSensorReceiver
{
    public class Socket
    {
        public void broadMain()
        {
            //Creates a UdpClient for reading incoming data.
            UdpClient udpServer = new UdpClient(7000);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPAddress ip = IPAddress.Any;
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 7000);

            try
            {
                // Blocks until a message is received on this socket from a remote host (a client).
                Console.WriteLine("Server is blocked");
                while (true)
                {
                    Byte[] receiveBytes = udpServer.Receive(ref RemoteIpEndPoint);
                    //Server is now activated");

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    string[] data = receivedData.Split('\n');
                    string sender = data[0];
                    string location = data[1];
                    string time = data[2];
                    string cO = data[3];
                    string nOx = data[4];
                    string particleLevel = data[5];

                    Console.WriteLine(sender + location + time + cO + nOx + particleLevel);

                    Console.WriteLine(receivedData);
                    //Console.WriteLine("Received from: " + clientName.ToString() + " " + text.ToString());

                    //string sendData = "Server: " + text.ToUpper();
                    //Byte[] sendBytes = Encoding.ASCII.GetBytes(sendData);

                    //udpServer.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint);

                    Console.WriteLine("This message was sent from " +
                                      RemoteIpEndPoint.Address.ToString() +
                                      " on their port number " +
                                      RemoteIpEndPoint.Port.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}