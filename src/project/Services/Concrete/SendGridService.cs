
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WatchParty.Services.Concrete
{
    public class SendGridService : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly EmailAddress _fromEmail;
        public string? Key { get; set; }

        public SendGridService(IConfiguration configuration)
        {
            _configuration = configuration;
            _fromEmail = new EmailAddress("CaimanLizardDevelopment@pm.me", "The CLD Team");
        }

        public async Task SendEmailAsync(string toEmail, string subject, string jsonData)
        {
            var apiKey = _configuration["SendGrid:APIKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("Null SendGridKey");
            }

            await Execute(apiKey, subject, jsonData, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string jsonData, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = _fromEmail,
                // Subject = subject, - provided on SendGrid thru template
                // PlainTextContent = message, - provided on SendGrid thru template
                // HtmlContent = message - provided on SendGrid thru template
            };
            msg.AddTo(new EmailAddress(toEmail));
            
            msg.SetTemplateId("d-e5b00788fb224653a39c6b5221c33bfd");
            
            TemplateData json = JsonConvert.DeserializeObject<TemplateData>(jsonData)!;
            var data = new TemplateData
            {
                Subject = "Social Watch Party: Account Confirmation",
                Username = json.Username,
                Email = toEmail,
                CallbackUrl = json.CallbackUrl,
                ExpireDate = json.ExpireDate
            };
            msg.SetTemplateData(data);
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);

            Console.WriteLine(response.IsSuccessStatusCode
                                ? $"Email to {toEmail} queued successfully!"
                                : $"Failure Email to {toEmail}");
        }

        public class TemplateData
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("callbackurl")]
            public string CallbackUrl { get; set; }

            [JsonProperty("expiredate")]
            public string ExpireDate { get; set; }
        }
    }
}