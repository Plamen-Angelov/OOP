﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables.Models
{
    public class OutsideTable : Table
    {
        private const decimal initialPricePerPerson = 3.50M;
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, initialPricePerPerson)
        {
        }
    }
}
