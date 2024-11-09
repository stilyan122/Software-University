using System.Collections.Generic;

namespace Problem04.BalancedParentheses
{
    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var items = new Stack<char>();

            foreach (char parenthesis in parentheses)
            {
                if (IsOpening(parenthesis))
                {
                    items.Push(parenthesis);
                }
                else
                {
                    if (items.Count == 0 || !AreMatching(items.Pop(), parenthesis))
                    {
                        return false;
                    }
                }
            }

            return items.Count == 0;
        }

        private bool IsOpening(char parenthesis)
            => parenthesis == '(' || parenthesis == '[' || parenthesis == '{';

        private bool AreMatching(char parenthesis1, char parenthesis2)
            => (parenthesis1 == '(' && parenthesis2 == ')') ||
               (parenthesis1 == '[' && parenthesis2 == ']') ||
               (parenthesis1 == '{' && parenthesis2 == '}');
    }
}
