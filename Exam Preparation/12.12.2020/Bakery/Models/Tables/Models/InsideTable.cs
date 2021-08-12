using System;

namespace Bakery.Models.Tables.Models
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, 2.50M)
        {
        }
    }
}
