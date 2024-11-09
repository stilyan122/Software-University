namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        private BinaryTree<T> FindLCA(BinaryTree<T> node, T first, T second)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.Equals(first) || node.Value.Equals(second))
            {
                return node;
            }

            BinaryTree<T> leftLCA = FindLCA(node.LeftChild, first, second);
            BinaryTree<T> rightLCA = FindLCA(node.RightChild, first, second);

            if (leftLCA != null && rightLCA != null)
            {
                return node;
            }

            return leftLCA ?? rightLCA;
        }

        public T FindLowestCommonAncestor(T first, T second)
        {
            return FindLCA(this, first, second).Value;
        }

        // My attempt (with throwing exceptions unlike other)
        //    var firstNode = FindBinaryTree(this, first);
        //    var secondNode = FindBinaryTree(this, second);

        //        if (firstNode == null || secondNode == null)
        //        {
        //            throw new InvalidOperationException("Exception thrown!");
        //}
        //        if (firstNode.Value.Equals(this.Value) || secondNode.Value.Equals(this.Value))
        //        {
        //    return this.Value;
        //}

        //        if (firstNode.Parent.Value.Equals(secondNode.Value))
        //        {
        //    return secondNode.Value;
        //}
        //        else if (secondNode.Parent.Value.Equals(firstNode.Value))
        //        {
        //    return firstNode.Value;
        //}
        //        else
        //        {
        //    var firstNodeParents = FindParents(firstNode);
        //    var secondNodeParents = FindParents(secondNode);

        //    if (firstNodeParents.Count > secondNodeParents.Count)
        //    {
        //        foreach (var item in secondNodeParents)
        //        {
        //            if (firstNodeParents.Contains(item))
        //            {
        //                return item.Value;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (var item in firstNodeParents)
        //        {
        //            if (secondNodeParents.Contains(item))
        //            {
        //                return item.Value;
        //            }
        //        }
        //    }
        //}

        //        throw new InvalidOperationException("Exception thrown!");

        private BinaryTree<T> FindBinaryTree(BinaryTree<T> root, T nodeValue)
            {
                if (root == null)
                {
                    return null;
                }

                var comparison = nodeValue.CompareTo(root.Value);

                if (comparison > 0)
                {
                    return FindBinaryTree(root.RightChild, nodeValue);
                }
                else if (comparison < 0)
                {
                    return FindBinaryTree(root.LeftChild, nodeValue);
                }

                return root;
            }
        
            private List<BinaryTree<T>> FindParents(BinaryTree<T> root)
            {
                var list = new List<BinaryTree<T>>() { root };

                while (root.Parent != null)
                {
                    list.Add(root.Parent);

                    root = root.Parent;
                }

                return list;
            }
        }
}
