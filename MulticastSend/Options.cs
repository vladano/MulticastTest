using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace MulticastSend
{
    internal class Options
    {
        private string _IPAddressValue = "";
        private int _PortValue = 5050;
        public int _TTLValue = 0;
        public int _PacketNumValue = 0;
        public int _PacketSizeValue = 0; // 20 KB

        #region desc
        /*
        What is multicast?

        Multicast is a kind of UDP traffic similar to BROADCAST, 
        but only hosts that have explicitly requested to receive this kind of traffic will get it. 
        This means that you have to JOIN a multicast group if you want to receive traffic that belongs to that group.
        IP addresses in the range 224.0.0.0 to 239.255.255.255 ( Class D addresses) belongs to multicast. 
        No host can have this as IP address, but every machine can join a multicast address group.        

         * 224.0.0.0 - 239.255.255.255
        IP multicast Description
        address 
        224.0.0.0 	    Base address(reserved)
        224.0.0.1 	    The All Hosts multicast group addresses all hosts on the same network segment.
        224.0.0.2 	    The All Routers multicast group addresses all routers on the same network segment.
        224.0.0.4 	    This address is used in the Distance Vector Multicast Routing Protocol(DVMRP) to address multicast routers.
        224.0.0.5 	    The Open Shortest Path First (OSPF) All OSPF Routers address is used to send Hello packets to all OSPF routers on a network segment.
        224.0.0.6 	    The OSPF All Designated Routers ""(DR)"" address is used to send OSPF routing information to designated routers on a network segment.
        224.0.0.9 	    The Routing Information Protocol(RIP) version 2 group address is used to send routing information to all RIP2-aware routers on a network segment.
        224.0.0.10 	    The Enhanced Interior Gateway Routing Protocol (EIGRP) group address is used to send routing information to all EIGRP routers on a network segment.
        224.0.0.13 	    Protocol Independent Multicast(PIM) Version 2
        224.0.0.18 	    Virtual Router Redundancy Protocol(VRRP)
        224.0.0.19–21 	IS-IS over IP
        224.0.0.22 	    Internet Group Management Protocol(IGMP) version 3[2]
        224.0.0.102 	Hot Standby Router Protocol version 2 (HSRPv2) / Gateway Load Balancing Protocol(GLBP)
        224.0.0.107 	Precision Time Protocol(PTP) version 2 peer delay measurement messaging
        224.0.0.251 	Multicast DNS(mDNS) address
        224.0.0.252 	Link-local Multicast Name Resolution(LLMNR) address
        224.0.0.253 	Teredo tunneling client discovery address[3]
        224.0.1.1 	    Network Time Protocol clients listen on this address for protocol messages when operating in multicast mode.
        224.0.1.22 	    Service Location Protocol version 1 general
        224.0.1.35 	    Service Location Protocol version 1 directory agent
        224.0.1.39 	    The Cisco multicast router AUTO-RP-ANNOUNCE address is used by RP mapping agents to listen for candidate announcements.
        224.0.1.40 	    The Cisco multicast router AUTO-RP-DISCOVERY address is the destination address for messages from the RP mapping agent to discover candidates.
        224.0.1.41 	    H.323 Gatekeeper discovery address
        224.0.1.129–132 Precision Time Protocol (PTP) version 1 messages(Sync, Announce, etc.) except peer delay measurement
        224.0.1.129 	Precision Time Protocol(PTP) version 2 messages(Sync, Announce, etc.) except peer delay measurement
        239.255.255.250 Simple Service Discovery Protocol address
        239.255.255.253 Service Location Protocol version 2 address
            */
        #endregion

        // Default: 224.0.0.1
        [Option('a', "multicastip", Required = false, HelpText = "Multicast IP address to send data", DefaultValue = "238.0.0.1")]
        public string IPAddressValue
        {
            get
            {
                return _IPAddressValue;
            }
            set
            {
                if (value == _IPAddressValue)
                    return;
                _IPAddressValue = value;
            }
        }

        // Default: 5050
        [Option('p', "port", Required = false, HelpText = "Port to send data", DefaultValue = 5050)]
        public int PortValue
        {
            get
            {
                return _PortValue;
            }
            set
            {
                if (value == _PortValue)
                    return;
                _PortValue = value;
            }
        }

        /*
        TTL     Scope
        ----------------------------------------------------------------------
           0    Restricted to the same host. Won't be output by any interface.
           1    Restricted to the same subnet. Won't be forwarded by a router.
         <32    Restricted to the same site, organization or department.
         <64    Restricted to the same region.
        <128    Restricted to the same continent.
        <255    Unrestricted in scope. Global.
        */
        // Default: 3
        [Option('t', "ttl", Required = false, HelpText = "Time To Live (TTL - Hop Limit)", DefaultValue = 3)]
        public int TTLValue
        {
            get
            {
                return _TTLValue;
            }
            set
            {
                if (value == _TTLValue)
                    return;
                _TTLValue = value;
            }
        }

        // Default: 5
        [Option('n', "numberofpacket", Required = false, HelpText = "Number of packet to sent", DefaultValue = 5)]
        public int PacketNumValue
        {
            get
            {
                return _PacketNumValue;
            }
            set
            {
                if (value == _PacketNumValue)
                    return;
                _PacketNumValue = value;
            }
        }

        /*
        #define MAXBUFSIZE 65536 // UDP Packet size is 64 Kbyte
        #define MAXBUFSIZE 1024 // UDP Packet size is 1 Kbyte
        1 byte = 1 character
        */
        // Default: 30 characters
        [Option('s', "size", Required = false, HelpText = "UDP Packet size in byte (1 byte=1 character)", DefaultValue = 30)]
        public int PacketSizeValue
        {
            get
            {
                return _PacketSizeValue;
            }
            set
            {
                if (value == _PacketSizeValue)
                    return;
                _PacketSizeValue = value;
            }
        }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}