using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IAddable, IRemoveble
    {
        private readonly List<string> collection = new List<string>();

        public int Used { get => collection.Count; }

        public int Add(string element)
        {
            collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string removedItem = collection[0];
            collection.RemoveAt(0);
            return removedItem;
        }
    }
}
