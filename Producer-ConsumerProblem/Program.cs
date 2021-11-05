using System;
using System.Threading.Tasks;

namespace Producer_ConsumerProblem
{
    class Program
    {
        static Buffer buf = new();
        static void Main(string[] args)
        {            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Producer: ");
                Producer();
                Console.WriteLine("\nConsumer: ");
                Consumer();
                Console.WriteLine();
            }
        }

        static void Producer()
        {
            Console.WriteLine("Producing something");
            Task.Delay(1000);

            Console.WriteLine("Blocking process");
            buf.s.WaitOne();

            Console.WriteLine("Decrease the value of the empty space in the buffer");
            buf.e.WaitOne();

            Console.WriteLine("Appending the newly produced data in the buffer");
            Task.Delay(1000);            

            Console.WriteLine("Marking buffer as full");
            buf.f.Release();

            Console.WriteLine("Releasing process");
            buf.s.Release();
        }

        static void Consumer()
        {
            Console.WriteLine("Blocking process");
            buf.s.WaitOne();

            Console.WriteLine("Marking buffer as empty");
            buf.f.WaitOne();

            Console.WriteLine("Taking the data from the buffer");
            Task.Delay(1000);            

            Console.WriteLine("Increase the value of the empty space in the buffer");
            buf.e.Release();

            Console.WriteLine("Releasing process");
            buf.s.Release();
        }
    }
}
