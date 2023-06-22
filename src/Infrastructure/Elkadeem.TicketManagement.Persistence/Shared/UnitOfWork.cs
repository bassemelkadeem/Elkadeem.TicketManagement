using Elkadeem.TicketManagement.Application.Interfaces.Persistence;

namespace Elkadeem.TicketManagement.Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _databaseContext;

        public UnitOfWork(IDatabaseContext databaseContext)
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
