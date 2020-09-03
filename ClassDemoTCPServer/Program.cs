using System;

namespace ClassDemoTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerWorker worker = new ServerWorker();
            MathServerWorker Mworker = new MathServerWorker();
            MoreMathServerWorker MMworker = new MoreMathServerWorker();
            DateTimeServerWorker datetimeWorker = new DateTimeServerWorker();

            //worker.Start();
            //Mworker.Start();
            //MMworker.Start();
            datetimeWorker.Start();

            Console.ReadLine();
        }
    }
}
