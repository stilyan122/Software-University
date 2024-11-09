namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private int front;
        private int rear;
        private T[] items;

        public CircularQueue(int capacity = 4)
        {
            this.Count = 0;
            this.front = -1;
            this.rear = -1;
            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            var current = this.items[front];
            this.items[front] = default(T);

            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else
            {
                front++;
                if (front == this.items.Length)
                {
                    front = 0;
                }
            }

            this.Count--;

            return current;
        }

        public void Enqueue(T item)
        {
            if (this.items.Length == this.Count)
            {
                this.Grow();
            }

            rear++;
            if (rear == this.items.Length)
            {
                rear = 0;
            }

            if (front == -1)
            {
                front = 0;
            }

            this.items[rear] = item;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[(this.front + i) % this.items.Length];
            }
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            return this.items[front];
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.items[(this.front + i) % this.items.Length];
            }
            return array;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            var newArray = new T[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[(this.front + i) % this.items.Length];
            }

            this.items = newArray;
            this.front = 0;
            this.rear = this.Count - 1;
        }
    }

}
