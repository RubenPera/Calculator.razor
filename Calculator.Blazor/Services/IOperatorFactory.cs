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
        private IList<IOperatorService> _operatorServices { get; }

        public OperatorFactory(IList<IOperatorService> operatorServices)
        {
            _operatorServices = operatorServices;
        }

        public IOperatorService GetOperator(OperatorType operatorType)
        {
            return _operatorServices.FirstOrDefault(x => GetOperatorType(x) == operatorType);
        }

        private OperatorType GetOperatorType(IOperatorService operatorService)
        {
            var attribute = Attribute.GetCustomAttribute(operatorService.GetType(), typeof(OperatorAttribute)) as OperatorAttribute;

            return attribute?.OperatorType ?? OperatorType.None;
        }
    }
}