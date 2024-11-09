namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree<T> Root { get; set; }
        public T Value { get; set; }
        public BinarySearchTree<T> LeftChild { get; set; }
        public BinarySearchTree<T> RightChild { get; set; }

        public BinarySearchTree(T value, BinarySearchTree<T> leftChild,
            BinarySearchTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Root = this;
        }

        public BinarySearchTree()
        {
            
        }

        public bool Contains(T element)
        {
            var result = ContainsDFS(element, this.Root);

            return result;
        }

        private bool ContainsDFS(T element, BinarySearchTree<T> current)
        {
            if (current == null)
            {
                return false;
            }

            var comparison = element.CompareTo(current.Value);

            if (comparison == -1)
            {
                return ContainsDFS(element, current.LeftChild);
            }
            else if (comparison == 1)
            {
                return ContainsDFS(element, current.RightChild);
            }
            else
            {
                return true;
            }
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrderDFS(action, this.Root);
        }

        private void EachInOrderDFS(Action<T> action, BinarySearchTree<T> current)
        {
            if (current == null)
            {
                return;
            }

            EachInOrderDFS(action, current.LeftChild);

            action(current.Value);

            EachInOrderDFS(action, current.RightChild);
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new BinarySearchTree<T>()
                {
                    Value = element
                };
            }
            else
            {
                InsertDFS(element, this.Root);
            }
        }

        private void InsertDFS(T element, BinarySearchTree<T> current)
        {
            var comparison = element.CompareTo(current.Value);

            if (comparison == -1)
            {
                if (current.LeftChild == null)
                {
                    current.LeftChild = new BinarySearchTree<T>(element, null, null);
                    return;
                }
                InsertDFS(element, current.LeftChild);
            }
            else if (comparison == 1)
            {
                if (current.RightChild == null)
                {
                    current.RightChild = new BinarySearchTree<T>(element, null, null);
                    return;
                }
                InsertDFS(element, current.RightChild);
            }
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var result = SearchDFS(element, this.Root);

            return result;
        }

        private BinarySearchTree<T> SearchDFS(T element, BinarySearchTree<T> current)
        {
            if (current == null)
            {
                return null;
            }

            var comparison = element.CompareTo(current.Value);

            if (comparison == -1)
            {
                return SearchDFS(element, current.LeftChild);
            }
            else if (comparison == 1)
            {
                return SearchDFS(element, current.RightChild);
            }
            else
            {
                return current;
            }
        }
    }
}
