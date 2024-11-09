namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;
            var result = false;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    result = true;
                    break;
                }
                current = current.Next;
            }

            return result;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            var current = this._head;
            this._head = current.Next;
            this.Count--;

            return current.Value;
        }

        public void Enqueue(T item)
        {
            if (this.Count == 0)
            {
                this._head = new Node<T>(item, null);
                this.Count++;
                return;
            }

            var current = this._head;
            var node = new Node<T>(item, null);

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            var head = this._head;
            return head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotImplementedException();
    }
}