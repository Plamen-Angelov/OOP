using System;

namespace Bakery.Models.Tables.Models
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, 3.50M)
        {
        }
    }
}
