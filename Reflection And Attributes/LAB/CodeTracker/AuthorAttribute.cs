using System;

namespace AuthorProblem
{
    public class AuthorAttribute : Attribute
    {
        public string Name { get; set; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }
}
