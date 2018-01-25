using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Z4_framework
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { "client" });
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { "server" });
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { "client" });
            Thread.Sleep(10000);







        }


        static void ThreadProc(Object stateInfo)
        {
            var message = ((object[])stateInfo)[0];

            if (message == "server")
            {
                TcpListener server = new TcpListener(IPAddress.Any, 2048);
                server.Start();
 
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    byte[] buffer = new byte[3];
                    client.GetStream().Read(buffer, 0, 3);

                    if (Encoding.UTF8.GetString(buffer) == "HEY")
                    {
                        Console.WriteLine("SERWER: Otrzymałem HEY odsyłam ACK");
                        client.GetStream().Write(Encoding.ASCII.GetBytes("ACK"), 0, 3);
                    }
                    else if (Encoding.UTF8.GetString(buffer) == "BYE")
                    {
                        client.Close();
                    }
                }
            }
            if (message == "client")
            {
                TcpClient client = new TcpClient();
                byte[] bufferc = new byte[3];
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
                NetworkStream stream = client.GetStream();
                Console.WriteLine("Klient: Wysyłam HEY");

                stream.Write(Encoding.ASCII.GetBytes("HEY"), 0, 3);
                while (true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Klient: czekam na ACK");
                   stream.Read(bufferc, 0, 3);
                    if (Encoding.UTF8.GetString(bufferc) == "ACK")
                    {
                        Console.WriteLine("Klient: Otrzymałem ACK wysylam BYE");

                        stream.Write(Encoding.ASCII.GetBytes("BYE"), 0, 3);
                        Thread.Sleep(500);
                        break;
                    }
                   

                }

            }



        }



    }
}
