namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public Stack()
        {
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            var result = false;
            var current = this._top;

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

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty!");
            }

            var top = this._top;
            return top.Value;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty!");
            }

            var top = this._top;
            this._top = this._top.Next;
            this.Count--;

            return top.Value;
        }

        public void Push(T item)
        {
            var node = new Node<T>(item, this._top);
            this._top = node;
            this.Count++;   
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}