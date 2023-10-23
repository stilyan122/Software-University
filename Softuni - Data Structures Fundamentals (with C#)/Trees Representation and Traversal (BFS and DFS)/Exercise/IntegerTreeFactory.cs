namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var item in input)
            {
                int parentValue = int.Parse(item.Split(' ')[0]);
                int childValue = int.Parse(item.Split(' ')[1]);
                this.AddEdge(parentValue, childValue);
            }
            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            IntegerTree tree = new IntegerTree(key);
            if (!nodesByKey.ContainsKey(key))
                nodesByKey.Add(key, tree);
            else
                tree = nodesByKey[key];
            return tree;
        }

        public void AddEdge(int parent, int child)
        {
            IntegerTree childTree = this.CreateNodeByKey(child);
            IntegerTree parentTree = this.CreateNodeByKey(parent);

            childTree.AddParent(parentTree);
            parentTree.AddChild(childTree);
        }

        public IntegerTree GetRoot()
        {
            List<IntegerTree> trees = this.nodesByKey.Values.ToList();
            foreach (var tree in trees)
            {
                if (tree.Parent is null)
                {
                    return tree;
                }
            }
            return null;
        }
    }
}
