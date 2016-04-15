using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class CalculatorItems
    {
        [Required]
        public double Item1 { get; set; }

        [Required]
        public double Item2 { get; set; }

        public CalculatorOperatorEnum Operator { get; set; }

        public double? Result { get; set; }
    }
}