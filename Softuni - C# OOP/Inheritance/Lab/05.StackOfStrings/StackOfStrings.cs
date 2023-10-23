using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddRange(Stack<string> add)
        {
            this.AddRange(add);
        }
    }
}
