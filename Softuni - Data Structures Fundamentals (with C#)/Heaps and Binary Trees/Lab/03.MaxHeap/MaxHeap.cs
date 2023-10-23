namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;
        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && 
                this.elements[index].CompareTo(
                this.elements[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int biggerChildIndex = GetBiggerChildIndex(index);

            while (biggerChildIndex < this.Size && biggerChildIndex>=0 &&
                this.elements[biggerChildIndex].CompareTo(
                this.elements[index]) > 0)
            {
                this.Swap(biggerChildIndex, index);
                index = biggerChildIndex;
                biggerChildIndex = GetBiggerChildIndex(index);
            }
        }

        private int GetBiggerChildIndex(int index)
        {
            int first = index * 2 + 1;
            int second = index * 2 + 2;

            if (second < this.Size)
            {
                if (this.elements[first].CompareTo(
                this.elements[second]) > 0)
                {
                    return first;
                }
                return second;
            }
            else if (first < this.Size)
            {
                return first;
            }
            else
            {
                return -1;
            }
        }

        private void Swap(int index,int parentIndex)
        {
            T help = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = help;
        }

        public T ExtractMax()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Heap empty!");
            }
            T element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);
            return element;
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
