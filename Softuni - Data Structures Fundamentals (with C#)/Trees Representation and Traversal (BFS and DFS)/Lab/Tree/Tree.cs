namespace Tree
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private List<Tree<T>> children = new List<Tree<T>>();

        public Tree(T value)
        {
            this.value = value;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.children = children.ToList();
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = FindNode(parentKey);

            if (parent == null)
            {
                throw new ArgumentNullException("Parent null!");
            }
            else
            {
                parent.children.Add(child);
            }
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> trees = new Queue<Tree<T>>();
            List<T> outputs = new List<T>();

            trees.Enqueue(this);

            while (trees.Count > 0)
            {
                var current = trees.Dequeue();

                outputs.Add(current.value);

                foreach (Tree<T> child in current.children)
                {
                    trees.Enqueue(child);
                }
            }

            return outputs;
        }

        public IEnumerable<T> OrderDfs()
        {
            return BFS(this, new List<T>());
        }

        private IEnumerable<T> BFS(Tree<T> tree, List<T> list)
        {       
            foreach (var child in tree.children)
            {
                BFS(child, list);
            }

            list.Add(tree.value);

            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            if (nodeKey.Equals(this.value))
            {
                throw new ArgumentException("Cannot remove root!");
            }

            Tree<T> nodeToFind = FindParentNode(nodeKey);

            if (nodeToFind == null)
            {
                throw new ArgumentNullException("Node null!");
            }
            else
            {
                nodeToFind.children.RemoveAll(c => c.value.Equals(nodeKey));
            }

        }

        private Tree<T> FindNode(T nodeKey)
        {
            Tree<T> nodeToFind = null;
            var trees = new Queue<Tree<T>>();

            trees.Enqueue(this);
            while (trees.Count > 0)
            {
                var current = trees.Dequeue();

                if (current.value.Equals(nodeKey))
                {
                    nodeToFind = current;
                    break;
                }

                foreach (Tree<T> currentChild in current.children)
                {
                    trees.Enqueue(currentChild);
                }
            }

            return nodeToFind;
        }

        private Tree<T> FindParentNode(T nodeKey)
        {
            Tree<T> nodeToFind = null;
            var trees = new Queue<Tree<T>>();

            trees.Enqueue(this);
            while (trees.Count > 0)
            {
                var current = trees.Dequeue();

                if (current.children.Any(c => c.value.Equals(nodeKey)))
                {
                    nodeToFind = current;
                    break;
                }

                foreach (Tree<T> currentChild in current.children)
                {
                    trees.Enqueue(currentChild);
                }
            }

            return nodeToFind;
        }

        public void Swap(T firstKey, T secondKey)
        {
            if (firstKey.Equals(this.value) || secondKey.Equals(this.value))
            {
                throw new ArgumentException("Cannot swap root!");
            }

            var firstParent = FindParentNode(firstKey);
            var secondParent = FindParentNode(secondKey);

            if (firstParent == null || secondParent == null)
            {
                throw new ArgumentNullException("Node null!");
            }
            else
            {
                var firstI = firstParent.children
                    .IndexOf(firstParent.children.Find(x => x.value.Equals(firstKey)));
                var secondI = secondParent.children
                    .IndexOf(secondParent.children.Find(x => x.value.Equals(secondKey)));

                (firstParent.children[firstI], secondParent.children[secondI]) =
                    (secondParent.children[secondI], firstParent.children[firstI]);
            }
        }
    }
}
