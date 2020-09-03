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
    class DateTimeServerWorker
    {
        public void Start()
        {

            TcpListener server = new TcpListener(IPAddress.Loopback, 3003);
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
            Console.WriteLine($"Indtastet format: {str}");

            // skriv tilbage til klient
            var dt = str.Split('&');

            //var i = DateTime.ParseExact(dt[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);


            try 
            {
                var i = DateTime.ParseExact(dt[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                Console.WriteLine($"Korrekt format");
                sw.WriteLine($"Valid");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Forkert format");
                sw.WriteLine($"Note valid");
            }

            


            //sw.WriteLine($"Her kommer resultatet fra Datetime {dt}");
            sw.Flush(); // tømmer buffer
        }

    }
}

