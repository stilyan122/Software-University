namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> 
        where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        // My attempt
        //public void Delete(T element)
        //{
        //    if (this.root == null) throw new InvalidOperationException("Tree is empty!");
        //    else if (this.root.Value.Equals(element)) this.root = null;
        //    else this.Delete(this.root, element);
        //}

        //private void Delete(Node node, T value)
        //{
        //    var leftChild = node.Left;
        //    var rightChild = node.Right;

        //    if (leftChild != null && leftChild.Value.Equals(value))
        //    {
        //        if (leftChild.Left == null && leftChild.Right == null)
        //        {
        //            node.Left = null;
        //        }
        //        else if (leftChild.Left == null)
        //        {
        //            node.Left = leftChild.Right;
        //        }
        //        else if (leftChild.Right == null)
        //        {
        //            node.Left = leftChild.Left;
        //        }
        //        else
        //        {
        //            var min = this.FindMin(leftChild.Right);
        //            this.Delete(leftChild.Right, min.Value);
        //            node.Left = min;
        //            min.Left = leftChild.Left;
        //            min.Right = leftChild.Right;
        //        }
        //    }
        //    else if (rightChild != null && rightChild.Value.Equals(value))
        //    {
        //        if (rightChild.Left == null && rightChild.Right == null)
        //        {
        //            node.Right = null;
        //        }
        //        else if (rightChild.Left == null)
        //        {
        //            node.Right = rightChild.Right;
        //        }
        //        else if (rightChild.Right == null)
        //        {
        //            node.Right = rightChild.Left;
        //        }
        //        else
        //        {
        //            var min = this.FindMin(rightChild.Right);
        //            this.Delete(rightChild.Right, min.Value);
        //            node.Right = min;
        //            min.Left = rightChild.Left;
        //            min.Right = rightChild.Right;
        //        }
        //    }
        //    else if (leftChild != null && node.Value.CompareTo(value) > 0)
        //    {
        //        Delete(leftChild, value);
        //    }
        //    else if (rightChild != null && node.Value.CompareTo(value) < 0)
        //    {
        //        Delete(rightChild, value);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Node not found!");
        //    }
        //}

        //private Node FindMin(Node node)
        //{
        //    if (node == null || node.Left == null)
        //    {
        //        return node;
        //    }

        //    return FindMin(node.Left);
        //}

        public void Delete(T element)
        {
            if (this.root == null) 
                throw new InvalidOperationException("Tree is empty!");
            this.root = Delete(this.root, element);
        }

        private Node Delete(Node node, T value)
        {
            if (node == null) 
                throw new InvalidOperationException("Node not found!");

            int comparison = value.CompareTo(node.Value);

            if (comparison < 0)
            {
                node.Left = Delete(node.Left, value);
            }
            else if (comparison > 0) 
            {
                node.Right = Delete(node.Right, value);
            }
            else
            {
                if (node.Left == null) 
                    return node.Right;

                if (node.Right == null) 
                    return node.Left;

                Node minLargerNode = FindMin(node.Right);
                node.Value = minLargerNode.Value;
                node.Right = Delete(node.Right, minLargerNode.Value);
            }

            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            else if (this.root.Right == null)
            {
                this.root = this.root.Left;
                return;
            }

            DeleteMaxReq(this.root);
        }

        private void DeleteMaxReq(Node node)
        {
            if (node.Right.Right == null)
            {
                node.Right = node.Right.Left;
                return;
            }

            DeleteMaxReq(node.Right);
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            else if (this.root.Left == null)
            {
                this.root = this.root.Right;
                return;
            }

            DeleteMinReq(this.root);
        }

        private void DeleteMinReq(Node node)
        {
            if (node.Left.Left == null)
            {
                node.Left = node.Left.Right;
                return;
            }

            DeleteMinReq(node.Left);
        }

        public int Count()
        {
            var count = 0;

            this.EachInOrder((current) => { count++; });

            return count;
        }

        public int Rank(T element)
        {
            return Rank(element, this.root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null) return 0;

            int comparison = element.CompareTo(node.Value);
            if (comparison < 0)
            {
                return Rank(element, node.Left);
            }
            else if (comparison > 0)
            {
                int leftCount = node.Left == null ? 0 : Count(node.Left);
                return 1 + leftCount + Rank(element, node.Right);
            }
            else
            {
                return node.Left == null ? 0 : Count(node.Left);
            }
        }

        public T Select(int rank)
        {
            if (this.root == null || rank < 0 || rank >= this.Count())
                throw new InvalidOperationException("Node not found!");

            return Select(this.root, rank);
        }

        private T Select(Node node, int rank)
        {
            int leftCount = node.Left == null ? 0 : Count(node.Left);

            if (leftCount > rank)
            {
                return Select(node.Left, rank);
            }
            else if (leftCount < rank)
            {
                return Select(node.Right, rank - leftCount - 1);
            }
            else
            {
                return node.Value;
            }
        }

        public T Ceiling(T element)
        {
            Node ceilingNode = FindCeiling(this.root, element);

            if (ceilingNode == null)
                throw new InvalidOperationException("No ceiling found!");

            return ceilingNode.Value;
        }

        private Node FindCeiling(Node node, T element)
        {
            Node result = null;
            while (node != null)
            {
                int comparison = element.CompareTo(node.Value);

                if (comparison < 0)
                {
                    result = node;
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return result;
        }

        public T Floor(T element)
        {
            Node floorNode = FindStrictFloor(this.root, element);

            if (floorNode == null)
                throw new InvalidOperationException("No floor found!");

            return floorNode.Value;
        }

        private Node FindStrictFloor(Node node, T element)
        {
            Node result = null;
            while (node != null)
            {
                int comparison = element.CompareTo(node.Value);

                if (comparison > 0)
                {
                    result = node;
                    node = node.Right;
                }
                else
                {
                    node = node.Left;
                }
            }
            return result;
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Count(node.Left) + Count(node.Right);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var list = new List<T>();

            this.EachInOrder((current) =>
            {
                var comparisonStart = current.CompareTo(startRange);
                var comparisonEnd = current.CompareTo(endRange);

                if (comparisonStart >= 0 && comparisonEnd <= 0)
                {
                    list.Add(current);
                }
            });

            return list;
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
