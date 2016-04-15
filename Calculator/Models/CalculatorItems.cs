namespace Calculator.Models
{
    public class CalculatorItems
    {
        public double Item1 { get; set; }
        public double Item2 { get; set; }
        public CalculatorOperatorEnum Operator { get; set; }
        public string Result { get; set; }

        public double calculate()
        {
            double result;
            switch (Operator)
            {
                case CalculatorOperatorEnum.Addition:
                    result = Item1 + Item2;
                    break;
                case CalculatorOperatorEnum.Subtraction:
                    result = Item1 - Item2;
                    break;
                case CalculatorOperatorEnum.Multiplication:
                    result = Item1 * Item2;
                    break;
                case CalculatorOperatorEnum.Division:
                    result = Item1 / Item2;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }
    }
}