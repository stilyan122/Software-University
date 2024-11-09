namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var result = new List<T>();
            var queue = new Queue<(BinaryTree<T> node, int hd)>();
            var topViewMap = new Dictionary<int, T>();

            queue.Enqueue((this, 0));

            while (queue.Count > 0)
            {
                var (node, hd) = queue.Dequeue();

                if (!topViewMap.ContainsKey(hd))
                {
                    topViewMap[hd] = node.Value;
                }

                if (node.LeftChild != null)
                {
                    queue.Enqueue((node.LeftChild, hd - 1));
                }

                if (node.RightChild != null)
                {
                    queue.Enqueue((node.RightChild, hd + 1));
                }
            }

            foreach (var value in topViewMap.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value))
            {
                result.Add(value);
            }

            return result;
        }
    }
}
