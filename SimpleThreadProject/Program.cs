using System;
using System.Threading;

namespace SimpleThreadProject
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() => PrintSymbols(3, 'a')).Start();
                new Thread(() => PrintSymbols(5, 'b')).Start();
            }
        }

        static void PrintSymbols(int number, char symbol)
        {
            for (int i = 0; i < number; i++)
                Console.Write(symbol);
        }
    }
}
