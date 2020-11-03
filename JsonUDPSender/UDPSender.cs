using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;

namespace JsonUDPSender
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
            Car car = new Car("Tesla", "Green", "JsonCar4");
            string json = JsonConvert.SerializeObject(car);
            byte[] outbuffer = Encoding.UTF8.GetBytes(json);
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
