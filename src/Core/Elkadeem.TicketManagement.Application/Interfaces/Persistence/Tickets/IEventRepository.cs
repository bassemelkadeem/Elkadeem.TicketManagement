using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Domain.Events;

namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets
{
    public partial interface IEventRepository : IRepository<Event>
    {
        Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime date);
    }
}
