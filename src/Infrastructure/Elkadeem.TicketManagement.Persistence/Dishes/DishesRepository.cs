using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Dishes
{
    public partial class DishesRepository : IDishesRepository
    {
        private readonly IDishesDatabaseContext _databaseContext;

        public DishesRepository(IDishesDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }
    }
}
