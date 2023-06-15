using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail.Models;

namespace Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
