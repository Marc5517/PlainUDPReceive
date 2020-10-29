using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ModelLib;

namespace PlainUDPServer
{
    internal class UDPSender
    {
        public UDPSender()
        {

        }

        public void Start()
        {
            UdpClient client = new UdpClient();

            byte[] buffer;

            // Sender
            IPEndPoint modtagerEndPoint = new IPEndPoint(IPAddress.Loopback, 11001);
            Car car = new Car("Tesla", "Rød", "EL 23 400");
            byte[] outbuffer = Encoding.UTF8.GetBytes(car.ToString());
            client.Send(outbuffer, outbuffer.Length, modtagerEndPoint);

            // Modtager
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            buffer = client.Receive(ref remoteEndPoint);

            Console.WriteLine($"har modtaget en pakke der kommer fra IP {remoteEndPoint.Address} og port {remoteEndPoint.Port}");
            string incommingstr = Encoding.UTF8.GetString(buffer);

            Console.WriteLine("tekst modtaget = " + incommingstr);

        }
    }
}
