using Calculator.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class CalculatorItems
    {
        public Guid Id { get; set; }

        [Required]
        public double FirstValue { get; set; }

        [Required]
        public double SecondValue { get; set; }

        public CalculatorOperatorEnum? Operator { get; set; }


        public string OperatorChar
        {
            get
            {
                if (Operator != null)
                {
                    return EnumExtension.Description(Operator);
                }
                else
                {
                    return null;
                }
                   
            }
        }

        public string Message { get; set; }

        public CalculatorItems()
        {
            Id = Guid.NewGuid();
            Message = string.Empty;
        }

        public CalculatorItems(string in1, string in2, string operation)
        {
            Id = Guid.NewGuid();
            FirstValue = double.Parse(in1);
            SecondValue = double.Parse(in2);

            switch (operation.ToLower())
            {
                case "addition":
                    Operator = CalculatorOperatorEnum.Addition;
                    break;
                case "Subtraction":
                    Operator = CalculatorOperatorEnum.Subtraction;
                    break;
                case "multiplication":
                    Operator = CalculatorOperatorEnum.Multiplication;
                    break;
                case "division":
                    Operator = CalculatorOperatorEnum.Division;
                    break;
            }
        }

        public double? Result { get; set; }
    }
}