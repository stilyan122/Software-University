namespace _01.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T element)
        {
            if (root == null)
            {
                root = new TreeNode<T>(element);
            }
            else
            {
                this.InsertIntoNode(root, element);
            }
        }

        private void InsertIntoNode(TreeNode<T> node, T element)
        {
            T promoted;
            TreeNode<T> newRight;
            InsertAndSplit(node, element, out promoted, out newRight);

            if (newRight != null) 
            {
                var newRoot = new TreeNode<T>(promoted);
                newRoot.LeftChild = this.root;
                newRoot.MiddleChild = newRight;
                this.root = newRoot;
            }
        }

        private void InsertAndSplit(TreeNode<T> node, T key, out T promoted, out TreeNode<T> newRight)
        {
            promoted = default(T);
            newRight = null;

            if (key.CompareTo(node.LeftKey) == 0 || (node.IsThreeNode() && key.CompareTo(node.RightKey) == 0))
            {
                return;
            }

            if (node.IsLeaf())
            {
                if (node.IsTwoNode())
                {
                    if (key.CompareTo(node.LeftKey) < 0)
                    {
                        node.RightKey = node.LeftKey;
                        node.LeftKey = key;
                    }
                    else
                    {
                        node.RightKey = key;
                    }
                    return;
                }
                else
                {
                    T a = node.LeftKey;
                    T b = node.RightKey;
                    T c = key;

                    T first = a, second = b, third = c;
                    if (first.CompareTo(second) > 0) { var t = first; first = second; second = t; }
                    if (second.CompareTo(third) > 0) { var t = second; second = third; third = t; }
                    if (first.CompareTo(second) > 0) { var t = first; first = second; second = t; }

                    promoted = second;

                    node.LeftKey = first;
                    node.RightKey = default(T);
                    node.LeftChild = null;
                    node.MiddleChild = null;
                    node.RightChild = null;

                    newRight = new TreeNode<T>(third);
                    return;
                }
            }
            else
            {
                if (node.IsTwoNode())
                {
                    if (key.CompareTo(node.LeftKey) < 0)
                    {
                        InsertAndSplit(node.LeftChild, key, out promoted, out newRight);
                        if (newRight != null)
                        {
                            node.RightKey = node.LeftKey;
                            node.LeftKey = promoted;

                            node.RightChild = node.MiddleChild;
                            node.MiddleChild = newRight;

                            promoted = default(T);
                            newRight = null;
                        }
                    }
                    else
                    {
                        InsertAndSplit(node.MiddleChild, key, out promoted, out newRight);
                        if (newRight != null)
                        {
                            node.RightKey = promoted;
                            node.RightChild = newRight;

                            promoted = default(T);
                            newRight = null;
                        }
                    }
                    return;
                }
                else
                {
                    int cmpL = key.CompareTo(node.LeftKey);
                    int cmpR = key.CompareTo(node.RightKey);

                    if (cmpL < 0)
                    {
                        // go Left
                        InsertAndSplit(node.LeftChild, key, out promoted, out newRight);
                        if (newRight != null)
                        {
                            T A = node.LeftKey;
                            T B = node.RightKey;
                            TreeNode<T> L = node.LeftChild;
                            TreeNode<T> M = node.MiddleChild;
                            TreeNode<T> R = node.RightChild;

                            node.LeftKey = promoted;
                            node.RightKey = default(T);
                            node.LeftChild = L;        
                            node.MiddleChild = newRight; 
                            node.RightChild = null;

                            TreeNode<T> rightNode = new TreeNode<T>(B);
                            rightNode.LeftChild = M;
                            rightNode.MiddleChild = R;

                            promoted = A;      
                            newRight = rightNode;
                        }
                    }
                    else if (cmpR > 0)
                    {
                        InsertAndSplit(node.RightChild, key, out promoted, out newRight);
                        if (newRight != null)
                        {
                            T A = node.LeftKey;
                            T B = node.RightKey;
                            TreeNode<T> L = node.LeftChild;
                            TreeNode<T> M = node.MiddleChild;
                            TreeNode<T> R = node.RightChild; 

                            node.LeftKey = A;
                            node.RightKey = default(T);
                            node.LeftChild = L;
                            node.MiddleChild = M;
                            node.RightChild = null;

                            TreeNode<T> rightNode = new TreeNode<T>(promoted);
                            rightNode.LeftChild = R;      
                            rightNode.MiddleChild = newRight;

                            promoted = B;      
                            newRight = rightNode;
                        }
                    }
                    else
                    {
                        InsertAndSplit(node.MiddleChild, key, out promoted, out newRight);
                        if (newRight != null)
                        {
                            T A = node.LeftKey;
                            T B = node.RightKey;
                            TreeNode<T> L = node.LeftChild;
                            TreeNode<T> M = node.MiddleChild;
                            TreeNode<T> R = node.RightChild;
                            TreeNode<T> pr = newRight;       

                            node.LeftKey = A;
                            node.RightKey = default(T);
                            node.LeftChild = L;
                            node.MiddleChild = M;
                            node.RightChild = null;

                            TreeNode<T> rightNode = new TreeNode<T>(B);
                            rightNode.LeftChild = pr;
                            rightNode.MiddleChild = R;

                            T mid = promoted;
                            promoted = mid;
                            newRight = rightNode;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
