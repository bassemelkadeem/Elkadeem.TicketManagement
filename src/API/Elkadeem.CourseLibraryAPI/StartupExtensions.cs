using Elkadeem.TicketManagement.Persistence.DbContexts;

namespace Elkadeem.CourseLibraryAPI
{
    public static class StartupExtensions
    {
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var dbContext = scope.ServiceProvider.GetService<IDishesDbContext>();
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
