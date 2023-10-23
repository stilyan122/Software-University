using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> collection;
        public Lake(List<int> list)
        {
            this.collection = list;
        }
        public IEnumerator<int> GetEnumerator()
        {
            foreach (int stone in collection)
            {
                yield return stone;
            }
        }
        public void Print()
        {
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (i%2==0)
                {
                    evens.Add(collection[i]);
                }
                else
                {
                    odds.Add(collection[i]);
                }
            }
            odds.Reverse();
            List<int> output = new List<int>();
            output.AddRange(evens);
            output.AddRange(odds);
            Console.WriteLine(string.Join(", ",output));
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
