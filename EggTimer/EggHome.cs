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

        [FindsBy(How = How.XPath, Using = "//*[@class='EggTimer-start-quick-time']/*[@title='5 minutes']")]
        public IWebElement FiveMinutesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='EggTimer-start-quick-time']/*[@title='10 minutes']")]
        public IWebElement TenMinutesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='EggTimer-start-quick-time']/*[@title='15 minutes']")]
        public IWebElement FiveTeenMinutesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='EggTimer-start-quick-time']/*[@title='Pomodoro']")]
        public IWebElement PomodoroButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='EggTimer-start-quick-time']/*[@title='Tabata']")]
        public IWebElement TabataButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='EggTimer-start-quick-time']/*[@title='Morning Routine']")]
        public IWebElement MorningButton { get; set; }

    }
}
