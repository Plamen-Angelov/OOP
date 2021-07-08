using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        private readonly List<string> collection = new List<string>();

        public int Add(string element)
        {
            collection.Add(element);
            return collection.Count - 1;
        }
    }
}
