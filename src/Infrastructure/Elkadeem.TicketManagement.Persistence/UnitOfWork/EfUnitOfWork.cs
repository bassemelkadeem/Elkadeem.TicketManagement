using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Persistence.DbContexts;

namespace Elkadeem.TicketManagement.Persistence.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IBaseDbContext _dbContext;

        public EfUnitOfWork(IBaseDbContext databaseContext)
        {
            _dbContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public int Save()
        {
            return _dbContext.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveAsync();
        }
    }
}
