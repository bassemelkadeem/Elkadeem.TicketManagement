namespace Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery.Dtos
{
    public class DishListItemDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
