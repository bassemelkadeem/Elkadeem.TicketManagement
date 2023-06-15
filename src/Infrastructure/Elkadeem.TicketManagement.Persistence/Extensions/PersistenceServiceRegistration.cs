using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Persistence.Repository;
using Elkadeem.TicketManagement.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elkadeem.TicketManagement.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddDbContext<DatabaseContext>(options =>
            //{
            //    var connectionString = configuration.GetConnectionString("ElkadeemTicketConnectionString");
            //    if (string.IsNullOrWhiteSpace(connectionString))
            //    {
            //        throw new NullReferenceException(nameof(connectionString) + " not found in appsettings.json");
            //    }

            //    options.UseSqlServer(connectionString);
            //    options.EnableSensitiveDataLogging();
            //});

            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
