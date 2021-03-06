﻿using ModelLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace JsonUDPReceiver
{
    internal class UDPReceiver
    {
        public UDPReceiver()
        {

        }

        public void Start()
        {
            UdpClient client = new UdpClient(11002);

            byte[] buffer;

            while (true)
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                buffer = client.Receive(ref remoteEndPoint);

                Console.WriteLine($"har modtaget en der kommer fra IP {remoteEndPoint.Address} og port {remoteEndPoint.Port}");
                string str = Encoding.UTF8.GetString(buffer);
                Car car = JsonConvert.DeserializeObject<Car>(str);

                Console.WriteLine("tekst modtaget = " + car);

                byte[] outbuffer = Encoding.UTF8.GetBytes(str.ToCharArray());
                client.Send(outbuffer, outbuffer.Length, remoteEndPoint);
            }
        }
    }
}
