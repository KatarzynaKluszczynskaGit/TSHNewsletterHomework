using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TSHNewsletterHomework.Base;
using TSHNewsletterHomework.Pages;
using TSHNewsletterHomework.Utils;

namespace TSHNewsletterHomework.Tests
{
    [TestFixture]
    public class NewsletterFormTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Navigate().Refresh();
        }

        [Test]
        public void Should_Fill_Up_Email_Field()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);

            //Act
            mainPage.TypeEmailAddress(mailSacConfig.EmailAddress);
            string text = GenericMethods.GetAttriibuteValue(mainPage.EmailInput, "value");

            //Assert
            text.Should().Be(mailSacConfig.EmailAddress);
        }

        [Test]
        public void Should_Fill_Up_Name_Field()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);
            string name = "Katarzyna";

            //Act
            mainPage.TypeFirstName(name);
            string text = GenericMethods.GetAttriibuteValue(mainPage.NameInput, "value");

            //Assert
            text.Should().Be(name);
        }

        [Test]
        public void Should_Fill_Up_Surname_Field()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);
            string surname = "Kluszczynska";

            //Act
            mainPage.TypeSurname(surname);
            string text = GenericMethods.GetAttriibuteValue(mainPage.SurnameInput, "value");

            //Assert
            text.Should().Be(surname);
        }

        [Test]
        public void Should_Fill_Up_Newsletter_Type()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);

            //Act
            mainPage.ChooseNewsletterType();

            string text = GenericMethods.GetTextValue(mainPage.NewsletterType);

            //Assert
            text.Should().Be("IT");
        }

        [Test]
        public void Should_Fill_Up_Date_Fields()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);
            string startDate = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
            string endDate = DateTime.Today.AddDays(32).ToString("yyyy-MM-dd");

            //Act
            mainPage.ChooseStartingDate(startDate);
            mainPage.ChooseEndingDate(endDate);

            string actualStartDate = GenericMethods.GetAttriibuteValue(mainPage.SelectedStartingDateField, "value");
            string actualEndDate = GenericMethods.GetAttriibuteValue(mainPage.SelectedEndingDateField, "value");

            //Assert
            actualStartDate.Should().Be(startDate);
            actualEndDate.Should().Be(endDate);
        }

        [Test]
        public void Should_Fill_Up_Sex()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);

            //Act
            mainPage.ChooseFemaleButton();
            bool isDisplayed = GenericMethods.ElementIsVisible(mainPage.CheckedSexRadioButton);

            //Assert
            isDisplayed.Should().BeTrue();
        }

        [Test]
        public void Should_Check_Agreement_Checkbox()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);

            //Act
            mainPage.AcceptAgreement();
            bool isChecked = GenericMethods.ElementIsChecked(mainPage.AgreementCheckbox);

            //Assert
            isChecked.Should().BeTrue();
        }

        [Test]
        public void Should_Check_If_Form_Cannot_Be_Submitted_Whem_Required_Fields_Are_Empty()
        {
            //Arrange
            MainPage mainPage = new MainPage(driver);

            //Act
            mainPage.SubmitButton.Click();

            //Asserts
            GenericMethods.ElementIsVisible(mainPage.EmailRequiredField).Should().BeTrue();
            GenericMethods.ElementIsVisible(mainPage.NameRequiredField).Should().BeTrue();
            GenericMethods.ElementIsVisible(mainPage.SurnameRequiredField).Should().BeTrue();
            GenericMethods.ElementIsVisible(mainPage.NewsletterTypeRequiredField).Should().BeTrue();
            GenericMethods.ElementIsVisible(mainPage.StartingDateRequiredField).Should().BeTrue();
            GenericMethods.ElementIsVisible(mainPage.AgreementRequiredField).Should().BeTrue();
        }
    }
}
