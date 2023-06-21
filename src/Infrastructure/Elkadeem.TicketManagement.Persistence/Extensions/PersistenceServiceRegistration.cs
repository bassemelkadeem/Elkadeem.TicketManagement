using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using Elkadeem.TicketManagement.Persistence.DbContexts.Courses;
using Elkadeem.TicketManagement.Persistence.DbContexts.Dishes;
using Elkadeem.TicketManagement.Persistence.DbContexts.Tickets;
using Elkadeem.TicketManagement.Persistence.Repository.Dishes;
using Elkadeem.TicketManagement.Persistence.Repository.Tickets;
using Elkadeem.TicketManagement.Persistence.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Elkadeem.TicketManagement.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ITicketDbContext, TicketDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();



            // Dishes db context 
            services.AddScoped<IDishesDbContext, DishesDbContext>();
            services.AddScoped<IIngredientsRepository, IngredientsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

            // Courses db context
            services.AddScoped<ICourseLibraryDbContext, CourseLibraryDbContext>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            return services;
        }
    }
}
