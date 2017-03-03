using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastReceive
{
    class Recv
    {
        private string str1 = "";
        private int numOfReceivedPackts = 0;

        public Recv(string mcastGroup, int port)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                s.Bind(ipep);

                IPAddress ip = IPAddress.Parse(mcastGroup);

                s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));

                Console.WriteLine("Waiting for data.. each 5 seconds received packet number will be reset to 0"+"\n\r");

                System.Timers.Timer aTimer;
                // Create a timer and set a five second interval.
                aTimer = new System.Timers.Timer();
                aTimer.Interval = 5000;
                // Create a timer with a five second interval.
                aTimer = new System.Timers.Timer(5000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                // Have the timer fire repeated events (true is the default)
                aTimer.AutoReset = true;

                // Start the timer
                aTimer.Enabled = true;
                while (true)
                {
                    byte[] b = new byte[65536];

                    s.Receive(b);
                    numOfReceivedPackts++;

                    int i = b.Length - 1;
                    while (b[i] == 0)
                        --i;
                    byte[] received = new byte[i + 1];
                    Array.Copy(b, received, i + 1);

                    str1 = System.Text.Encoding.ASCII.GetString(received);
                    Console.WriteLine("RX: " + str1.Trim());

                }
                //s.Close();
            }
            catch (Exception ex)
            {
                if (ex.HResult== -2147467259)
                {
                    Console.WriteLine("\n\rWarning: Used Multicast IP address:"+ mcastGroup +" and port:"+ port +", ALREADY IN USE !!!");
                }
                else
                {
                    Console.WriteLine("\n\rError Number:" + ex.HResult.ToString() + " Message: " + ex.Message);
                }
            }
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Received {0} Packet of Size {1} " + "\n\r", numOfReceivedPackts, str1.Length);
            numOfReceivedPackts = 0;
            str1 = "";
        }
    }
}
