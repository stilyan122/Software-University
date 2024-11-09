namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            if (children != null)
            {
                foreach (var child in children)
                {
                    this.AddChild(child);
                    child.AddParent(this);
                }
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
        {
            get
            {
                return children.AsReadOnly();
            }
            set
            {
                children = value.ToList();
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
            var sb = new StringBuilder();

            TreeAsStringDFS(this, sb, 0);

            return sb.ToString().Trim();
        }

        private void TreeAsStringDFS(Tree<T> tree, StringBuilder sb, int indents)
        {
            sb.AppendLine($"{new string(' ', indents)}{tree.Key}");
            foreach (var child in tree.children)
            {
                TreeAsStringDFS(child, sb, indents + 2);
            }
        }

        public IEnumerable<T> GetMiddleKeys()
        {
            var internalNodes = new List<T>();

            GetInternalKeysDFS(internalNodes, this);

            return internalNodes.AsEnumerable();
        }

        private void GetInternalKeysDFS(List<T> list, Tree<T> tree)
        {
            if (tree.Parent != null && tree.Children.Any())
            {
                list.Add(tree.Key);
            }
            foreach (var child in tree.Children)
            {
                GetInternalKeysDFS(list, child);
            }
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var leaves = new List<Tree<T>>();

            GetLeafKeysDFS(leaves, this);

            return leaves.Select(t => t.Key);
        }

        private void GetLeafKeysDFS(List<Tree<T>> list, Tree<T> tree) 
        {
            if (!tree.Children.Any())
            {
                list.Add(tree);
            }
            foreach (var child in tree.Children)
            {
                GetLeafKeysDFS(list, child);
            }
        }

        public T GetDeepestKey()
        {
            var deepestNode = FindDeepestNode();

            return deepestNode.Key;
        }

        private Tree<T> FindDeepestNode()
        {
            var leaves = new List<Tree<T>>();
            this.GetLeafKeysDFS(leaves, this);

            var maxDepth = 0;
            var maxNode = this;

            foreach (var leaf in leaves)
            {
                var depth = this.GetNodeDepth(leaf);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    maxNode = leaf;
                }
            }

            return maxNode;
        }

        private int GetNodeDepth(Tree<T> node)
        {
            var depth = 0;

            while (node != null)
            {
                node = node.Parent;
                depth++;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var output = new List<T>();
            var deepestNode = this.FindDeepestNode();

            while (deepestNode != null)
            {
                output.Add(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            output.Reverse();

            return output;
        }
    }
}
