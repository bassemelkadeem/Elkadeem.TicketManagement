using Elkadeem.TicketManagement.Domain.Dishes;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Dishes
{
    public partial interface IDishesDatabaseContext
    {
        DbSet<Dish> Dishes { get; set; }

        DbSet<Ingredient> Ingredients { get; set; }
    }
}
