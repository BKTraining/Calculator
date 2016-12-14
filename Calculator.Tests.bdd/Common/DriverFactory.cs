using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Calculator.Tests.BddTest
{
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Firefox
    }

    public class DriverFactory
    {
        private static readonly FirefoxProfile FirefoxProfile = CreateFirefoxProfile();

        private static FirefoxProfile CreateFirefoxProfile()
        {
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://localhost");
            return firefoxProfile;
        }

        public IWebDriver Create()
        {
            IWebDriver driver;
            DriverToUse driverToUse = (DriverToUse)Enum.Parse(typeof(DriverToUse), ConfigurationManager.AppSettings["DriverToUse"]);

            string AppLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//IEDriverServer.exe";

            switch (driverToUse)
            {
                case DriverToUse.InternetExplorer:
                    AppLocation = @"C:\Drivers\IEDriverServer.exe";
                    //    System.Environment.SetEnvironmentVariable("webdriver.ie.driv‌​er", AppLocation + "//IEDriverServer.exe");

                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", AppLocation);
                    //     driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, new InternetExplorerOptions(), TimeSpan.FromMinutes(5));
                    driver = new InternetExplorerDriver();
                    break;
                case DriverToUse.Firefox:
                    var firefoxProfile = FirefoxProfile;
                    firefoxProfile.Clean();
                    AppLocation = @"C:\Drivers\geckodriver.exe";
                    System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", AppLocation);
                    firefoxProfile.Port = new Random().Next(7000, 7500);
                    //driver = new FirefoxDriver(firefoxProfile);
                    driver = new FirefoxDriver(new FirefoxOptions());
                    driver.Manage().Window.Maximize();
                    break;
                case DriverToUse.Chrome:
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();

            timeouts.ImplicitlyWait(TimeSpan.FromSeconds((double)Convert.ChangeType(ConfigurationManager.AppSettings["ImplicitlyWait"], typeof(double))));
            timeouts.SetPageLoadTimeout(TimeSpan.FromSeconds((double)Convert.ChangeType(ConfigurationManager.AppSettings["PageLoadTimeout"], typeof(double))));

            // Suppress the onbeforeunload event first. This prevents the application hanging on a dialog box that does not close.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.onbeforeunload = function(e){};");
            return driver;
        }
    }
}

