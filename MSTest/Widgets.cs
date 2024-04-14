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
        private IList<IWebElement> Cards => driver.FindElements(By.XPath("//div[@class='card']"));

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

        public void AccordianPerf(List<string> title,List<string> cardBody)
        {
            foreach (var ele in Cards)
            {
                for (int i = 0; i < title.Count; i++)
                {
                    //to check title is present or not
                    if (ele.Text.Contains(title[i]))
                    {
                        //if card body is available or not
                        if (!ele.Text.Contains(cardBody[i]))
                        {
                            js.ExecuteScript("arguments[0].scrollIntoView(true)", ele);
                            //if cardbody is not available it will click on title
                            ele.Click();
                            //find element on list by using class name.
                            string para = ele.FindElement(By.ClassName("card-body")).Text;
                            Console.WriteLine(para);
                        }
                        else
                        {
                            Console.WriteLine(ele.Text);
                        }
                    }
                }
            }
        }     
    }
}
