using System;
using System.Collections.Generic;

namespace Calculator.Models
{
    public class Calculation : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CalculationEntry> Entries { get; set; }
    }
}