using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace AndroidTest
{
    public class UnitTest1
    {

        private AndroidDriver<AndroidElement> _driver;

        [SetUp]
        public void Setup()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Samsung");
            driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage,
                "com.spotify.music");
            driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity,
                "MainActivity");
            driverOption.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            driverOption.AddAdditionalCapability(MobileCapabilityType.FullReset, false);


            driverOption.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\mikyy\OneDrive\Desktop\NPO7_1\NPO7_1\chromedriver.exe");

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), driverOption);

            Assert.IsNotNull(_driver.Context);
        }

        [Test]
        public void Test1_SearchSong()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            wait.Until(driver => driver.FindElement(By.XPath(".//android.widget.ImageView[@content-desc=\"Поиск\"]")));
            _driver.FindElement(By.XPath(".//android.widget.ImageView[@content-desc=\"Поиск\"]")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.widget.FrameLayout/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/android.view.ViewGroup[7]/android.widget.Button/android.widget.TextView")));
            _driver.FindElement(By.XPath("./hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.widget.FrameLayout/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/android.view.ViewGroup[7]/android.widget.Button/android.widget.TextView")).Click();
            Thread.Sleep(2000);

            wait.Until(driver => driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/androidx.recyclerview.widget.RecyclerView[1]/android.widget.LinearLayout[1]/android.widget.ImageView")));
            _driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/androidx.recyclerview.widget.RecyclerView[1]/android.widget.LinearLayout[1]/android.widget.ImageView")).Click();
            Thread.Sleep(2000);

            wait.Until(driver => driver.FindElement(By.XPath("//android.view.ViewGroup[@content-desc=\"плейлист: слушать\"]/android.widget.ImageButton")));
            _driver.FindElement(By.XPath("//android.view.ViewGroup[@content-desc=\"плейлист: слушать\"]/android.widget.ImageButton")).Click();
            Thread.Sleep(2000);

            _driver.CloseApp();
        }

        [Test] 
        public void Test2_AddToFavorites() {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            wait.Until(driver => driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.view.ViewGroup/android.widget.FrameLayout/android.widget.FrameLayout/androidx.recyclerview.widget.RecyclerView/androidx.recyclerview.widget.RecyclerView[1]/android.widget.FrameLayout[4]/android.view.ViewGroup\r\n")));
            _driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[3]/android.view.ViewGroup/android.widget.FrameLayout/android.widget.FrameLayout/androidx.recyclerview.widget.RecyclerView/androidx.recyclerview.widget.RecyclerView[1]/android.widget.FrameLayout[4]/android.view.ViewGroup\r\n")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc=\"Открыть контекстное меню трека «EDGING»\"]")));
            _driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc=\"Открыть контекстное меню трека «EDGING»\"]")).Click();
            Thread.Sleep(2000);

            wait.Until(driver => driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.widget.LinearLayout/android.widget.TextView[1]")));
            _driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.widget.LinearLayout/android.widget.TextView[1]")).Click();
            Thread.Sleep(2000);

            _driver.CloseApp();
        }

        [Test]
        public void Test3_RemoveFromFavorites()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            wait.Until(driver => driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"Моя медиатека\"]")));
            _driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"Моя медиатека\"]")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//android.view.ViewGroup[@content-desc=\"Любимые треки, Плейлист • 51 трек, Закреплено, \"]/android.widget.TextView[1]")));
            _driver.FindElement(By.XPath("//android.view.ViewGroup[@content-desc=\"Любимые треки, Плейлист • 51 трек, Закреплено, \"]/android.widget.TextView[1]")).Click();
            Thread.Sleep(2000);

            wait.Until(driver => driver.FindElement(By.XPath("(//android.widget.ImageButton[@content-desc=\"Удалить трек из любимых\"])[1]")));
            _driver.FindElement(By.XPath("(//android.widget.ImageButton[@content-desc=\"Удалить трек из любимых\"])[1]")).Click();
            Thread.Sleep(2000);

            wait.Until(driver => driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.Button[1]")));
            _driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.Button[1]")).Click();
            Thread.Sleep(2000);

            _driver.CloseApp();
        }

    }
}