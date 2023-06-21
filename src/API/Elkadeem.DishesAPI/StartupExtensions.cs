using Elkadeem.TicketManagement.Persistence.Dishes;

namespace Elkadeem.DishesAPI
{
    public static class StartupExtensions
    {
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var dbContext = scope.ServiceProvider.GetService<IDishesDatabaseContext>();
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
