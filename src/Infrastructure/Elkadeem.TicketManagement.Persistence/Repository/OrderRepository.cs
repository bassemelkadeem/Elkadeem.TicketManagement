﻿using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Domain.Orders;
using Elkadeem.TicketManagement.Persistence.Shared;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
            if (databaseContext is null)
            {
                throw new ArgumentNullException(nameof(databaseContext));
            }
        }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _databaseContext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _databaseContext.Orders
                .CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }
    }
}
