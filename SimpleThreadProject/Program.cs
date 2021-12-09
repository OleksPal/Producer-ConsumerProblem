using System;
using System.Threading;

namespace SimpleThreadProject
{
    class Program
    {
        static volatile bool indicator = true;
        static void Main(string[] args)
        {
            Item a = new Item('a', 8000);

            new Thread(() => PrintSymbols(a)).Start();
            new Thread(() => SleepingThread()).Start();
        }

        static void PrintSymbols(Item item)
        {
            while (indicator)
                Console.Write(item.Name);
        }

        static void SleepingThread()
        {
            Thread.Sleep(200);
            indicator = false;
        }
    }
}