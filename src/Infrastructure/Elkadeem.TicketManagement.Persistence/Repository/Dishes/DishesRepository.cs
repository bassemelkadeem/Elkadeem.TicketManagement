using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Domain.Dishes;
using Elkadeem.TicketManagement.Persistence.DbContexts.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Repository.Dishes
{
    public class DishesRepository : DishesBaseRepository<Dish>, IDishesRepository
    {
        public DishesRepository(IDishesDbContext dishesDatabaseContext) :
            base(dishesDatabaseContext)
        {
        }
    }
}
