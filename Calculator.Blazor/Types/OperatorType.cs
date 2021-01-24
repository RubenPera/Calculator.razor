using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Types
{
    public enum OperatorType
    {
        None = 0,

        [Display(Name = "+")]
        Add = 1,
    }
}