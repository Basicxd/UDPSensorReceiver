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
            UdpClient udpServer = new UdpClient(11111);

            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPAddress ip = IPAddress.Any;
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 11111);

            try
            {
                // Blocks until a message is received on this socket from a remote host (a client).
                Console.WriteLine("Reciever is started");
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
                    //double cO = Convert.ToDouble(data[3]);
                    //double nOx = Convert.ToDouble(data[4]);
                    string particleLevel = data[5];

                    string[] some = data[3].Split(':');
                    string some1 = some[3];

                    Console.WriteLine(some1);

                    for (int i = 0; i <= 5; i++)
                    {
                        Console.WriteLine(i + "   " + data[i]);
                    }


                    //Console.WriteLine($"{sender} {location}");

                    //Console.WriteLine(sender);
                    //Console.WriteLine(location);
                    //Console.WriteLine(time);
                    //Console.WriteLine(cO);
                    //Console.WriteLine(nOx);
                    //Console.WriteLine(particleLevel);
                    //Console.WriteLine();


                    //Console.WriteLine(receivedData);

                    //Console.WriteLine("This message was sent from " +
                    //                  RemoteIpEndPoint.Address.ToString() +
                    //                  " on their port number " +
                    //                  RemoteIpEndPoint.Port.ToString());

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}