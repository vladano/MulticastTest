using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MulticastSend
{
    class Program
    {
        static void Main(string[] args)
        {

            var options = new Options();

            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
            else
            {
                string errorMessage = "";
                IPAddress address;
                if (!IPAddress.TryParse(options.IPAddressValue, out address))
                {
                    errorMessage += "You must provide valid Multicast IP address" + "\n\r";
                }
                if (options.PortValue < 1024 || options.PortValue > 65536)
                {
                    errorMessage += "You must provide valid Port number, between 1024 and 65536" + "\n\r";
                }
                if (options.TTLValue < 1 || options.TTLValue > 254)
                {
                    errorMessage += "You must provide valid TTL value, between 1 and 254" + "\n\r";
                }
                if (options.PacketNumValue < 1 || options.PacketNumValue > 254)
                {
                    errorMessage += "You must provide valid Packet number value, between 1 and 254" + "\n\r";
                }
                if (options.PacketSizeValue < 1 || options.PacketSizeValue > 65536)
                {
                    errorMessage += "You must provide valid Packet size value, between 1 and 65536 bytes" + "\n\r";
                }
                if (errorMessage != "")
                {
                    Console.WriteLine(errorMessage + "\n\r\n\r");
                    Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
                }
                else
                {
                    Console.WriteLine("Multicat IP address: " + options.IPAddressValue);
                    Console.WriteLine("Port: " + options.PortValue);
                    Console.WriteLine("TTL: " + options.TTLValue);
                    Console.WriteLine("Packet Number: " + options.PacketNumValue.ToString());
                    Console.WriteLine("Packet Size: " + options.PacketSizeValue.ToString());

                    new Send(options.IPAddressValue, options.PortValue, options.TTLValue, options.PacketNumValue, options.PacketSizeValue);
                }
            }
        }
    }
}
