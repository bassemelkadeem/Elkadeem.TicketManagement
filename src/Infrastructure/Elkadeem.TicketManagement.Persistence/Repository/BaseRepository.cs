using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IBaseDbContext _dbContext;

        public BaseRepository(IBaseDbContext databaseContext)
        {
            _dbContext = databaseContext
                ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T GetById(object id)
        {
            return _dbContext.Set<T>().Find(id)!;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return (await _dbContext.Set<T>().FindAsync(id))!;
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
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
