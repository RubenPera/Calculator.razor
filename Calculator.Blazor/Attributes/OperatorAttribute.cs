using System;

namespace Calculator.Attributes
{
    public class OperatorAttribute : Attribute
    {
        public Type OperatorServiceType { get; set; }

        public OperatorAttribute(Type operatorServiceType)
        {
            OperatorServiceType = operatorServiceType;
        }
    }
}