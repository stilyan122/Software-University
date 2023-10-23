using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IAdd, IRemove
    {
        private List<string> collection;
        private int used;
        public MyList(List<string> collection)
        {
            this.Collection = collection;
        }
        public List<string> Collection{ get; set; }
        public int Used
        {
            get
            {
                return this.Collection.Count;
            }
        }
        public void Add(string item)
        {
            this.Collection.Insert(0, item);
            Console.Write(0+" ");
        }

        public void Remove()
        {
            Console.Write(this.Collection[0]+" ");
            this.Collection.RemoveAt(0);
        }
    }
}
