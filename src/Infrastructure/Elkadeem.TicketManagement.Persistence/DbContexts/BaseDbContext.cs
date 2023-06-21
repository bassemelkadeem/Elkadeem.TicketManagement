using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts
{
    public class BaseDbContext : DbContext, IBaseDbContext
    {
        public virtual Task EnsureDeleteAsync()
        {
            return Database.EnsureDeletedAsync();
        }

        public virtual Task MigrateAsync()
        {
            return Database.MigrateAsync();
        }

        public virtual int Save()
        {
            return SaveChanges();
        }

        public virtual Task<int> SaveAsync()
        {
            return SaveChangesAsync();
        }

        public virtual new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
