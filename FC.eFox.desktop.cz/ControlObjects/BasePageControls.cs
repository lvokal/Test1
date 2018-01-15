using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.eFox.desktop.cz.ControlObjects
{
	public class BasePageControls
	{
		public IWebDriver driver;
		public IWebElement appWindow;
		public Actions actions;


		[FindsBy(How = How.Name, Using = "Address Bar")]
		public IWebElement adrsBar;

		[FindsBy(How = How.Id, Using = "Item 100")]
		public IWebElement btnGo;

		[FindsBy(How = How.ClassName, Using = "IEFrame")]
		public IWebElement appWnd;

		[FindsBy(How = How.Name, Using = "TrustManagerDialog")]
		public IWebElement trustMngrDlgWnd;

		[FindsBy(How = How.Name, Using = "InstallOrRunButton")]
		public IWebElement btnRun;

		[FindsBy(How = How.Id, Using = "LogoutImage")]
		public IWebElement btnLogout;

		[FindsBy(How = How.ClassName, Using = "GroupBox")]
		public IWebElement logInPopUpWindow;

		[FindsBy(How = How.Id, Using = "AuthenticationComboBox")]
		public IWebElement authenticationComboBox;

		[FindsBy(How = How.Name, Using = "Windows Authentication")]
		public IWebElement windowsAuthentication;

		[FindsBy(How = How.Id, Using = "LogonButton")]
		public IWebElement logOnBtn;

		[FindsBy(How = How.Id, Using = "Close")]
		public IWebElement closeBtn;

        [FindsBy(How = How.Name, Using = "Process")]
        public IWebElement ProcessItem;

        [FindsBy(How = How.Name, Using = "C-C-2")]
        public IWebElement CC2Item;

        [FindsBy(How = How.Name, Using = "Pre-kit")]
        public IWebElement PreKitItem;

        [FindsBy(How = How.Name, Using = "Assembly")]
        public IWebElement AssemblyItem;

        [FindsBy(How = How.ClassName, Using = "TextBox")]
        public IWebElement TextBox;

        [FindsBy(How = How.Name, Using = "Leak Test")]
        public IWebElement LeakTestItem;

        public BasePageControls(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
			actions = new Actions(driver);

			//this.appWindow = appWindow;
		}

	}
}
