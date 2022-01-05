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

            for (int i = 0; i < 5; i++) 
            {
                new Thread(() => consumer.Consume(buf, i)).Start();
                new Thread(() => producer.Produce(buf, i)).Start();
            }
        }
    }
}
