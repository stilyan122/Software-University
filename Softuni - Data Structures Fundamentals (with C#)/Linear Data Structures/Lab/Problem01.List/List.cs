namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid capacity!");
            }

            this._items = new T[capacity];
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }

                return this._items[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }

                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this._items.Length)
            {
                this.Grow();
            }

            this._items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                var current = this._items[i];

                if (current.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            var index = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index for insertion!");
            }

            if (this.Count == this._items.Length)
            {
                this.Grow();
            }

            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;

            this.Count++;
        }

        public bool Remove(T item)
        {
            var result = false;
            var index = this.IndexOf(item); 

            if (index != -1)
            {
                this.RemoveAt(index);
                result = true;
            }

            return result;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            for (int i = index; i < this.Count; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count] = default(T);
            this.Count--;

            if (this.Count == this._items.Length / 2)
            {
                this.Shrink();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            var newArray = new T[this.Count * 2];
            this._items.CopyTo(newArray, 0);
            this._items = newArray;
        }

        private void Shrink()
        {
            var newArray = new T[this.Count / 2];
            this._items.CopyTo(newArray, 0);
            this._items = newArray;
        }
    }
}