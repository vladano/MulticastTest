using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastSend
{
    class Send
    {
        const string AllowedChars =
                "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()"; // 69

        public Send(string mcastIPAddrGroup, int port, int ttl, int packetNum, int packetSize)
        {
            IPAddress ip;
            try
            {
                Console.WriteLine("MCAST Send on Group: {0} Port: {1} TTL: {2}", mcastIPAddrGroup, port, ttl);
                ip = IPAddress.Parse(mcastIPAddrGroup);

                Socket s = new Socket(AddressFamily.InterNetwork,
                                SocketType.Dgram, ProtocolType.Udp);

                s.SetSocketOption(SocketOptionLevel.IP,
                    SocketOptionName.AddMembership, new MulticastOption(ip));

                s.SetSocketOption(SocketOptionLevel.IP,
                    SocketOptionName.MulticastTimeToLive, ttl);

                string bytesToSend = GetStringOfSize(packetSize);
                byte[] b = Encoding.ASCII.GetBytes(bytesToSend);

                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(mcastIPAddrGroup), port);

                Console.WriteLine("Connecting...");

                s.Connect(ipep);

                Console.WriteLine("Sending data ...");
                for (int x = 0; x < packetNum; x++)
                {
                    Console.WriteLine("TX: "+bytesToSend);
                    s.Send(b, b.Length, SocketFlags.None);
                }

                Console.WriteLine("Closing Connection...");
                s.Close();
                Console.WriteLine("\n\r");
                Console.WriteLine("Sent {0} Packet of Size {1} ", packetNum, packetSize);
            }
            catch (System.Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        private string GetStringOfSize(int strLenght)
        {
            string retVal = "";

            if (strLenght <= 1)
            {
                retVal = AllowedChars;
            }
            else if (strLenght <= 69)
            {
                retVal = AllowedChars.Substring(0, strLenght);
            }
            else
            {
                int index = strLenght / AllowedChars.Length;
                int currentLength = 0;
                for (int i = 0; i < index; i++)
                {
                    retVal += AllowedChars;
                    currentLength++;

                }
                retVal += AllowedChars.Substring(0, AllowedChars.Length - (strLenght - currentLength * AllowedChars.Length));
            }

            return retVal;
        }

    }
}
