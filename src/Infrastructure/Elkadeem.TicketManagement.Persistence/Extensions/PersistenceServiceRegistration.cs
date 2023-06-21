using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Persistence.Dishes;
using Elkadeem.TicketManagement.Persistence.Repository;
using Elkadeem.TicketManagement.Persistence.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Elkadeem.TicketManagement.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            // Dishes db context 
            services.AddScoped<IDishesDatabaseContext, DishesDatabaseContext>();
            services.AddScoped<IIngredientsRepository, IngredientsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

            return services;
        }
    }
}
