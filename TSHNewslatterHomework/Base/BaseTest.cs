using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TSHNewsletterHomework.Models;

namespace TSHNewsletterHomework.Base
{
    public class BaseTest
    {
        public IWebDriver driver;

        public WebDriverConfiguration driverConfig = Configuration.Driver;
        public MailSacConfiguration mailSacConfig = Configuration.MailSac;

        public string startDate = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
        public string endDate = DateTime.Today.AddDays(32).ToString("yyyy-MM-dd");

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(driverConfig.BaseUrl);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        public void PurgeInboxAfterEachTest()
        {
            RestClient client = CreateRestClient();

            //Those two requests can be replaced by one (Delete all messages)
            //but only when mailsac plan will be upgraded to paid version

            //Should get already created mail id
            RestRequest request = new RestRequest(mailSacConfig.GetAllMessagesEndpoint, Method.GET);
            AddAutorizationHeader(request);
            RestResponse<List<Message>> response = (RestResponse<List<Message>>)client.Execute<List<Message>>(request);
            string id = response.Data[0].Id;

            //Delete already created mail using its id
            RestRequest deleteRequest = new RestRequest(mailSacConfig.GetAllMessagesEndpoint + "/" + id, Method.DELETE);
            AddAutorizationHeader(deleteRequest);
            RestResponse deleteResponse = (RestResponse)client.Execute(deleteRequest);

            Assert.AreEqual(deleteResponse.StatusCode, HttpStatusCode.OK);
        }

        public void AddAutorizationHeader(RestRequest request)
        {
            request.AddHeader("Mailsac-Key", mailSacConfig.MailsacKey);
        }

        public RestClient CreateRestClient()
        {
            return new RestClient(mailSacConfig.MailsacBaseEndpoint);
        }
    }
}
