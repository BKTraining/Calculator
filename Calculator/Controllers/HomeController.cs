using Calculator.Models;
using log4net;
using log4net.Config;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private ILog aLogger = LogManager.GetLogger("Calculator");

        [HttpGet]
        public ActionResult Index()
        {
            aLogger.Info("HomeController get Index");

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
                            aLogger.Info("Division by zero is not allowed.");
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
                
                aLogger.Info(string.Format("Requested operation is {0} {1} {2}", model.Item1, model.Operator, model.Item2));
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


    }
}