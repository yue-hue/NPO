using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace test1
{
    [TestFixture]
    public class Class1
    {
        const string PATH_TO_SITE = "https://krassh.schools.by/";
        const string PATH_TO_DRIVER = "C:Пользователи/mikyy/.nuget/packages/selnium.webdriver.chromedriver/87.0.4280.2000/driver/win32";

        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(PATH_TO_DRIVER);
            _driver.Navigate().GoToUrl(PATH_TO_SITE);
            _driver.Manage().Window.Maximize();
        }

        [Test] 
        public void Test_Click()
        {
            var ClickOn = _driver.FindElement(By.XPath("//div[@class='d1']"));
            ClickOn.Click();

            ClickOn = _driver.FindElement(By.XPath("//a[@class='user_type_7']"));
            ClickOn.Click();
        }

        [Test]
        public void Test_SearchInfo()
        {
            var lookingFor = _driver.FindElement(By.XPath("//input[@name='q']"));
            lookingFor.Click();
            lookingFor.SendKeys("Черницкая");

            var lookingButton = _driver.FindElement(By.XPath("//input[@class='btn']"));
            lookingButton.Click();
        }

        [Test]
        public void Test_VisuallyImpaired()
        {
            var eyeBtn = _driver.FindElement(By.XPath("//div[@class='finevision-element']"));
            eyeBtn.Click();

            var bluePage = _driver.FindElement(By.XPath("//a[@class='control color-blue']"));
            bluePage.Click();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}

