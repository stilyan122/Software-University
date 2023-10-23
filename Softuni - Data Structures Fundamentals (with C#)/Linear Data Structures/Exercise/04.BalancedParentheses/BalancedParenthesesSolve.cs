namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0)
            {
                return false;
            }
            Stack<char> stack = new Stack<char>(parentheses.Length/2);
            foreach (var character in parentheses)
            {
                char expected = default;
                switch (character)
                {
                    case ')':
                        expected = '(';
                    break;

                    case ']':
                        expected = '[';
                        break;

                    case '}':
                        expected = '{';
                        break;
                    default:
                        stack.Push(character);
                        break;
                }
                if (expected == default)
                {
                    continue;
                }
                if (expected != stack.Pop())
                {
                    return false;   
                }
            }
            return stack.Count==0;
        }
    }
}
