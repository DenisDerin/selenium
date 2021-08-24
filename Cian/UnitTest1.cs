using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Cian
{
    public class Tests
    {
        private string chromePath = "D:\\3rdparty\\chrome";
        private string baseUrl = "https://cian.ru";
        private IWebDriver driver;

        private string email = "zmejka77@yandex.ru";
        private string pass = "123QWEasd";

        private readonly By _signInButton = By.XPath("//span[text()='Войти']");
        private readonly By _chooseMethodButton = By.XPath("//span[text()='Войти по email или id']");
        private readonly By _emailOrId = By.XPath("//input[@name='username']");
        private readonly By _continueButton = By.XPath("//button[@data-mark='ContinueAuthBtn']");
        private readonly By _password = By.XPath("//input[@name='password']");
        private readonly By _enterButton = By.XPath("//button[@data-mark='ContinueAuthBtn']");
        private readonly By _avatarIcon = By.XPath("//img[@class='user-avatar']");
        private readonly By _userId = By.XPath("//a[@data-name='OptionalLink']");

        private string expectedId = "ID 51350476";

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("incognito");
            driver = new ChromeDriver(chromePath, chromeOptions);
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            Thread.Sleep(1500);

            try
            {
                var chooseMethoButton = driver.FindElement(_chooseMethodButton);
                chooseMethoButton.Click();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Not found");
            }
            
            var emailOrId = driver.FindElement(_emailOrId);
            emailOrId.SendKeys(email);

            Thread.Sleep(1500);

            var continueButton = driver.FindElement(_continueButton);
            continueButton.Click();

            Thread.Sleep(1500);

            var password = driver.FindElement(_password);
            password.SendKeys(pass);

            Thread.Sleep(1500);

            var enter = driver.FindElement(_enterButton);
            enter.Click();

            Thread.Sleep(1500);

            var avatar = driver.FindElement(_avatarIcon);
            avatar.Click();

            Thread.Sleep(1500);

            var id = driver.FindElement(_userId);
            var actualId = id.Text;

            Assert.AreEqual(expectedId, actualId);
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }
    }
}