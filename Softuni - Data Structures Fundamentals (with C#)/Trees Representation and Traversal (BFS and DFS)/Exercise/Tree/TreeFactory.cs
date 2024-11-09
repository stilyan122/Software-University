namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public TreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            if (input.Length > 0)
            {
                var rootInput = input[0].Split(' ');

                var rootKey = int.Parse(rootInput[0]);
                var rootChildKey = int.Parse(rootInput[1]);

                var rootNode = CreateNodeByKey(rootKey);
                var childNode = CreateNodeByKey(rootChildKey);

                this.nodesByKey.Add(rootKey, rootNode);
                this.nodesByKey.Add(rootChildKey, childNode);

                AddEdge(rootKey, rootChildKey);

                for (int i = 1; i < input.Length; i++)
                {
                    var kvp = input[i];
                    var splitInput = kvp.Split(' ');

                    var parent = int.Parse(splitInput[0]);
                    var child = int.Parse(splitInput[1]);

                    var parentNode = this.nodesByKey.FirstOrDefault(p => p.Key == parent).Value;
                    var childTree = new IntegerTree(child, null);

                    parentNode.AddChild(childTree);
                    childTree.AddParent(parentNode);

                    this.nodesByKey.Add(child, childTree);
                }
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            return new IntegerTree(key, null);
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.nodesByKey.First(node => node.Key == parent).Value;
            var childNode = this.nodesByKey.First(node => node.Key == child).Value;

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public IntegerTree GetRoot()
        {
            return nodesByKey.Values.First();
        }
    }
}
