using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString(List<string> list)
        {
            Random rnd = new Random();
            int count = list.Count;
            int index = rnd.Next(0, count);
            string item = list[index];
            list.RemoveAt(index);
            return item;
        }
    }
}
