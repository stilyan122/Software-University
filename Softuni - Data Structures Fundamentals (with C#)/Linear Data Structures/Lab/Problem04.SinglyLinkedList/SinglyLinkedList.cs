namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
            this.Count = 0;
        }

        public void AddFirst(T item)
        {
            this.Count++;
            var node = new Node<T>(item, null);

            if (this._head == null)
            {
                this._head = node;
                return;
            }

            node.Next = this._head;
            this._head = node;
        }

        public void AddLast(T item)
        {
            this.Count++;
            var node = new Node<T>(item, null);

            if (this._head == null)
            {
                this._head = node;
                return;
            }

            var current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            var head = this._head;
            return head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            var current = this._head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            this.Count--;
            var head = this._head;
            this._head = this._head.Next;
            return head.Value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }

            if (this.Count == 1)
            {
                var head = this._head;
                this._head = null;
                this.Count--;
                return head.Value;
            }

            this.Count--;
            var current = this._head;

            while (current.Next.Next != null)
            {
                current = current.Next; 
            }

            var node = current.Next;
            current.Next = null;

            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}