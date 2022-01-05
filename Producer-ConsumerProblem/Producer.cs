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
            Console.WriteLine($"\nProducer-{i} produced: {item.Name} - {item.Price}");

            while (buf.s.CurrentCount < 1 || buf.e.CurrentCount < 1 || buf.f.CurrentCount > 0)
                Thread.Sleep(100);

            buf.e.Wait();
            Console.WriteLine($"\nProducer-{i} Decrease the value of the empty space in the buffer");

            buf.s.Wait();
            Console.WriteLine($"\nProducer-{i} Blocking process");            

            buf.item = item;
            Console.WriteLine($"\nProducer-{i} Appending the newly produced data in the buffer");            

            Console.WriteLine($"\nProducer-{i} Releasing process");
            buf.s.Release();

            buf.f.Release();
            Console.WriteLine($"\nProducer-{i} Marking buffer as full");
        }
    }
}
