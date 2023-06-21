using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Persistence.DbContexts.Dishes;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository.Dishes
{
    public class DishesBaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IDishesDbContext _databaseContext;

        public DishesBaseRepository(IDishesDbContext dishesDatabaseContext)
        {
            _databaseContext = dishesDatabaseContext ?? throw new ArgumentNullException(nameof(dishesDatabaseContext));
        }

        public void Add(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = await _databaseContext.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public void Delete(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _databaseContext.Set<T>().ToListAsync();
        }

        public T GetById(object id)
        {
            return _databaseContext.Set<T>().Find(id)!;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return (await _databaseContext.Set<T>().FindAsync(id))!;
        }

        public void Update(T entity)
        {
            _databaseContext.Set<T>().Update(entity);
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
