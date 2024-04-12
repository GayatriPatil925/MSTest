using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        { 
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/";
        }

        [ClassCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        //[Priority(0)]
        public void AccordianVerification()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NevigateToElements("Widgets");

            Widgets widgets=new Widgets(driver);
            widgets.NavigateToWidgetsType("Accordian");

            string AC = "Accordian";
            Assert.AreEqual(AC, widgets.WidgetsVerification("Accordian"));
        }
    }
}