using System;
using System.Threading;

namespace Producer_ConsumerProblem
{
    class Producer
    {
        public void Produce(Buffer buf, int i)
        {
            Random rand = new();
            Item item = new();
            item.Name = $"ItemName{i}";
            item.Price = rand.Next(1, 10);
            Console.WriteLine($"\n{i} Produced something: {item.Name} - {item.Price}");

            while (buf.s.CurrentCount < 1 || buf.e.CurrentCount < 1 || buf.f.CurrentCount > 0)
                Thread.Sleep(100);

            buf.s.Wait();
            Console.WriteLine($"\n{i} Blocking process (producer)");

            buf.e.Wait();
            Console.WriteLine($"\n{i} Decrease the value of the empty space in the buffer (producer)");

            buf.item = item;
            Console.WriteLine($"\n{i} Appending the newly produced data in the buffer (producer)");

            buf.f.Release();
            Console.WriteLine($"\n{i} Marking buffer as full (producer)");

            Console.WriteLine($"\n{i} Releasing process (producer)");
            buf.s.Release();                       
        }
    }
}
