namespace Problem02.Stack
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node(T val, Node<T> next)
        {
            this.Value = val;
            this.Next = next;
        }
    }
}