using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Areas.Identity
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }


    public class EmailSender : IEmailSender
    {
        private readonly AuthMessageSenderOptions _configuration;

        public EmailSender(IOptions<AuthMessageSenderOptions> configuration)
        {
            this._configuration = configuration.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            var apiKey = _configuration.SendGridKey;
            var apiName = _configuration.SendGridUser;

            if (string.IsNullOrEmpty(apiKey)) throw new ArgumentNullException(apiKey);

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("welwrdany@selecteg.com", apiName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
