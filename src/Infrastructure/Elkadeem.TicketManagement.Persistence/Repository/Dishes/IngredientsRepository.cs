using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Domain.Dishes;
using Elkadeem.TicketManagement.Persistence.DbContexts.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Repository.Dishes
{
    public class IngredientsRepository : BaseRepository<Ingredient>, IIngredientsRepository
    {
        private readonly IDishesDbContext _dbContext;

        public IngredientsRepository(IDishesDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
