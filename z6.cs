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
            fs.BeginRead(buffer, 0, buffer.Length, myAsyncCallback, new object[] { fs, buffer });
            Thread.Sleep(10000);



        }
        static void myAsyncCallback(IAsyncResult state)
        {
            byte[] buffer = (byte[])((object[])state.AsyncState)[1];
            FileStream fs = (FileStream)((object[])state.AsyncState)[0];

            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            fs.Close();



        }


    }
}
 