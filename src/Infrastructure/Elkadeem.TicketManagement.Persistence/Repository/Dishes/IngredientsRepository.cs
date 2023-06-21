using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Domain.Dishes;
using Elkadeem.TicketManagement.Persistence.DbContexts.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Repository.Dishes
{
    public class IngredientsRepository : DishesBaseRepository<Ingredient>, IIngredientsRepository
    {
        public IngredientsRepository(IDishesDbContext dishesDatabaseContext)
            : base(dishesDatabaseContext)
        {
        }
    }
}
