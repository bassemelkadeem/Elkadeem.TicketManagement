using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery.Dtos;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Dishes;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery
{
    public class GetDishesListQueryHandler : IRequestHandler<GetDishesListQuery, List<DishListItemDto>>
    {
        private readonly IDishesRepository _dishesRepository;
        private readonly IMapper _mapper;

        public GetDishesListQueryHandler(IDishesRepository dishesRepository, IMapper mapper)
        {
            _dishesRepository = dishesRepository ?? throw new ArgumentNullException(nameof(dishesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DishListItemDto>> Handle(GetDishesListQuery request, CancellationToken cancellationToken)
        {
            var dishes = await _dishesRepository.GetAllAsync();
            var mappedDishes = _mapper.Map<List<DishListItemDto>>(dishes);
            return mappedDishes;
        }
    }
}
