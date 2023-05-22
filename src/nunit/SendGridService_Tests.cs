using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Smtp;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using WatchParty.Services.Concrete;

namespace WatchPartyTest
{
    public class SendGridService_Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SendEmailAsync_NullKey_ThrowsException()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["SendGrid:APIKey"]).Returns((string)null);
            var sendGridService = new SendGridService(mockConfiguration.Object);
            var toEmail = "test@test.com";
            var subject = "Test Subject";
            var jsonData = "{\"Username\":\"testuser\",\"CallbackUrl\":\"https://www.example.com\",\"ExpireDate\":\"2022-03-19T00:00:00Z\"}";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => sendGridService.SendEmailAsync(toEmail, subject, jsonData));
        }

        [Test]
        public void SendEmailAsync_EmptyKey_ThrowsException()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["SendGrid:APIKey"]).Returns("");
            var sendGridService = new SendGridService(mockConfiguration.Object);
            var toEmail = "test@test.com";
            var subject = "Test Subject";
            var jsonData = "{\"Username\":\"testuser\",\"CallbackUrl\":\"https://www.example.com\",\"ExpireDate\":\"2022-03-19T00:00:00Z\"}";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => sendGridService.SendEmailAsync(toEmail, subject, jsonData));
        }
        /*
        [Test]
        public async Task SendEmailAsync_ValidKey_SendsEmail()
        {
            // Arrange
            var mockClient = new Mock<ISendGridClient>();
            var mockResponse = new Response(HttpStatusCode.OK, null, null);
            mockClient.Setup(x => x.SendEmailAsync(It.IsAny<SendGridMessage>(), It.IsAny<CancellationToken>()))
                .Callback<SendGridMessage, CancellationToken>((message, token) => {
                    var toEmail = message.Personalizations[0].Tos[0].Email;
                    var fromEmail = message.From.Email;
                    var subject = message.Subject;
                })
                .ReturnsAsync(mockResponse);

            var toEmail = "test@test.com";
            var subject = "Test Subject";
            var jsonData = "{\"Username\":\"testuser\",\"CallbackUrl\":\"https://www.example.com\",\"ExpireDate\":\"2022-03-19T00:00:00Z\"}";

            var sendGridService = new SendGridService(new ConfigurationBuilder().Build())
            {
                Key = "validApiKey"
            };

            // Act
            await sendGridService.Execute(sendGridService.Key, subject, jsonData, toEmail);

            // Assert
            mockClient.Verify(x => x.SendEmailAsync(
                It.Is<SendGridMessage>(m =>
                    m.From.Email == "CaimanLizardDevelopment@pm.me" &&
                    m.From.Name == "The CLD Team" &&
                    m.TemplateId == "d-e5b00788fb224653a39c6b5221c33bfd" &&
                    m.Personalizations.Count == 1 &&
                    m.Personalizations[0].TemplateData.GetType() == typeof(SendGridService.TemplateData) &&
                    ((SendGridService.TemplateData)m.Personalizations[0].TemplateData).Subject == "Social Watch Party: Account Confirmation" &&
                    ((SendGridService.TemplateData)m.Personalizations[0].TemplateData).Username == "testuser" &&
                    ((SendGridService.TemplateData)m.Personalizations[0].TemplateData).Email == toEmail &&
                    ((SendGridService.TemplateData)m.Personalizations[0].TemplateData).CallbackUrl == "https://www.example.com" &&
                    ((SendGridService.TemplateData)m.Personalizations[0].TemplateData).ExpireDate == "2022-03-19T00:00:00Z"
                ),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }
        */
    }
}
