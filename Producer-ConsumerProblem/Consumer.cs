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

            buf.s.Wait();
            Console.WriteLine($"\n{i} Blocking process (consumer)");

            buf.f.Wait();
            Console.WriteLine($"\n{i} Marking buffer as empty (consumer)");
            
            Console.Write($"\n{i} Taking the data from the buffer: ");
            Console.Write($"{buf.item.Name} - {buf.item.Price} (consumer)\n");
            buf.item = null;

            buf.e.Release();
            Console.WriteLine($"\n{i} Increase the value of the empty space in the buffer (consumer)");

            buf.s.Release();
            Console.WriteLine($"\n{i} Releasing process (consumer)");            
        }
    }
}