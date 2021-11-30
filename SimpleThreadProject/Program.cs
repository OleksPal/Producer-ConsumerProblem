using System;
using System.Threading;

namespace SimpleThreadProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Item a = new Item('a', 3);
            Item b = new Item('b', 5);
            for (int i = 0; i < 5; i++)
            {
                new Thread(() => PrintSymbols(a)).Start();
                new Thread(() => PrintSymbols(b)).Start();
            }
        }

        static void PrintSymbols(Item item)
        {
            for (int i = 0; i < item.Number; i++)
                Console.Write(item.Name);
        }
    }
}