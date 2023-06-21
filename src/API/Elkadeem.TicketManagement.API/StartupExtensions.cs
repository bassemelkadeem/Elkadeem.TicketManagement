using Elkadeem.TicketManagement.Application.Extensions;
using Elkadeem.TicketManagement.Infrastructure.Extensions;
using Elkadeem.TicketManagement.Persistence.DbContexts;
using Elkadeem.TicketManagement.Persistence.Extensions;

namespace Elkadeem.TicketManagement.API
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "1.0",
                    Title = "Elkadeem Ticket Management API"
                });

                //options.OperationFilter<FileResultContentTypeOperationFilter>();
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Elkadeem Ticket Management API");
                });
            }

            app.UseHttpsRedirection();
            app.UseCors("Open");
            app.MapControllers();
            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var dbContext = scope.ServiceProvider.GetService<ITicketDbContext>();
                if (dbContext != null)
                {
                    await dbContext.EnsureDeleteAsync();
                    await dbContext.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                if (logger != null)
                {
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
        }
    }
}
