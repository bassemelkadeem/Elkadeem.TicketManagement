using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts.Tickets
{
    public partial interface ITicketDbContext : IBaseDbContext
    {
        DbSet<Event> Events { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Order> Orders { get; set; }
    }
}
