using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Persistence.Shared;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
            if (databaseContext is null)
            {
                throw new ArgumentNullException(nameof(databaseContext));
            }
        }

        public async Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime date)
        {
            var isMatch = await _databaseContext.Events.AnyAsync(a => a.Name.Equals(name) && a.Date.Date.Equals(date.Date));
            return isMatch;
        }
    }
}
