using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Shared
{
    public interface IDatabaseContext
    {
        DbSet<Event> Events { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveAsync(CancellationToken cancellationToken = new CancellationToken());

        int Save();

        Task EnsureDeleteAsync();

        Task MigrateAsync();
    }
}
