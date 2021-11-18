using System.Threading;

namespace Producer_ConsumerProblem
{
    class Buffer
    {
        public Item item;
        public SemaphoreSlim s; // Mutual exclusion between processes
        public SemaphoreSlim e; // Defining empty space
        public SemaphoreSlim f; // Defining the space that is filled by the producer

        public Buffer(Item item)
        {
            s = new(1, 1);
            e = new(1, 1);
            f = new(0, 1);
            this.item = item;
        }
    }
}
