namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return ReturnAsText(new StringBuilder(), this, indent);
        }

        private string ReturnAsText(StringBuilder sb,IAbstractBinaryTree<T> tree,int indent)
        {
            sb.Append(new string(' ', indent)).Append(tree.Value).AppendLine();
            if(tree.LeftChild != null)
            ReturnAsText(sb, tree.LeftChild, indent + 2);
            if(tree.RightChild != null)
            ReturnAsText(sb, tree.RightChild, indent + 2);

            return sb.ToString().Trim();
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
                this.LeftChild.ForEachInOrder(action);

            action.Invoke(this.Value);

            if (this.RightChild != null)
                this.RightChild.ForEachInOrder(action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result =
               new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
                result.AddRange(this.LeftChild.InOrder());
            
            result.Add(this);

            if (this.RightChild != null)
                result.AddRange(this.RightChild.InOrder());

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result =
               new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
                result.AddRange(this.LeftChild.PostOrder());

            if (this.RightChild != null)
                result.AddRange(this.RightChild.PostOrder());

            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result =
                new List<IAbstractBinaryTree<T>>();

            result.Add(this);

            if (this.LeftChild != null)
                result.AddRange(this.LeftChild.PreOrder());

            if (this.RightChild != null)
                result.AddRange(this.RightChild.PreOrder());

            return result;
        }
    }
}
