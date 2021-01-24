using Xunit;
using Moq;
using Calculator.Services;
using Calculator.Types;
using System.Collections.Generic;
using System;

namespace Calculator.Tests.Services
{
    public class OperatorFactoryTests
    {
        [Theory]
        [InlineData(typeof(AddOperatorService), OperatorType.Add)]
        [InlineData(typeof(SubtractOperatorService), OperatorType.Subtract)]
        public void Can_GetOperator(Type expectedType, OperatorType operatorType)
        {
            // Arrange
            var service = new OperatorFactory(new List<IOperatorService>{
                new AddOperatorService(),
                new SubtractOperatorService(),
            });

            // Act
            var operatorService = service.GetOperator(operatorType);

            // Assert
            Assert.IsType(expectedType, operatorService);
        }
    }
}