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
                new Thread(() => producer.Produce(ref buf, i)).Start();

                //Thread thread1 = new Thread(new ParameterizedThreadStart(producer.Produce));
                //thread1.Start(new InputThreadParameters(ref buf, i));

                Consumer consumer = new();
                new Thread(() => consumer.Consume(ref buf, i)).Start();
            }
        }
    }

    //class InputThreadParameters
    //{        
    //    Buffer buf;
    //    int i;

    //    public InputThreadParameters(ref Buffer buf, int i)
    //    {
    //        this.buf = buf;
    //        this.i = i;
    //    }
    //}
}
