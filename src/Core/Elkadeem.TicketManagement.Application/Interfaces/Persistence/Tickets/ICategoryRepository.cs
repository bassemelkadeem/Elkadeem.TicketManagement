using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Domain.Events;

namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllCategoriesWithEventsAsync(bool inCludeHistory);
    }
}
