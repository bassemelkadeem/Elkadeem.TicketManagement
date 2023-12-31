﻿using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared;
using Elkadeem.TicketManagement.Domain.Dishes;

namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes
{
    public interface IIngredientsRepository : IRepository<Ingredient>
    {
    }
}
