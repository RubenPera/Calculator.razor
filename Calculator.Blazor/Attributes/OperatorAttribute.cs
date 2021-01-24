using System;
using Calculator.Types;

namespace Calculator.Attributes
{
    public class OperatorAttribute : Attribute
    {
        public OperatorType OperatorType { get; set; }

        public OperatorAttribute(OperatorType operatorType)
        {
            OperatorType = operatorType;
        }
    }
}