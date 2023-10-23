namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] items;

        private readonly int INIT_CAPACITY = 4;

        private int count = 0;

        public int Count {get; private set;}

        public CircularQueue()
        {
            this.items = new T[INIT_CAPACITY];
            this.Count = 0;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }
            else
            {
                T value = this.items[0];
                for (int i = 1; i < this.Count; i++)
                {
                    this.items[i - 1] = this.items[i];
                }
                this.items[this.Count - 1] = default;
                this.Count--;
                return value;  
            }
        }

        public void Enqueue(T item)
        {
            GrowQueue();
            this.items[this.Count] = item;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }
            else
            {
                return this.items[0];
            }
        }

        public T[] ToArray()
        {
            return this.items.Where(x => !x.Equals(default(T))).ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void GrowQueue()
        {
            if (this.Count==this.items.Length)
            {
                T[] copy = new T[this.items.Length * 2];
                Array.Copy(this.items, copy, this.Count);
                this.items = copy;
            }
        }
    }

}
