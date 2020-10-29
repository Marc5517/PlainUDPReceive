using System;

namespace PlainUDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPSender udpSender = new UDPSender();
            udpSender.Start();

            Console.ReadLine();
        }
    }
}
