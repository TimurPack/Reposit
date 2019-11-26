using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver
{
    [TestClass]
    public class ZhdTests
    {
        IWebDriver driver = new ChromeDriver();
        [TestMethod]
        public void FindTicketWithoutArrivalStation()
        {
            driver.Navigate().GoToUrl(@"https://travel.yandex.ru/trains/");
            driver.FindElement(By.CssSelector("._3kjfH._1kF3E")).Click();
            driver.FindElement(By.XPath("//button[@class = 'control.button2.button2_view_default.button2_tone_default.button2_size_m.button2_theme_normal.bIgMU'")).Click();
            driver.FindElement(By.XPath("//INPUT[@class='control button2 button2_view_default button2_tone_default button2_size_m button2_theme_normal bIgMU")).Click();
            driver.FindElement(By.XPath("//INPUT[@class='_2VcIa _3Uf5Q']")).Click();
            IWebElement error = GetElement(driver, "//DIV[@class='_2OX-Z _3Kcp8 _1cvA-']/p");
            Assert.AreEqual("Укажите станцию прибытия", error.Text);
            driver.Quit();
        }
        [TestMethod]
        public void SearchWithWrongDate()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://travel.yandex.ru/trains/");
            driver.FindElement(By.XPath("//INPUT[@class='slide_tcal tc1']")).SendKeys("Москва");
            driver.FindElement(By.XPath("//INPUT[@class='slide_tcal tc2']")).SendKeys("Казань");
            IWebElement dateString = driver.FindElement(By.XPath("//INPUT[@class='slide_tcal tc3']"));
            dateString.Clear();
            dateString.SendKeys(DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"));
            driver.FindElement(By.XPath("//INPUT[@class='search_button']")).Click();
            Assert.AreEqual("Дата устарела, в указанную дату поезд не ходит. Пожалуйста, выберите другую.",
                GetElement(driver, "//DIV[@class='inner_left']/p").Text);
            driver.Quit();
        }
        IWebElement GetElement(IWebDriver driver, string xPath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                IWebElement webElement = d.FindElement(By.XPath(xPath));
                if (webElement.Displayed)
                    return webElement;
                return null;
            });
            return element;
        }
    }
}
