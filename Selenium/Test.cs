namespace Selenium
{
    using System;    
    using System.Threading;    
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Selenium.PageObject;

    public class Test
    {
        private IWebDriver driver;
        private WikiPage _WikiPage;
        private string page = "Filozofie";

        [Test]
        public void PhilosophyTest()
        {            
            OpenUrl("https://cs.wikipedia.org/wiki");
            OpenArticle(page);
            RedirectPage();
            driver.Close();
        }

        public void OpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
            Thread.Sleep(500);
        }

        public void OpenArticle(string article)
        {
            _WikiPage = new WikiPage(driver);
            _WikiPage.searchField.SendKeys(article);
            Thread.Sleep(500);
            _WikiPage.searchBtn.Click();
            Thread.Sleep(500);
        }

        public void RedirectPage()
        {
            int i = 0;
            do
            {
                GetLink().Click();
                Thread.Sleep(500);
                Console.WriteLine(_WikiPage.firstHeading.FindElement(By.ClassName("mw-page-title-main")).Text);
                i++;
            }
            while (_WikiPage.firstHeading.FindElement(By.ClassName("mw-page-title-main")).Text != page);

            Console.WriteLine("----------------------");
            Console.WriteLine("Number of redirect = " + i);
            Thread.Sleep(500);
        }

        public IWebElement GetLink()
        {            
            IWebElement link = _WikiPage.bodyContent.FindElement(By.CssSelector("[href ^= '/wiki/']"));
            Console.WriteLine("-> " + link.Text);
            Thread.Sleep(500);
            return link;
        }
    }
}