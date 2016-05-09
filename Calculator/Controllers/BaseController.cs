using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;
using System.Web.Mvc;
using System.Globalization;

namespace Calculator.Controllers
{
    public class BaseController : Controller
    {
        protected ILog aLogger = LogManager.GetLogger("Calculator");

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = string.Format(CultureInfo.InvariantCulture,
                                        "OnActionExecuted : {0} {1}.{2}  {3}",
                                        HttpContext.Request.HttpMethod,
                                        filterContext.Controller.GetType().Name,
                                        filterContext.ActionDescriptor.ActionName.Trim(),
                                        HttpContext.Request.Form);
            aLogger.Debug(message);

            // Logs error no matter what
            if (filterContext.Exception != null)
            {
                message = string.Format(CultureInfo.InvariantCulture,
                                            "Exception occured {0}.{1} => {2}",
                                            filterContext.Controller.GetType().Name,
                                            filterContext.ActionDescriptor.ActionName.Trim(),
                                            filterContext.Exception.Message);
                aLogger.Error(message);
            }

            base.OnActionExecuted(filterContext);
        }

    }
}