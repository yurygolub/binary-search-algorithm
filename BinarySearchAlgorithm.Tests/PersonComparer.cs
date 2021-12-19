using System;
using System.Collections.Generic;

namespace BinarySearchAlgorithm.Tests
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x is null)
            {
                throw new ArgumentException($"{nameof(x)} can not be null.");
            }

            if (y is null)
            {
                throw new ArgumentException($"{nameof(y)} can not be null.");
            }

            return string.Compare(x.Name, y.Name, StringComparison.InvariantCulture);
        }
    }
}
