using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Domain.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Dishes
{
    public class IngredientsRepository : DishesBaseRepository<Ingredient>, IIngredientsRepository
    {
        public IngredientsRepository(IDishesDatabaseContext dishesDatabaseContext)
            : base(dishesDatabaseContext)
        {
        }
    }
}
