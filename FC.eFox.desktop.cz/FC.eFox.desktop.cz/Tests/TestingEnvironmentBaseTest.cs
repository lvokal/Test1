using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using FC.eFox.desktop.cz.ControlObjects;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;

namespace FC.eFox.desktop.cz.Tests
{
    /// <summary>
    /// Class contain all basic things
    /// </summary>
    [TestFixture, Category("Smoke")]
    public class TestingEnvironmentBaseTest
    {
        protected string appURL;
        private RemoteWebDriver driver;
        private string winiumFilePath = @"C:\Users\lvokal\Desktop\FC.eFox.desktop.cz\FC.eFox.desktop.cz\Files\Winium.Desktop.Driver.exe";
        private string iEFilePath = @"C:\Program Files\Internet Explorer\iexplore.exe";
        private IWebElement appWindow = null;
        private Process process;
        private DesiredCapabilities dc = new DesiredCapabilities();
        public BasePageControls basePageControls;
        public Actions actions;


        /// <summary>
        /// Method to do the basic things to start the actual tests(Open the URL and focus on application window)
        /// </summary>
        [SetUp]
        public void OpenURLOnIEBrowser()
        {
            basePageControls.adrsBar.SendKeys(appURL);
            //basePageControls.btnGo.Click();
            basePageControls.adrsBar.Submit();
            RunTheInstaller();
            GetTheApplicationWindow();
            LogOut();
        }

        /// <summary>
        /// Method to open and run the winium driver
        /// </summary>
        [OneTimeSetUp]
        public void RunTheDriver()
        {
            StartDriver();
            GetURL();
            basePageControls = new BasePageControls(driver);
            actions = new Actions(driver);
        }

        /// <summary>
        /// Method to get and focus on shopFloor window
        /// </summary>
        private void GetTheApplicationWindow()
        {
            try
            {
                if (appWindow == null)
                {
                    appWindow = basePageControls.appWnd;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Application not found" + appWindow);
            }

        }

        /// <summary>
        /// Mathod to initiate a Winium driver
        /// </summary>
        private void StartDriver()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
            foreach (Process process in Process.GetProcessesByName("Winium.Desktop.Driver"))
            {
                process.Kill();
            }
            process = Process.Start(winiumFilePath);
            //dc = new DesiredCapabilities();
            dc.SetCapability("app", iEFilePath);
            driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
            //dc.SetCapability("launchDelay", 15);
            Thread.Sleep(15000);
        }

        /// <summary>
        /// Method provised to install and run the application
        /// </summary>
        private void RunTheInstaller()
        {
            try
            {
                //basePageControls.trustMngrDlgWnd;
                IWebElement trustMngrDlgWnd = basePageControls.trustMngrDlgWnd;
                if (trustMngrDlgWnd == null)
                {
                    return;
                }

                basePageControls.btnRun.Click();

            }
            catch (Exception)
            {
                Console.WriteLine("Trust manager dialogue didn't appear because you already installed this application");
            }

        }

        /// <summary>
        /// Mathod to logout from eFox system
        /// </summary>
        private void LogOut()
        {
            basePageControls.btnLogout.Click();
        }

        /// <summary>
        /// Methos to login into eFox system
        /// </summary>
        public void LogInToShopFloor()
        {
            try
            {
                //don't put the debug point here - if yes, you may loose the focus of drop down list
                IWebElement logInPopUpWindow = basePageControls.logInPopUpWindow;
                basePageControls.authenticationComboBox.Click();
                basePageControls.windowsAuthentication.Click();
                basePageControls.logOnBtn.Click();

            }
            catch (Exception)
            {
                Console.WriteLine("User already logged in - So Login window didn't appeer");
            }

        }
        public void ColumnTest()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void TestTestMenu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CC2Item.Click();
            basePageControls.LeakTestItem.Click();
        }
        public void TestTestProcess()
        {
            string sn = DBSelector.SelectSnByTreenodeId("1295");
            basePageControls.TextBox.SendKeys(sn);
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(10000);

            string result = DBSelector.SaveEventLog(sn);
            MessageBox.Show(result);
            Assert.AreEqual("False False",result);
        }
        
        public void TestTest()
        {
            TestTestMenu();
            TestTestProcess();
           
        }

        /// <summary>
        /// Gets the application URL based on the environment
        /// </summary>
        private void GetURL()
        {
            var environment = GetEnvironment();
            switch (environment)
            {
                case "test":
                    appURL = ConfigurationManager.AppSettings["testUrl"];
                    break;
                case "acc":
                    appURL = ConfigurationManager.AppSettings["accUrl"];
                    break;
                case "prod":
                    appURL = ConfigurationManager.AppSettings["prodUrl"]; ;
                    break;
                default:
                    Console.WriteLine("NO valid environment parameter was provided. Test env will be used.");
                    appURL = ConfigurationManager.AppSettings["testUrl"];
                    break;

            }

        }

        /// <summary>
        /// Gets the proper environment
        /// </summary>
        /// <returns></returns>
        private string GetEnvironment()
        {
            var environment = TestContext.Parameters.Get("environment", "test");
            return environment;
        }

        /// <summary>
        /// If the test failed, take a screenshot.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            string testResult = GetTestResult();
            string testName = GetTestName();

            if (testResult.Contains("Failed"))
            {
                driver.TakeScreenshot(testName);
            }
        }

        /// <summary>
        /// Gets actual test result and returns it as a string
        /// </summary>
        /// <returns></returns>
        public string GetTestResult()
        {
            string testResult = TestContext.CurrentContext.Result.Outcome.ToString();
            return testResult;
        }

        /// <summary>
        /// Gets name of actual test and returns it as a string
        /// </summary>
        /// <returns></returns>
        public string GetTestName()
        {
            string testName = TestContext.CurrentContext.Test.MethodName.ToString();
            return testName;
        }

        /// <summary>
        /// Close all instances(webdriver, winium, appWindow)
        /// </summary>
        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {

            if (appWindow != null)
            {
                try
                {
                    TimeSpan.FromSeconds(10);
                    //close the application window
                    //driver.FindElement(By.Id("Close")).Click();
                }
                finally { appWindow = null; }
            }
            if (driver != null)
            {
                try
                {
                    //closing the driver
                    driver.Quit();
                }
                finally { driver = null; }
            }
            if (process != null)
            {
                try
                {
                    //kill the process window
                    process.Kill();
                }
                finally { process = null; }


            }
        }
    }
}
