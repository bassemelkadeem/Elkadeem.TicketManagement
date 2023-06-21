using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts
{
    public partial interface IBaseDbContext
    {
        Task EnsureDeleteAsync();

        Task MigrateAsync();

        int Save();

        Task<int> SaveAsync();

        DbSet<T> Set<T>() where T : class;
    }
}
