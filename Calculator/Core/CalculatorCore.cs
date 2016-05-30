using Calculator.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Core
{
    public static class CalculatorCore
    {
        private static ILog aLogger = LogManager.GetLogger("Calculator");

        public static CalculatorItems calculate(CalculatorItems model)
        {
            switch (model.Operator)
            {
                case CalculatorOperatorEnum.Addition:
                    model.Result = model.FirstValue + model.SecondValue;
                    break;

                case CalculatorOperatorEnum.Division:
                    if (model.SecondValue == 0)
                    {
                        aLogger.Info("Division by zero is not allowed.");
                        model.Message = "Division by zero is not allowed";
                        break;
                    }
                    model.Result = model.FirstValue / model.SecondValue;
                    break;

                case CalculatorOperatorEnum.Multiplication:
                    model.Result = model.FirstValue * model.SecondValue;
                    break;

                case CalculatorOperatorEnum.Subtraction:
                    model.Result = model.FirstValue - model.SecondValue;
                    break;
            }
            return model;
        }
    }
}