using Calculator.Models;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new CalculatorItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalculatorItems model)
        {
         //   model.Result = model.Item1 + model.Item2;
            return View(model);
        }
    }
}