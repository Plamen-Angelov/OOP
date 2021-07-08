using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddable, IRemoveble
    {
        private readonly List<string> collection = new List<string>();

        public int Add(string element)
        {
            collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string removedItem = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count-1);
            return removedItem;
        }
    }
}
