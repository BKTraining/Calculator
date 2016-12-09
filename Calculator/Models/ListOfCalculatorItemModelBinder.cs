using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Models
{
    public class ListOfCalculatorItemModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext", "controllerContext is null.");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext", "bindingContext is null.");

            var request = controllerContext.HttpContext.Request;

            string textToParse = request.Form["AllCalculation"];

            ListOfCalculatorItem result = TryParse(textToParse);

            return result;
            //new CalculatorItems { FirstValue = 1, SecondValue = 3, Operator = CalculatorOperatorEnum.Multiplication };
        }

        ListOfCalculatorItem TryParse(string textToParse)
        {
            ListOfCalculatorItem result = null;
            string[] listOfCalc = textToParse.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (listOfCalc.Count()>0)
            {
                result = new ListOfCalculatorItem();
                foreach(string item in listOfCalc)
                {
                    CalculatorItems calcItem = new CalculatorItems();
                    // find operator to use
                    int itemPos = 0;
                    int itemLenght = item.Length;
                    if (item.IndexOf("+")>0)
                    {
                        itemPos = item.IndexOf("+");
                        calcItem.Operator = CalculatorOperatorEnum.Addition;
                    }
                    if (item.IndexOf("-") > 0)
                    {
                        itemPos = item.IndexOf("-");
                        calcItem.Operator = CalculatorOperatorEnum.Subtraction;
                    }
                    if (item.IndexOf("/") > 0)
                    {
                        itemPos = item.IndexOf("/");
                        calcItem.Operator = CalculatorOperatorEnum.Division;
                    }
                    if (item.IndexOf("*") > 0)
                    {
                        itemPos = item.IndexOf("*");
                        calcItem.Operator = CalculatorOperatorEnum.Multiplication;
                    }
                    if (calcItem.Operator != null)
                    {
                        calcItem.FirstValue = Double.Parse(item.Substring(0, itemPos));
                        calcItem.SecondValue = Double.Parse(item.Substring(itemPos+1, itemLenght - itemPos-1));
                    }
                    result.Add(calcItem);
                }
                return result;
            }
            return null;
        }

        private Nullable<T> TryGet<T>(ModelBindingContext bindingContext, string key) where T : struct
        {
            if (String.IsNullOrEmpty(key))
                return null;

            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "." + key);
            if (valueResult == null && bindingContext.FallbackToEmptyPrefix == true)
                valueResult = bindingContext.ValueProvider.GetValue(key);

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueResult);

            if (valueResult == null)
                return null;

            try
            {
                return (Nullable<T>)valueResult.ConvertTo(typeof(T));
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex);
                return null;
            }
        }
    }
}