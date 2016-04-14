using System.ComponentModel;

namespace Calculator.Models
{
    public enum CalculatorOperatorEnum
    {
        [Description("+")]
        Addition = 1,

        [Description("-")]
        Subtraction = 2,

        [Description("*")]
        Multiplication = 3,

        [Description("/")]
        Division = 4
    }
}