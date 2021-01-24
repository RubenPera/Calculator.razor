using System.ComponentModel.DataAnnotations;
using Calculator.Attributes;
using Calculator.Services;

namespace Calculator.Types
{
    public enum OperatorType
    {
        [Operator(typeof(AddOperatorService))]
        [Display(Name = "+")]
        Add = 1,

        [Operator(typeof(SubtractOperatorService))]
        [Display(Name = "-")]
        Subtract = 2,
    }
}