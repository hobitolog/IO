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
        delegate int DelegateType(int i);
        static DelegateType delegateName;
        static DelegateType delegateName2;
        static DelegateType delegateName3;


        static int silniaR(int i)
        {
          
            if (i < 1)
                return 1;
            else
                return i * silniaR(i - 1);

            
            return 0;
        }
        static int wypSilniaR(int i)
        {
            int a = silniaR(i);
            Console.WriteLine("Rek"+a);
            return a; //zadania do 
        }
        static int wypFib(int i)
        {
            int a = fib(i);
            Console.WriteLine("Fib" + a);
            return a; //zadania do 
        }
        static int silniaI(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine("Ite: " + result);

            return result;
        }
        static int fib(int n)
        {
            if ((n == 1) || (n == 2))
                return 1;
            else
                return fib(n - 1) + fib(n - 2);
        }

        static void Main(string[] args)
        {
            delegateName = new DelegateType(wypSilniaR);
            delegateName2 = new DelegateType(silniaI);
            delegateName3 = new DelegateType(wypFib);
            IAsyncResult ar = delegateName.BeginInvoke(6,null,null);
            IAsyncResult ar2 = delegateName2.BeginInvoke(6, null, null);
            IAsyncResult ar3 = delegateName3.BeginInvoke(6, null, null);
            int result = delegateName.EndInvoke(ar);

            int result2 = delegateName2.EndInvoke(ar2);

            int result3 = delegateName3.EndInvoke(ar3);



        }
    }

}
