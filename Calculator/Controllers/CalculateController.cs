using Calculator.Core;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc.Html;

namespace Calculator.WebServices
{
    [RoutePrefix("api/calculator")]
    public class CalculateController : ApiController
    {
        [Route("calculate")]
        public HttpResponseMessage PostCalcule(CalculatorItems item)
        {
            item = CalculatorCore.calculate(item);
            var response = Request.CreateResponse<CalculatorItems>(HttpStatusCode.Created, item);

            return response;
        }
    }
}