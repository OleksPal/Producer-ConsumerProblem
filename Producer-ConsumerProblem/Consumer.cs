using System;
using System.Threading;

namespace Producer_ConsumerProblem
{
    class Consumer
    {
        public void Consume(ref Buffer buf, int i)
        {            
            while (buf.s.CurrentCount > 0 && buf.e.CurrentCount < 1 && buf.f.CurrentCount > 0)
                Thread.Sleep(100);

            Console.WriteLine($"{i} Blocking process (consumer)");
            buf.s.Wait();

            Console.WriteLine($"\n{i} Marking buffer as empty (consumer)");
            buf.f.Wait();

            Console.WriteLine($"{i} Taking the data from the buffer: ");
            Console.Write($"{buf.item.Name} - {buf.item.Price} (consumer)");

            Console.WriteLine($"\n{i} Increase the value of the empty space in the buffer (consumer)");
            buf.e.Release();

            Console.WriteLine($"{i} Releasing process (consumer)");
            buf.s.Release();
        }
    }
}
