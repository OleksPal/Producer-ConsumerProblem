using System.Threading;

namespace Producer_ConsumerProblem
{
    class Program
    {
        static volatile Buffer buf = new(new Item());
        static void Main(string[] args)
        {
            Consumer consumer = new();
            Producer producer = new();

            new Thread(() => consumer.Consume(buf, 1)).Start();
            new Thread(() => consumer.Consume(buf, 2)).Start();
            new Thread(() => producer.Produce(buf, 1)).Start();
            new Thread(() => producer.Produce(buf, 2)).Start();
        }
    }
}
