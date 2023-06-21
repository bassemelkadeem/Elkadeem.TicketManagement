using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Persistence.DbContexts;

namespace Elkadeem.TicketManagement.Persistence.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ITicketDbContext _databaseContext;

        public EfUnitOfWork(ITicketDbContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public int Save()
        {
            return _databaseContext.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _databaseContext.SaveAsync();
        }
    }
}
