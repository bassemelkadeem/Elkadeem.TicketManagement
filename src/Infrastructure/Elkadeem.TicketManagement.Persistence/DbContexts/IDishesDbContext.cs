using Elkadeem.TicketManagement.Domain.Dishes;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts
{
    public partial interface IDishesDbContext : IBaseDbContext
    {
        DbSet<Dish> Dishes { get; set; }

        DbSet<Ingredient> Ingredients { get; set; }
    }
}
