using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Persistence.Shared;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
            if (databaseContext is null)
            {
                throw new ArgumentNullException(nameof(databaseContext));
            }
        }

        public async Task<IReadOnlyList<Category>> GetAllCategoriesWithEventsAsync(bool inCludeHistory)
        {
            var allCategories = await _databaseContext.Categories.Include(a => a.Events).ToListAsync();
            if (!inCludeHistory)
            {
                allCategories.ForEach(c =>
                {
                    c.Events.ToList().RemoveAll(a => a.Date < DateTime.Today);
                });
            }

            return allCategories;
        }
    }
}
