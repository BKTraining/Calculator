using log4net;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Web;


namespace Calculator.Core
{
    public class LoggerHttpModule : IHttpModule
    {
        protected ILog aLogger = LogManager.GetLogger("Calculator");

        public void Init(HttpApplication httpApp)
        {
            httpApp.BeginRequest += OnBeginRequest;
            httpApp.EndRequest += OnEndRequest;
            httpApp.PreSendRequestHeaders += OnHeaderSent;
        }

        public void OnHeaderSent(object sender, EventArgs e)
        {
            var httpApp = (HttpApplication)sender;
            httpApp.Context.Items["HeadersSent"] = true;
        }

        // Record the time of the begin request event.
        public void OnBeginRequest(Object sender, EventArgs e)
        {
            var httpApp = (HttpApplication)sender;
            if (httpApp.Request.Path.StartsWith("/media/")) return;
            var timer = new Stopwatch();
            httpApp.Context.Items["Timer"] = timer;
            httpApp.Context.Items["HeadersSent"] = false;
            timer.Start();

            var message = string.Format(CultureInfo.InvariantCulture,
                            "Begin request : {0} {1} --{2}--  {3}",
                            HttpContext.Current.Request.HttpMethod,
                            HttpContext.Current.Request.Path,
                            HttpContext.Current.Request.QueryString,
                            HttpContext.Current.Request.Form);

            aLogger.Debug(message);
        }

        public void OnEndRequest(Object sender, EventArgs e)
        {
            var httpApp = (HttpApplication)sender;
            var timer = (Stopwatch)httpApp.Context.Items["Timer"];

            if (timer != null)
            {
                timer.Stop();
                if (!(bool)httpApp.Context.Items["HeadersSent"])
                {
                    httpApp.Context.Response.AppendHeader("ProcessTime",
                                                          ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000 +
                                                          " ms.");
                }
            }

            httpApp.Context.Items.Remove("Timer");
            httpApp.Context.Items.Remove("HeadersSent");

            var message = string.Format(CultureInfo.InvariantCulture,
                          "End request : {0} {1} --{2}--  {3} ProcessTime : {4}",
                          HttpContext.Current.Request.HttpMethod,
                          HttpContext.Current.Request.Path,
                          HttpContext.Current.Request.QueryString,
                          HttpContext.Current.Request.Form,
                          httpApp.Context.Response.Headers["ProcessTime"]);
            aLogger.Debug(message);
        }

        public void Dispose() { /* Not needed */ }

    }
}