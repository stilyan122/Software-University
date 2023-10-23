namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
             
        }
        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.LeftChild);
            this.PreOrderCopy(node.RightChild);
        }

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
        }

        private Node root;

        public bool Contains(T element)
        {
            return this.FindNode(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.RightChild);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }

            else if (element.CompareTo(node.Value) < 0)
            {
                node.LeftChild = this.Insert(element, node.LeftChild);
            }

            else if (element.CompareTo(node.Value) > 0)
            {
                node.RightChild = this.Insert(element, node.RightChild);
            }

            return node;
        }

        private Node FindNode(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;

        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
