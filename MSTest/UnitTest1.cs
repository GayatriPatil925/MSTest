using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver;
        public static HomePage homePage;
        public static Widgets widgets;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        { 
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/";
            homePage = new HomePage(driver);
            widgets = new Widgets(driver);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        [Priority(0)]
        public void AccordianVerification()
        {
            //To create list title
            List<string> title = new List<string> { "What is Lorem Ipsum?", "Where does it come from?", "Why do we use it?" };
            //To create list of Card_body
            List<string> cardBody = new List<string> { "Lorem Ipsum is simply", "Contrary to popular belief", "It is a long established" };

            
            homePage.NevigateToElements("Widgets");

           
            widgets.NavigateToWidgetsType("Accordian");

            string AC = "Accordian";
            Assert.AreEqual(AC, widgets.WidgetsVerification("Accordian"));

            widgets.AccordianPerf(title, cardBody);
        }
    }
}