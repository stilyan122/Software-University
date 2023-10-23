namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {

        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            List<List<int>> paths = new List<List<int>>();
            List<List<int>> leafPaths =
                this.TraverseForLeafRootPaths(new List<List<int>>());
            foreach (var leafPath in leafPaths)
            {
                if (leafPath.Sum() == sum)
                {
                    paths.Add(leafPath);
                }
            }
            return paths;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            List<Tree<int>> result = new List<Tree<int>>();
            FindSubtreesWithSum(this, sum, result);
            return result;
        }

        private List<List<int>> TraverseForLeafRootPaths(List<List<int>> path)
        {
            List<Tree<int>> leaves = this.TraverseForLeaves(this,
                new List<Tree<int>>());
            foreach (var leaf in leaves)
            {
                List<int> leafPath = new List<int>();
                leafPath.Add(leaf.Key);

                Tree<int> parent = leaf.Parent;
                while (parent!=null)
                {
                    leafPath.Add(parent.Key);
                    parent = parent.Parent;
                }
                leafPath.Reverse();
                path.Add(leafPath);
            }
            return path;
        }
        private List<Tree<int>> TraverseForLeaves(Tree<int> tree
            ,List<Tree<int>> list)
        {
            if (tree.Children.Count == 0)
                list.Add(tree);
            foreach (var item in tree.Children)
            {
                TraverseForLeaves(item, list);
            }
            return list;
        }


        private int FindSubtreesWithSum(Tree<int> node,
            int targetSum, List<Tree<int>> result)
        {
            if (node == null)
                return 0;

            int currentSum = Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                currentSum += FindSubtreesWithSum(child, targetSum, result);
            }

            if (currentSum == targetSum)
            {
                result.Add(node);
            }

            return currentSum;
        }
    }
}
