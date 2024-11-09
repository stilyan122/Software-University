namespace Tree
{
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var deepest = new List<Tree<int>>();
            var result = new List<List<int>>();

            this.GetLeafKeysDFS(deepest, this);

            foreach (var leaf in deepest)
            {
                var currentSum = 0;
                var copy = leaf;
                var elements = new List<int>();

                while (copy != null)
                {
                    currentSum += copy.Key;
                    elements.Add(copy.Key);

                    if (currentSum > sum)
                    {
                        elements.Clear();
                        break;
                    }
                    copy = copy.Parent;
                }

                if (elements.Count != 0 && currentSum == sum)
                {
                    elements.Reverse();
                    result.Add(elements);
                }
            }

            return result;
        }

        private void GetLeafKeysDFS(List<Tree<int>> list, Tree<int> tree)
        {
            if (tree.Children.Count == 0)
            {
                list.Add(tree);
            }
            foreach (var child in tree.Children)
            {
                GetLeafKeysDFS(list, child);
            }
        }

       
        
        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var root = this;

            var rootsForPaths = new List<Tree<int>>();
            FindSubtreesWithSum(root, rootsForPaths, sum);

            return rootsForPaths;
        }

        private void FindSubtreesWithSum(Tree<int> root, List<Tree<int>> paths, int givenSum)
        {
            var sum = SumWithDFS(root);
            if (sum == givenSum)
            {
                paths.Add(root);
            }

            foreach (var child in root.Children)
            {
                FindSubtreesWithSum(child, paths, givenSum);
            }
        }

        private int SumWithDFS(Tree<int> tree)
        {
            if (tree == null)
            {
                return 0;
            }

            var sum = tree.Key;

            foreach (var child in tree.Children)
            {
               sum += SumWithDFS(child);
            }

            return sum;
        }
    
    }
}
