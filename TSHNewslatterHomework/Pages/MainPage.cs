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
        public IWebElement NameInput => _driver.FindElement(By.Id("newsletter_name"));
        public IWebElement SurnameInput => _driver.FindElement(By.Id("newsletter_surname"));
        public IWebElement NewsletterTypeDropDown => _driver.FindElement(By.Id("newsletter_newsType"));
        public IWebElement NewsletterDropDownITOption => _driver.FindElement(By.XPath(".//li[contains(text(),'IT')]"));
        public IWebElement NewsletterType => _driver.FindElement(By.ClassName("ant-select-selection-selected-value"));
        public IWebElement StartingDateField => _driver.FindElement(By.Id("newsletter_startDate"));
        public IWebElement StartingDateCalendar => _driver.FindElement(By.ClassName("ant-calendar-input"));
        public IWebElement SelectedStartingDateField => _driver.FindElement(By.XPath("//span[@id='newsletter_startDate']/div/input"));
        public IWebElement EndingDateField => _driver.FindElement(By.Id("newsletter_endDate"));
        public IWebElement EndingDateCalendar => _driver.FindElement(By.ClassName("ant-calendar-input"));
        public IWebElement SelectedEndingDateField => _driver.FindElement(By.XPath("//span[@id='newsletter_endDate']/div/input"));
        public IWebElement FemaleRadioButton => _driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement CheckedSexRadioButton => _driver.FindElement(By.XPath("//span[@class='ant-radio ant-radio-checked']"));
        public IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button.ant-btn"));
        public IWebElement AgreementCheckbox => _driver.FindElement(By.Id("newsletter_agreement"));
        public IWebElement OkButton => _driver.FindElement(By.XPath("//div[@class='ant-modal-confirm-btns']/button"));
        public IWebElement EmailRequiredField => _driver.FindElement(By.XPath("//div[@class='ant-form-explain' and contains(text(),'E-mail')] "));
        public IWebElement NameRequiredField => _driver.FindElement(By.XPath("//div[@class='ant-form-explain' and contains(text(),'First name')] "));
        public IWebElement SurnameRequiredField => _driver.FindElement(By.XPath("//div[@class='ant-form-explain' and contains(text(),'Surname')] "));
        public IWebElement NewsletterTypeRequiredField => _driver.FindElement(By.XPath("//div[@class='ant-form-explain' and contains(text(),'newsletter type')] "));
        public IWebElement StartingDateRequiredField => _driver.FindElement(By.XPath("//div[@class='ant-form-explain' and contains(text(),'Start date')] "));
        public IWebElement AgreementRequiredField => _driver.FindElement(By.XPath("//div[@class='ant-form-explain' and contains(text(),'terms and condition')] "));

        public MainPage TypeEmailAddress(string emailAddress)
        {
            EmailInput.SendKeys(emailAddress);
            return this;
        }

        public MainPage TypeFirstName(string firstname)
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
            Thread.Sleep(2000);
            return this;
        }


    }
}
