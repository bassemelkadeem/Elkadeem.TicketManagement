using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using Elkadeem.TicketManagement.Domain.Events;
using Elkadeem.TicketManagement.Persistence.DbContexts.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository.Tickets
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly ITicketDbContext _dbContext;

        public EventRepository(ITicketDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime date)
        {
            var isMatch = await _dbContext.Events.AnyAsync(a => a.Name.Equals(name) && a.Date.Date.Equals(date.Date));
            return isMatch;
        }
    }
}
