using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TSHNewsletterHomework.Base;
using TSHNewsletterHomework.Models;
using TSHNewsletterHomework.Pages;

namespace TSHNewsletterHomework
{
    [TestFixture]
    public class NewsletterMailTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.TypeEmailAddress(mailSacConfig.EmailAddress)
                .TypeFirtName("Katarzyna")
                .TypeSurname("Kluszczynska")
                .ChooseNewsletterType()
                .ChooseStartingDate(startDate)
                .ChooseEndingDate(endDate)
                .ChooseFemaleButton()
                .AcceptAgreement()
                .SubmitForm();
        }

        [Test]
        public void Should_Send_Email_To_Appopriate_User()
        {
            //Arrange
            var client = CreateRestClient();

            RestRequest request = new RestRequest(mailSacConfig.GetAllMessagesEndpoint, Method.GET);
            AddAutorizationHeader(request);

            //Act
            RestResponse<List<Message>> response = (RestResponse<List<Message>>)client.Execute<List<Message>>(request);

            //Assert
            response.Data[0].To[0].Address.Should().Be(mailSacConfig.EmailAddress);
        }

        [Test]
        public void Should_Send_Exactly_One_Email()
        {
            //Arrange
            var client = CreateRestClient();

            RestRequest request = new RestRequest(mailSacConfig.MessagesCountEndpoint, Method.GET);
            AddAutorizationHeader(request);

            //Act
            RestResponse<InboxMessages> response = (RestResponse<InboxMessages>)client.Execute<InboxMessages>(request);

            //Assert
            response.Data.Count.Should().Be(1);
        }

        [Test]
        public void Should_Send_Email_With_Appopriate_Metadata()
        {
            //Arrange
            var client = CreateRestClient();

            RestRequest request = new RestRequest(mailSacConfig.GetAllMessagesEndpoint, Method.GET);
            AddAutorizationHeader(request);

            //Act
            RestResponse<List<Message>> response = (RestResponse<List<Message>>)client.Execute<List<Message>>(request);

            //Assert
            response.Data[0].From[0].Address.Should().Be("tsh.test.qa@gmail.com");
            response.Data[0].To[0].Address.Should().Be(mailSacConfig.EmailAddress);
            response.Data[0].Subject.Should().Be("You have been signed to it newsletter");
        }

        [Test]
        public void Should_Send_Email_With_Appopriate_Body()
        {
            //Arrange
            var client = CreateRestClient();

            RestRequest request = new RestRequest(mailSacConfig.GetAllMessagesEndpoint, Method.GET);
            AddAutorizationHeader(request);

            //Act
            RestResponse<List<Message>> response = (RestResponse<List<Message>>)client.Execute<List<Message>>(request);
            var messageId = response.Data[0].Id;

            RestRequest bodyRequest = new RestRequest(mailSacConfig.GetMessageBodyEndpoint + "/" + messageId, Method.GET);
            AddAutorizationHeader(bodyRequest);
            string responseBody = client.Execute(bodyRequest).Content;

            //Assert
            responseBody.Length.Should().NotBe(0);
            responseBody.Should().NotBeNull();
            responseBody.Should().Contain("Katarzyna Kluszczynska");
        }

        [TearDown]
        public void TearDown()
        {
            PurgeInboxAfterEachTest();
        }
    }
}