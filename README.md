# Test Multicast IP network traffic

What is multicast?

Multicast is a kind of UDP traffic similar to BROADCAST, 
but only hosts that have explicitly requested to receive this kind of traffic will get it. 
This means that you have to JOIN a multicast group if you want to receive traffic that belongs to that group.
IP addresses in the range 224.0.0.0 to 239.255.255.255 ( Class D addresses) belongs to multicast. 
No host can have this as IP address, but every machine can join a multicast address group.        

Wikipedia https://en.wikipedia.org/wiki/Multicast

How to use

The program consists of two executable (.exe) programs.
One executable program need to be started on computer where we will test acceptance of multicast IP packets that are sent from the network (MulticastReceive.exe) and the other executable program need to be started to generate multicast IP traffic (MulticastSend.exe).

If MulticastReceive.exe starts without any parameters, the program by default listens for incoming multicast traffic on the IP address 238.0.0.1 and port 5050.
Possible parameters and values that can be used when starting the program, can be get if you start the program with the drive parameter "-h":

MulticastReceive.exe -h
MulticastReceive 1.0.0.0
Copyright c 2017

  -a, --multicastip (Default: 238.0.0.1) multicast IP address to send data

  -p, --port (Default: 5050) Port to send data

  --help Display this help screen.

If, for example, you want to start listening for incoming multicast traffic on a multicast IP address 224.0.1 and port 5000, it is necessary to start the program as follows:
MulticastReceive.exe 224.0.01 -a -p 5000

Another program required for testing, need to be start on the computer that will generate and send the network multicast traffic (MulticastSend.exe).
If you start the program without any parameters, program will send multicast IP traffic to the IP address 238.0.0.1, port 5050, with default value of 3 for the limitation of the jump (TTL - eng. Time To Live or Hop Limit), and 5 data packets with a length of 30 characters per package.
Possible parameters and values that can be used when you start the program, you can see if you start program with -h parameter:

MulticastSend.exe -h
MulticastTest 1.0.0.0
Copyright c 2017

  -a, --multicastip (Default: 238.0.0.1) multicast IP address to send
                          data

  -p, --port (Default: 5050) Port to send data

  -t, --ttl (Default: 3) The Time To Live (TTL - Hop Limit)

  -n, --numberofpacket (Default: 5) Number of packet sent to

  -s, --size (Default: 30) UDP packet size in bytes (1 byte = 1
                          character)

  --help Display this help screen.
  
If, for example, you want to start sending the multicast IP traffic to IP address 224.0.1, port 5000, with TTL 5, 10 packages with packet size of 1KB (1,024 characters), it is necessary to start the program as follows:
MulticastReceive.exe 224.0.01 -a -p 5000 -t 10 -s 5 -n 1024

Complete help with screenshots you can find inside "doc" folder in different file formats.
I used chmProcessor tool from location http://chmprocessor.sourceforge.net/ to generate different file formats from MS Word document.

To generate this type of help documentations you need to download software and make chmProcessor project file (file with .WHC extension inside "doc" folder).
