using System.Collections.Generic;

namespace Calculator.models
{
    public class Calculation
    {
        public string Name { get; set; }

        public List<CalculationEntry> Entries { get; set; }
    }
}