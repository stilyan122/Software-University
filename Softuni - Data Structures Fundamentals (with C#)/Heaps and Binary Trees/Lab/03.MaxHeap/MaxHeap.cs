namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> 
        where T : IComparable<T>
    {
        private List<T> elements;

        // parent (i) => (i - 1) / 2
        // left child (i) => 2i + 1
        // right child (i) => 2i + 2
        public MaxHeap()
        {
            this.Size = 0;
            this.elements = new List<T>();
        }

        public int Size { get; private set; }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.Size++;

            if (this.Size != 1)
            {
                HeapifyUp();
            }
        }

        private void HeapifyUp()
        {
            var i = this.Size - 1;
            var parent = this.elements[(i - 1) / 2];

            while (i > 0 && this.elements[i].CompareTo(parent) > 0)
            {
                // Swap
                (this.elements[i], this.elements[(i - 1) / 2])
                    = (this.elements[(i - 1) / 2], this.elements[i]);

                i = (i - 1) / 2;
                parent = this.elements[(i - 1) / 2];
            }
        }

        public T ExtractMax()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }

            if (this.Size == 1)
            {
                var onlyElement = this.elements[0];
                this.elements = new List<T>();
                this.Size = 0;
                return onlyElement;
            }

            var root = this.elements[0];

            this.elements[0] = this.elements[this.Size - 1];
            this.elements.RemoveAt(this.Size - 1);
            this.Size--;

            int i = 0;
            while (true)
            {
                int leftChildI = 2 * i + 1;
                int rightChildI = 2 * i + 2;
                int largerChildI = i;

                if (leftChildI < this.Size && this.elements[leftChildI].CompareTo(this.elements[largerChildI]) > 0)
                {
                    largerChildI = leftChildI;
                }

                if (rightChildI < this.Size && this.elements[rightChildI].CompareTo(this.elements[largerChildI]) > 0)
                {
                    largerChildI = rightChildI;
                }

                if (largerChildI == i)
                {
                    break;
                }

                (this.elements[i], this.elements[largerChildI]) = 
                    (this.elements[largerChildI], this.elements[i]);

                i = largerChildI;
            }

            return root;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Heap empty!");
            }

            return this.elements[0];
        }
    }
}
