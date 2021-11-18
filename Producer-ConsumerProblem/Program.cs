using System.Threading;

namespace Producer_ConsumerProblem
{
    class Program
    {
        static Buffer buf;
        static void Main(string[] args)
        {
            buf = new(new Item());
            for (int i = 0; i < 5; i++)
            {
                Producer producer = new();
                new Thread(() => producer.Produce(buf, i)).Start();

                Consumer consumer = new();
                new Thread(() => consumer.Consume(buf, i)).Start();
            }
        }
    }
}
