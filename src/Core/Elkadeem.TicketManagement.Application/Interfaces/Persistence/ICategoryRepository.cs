using Elkadeem.TicketManagement.Domain.Events;

namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllCategoriesWithEventsAsync(bool inCludeHistory);
    }
}
