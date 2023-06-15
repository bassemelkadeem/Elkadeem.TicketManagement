using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Elkadeem.TicketManagement.Infrastructure.Mail
{
    public class SendGridEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SendGridEmailService(IOptions<EmailSettings> mailSettings)
        {
            if (mailSettings is null)
            {
                throw new ArgumentNullException(nameof(mailSettings));
            }

            _emailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
