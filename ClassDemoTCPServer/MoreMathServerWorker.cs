using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoTCPServer
{
    class MoreMathServerWorker
    {
        public void Start()
        {

            TcpListener server = new TcpListener(IPAddress.Loopback, 3002);
            server.Start();
            TcpClient socket = server.AcceptTcpClient();

            while (true)
            {
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });

            }


        }

        public void DoClient(TcpClient socket)
        {
            // venter på en klient skal lave et opkald

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            // læs tekst fra klient
            String str = sr.ReadLine();
            Console.WriteLine($"Her er server input fra MoreMath: {str}");

            // skriv tilbage til klient
            var strings = str.Split(' ');

            var i = double.Parse(strings[1], new CultureInfo("en-UK"));
            var j = double.Parse(strings[2], new CultureInfo("en-UK"));

            sw.WriteLine($"Her kommer resultatet fra MoreMath {i + j}");
            sw.Flush(); // tømmer buffer
        }

    }
}
