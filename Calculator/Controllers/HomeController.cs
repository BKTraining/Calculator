using Calculator.Models;
using log4net;
using log4net.Config;
using Calculator.Core;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Calculator.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            aLogger.Info("display HomeController/Index view");

            return View();
        }

        [HttpPost]
        public ActionResult Index(CalculatorItems model)
        {
            model.Result = null;

            if (ModelState.IsValid)
            {
                aLogger.Info(string.Format("Requested operation is {0} {1} {2}", model.FirstValue, model.Operator, model.SecondValue));
                model = CalculatorCore.calculate(model);
                if (model.Message != string.Empty)
                {
                    ModelState.AddModelError("Message", model.Message);
                }
                if (model.Result != null)
                {
                    aLogger.Info("Result is " + model.Result);
                }
            }
            else
            {
                aLogger.Info("ModelState is invalid");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult MatrixCalculator(CalculatorItems model)
        {
            model.Result = null;

            return View(model);
        }

        [HttpPost]
        public ActionResult MultiLineCalculator(ListOfCalculatorItem toCalculateLine)
        {
            ListOfCalculatorItem result = new ListOfCalculatorItem();
            
            CalculatorItems temp;
            foreach (CalculatorItems c in toCalculateLine)
            {
                temp = CalculatorCore.calculate(c);
                if (temp != null) result.Add(temp);
            }

            return View(result);
        }
        

        public ActionResult MultiLineCalculator()
        {
            aLogger.Info("display HomeController/MultiLineCalculator view");

            return View();
        }

        [HttpGet]
        public ActionResult CalcWithApi()
        {
            aLogger.Info("display HomeController/CalcWithApi view");

            return View();
        }

        public ActionResult MatrixCalculator()
        {
            aLogger.Info("display HomeController/MatrixCalculator view");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}