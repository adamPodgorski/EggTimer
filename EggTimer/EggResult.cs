using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;



namespace EggTimer
{
    class EggResult
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public EggResult()
        {
            ////this.driver = driver;
            //wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            //PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Time Expired!']")]
        public IWebElement EggResultText { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ClassicTimer-time")]
        public IWebElement EggResultTime{ get; set; }
    }
}
