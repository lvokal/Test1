using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using FC.eFox.desktop.cz.ControlObjects;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace FC.eFox.desktop.cz.Tests
{
    /// <summary>
    /// Class contain all basic things
    /// </summary>
    [TestFixture, Category("Smoke")]
    public class IN003BaseTest
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
        public void Assembly1Menu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.Assembly1Item.Click();
        }
        public void Assembly1Process()
        {
            string Sn = DBSelector.SelectSnByTreenodeId("963' OR treenodeid ='272' OR treenodeid = '274' OR treenodeid = '691");
            string WO = DBSelector.SelectWoBySn(Sn);
            basePageControls.WODropDown.Click();
            basePageControls.WODropDown.SendKeys(WO);
            basePageControls.ProcessButton.Click();
            System.Threading.Thread.Sleep(1000);
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            GenerateSN generateSN = new GenerateSN();
            string compressor = generateSN.GenerateCompressor();
            basePageControls.TextBox.SendKeys(compressor);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.FlowTextBox);
            basePageControls.FlowTextBox.SendKeys("10");
            basePageControls.FlowTextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.PowerTextBox);
            basePageControls.PowerTextBox.SendKeys("20");
            basePageControls.PowerTextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.EfficienyTextBox);
            basePageControls.EfficienyTextBox.SendKeys("2");
            basePageControls.EfficienyTextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("pass");
            basePageControls.TextBox.Submit();



        }
        public void Assembly1()
        {
            Assembly1Menu();
            System.Threading.Thread.Sleep(2500);
            Assembly1Process();
            System.Threading.Thread.Sleep(1000);
            basePageControls.CloseX.Click();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void Assembly2Menu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.Assembly2Item.Click();
        }
        public void Assembly2Process()
        {
            string Sn = DBSelector.SelectSnByTreenodeId("962");
            string compressor = DBSelector.SelectComponentBySnAndMatrerial(Sn,"77");
            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys(compressor);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("pass");
            basePageControls.TextBox.Submit();

        }
        public void Assembly2()
        {
            Assembly2Menu();
            System.Threading.Thread.Sleep(2500);
            Assembly2Process();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void Assembly3Menu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.Assembly3Item.Click();
        }
        public void Assebmly3Process()
        {
            string Sn = DBSelector.SelectSnByTreenodeId("961");
            GenerateSN generate = new GenerateSN();
            string motherBoard = generate.GenerateMotherBoard();

            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys(motherBoard);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("1.2");
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("4.1");
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("pass");
            basePageControls.TextBox.Submit();
        }
        public void Assembly3()
        {
            Assembly3Menu();
            System.Threading.Thread.Sleep(2500);
            Assebmly3Process();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void Assembly4Menu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.Assembly4Item.Click();
        }
        public void Assembly4Process()
        {
            string Sn = DBSelector.SelectSnByTreenodeId("960");
            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("pass");
            basePageControls.TextBox.Submit();
        }
        public void Assembly4()
        {
            Assembly4Menu();
            Assembly4Process();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void Assembly5Menu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.Assembly5Item.Click();
        }
        public IWebElement GetScanTextBox(int index)
        {
            return driver
                .FindElements(By.XPath("//*[@AutomationId='ScanTextBox']"))
                .ElementAt(index);
        }
        public void Assembly5Process()
        {
            string Sn = DBSelector.SelectSnByTreenodeId("959");
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(1000);
            string column = DBSelector.SelectUnusedProduct("IN002");
            var scantextbox1 = GetScanTextBox(0);
            scantextbox1.SendKeys(column + "-A");
            scantextbox1.Submit();
            System.Threading.Thread.Sleep(5000);
            var scantextbox2 = GetScanTextBox(1);
            scantextbox2.SendKeys(column+"-B");
            scantextbox2.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            GenerateSN generate = new GenerateSN();
            string powersupply = generate.GeneratePowerSupply();
            basePageControls.TextBox.SendKeys(powersupply);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys(column);
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("2017-046");
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.Submit();
            basePageControls.TextBox.SendKeys("pass");
            basePageControls.TextBox.Submit();
            WebdriverExtensions.WaitForElement(driver, basePageControls.TextBox);
            basePageControls.TextBox.SendKeys("010081713102006321");
            basePageControls.TextBox.Submit();

        }
        public void Assembly5()
        {
            Assembly5Menu();
            Assembly5Process();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void BurnInMenu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.BurnInItem.Click();
        }
       
        public void BurnInProcess()
        {
           


                System.Threading.Thread.Sleep(5000);
                basePageControls.TrolleyTextBox.SendKeys("SAA01");
                basePageControls.TrolleyTextBox.Submit();
                System.Threading.Thread.Sleep(5000);
            //basePageControls.CloseTrolleyButton.Click();
            //System.Threading.Thread.Sleep(1000);

            string Sn = DBSelector.SelectSnByTreenodeId("958");
            basePageControls.TextBox.SendKeys(Sn);
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(1000);
            basePageControls.TextBox.SendKeys("100:00");
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(1000);
            basePageControls.CloseTrolleyButton.Click();
        }
        public void BurnIn()
        {
            BurnInMenu();
            BurnInProcess();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void FinalTestMenu()
        {
            basePageControls.ProcessItem.Click();
            basePageControls.CO2Item.Click();
            basePageControls.FinalTestItem.Click();
        }
        public void FinalTestProcess()
        {
            string sn = DBSelector.SelectSnByTreenodeId("266");
            basePageControls.TextBox.SendKeys(sn);
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(1000);
            basePageControls.TextBox.SendKeys("pass");
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(1000);
            basePageControls.TextBox.SendKeys("100:00");
            basePageControls.TextBox.Submit();
            System.Threading.Thread.Sleep(5000);
            basePageControls.ConcentrationExternalTextbox.SendKeys("95");
            basePageControls.ConcentrationExternalTextbox.Submit();
            System.Threading.Thread.Sleep(500);
            basePageControls.DeviationsInitialTextbox.SendKeys("0");
            basePageControls.DeviationsInitialTextbox.Submit();
            System.Threading.Thread.Sleep(500);
            basePageControls.CurrentTextbox.SendKeys("0");
            basePageControls.CurrentTextbox.Submit();
            System.Threading.Thread.Sleep(500);
            basePageControls.PowerTextbox.SendKeys("10");
            basePageControls.PowerTextBox.Submit();
            System.Threading.Thread.Sleep(500);
            basePageControls.ConcentrationTextbox.SendKeys("95");
            basePageControls.ConcentrationTextbox.Submit();
            System.Threading.Thread.Sleep(1000);
            string ps = DBSelector.SelectComponentBySnAndMatrerial(sn,"89");
            basePageControls.TextBox.SendKeys(ps);
            basePageControls.TextBox.Submit();

        }
        public void FinalTest()
        {
            FinalTestMenu();
            FinalTestProcess();
            System.Threading.Thread.Sleep(1000);
            TestFixtureTearDown();
        }
        public void TestAllIN003(int length)
        {
            
                basePageControls.ProcessItem.Click();
                basePageControls.CO2Item.Click();
            for (int i = 0; i < length; i++)
            {
                basePageControls.Assembly1Item.Click();
                System.Threading.Thread.Sleep(1000);
                Assembly1Process();
                basePageControls.CloseX.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.Assembly2Item.Click();
                System.Threading.Thread.Sleep(1000);
                Assembly2Process();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.Assembly3Item.Click();
                System.Threading.Thread.Sleep(1000);
                Assebmly3Process();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.Assembly4Item.Click();
                System.Threading.Thread.Sleep(1000);
                Assembly4Process();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.Assembly5Item.Click();
                System.Threading.Thread.Sleep(1000);
                Assembly5Process();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.BurnInItem.Click();
                System.Threading.Thread.Sleep(1000);
                BurnInProcess();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
                System.Threading.Thread.Sleep(1000);
                basePageControls.FinalTestItem.Click();
                System.Threading.Thread.Sleep(1000);
                FinalTestProcess();
                System.Threading.Thread.Sleep(1000);
                basePageControls.MenuButton.Click();
            }
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
                    driver.FindElement(By.Id("Close")).Click();
                }
                finally { appWindow = null; }
            }
            //if (driver != null)
            //{
            //    //try
            //    //{
            //    //    //closing the driver
            //    //    //driver.Quit();
            //    //}
            //    //finally { driver = null; }
            //}
            //if (process != null)
            //{
            //    try
            //    {
            //        //kill the process window
            //        process.Kill();
            //    }
            //    finally { process = null; }


            //}
        }
    }
}
