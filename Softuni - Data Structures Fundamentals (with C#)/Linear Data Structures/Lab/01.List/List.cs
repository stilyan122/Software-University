namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity must be a positive number!");
            }
            items = new T[capacity];
            this.Count = 0;
        }

        public T this[int index] 
        {
            get
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("Index out of range!");
                return items[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("Index out of range!");
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            CheckForSpace();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                    return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
            else
            {
                CheckForSpace();
                for (int i = this.Count; i > index; i--)
                {
                    this.items[i] = this.items[i - 1];
                }
                this.items[index] = item;
                this.Count++;
            }
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                this.RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
            else
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.items[this.Count - 1] = default;
                this.Count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void CheckForSpace()
        {
            if (this.Count == this.items.Length)
            {
                T[] newArr = new T[this.Count * 2];
                Array.Copy(this.items, newArr, this.items.Length);
                this.items = newArr;
            }
        }
    }
}