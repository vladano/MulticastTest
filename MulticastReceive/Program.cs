using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MulticastReceive
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
                if (errorMessage != "")
                {
                    Console.WriteLine(errorMessage + "\n\r\n\r");
                    Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
                }
                else
                {
                    Console.WriteLine("Multicat IP address: " + options.IPAddressValue);
                    Console.WriteLine("Port: " + options.PortValue);
                    new Recv(options.IPAddressValue, options.PortValue);
                }

            }
        }
    }
}

