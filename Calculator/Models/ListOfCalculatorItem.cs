using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class ListOfCalculatorItem : List<CalculatorItems>
    {
        public string Message;
    }
}