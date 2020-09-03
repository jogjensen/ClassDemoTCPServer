using System;

namespace ClassDemoTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientWorker worker = new ClientWorker();
            MathClient mWorker = new MathClient();
            MoreMathClient mmworker = new MoreMathClient();
            DateTimeClient dateTimeWorker = new DateTimeClient();
            //worker.Start();
            //mWorker.Start();
            //mmworker.Start();
            dateTimeWorker.Start();

            Console.ReadLine();
        }
    }
}
