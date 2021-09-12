using OpenQA.Selenium;
using SeleniumExtras.PageObjects;



namespace EggTimer
{
    class EggHome
    {
        private IWebDriver driver;
        public EggHome()
        {
        }

        [FindsBy(How = How.Id, Using = "EggTimer-start-time-input-text")]
        public IWebElement TimerInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Start')]")]
        public IWebElement CountStarterButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Help and Settings")]
        public IWebElement HelpSettingsButton { get; set; }

    }
}
