using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static Object sem = new object();
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("C:\\Users\\hobit\\Documents\\IO\\plik.txt", FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            IAsyncResult res =fs.BeginRead(buffer, 0, buffer.Length, null, new object[] { fs, buffer });
          
            fs.EndRead(res);
            fs.Close();
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            Thread.Sleep(5000);
        }
        


    }
}
 