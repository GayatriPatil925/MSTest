using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    public class Widgets
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;

        public Widgets(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            js=(IJavaScriptExecutor)driver;
        }

        public void NavigateToWidgetsType(string eleType)
        {
            IWebElement elements = driver.FindElement(By.XPath("//span[@class='text' and contains(text(),'" + eleType + "')]"));
            js.ExecuteScript("arguments[0].scrollIntoView(true)", elements);
            elements.Click();
        }

        public string WidgetsVerification(string eleType)
        {
            return  driver.FindElement(By.XPath("//h1[contains(text(),'"+eleType+"')]")).Text;
        }
    }
}
