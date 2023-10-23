using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        private List<string> collection;

        public AddCollection(List<string> collection)
        {
            this.Collection = collection;
        }

        public List<string> Collection { get; set; }

        public void Add(string item)
        {
            this.Collection.Add(item);
            Console.Write(this.Collection.Count-1+" ");
        }
    }
}
