using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            var childIndex = this.elements.Count - 1;

            this.HeapifyUp(childIndex);
        }

        protected void HeapifyUp(int childIndex)
        {
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (this.elements[childIndex].CompareTo(this.elements[parentIndex]) >= 0)
                    break;

                (this.elements[parentIndex], this.elements[childIndex]) =
                    (this.elements[childIndex], this.elements[parentIndex]);

                childIndex = parentIndex;
            }
        }

        public T ExtractMin()
        {
            var root = this.Peek();
            this.elements[0] = this.elements.Last();
            this.elements.RemoveAt(this.elements.Count - 1);

            this.HeapifyDown(0);

            return root;
        }

        private void HeapifyDown(int parentIndex)
        {
            while (true)
            {
                int leftChildIndex = 2 * parentIndex + 1;
                int rightChildIndex = 2 * parentIndex + 2;
                int smallestChildIndex = parentIndex;

                if (leftChildIndex < this.Count &&
                    this.elements[leftChildIndex]
                    .CompareTo(this.elements[smallestChildIndex]) < 0)
                {
                    smallestChildIndex = leftChildIndex;
                }

                if (rightChildIndex < this.Count &&
                    this.elements[rightChildIndex]
                    .CompareTo(this.elements[smallestChildIndex]) < 0)
                {
                    smallestChildIndex = rightChildIndex;
                }

                if (smallestChildIndex == parentIndex)
                    break;

                (this.elements[parentIndex], this.elements[smallestChildIndex]) =
                    (this.elements[smallestChildIndex], this.elements[parentIndex]);

                parentIndex = smallestChildIndex;
            }
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Heap empty!");
            }

            return this.elements[0];
        }

        public List<T> Elements => this.elements;
    }
}
