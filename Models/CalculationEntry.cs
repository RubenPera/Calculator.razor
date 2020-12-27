using System;

namespace Calculator.Models
{
    public class CalculationEntry
    {
        public string Operator { get; set; }
        public string Value { get; set; }
        public string Result { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}