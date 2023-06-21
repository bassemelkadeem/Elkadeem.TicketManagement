using Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery.Dtos;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery
{
    public class GetDishesListQuery : IRequest<List<DishListItemDto>>
    {
    }
}
