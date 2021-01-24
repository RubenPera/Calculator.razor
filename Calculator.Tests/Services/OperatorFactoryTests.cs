using Xunit;
using Moq;
using Calculator.Services;
using Calculator.Types;
using System.Collections.Generic;

namespace Calculator.Tests.Services
{
    public class OperatorFactoryTests
    {
        [Fact]
        public void Can_GetOperator()
        {
            // Arrange
            var service = new OperatorFactory(new List<IOperatorService>{
                new AddOperatorService()
            });

            // Act
            var operatorService = service.GetOperator(OperatorType.Add);

            // Assert
            Assert.IsType<AddOperatorService>(operatorService);
        }
    }
}