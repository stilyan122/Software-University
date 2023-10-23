using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAdd,IRemove
    {
        private List<string> collection;

        public AddRemoveCollection(List<string> collection)
        {
            this.Collection = collection;
        }

        public List<string> Collection { get; set; }

        public void Add(string item)
        {
            this.Collection.Insert(0, item);
            Console.Write(this.Collection.IndexOf(item)+" ");
        }

        public void Remove()
        {
            Console.Write(this.Collection[this.Collection.Count-1]+" ");
            this.Collection.RemoveAt(this.Collection.Count - 1);
        }
    }
}
