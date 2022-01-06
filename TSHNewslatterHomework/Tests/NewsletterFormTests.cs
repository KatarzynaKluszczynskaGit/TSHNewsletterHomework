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
        [Test]
        public void Should_Full_Up_Email_Field()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.TypeEmailAddress(mailSacConfig.EmailAddress);

            string text = GenericMethods.GetAttriibuteValue(mainPage.EmailInput);

            text.Should().Be(mailSacConfig.EmailAddress);
        }
    }
}
