using Elkadeem.TicketManagement.Domain.Dishes;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Dishes
{
    public class DishesDatabaseContext : DbContext, IDishesDatabaseContext
    {
        public DishesDatabaseContext()
        {

        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
