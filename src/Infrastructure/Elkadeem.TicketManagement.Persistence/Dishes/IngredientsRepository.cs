using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Dishes
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly IDishesDatabaseContext _databaseContext;

        public IngredientsRepository(IDishesDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }
    }
}
