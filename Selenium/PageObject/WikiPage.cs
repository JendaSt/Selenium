namespace Selenium.PageObject
{
    using OpenQA.Selenium;

    public class WikiPage
    {
        public IWebDriver driver;

        public WikiPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement searchField => driver.FindElement(By.Name("search"));
        public IWebElement searchBtn => driver.FindElement(By.XPath(".//*[@class='cdx-button cdx-button--action-default cdx-button--weight-normal cdx-button--size-medium cdx-button--framed cdx-search-input__end-button']"));
        public IWebElement bodyContent => driver.FindElement(By.Id("bodyContent")).FindElement(By.TagName("p"));
        public IWebElement firstHeading => driver.FindElement(By.Id("firstHeading"));
    }    
}
