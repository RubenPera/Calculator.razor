using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Attributes;
using Calculator.Types;

namespace Calculator.Services
{
    public interface IOperatorFactory
    {
        IOperatorService GetOperator(OperatorType operatorType);
    }

    public class OperatorFactory : IOperatorFactory
    {
        private List<IOperatorService> operatorServices { get; }

        public OperatorFactory(List<IOperatorService> operatorServices)
        {
            this.operatorServices = operatorServices;
        }

        public IOperatorService GetOperator(OperatorType operatorType)
        {
            return operatorServices.FirstOrDefault(x => GetOperatorType(x) == operatorType);
        }

        public OperatorType GetOperatorType(IOperatorService operatorService)
        {
            var attribute = Attribute.GetCustomAttribute(operatorService.GetType(), typeof(OperatorAttribute)) as OperatorAttribute;

            return attribute?.OperatorType ?? OperatorType.None;
        }
    }
}