using System.Threading;

namespace Producer_ConsumerProblem
{
    class Buffer
    {
        public Semaphore s; // Mutual exclusion between processes
        public Semaphore e; // Defining empty space
        public Semaphore f; // Defining the space that is filled by the producer

        public Buffer()
        {
            s = new(1, 1);
            e = new(1, 1);
            f = new(0, 1);
        }
    }
}
