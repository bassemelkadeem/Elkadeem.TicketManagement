﻿using Elkadeem.TicketManagement.Domain.Orders;

namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size);

        Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
    }
}
