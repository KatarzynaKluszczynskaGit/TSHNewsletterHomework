using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace TSHNewsletterHomework.Pages
{
    public class MainPage
    {
        private readonly IWebDriver _driver;
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement EmailInput => _driver.FindElement(By.Id("newsletter_email"));
        IWebElement NameInput => _driver.FindElement(By.Id("newsletter_name"));
        IWebElement SurnameInput => _driver.FindElement(By.Id("newsletter_surname"));
        IWebElement NewsletterTypeDropDown => _driver.FindElement(By.Id("newsletter_newsType"));
        IWebElement NewsletterDropDownITOption => _driver.FindElement(By.XPath(".//li[contains(text(),'IT')]"));
        IWebElement StartingDateField => _driver.FindElement(By.Id("newsletter_startDate"));
        IWebElement StartingDateCalendar => _driver.FindElement(By.ClassName("ant-calendar-input"));
        IWebElement EndingDateField => _driver.FindElement(By.Id("newsletter_endDate"));
        IWebElement EndingDateCalendar => _driver.FindElement(By.ClassName("ant-calendar-input"));
        IWebElement FemaleRadioButton => _driver.FindElement(By.XPath("//input[@value='female']"));
        IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button.ant-btn"));
        IWebElement AgreementCheckbox => _driver.FindElement(By.Id("newsletter_agreement"));
        IWebElement OkButton => _driver.FindElement(By.XPath("//div[@class='ant-modal-confirm-btns']/button"));

        public MainPage TypeEmailAddress(string emailAddress)
        {
            EmailInput.SendKeys(emailAddress);
            return this;
        }

        public MainPage TypeFirtName(string firstname)
        {
            NameInput.SendKeys(firstname);
            return this;
        }

        public MainPage TypeSurname(string surname)
        {
            SurnameInput.SendKeys(surname);
            return this;
        }
        public MainPage ChooseNewsletterType()
        {
            NewsletterTypeDropDown.Click();
            NewsletterDropDownITOption.Click();

            return this;
        }

        public MainPage ChooseStartingDate(string startingDate)
        {
            StartingDateField.Click();
            Actions action = new Actions(_driver);
            action.SendKeys(StartingDateCalendar, startingDate).SendKeys(StartingDateCalendar, Keys.Enter).Build().Perform();
            return this;
        }

        public MainPage ChooseEndingDate(string endingDate)
        {
            EndingDateField.Click();
            Actions action = new Actions(_driver);
            action.SendKeys(EndingDateCalendar, endingDate).SendKeys(EndingDateCalendar, Keys.Enter).Build().Perform();
            return this;
        }

        public MainPage ChooseFemaleButton()
        {
            FemaleRadioButton.Click();
            return this;
        }

        public MainPage AcceptAgreement()
        {
            AgreementCheckbox.Click();
            return this;
        }

        public MainPage SubmitForm()
        {
            SubmitButton.Click();
            OkButton.Click();
            Thread.Sleep(2000);
            return this;
        }


    }
}
