using System;
using System.Threading;

namespace Producer_ConsumerProblem
{
    class Producer
    {
        public void Produce(ref Buffer buf, int i)
        {
            Random rand = new();
            Item item = new();
            item.Name = $"ItemName{i}";
            item.Price = rand.Next(1, 10);
            Console.Write($"{i} Produced something: {item.Name} - {item.Price}");

            while (buf.s.CurrentCount > 0 && buf.e.CurrentCount > 0 && buf.f.CurrentCount < 1)
                Thread.Sleep(120);

            Console.WriteLine($"\n{i} Blocking process (producer)");
            buf.s.Wait();             

            Console.WriteLine($"{i} Decrease the value of the empty space in the buffer (producer)");
            buf.e.Wait();

            Console.WriteLine($"{i} Appending the newly produced data in the buffer (producer)");
            buf.item = item;

            Console.WriteLine($"{i} Marking buffer as full (producer)");
            buf.f.Release();

            Console.WriteLine($"{i} Releasing process (producer)");
            buf.s.Release();
        }
    }
}
