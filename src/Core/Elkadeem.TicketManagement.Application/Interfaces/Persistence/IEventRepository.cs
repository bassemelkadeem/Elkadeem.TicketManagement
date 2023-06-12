using Elkadeem.TicketManagement.Domain.Events;

namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public partial interface IEventRepository : IRepository<Event>
    {
    }
}
