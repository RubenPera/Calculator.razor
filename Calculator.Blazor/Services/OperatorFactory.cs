using System.Collections.Generic;
using System.Linq;
using Calculator.Attributes;
using Calculator.Extensions;
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
            var attribute = operatorType.GetAttribute<OperatorAttribute>();

            return operatorServices.FirstOrDefault(x => x.GetType() == attribute?.OperatorServiceType);
        }
    }
}