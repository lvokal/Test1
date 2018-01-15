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


        [FindsBy(How = How.Name, Using = "Address bar")]
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

        [FindsBy(How = How.Name, Using = "C-O-2")]
        public IWebElement CO2Item;

        [FindsBy(How = How.Name, Using = "Assembly1")]
        public IWebElement Assembly1Item;

        [FindsBy(How = How.ClassName, Using = "ComboBox")]
        public IWebElement WODropDown;

        [FindsBy(How = How.Name, Using = "Process")]
        public IWebElement ProcessButton;

        [FindsBy(How = How.Id, Using = "FlowTextBox")]
        public IWebElement FlowTextBox;

        [FindsBy(How = How.Id, Using = "PowerTextBox")]
        public IWebElement PowerTextBox;

        [FindsBy(How = How.Id, Using = "EfficiencyTextBox")]
        public IWebElement EfficienyTextBox;

        [FindsBy(How = How.Name, Using = "Assembly2")]
        public IWebElement Assembly2Item;

        [FindsBy(How = How.Name, Using = "Assembly3")]
        public IWebElement Assembly3Item;

        [FindsBy(How = How.Name, Using = "Assembly4")]
        public IWebElement Assembly4Item;

        [FindsBy(How = How.Name, Using = "Assembly5")]
        public IWebElement Assembly5Item;

        [FindsBy(How = How.XPath, Using = "//*[@AutomationId='ScanTextBox'][1]")]
        public IWebElement ScanTextBox1;

        [FindsBy(How = How.XPath, Using = "//*[@AutomationId='ScanTextBox']//*[IsEnabled='True']")]
        public IWebElement ScanTextBox2;

        [FindsBy(How = How.Name, Using = "Burnin")]
        public IWebElement BurnInItem;

        [FindsBy(How = How.Name, Using = "Close")]
        public IWebElement CloseTrolley;

        [FindsBy(How = How.Id, Using = "")]
        public IWebElement TrolleyTextBox;

        [FindsBy(How = How.Name, Using = "Final test")]
        public IWebElement FinalTestItem;

        [FindsBy(How = How.Id, Using = "O2ConcentrationExternalTextBox")]
        public IWebElement ConcentrationExternalTextbox;

        [FindsBy(How = How.Id, Using = "DeviationsInitialTextBox")]
        public IWebElement DeviationsInitialTextbox;

        [FindsBy(How = How.Id, Using = "CurrentTextBox")]
        public IWebElement CurrentTextbox;

        [FindsBy(How = How.Id, Using = "PowerTextBox")]
        public IWebElement PowerTextbox;

        [FindsBy(How = How.Id, Using = "O2ConcentrationInternalTextBox")]
        public IWebElement ConcentrationTextbox;

        [FindsBy(How = How.Name, Using = "C-S-1")]
        public IWebElement CS1Item;

        [FindsBy(How = How.Name, Using = "VI")]
        public IWebElement VIItem;

        [FindsBy(How = How.Name, Using = "County Kit")]
        public IWebElement CountryKitItem;

        [FindsBy(How = How.Name, Using = "Packing")]
        public IWebElement PackingItem;

        [FindsBy(How = How.Name, Using = "Weight Check")]
        public IWebElement WeightCheckItem;

        [FindsBy(How = How.Id, Using = "MenuImage")]
        public IWebElement MenuButton;

        [FindsBy(How = How.Name, Using = "Close")]
        public IWebElement CloseX;

        [FindsBy(How = How.Name, Using = "Palletization")]
        public IWebElement PalletizationItem;

        [FindsBy(How = How.Id, Using = "CloseButton")]
        public IWebElement ClosePallet;

        [FindsBy(How = How.Name, Using = "Stock In")]
        public IWebElement StockInItem;

        [FindsBy(How = How.Id, Using = "ScanTextBox")]
        public IWebElement ScanTextBox;

        [FindsBy(How = How.Id, Using = "LocationTextBox")]
        public IWebElement LocationTextBox;

        [FindsBy(How = How.Name, Using = "Close Trolley")]
        public IWebElement CloseTrolleyButton;

        public BasePageControls(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
			actions = new Actions(driver);

			//this.appWindow = appWindow;
		}

	}
}
