
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WatchParty.Services.Concrete
{
    public class SendGridService : IEmailSender
    {
        public string? Key { get; set; }

        public SendGridService(string? key)
        {
            Key = key;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new Exception("Null SendGridKey");
            }

            await Execute(Key, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("CaimanLizardDevelopment@pm.me", "The CLD Team"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.IsSuccessStatusCode
                                ? $"Email to {toEmail} queued successfully!"
                                : $"Failure Email to {toEmail}");
        }
    }
}