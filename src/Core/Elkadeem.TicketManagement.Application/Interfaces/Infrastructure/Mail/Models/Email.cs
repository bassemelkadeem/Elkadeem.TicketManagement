﻿namespace Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail.Models
{
    public class Email
    {
        public string To { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public string Body { get; set; } = default!;
    }
}
