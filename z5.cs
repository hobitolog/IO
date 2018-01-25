using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static Object sem = new Object();

        static int sum = 0;

        static void Main(string[] args)
        {
            Random random = new Random();
            int suma = 0;
            int size = 40;
            int piece = 5;


            int[] table = new int[size];
            for (int i = 0; i < size; i++)
            {
                table[i] = random.Next(50);
                suma += table[i];
            }

            Console.WriteLine("Suma: " + suma);

            for (int i = 0; i < size; i += piece)
            {
                List<int> list = new List<int>();
                if (i + piece >= size)
                {
                    for (int j = 0; j < size - i; j++)
                    {
                        list.Add(table[i + j]);
                    }

                }
                else
                {
                    for (int j = 0; j < piece; j++)
                    {
                        list.Add(table[i + j]);
                    }
                }

                ThreadPool.QueueUserWorkItem(new WaitCallback(sumThread), new object[] { list });
            }


            Console.ReadKey();
        }

        static void sumThread(Object stateInfo)
        {
            List<int> list = (List<int>)(((object[])stateInfo)[0]);

            foreach (int number in list)
            {
                lock (sem)
                {
                    sum += number;
                    Console.WriteLine("Dodana liczba: " + number + " suma: " + sum);
                }

            }



        }

    }
}
