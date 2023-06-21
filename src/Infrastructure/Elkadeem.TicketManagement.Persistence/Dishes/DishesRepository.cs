﻿using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using Elkadeem.TicketManagement.Domain.Dishes;

namespace Elkadeem.TicketManagement.Persistence.Dishes
{
    public class DishesRepository : DishesBaseRepository<Dish>, IDishesRepository
    {
        public DishesRepository(IDishesDatabaseContext dishesDatabaseContext) :
            base(dishesDatabaseContext)
        {
        }
    }
}