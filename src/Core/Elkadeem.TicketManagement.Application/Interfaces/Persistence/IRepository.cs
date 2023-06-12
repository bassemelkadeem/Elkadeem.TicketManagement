﻿namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);

        IReadOnlyList<T> GetAll();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<T> GetByIdAsync(object id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
