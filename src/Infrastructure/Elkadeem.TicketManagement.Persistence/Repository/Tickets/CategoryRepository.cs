using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository.Tickets
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ITicketDbContext databaseContext)
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
                foreach (var cat in allCategories)
                {
                    var eventsToRemove = cat.Events.Where(a => a.Date < DateTime.Today);
                    foreach (var eventItem in eventsToRemove)
                    {
                        cat.Events.Remove(eventItem);
                    }
                }
            }

            return allCategories;
        }
    }
}
