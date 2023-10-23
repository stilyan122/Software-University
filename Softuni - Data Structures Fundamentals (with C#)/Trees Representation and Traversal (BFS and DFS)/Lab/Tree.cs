namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        public T Value;
        public Tree<T> Parent;
        public List<Tree<T>> Children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.Children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> tree = FindTreeByKey(parentKey);
            if (tree is null)
            {
                throw new ArgumentNullException("Node not found!");
            }
            else
            {
                tree.Children.Add(child);
                child.Parent = tree;
            }
        }

        private Tree<T> FindTreeByKey(T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            if (this.Value.Equals(key))
            {
                return this;
            }
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> tree = queue.Dequeue();
                if (tree.Value.Equals(key))
                {
                    return tree;
                }
                foreach (var child in tree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            List<T> results = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> tree = queue.Dequeue();
                results.Add(tree.Value);
                foreach (var child in tree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return results;
        }

        /* -- Stack Method
         public IEnumerable<T> OrderDfs()
        {
            Stack<T> results = new Stack<T>();
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                Tree<T> tree = stack.Pop();
                foreach (var child in tree.Children)
                {
                    stack.Push(child);
                }

                results.Push(tree.Value);
            }
            return results;
        } */

        // -- Recursion Method
        public IEnumerable<T> OrderDfs()
        {
            List<T> results = new List<T>();
            RecursionMethod(this, results);
            return results;
        }

        private void RecursionMethod(Tree<T> tree,List<T> result)
        {
            foreach (var child in tree.Children)
            {
                RecursionMethod(child, result);
            }
            result.Add(tree.Value);
        }

        public void RemoveNode(T nodeKey)
        {
            if (this.Value.Equals(nodeKey))
            {
                throw new ArgumentException("Cannot remove root!");
            }
            Tree<T> tree = FindTreeByKey(nodeKey);
            if (tree is null)
            {
                throw new ArgumentNullException("Node not found!");
            }
            tree.Parent.Children.Remove(tree);
        }

        public void Swap(T firstKey, T secondKey)
        {
            if (this.Value.Equals(firstKey) || this.Value.Equals(secondKey))
            {
                throw new ArgumentException("Cannot swap root!");
            }
            Tree<T> firstTree = FindTreeByKey(firstKey);
            Tree<T> secondTree = FindTreeByKey(secondKey);
            if (firstTree is null || secondTree is null)
            {
                throw new ArgumentNullException("Node/s not found!");
            }

            Tree<T> firstParent = firstTree.Parent;
            Tree<T> secondParent = secondTree.Parent;

            if (firstTree.Children.Contains(secondTree))
            {
                int firstIndex = firstParent.Children.IndexOf(firstTree);
                firstParent.Children.Remove(firstTree);
                firstParent.Children.Insert(firstIndex, secondTree);
                secondTree.Parent = firstParent;
            }
            else if (secondTree.Children.Contains(firstTree))
            {
                int secondIndex = secondParent.Children.IndexOf(secondTree);
                secondParent.Children.Remove(secondTree);
                secondParent.Children.Insert(secondIndex, firstTree);
                firstTree.Parent = secondParent;
            }
            else
            {
                int firstIndex = firstParent.Children.IndexOf(firstTree);
                int secondIndex = secondParent.Children.IndexOf(secondTree);

                firstParent.Children.RemoveAt(firstIndex);
                firstParent.Children.Insert(firstIndex,secondTree);

                secondParent.Children.RemoveAt(secondIndex);
                secondParent.Children.Insert(secondIndex,firstTree);

                firstTree.Parent = secondParent;
                secondTree.Parent = firstParent;
            }
        }
    }
}
