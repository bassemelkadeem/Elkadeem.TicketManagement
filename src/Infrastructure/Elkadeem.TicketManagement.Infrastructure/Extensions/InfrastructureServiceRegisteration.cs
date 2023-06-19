using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Export;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail.Models;
using Elkadeem.TicketManagement.Infrastructure.Export;
using Elkadeem.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elkadeem.TicketManagement.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(cofig =>
            {
                var section = configuration.GetSection("EmailSettings");
                if (section != null)
                {
                    cofig.ApiKey = section["ApiKey"]!;
                    cofig.FromAddress = section["FromAddress"]!;
                    cofig.FromName = section["FromName"]!;
                }
            });

            services.AddTransient<IEmailService, SendGridEmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
