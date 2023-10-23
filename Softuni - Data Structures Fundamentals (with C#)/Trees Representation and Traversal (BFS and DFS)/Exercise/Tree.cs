namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = children.ToList();
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
        {
            get
            {
                return children.AsReadOnly();
            }
            private set
            {
                this.children = value.ToList();
            }
        }

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.TraverseForString(this, 0, new StringBuilder());
        }

        public List<T> GetMiddleKeys()
        {
            return this.TraverseForInternal(this, new List<T>());
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.TraverseForLeaf(this, new List<T>());
        }

        public T GetDeepestLeftomostNode()
        {
            return this.TraverseForDeepestKey().Key;
        }

        public IEnumerable<T> GetLongestPath()
        {
            List<T> path = this.TraverseForLongestPath(new List<T>());
            
            return path;
        }

        private List<Tree<T>> TraverseForLeaves(Tree<T> tree, List<Tree<T>> list)
        {
            if (tree.Children.Count == 0)
                list.Add(tree);
            foreach (var item in tree.Children)
            {
                TraverseForLeaves(item, list);
            }
            return list;
        }

        private Tree<T> TraverseForDeepestKey()
        {
            List<Tree<T>> leaves = 
                this.TraverseForLeaves(this, new List<Tree<T>>());
            Tree<T> deepest = null;
            if(leaves.Count > 0)
                deepest = leaves[0];
            foreach (var tree in leaves)
            {
                if (
                    this.ReturnPathLengthForALeaf(tree)
                    >
                    this.ReturnPathLengthForALeaf(deepest))
                        deepest = tree; 
            }
            return deepest;
        }

        private int ReturnPathLengthForALeaf(Tree<T> leaf)
        {
            int count = 1;
            Tree<T> parent = leaf.Parent;
            while (parent != null)
            {
                count++;
                parent = parent.Parent;
            }
            return count;
        }

        private string TraverseForString(Tree<T> tree, int indent, StringBuilder sb)
        {
            sb.Append(new string(' ', indent) + tree.Key).AppendLine();
            foreach (var item in tree.Children)
            {
                TraverseForString(item, indent + 2, sb);
            }
            return sb.ToString().Trim();
        }

        private List<T> TraverseForLeaf(Tree<T> tree, List<T> list)
        {
            if (tree.Children.Count == 0)
                list.Add(tree.Key);
            foreach (var item in tree.Children)
            {
                TraverseForLeaf(item, list);
            }
            return list;
        }

        private List<T> TraverseForInternal(Tree<T> tree, List<T> list)
        {
            if (tree.Children.Count > 0 && !(tree.Parent is null))
                list.Add(tree.Key);
            foreach (var item in tree.Children)
            {
                TraverseForInternal(item, list);
            }
            return list;
        }
        
        private List<T> TraverseForLongestPath(List<T> path)
        {
            Tree<T> deepestLeaf = this.TraverseForDeepestKey();
            path.Add(deepestLeaf.Key);
            Tree<T> parent = deepestLeaf.Parent;
            while (parent != null)
            {
                path.Add(parent.Key);
                parent = parent.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}
