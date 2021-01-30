using Calculator.Attributes;
using Calculator.Services;
using Xunit;

namespace Calculator.Tests.Attributes
{
    public class OperatorAttributeTests
    {
        [Fact]
        public void OperatorAttribute_Constructor_Checks_IOperatorService()
        {
            Assert.Null(new OperatorAttribute(typeof(OperatorFactory)).OperatorServiceType);
            Assert.NotNull(new OperatorAttribute(typeof(AddOperatorService)).OperatorServiceType);
        }
    }
}