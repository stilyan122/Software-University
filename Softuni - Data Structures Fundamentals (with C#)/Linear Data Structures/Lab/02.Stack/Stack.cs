namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public Node(T val,Node next,Node prev)
            {
                this.Value = val;
                this.Next = next;
                this.Previous = prev;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node node = new Node(item, null, this.top);
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("Stack empty!");
            }
            else
            {
                Node topOfStack = this.top;
                this.top = topOfStack.Previous;
                this.Count--;
                return topOfStack.Value;
            }
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty!");
            }
            else
            {
                return this.top.Value;
            }
        }

        public bool Contains(T item)
        {
            Node currentTop = this.top;
            while (currentTop!=null)
            {
                if (currentTop.Value.Equals(item))
                {
                    return true;
                }
                currentTop = currentTop.Previous;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node top = this.top;
            while (top!=null)
            {
                yield return top.Value;
                top = top.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}