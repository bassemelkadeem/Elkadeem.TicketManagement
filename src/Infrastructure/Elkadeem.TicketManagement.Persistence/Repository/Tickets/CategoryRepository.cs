using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Persistence.DbContexts.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository.Tickets
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ITicketDbContext _dbContext;

        public CategoryRepository(ITicketDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<Category>> GetAllCategoriesWithEventsAsync(bool inCludeHistory)
        {
            var allCategories = await _dbContext.Categories.Include(a => a.Events).ToListAsync();
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
