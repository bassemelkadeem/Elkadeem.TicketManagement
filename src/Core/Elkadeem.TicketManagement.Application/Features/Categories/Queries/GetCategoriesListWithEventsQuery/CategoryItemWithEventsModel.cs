namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery
{
    public class CategoryItemWithEventsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<EventItemModel> Events { get; set; } = default!;
    }
}
