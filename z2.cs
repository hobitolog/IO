using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(serverThread); //serwer
            ThreadPool.QueueUserWorkItem(clientThread, new object[] {"klient1" });
            ThreadPool.QueueUserWorkItem(clientThread, new object[] {"klient2" });
            Thread.Sleep(10000);
        }

        static void clientThread(Object stateInfo)
        {  

            string input = (string)((object[])stateInfo)[0];
            byte[] message;
            message = Encoding.UTF8.GetBytes(input);

            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
            client.GetStream().Write(message, 0, message.Length);


            byte[] back = new byte[1024];

            int len = client.GetStream().Read(back, 0, 1024);
            String output = Encoding.UTF8.GetString(back, 0, len);
            Console.WriteLine(output);
        }

        static void serverThread(Object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                byte[] buffer = new byte[1024];
                int len = client.GetStream().Read(buffer, 0, 1024);//czytam
                client.GetStream().Write(buffer, 0, len);//pisze echo
                client.Close();

            }
        }

    }
}
 