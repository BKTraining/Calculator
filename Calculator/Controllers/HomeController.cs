﻿using Calculator.Models;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalculatorItems model)
        {
            model.Result = null;

            if (ModelState.IsValid)
            {
                switch (model.Operator)
                {
                    case CalculatorOperatorEnum.Addition:
                        model.Result = model.Item1 + model.Item2;
                        break;

                    case CalculatorOperatorEnum.Division:
                        if (model.Item2 == 0)
                        {
                            ModelState.AddModelError("Item2", "Division by zero is not allowed");
                            break;
                        }
                        model.Result = model.Item1 / model.Item2;
                        break;

                    case CalculatorOperatorEnum.Multiplication:
                        model.Result = model.Item1 * model.Item2;
                        break;

                    case CalculatorOperatorEnum.Subtraction:
                        model.Result = model.Item1 - model.Item2;
                        break;
                }
            }

            return View(model);
        }


    }
}