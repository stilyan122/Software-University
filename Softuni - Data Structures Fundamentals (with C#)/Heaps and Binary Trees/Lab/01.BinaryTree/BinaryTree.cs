namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        private BinaryTree<T> left;
        private BinaryTree<T> right;
        private T value;

        public BinaryTree(T element, IAbstractBinaryTree<T> left, 
            IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get => this.value; set => this.value = value; }

        public IAbstractBinaryTree<T> LeftChild 
        { get => this.left; set => this.left = (BinaryTree<T>)value; }

        public IAbstractBinaryTree<T> RightChild
        { get => this.right; set => this.right = (BinaryTree<T>)value; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            PreOrderStr(this, sb, indent);

            return sb.ToString().Trim();
        }

        private void PreOrderStr(IAbstractBinaryTree<T> current,
            StringBuilder sb, int indent)
        {
            if (current == null)
            {
                return;
            }

            sb.AppendLine($"{new string(' ', indent)}{current.Value}");
            
            PreOrderStr(current.LeftChild, sb, indent+2);
            PreOrderStr(current.RightChild, sb, indent+2);
        }

        public void ForEachInOrder(Action<T> action)
        {
            var list = new List<IAbstractBinaryTree<T>>();

            this.InOrder(this, list);

            list.ForEach(n => action(n.Value));
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            InOrder(this, list);

            return list;
        }

        private void InOrder(IAbstractBinaryTree<T> current,
            List<IAbstractBinaryTree<T>> list)
        {
            if (current == null)
            {
                return;
            }

            InOrder(current.LeftChild, list);
            list.Add(current);
            InOrder(current.RightChild, list);
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            PostOrder(this, list);

            return list;
        }

        private void PostOrder(IAbstractBinaryTree<T> current,
            List<IAbstractBinaryTree<T>> list)
        {
            if (current == null)
            {
                return;
            }

            PostOrder(current.LeftChild, list);
            PostOrder(current.RightChild, list);
            list.Add(current);
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            PreOrder(this, list);

            return list;
        }

        private void PreOrder(IAbstractBinaryTree<T> current,
            List<IAbstractBinaryTree<T>> list)
        {
            if (current == null)
            {
                return;
            }

            list.Add(current);

            PreOrder(current.LeftChild, list);
            PreOrder(current.RightChild, list);
        }
    }
}
