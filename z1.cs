using System;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { 1000, 1});
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { 200, 2});
            Thread.Sleep(2000);
        }

        static void ThreadProc(Object stateInfo)
        {
            int time = (int)(((object[])stateInfo)[0]);
            int x = (int)(((object[])stateInfo)[1]);

            Thread.Sleep(time);
            Console.WriteLine(x+" czekał: " +Time);
        }

    }
}
