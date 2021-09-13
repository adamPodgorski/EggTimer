using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
namespace EggTimer
{
    class EggRunner
    {
        private const string url = "https://e.ggtimer.com/";
        private WebDriverWait wait;
        private IWebDriver driver;

        EggHome homePage;
        EggResult resultPage;

        [SetUp]
        public void SetupDriver()
        {
            driver = new ChromeDriver();
            driver.Url = url;
            homePage = new EggHome();
            PageFactory.InitElements(driver, homePage);
        }

        [TestCase(25,1)]
        public void TestEggCustomTimer(int timeToWait,int interval)
        {
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(interval));           

            homePage.TimerInput.SendKeys(timeToWait.ToString());
            homePage.CountStarterButton.Click();
            
            resultPage = new EggResult();
            PageFactory.InitElements(driver, resultPage);

            for (var x = timeToWait; x > 0; x--)
            {
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath($"//span[contains(text(), '{(x-1).ToString()}')]"))));
                System.IO.File.AppendAllText("C:/tmp/t.txt","\n" + resultPage.EggResultTime.Text + "   |" +x.ToString());
            }
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Assert.IsTrue(resultPage.EggResultText.Displayed);
        }

        [Test]
        public void validatePageElements()
        {
            Assert.IsTrue(homePage.TimerInput.Displayed);
            Assert.IsTrue(homePage.CountStarterButton.Displayed);
            Assert.IsTrue(homePage.FiveMinutesButton.Displayed);
            Assert.IsTrue(homePage.TenMinutesButton.Displayed);
            Assert.IsTrue(homePage.FiveTeenMinutesButton.Displayed);
            Assert.IsTrue(homePage.PomodoroButton.Displayed);
            Assert.IsTrue(homePage.TabataButton.Displayed);
            Assert.IsTrue(homePage.MorningButton.Displayed);
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
