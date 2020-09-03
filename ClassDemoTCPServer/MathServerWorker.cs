using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoTCPServer
{
    class MathServerWorker
    {
        public void Start()
        {
           
            TcpListener server = new TcpListener(IPAddress.Loopback, 3001);
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
            Console.WriteLine($"Her er server input fra Math: {str}");

            // skriv tilbage til klient
            var strings = str.Split(' ');

            var i = Int32.Parse(strings[1]);
            var j = Int32.Parse(strings[2]);

            sw.WriteLine($"Her kommer resultatet {i+j}");
            sw.Flush(); // tømmer buffer
        }

    }
}
