using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ClassDemoTCPClient
{
    class MathClient
    {
        public void Start()
        {
            // client opretter forbindelse til server, der ligger på 'localhost' og port 7
            TcpClient socket = new TcpClient("localhost", 3001);

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());


            String strSomSendes = "ADD 5 5 ";
            sw.WriteLine(strSomSendes);
            sw.Flush();

            String strRetur = sr.ReadLine();
            Console.WriteLine($"Tilbage fra Server : {strRetur}");

            socket.Close();
        }

    }
}
