using System;
using System.Threading;

namespace Producer_ConsumerProblem
{
    class Consumer
    {
        public void Consume(Buffer buf, int i)
        {
            while (buf.s.CurrentCount < 1 || buf.e.CurrentCount > 0 || buf.f.CurrentCount < 1)
                Thread.Sleep(100);

            buf.f.Wait();
            Console.WriteLine($"\nConsumer-{i} Marking buffer as empty");

            buf.s.Wait();
            Console.WriteLine($"\nConsumer-{i} Blocking process");            
            
            Console.Write($"\nConsumer-{i} Taking the data from the buffer: ");
            Console.Write($"{buf.item.Name} - {buf.item.Price}\n");
            buf.item = null;

            buf.s.Release();
            Console.WriteLine($"\nConsumer-{i} Releasing process");

            buf.e.Release();
            Console.WriteLine($"\nConsumer-{i} Increase the value of the empty space in the buffer");                       
        }
    }
}