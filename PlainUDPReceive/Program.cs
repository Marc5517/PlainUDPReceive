using System;

namespace PlainUDPReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiver udpReceiver = new UDPReceiver();
            udpReceiver.Start();

            Console.ReadLine();
        }
    }
}
