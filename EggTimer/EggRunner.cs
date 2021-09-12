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

        [TestCase(25,1)]
        public void TestEggCustomTimer(int timeToWait,int interval)
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(interval));
            driver.Url = url;

            
            var homePage = new EggHome();
            PageFactory.InitElements(driver, homePage);

            homePage.TimerInput.SendKeys(timeToWait.ToString());
            homePage.CountStarterButton.Click();
            

            var resultPage = new EggResult();
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
    }
}
