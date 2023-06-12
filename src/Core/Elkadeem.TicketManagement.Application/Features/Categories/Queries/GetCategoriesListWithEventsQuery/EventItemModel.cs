namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery
{
    public class EventItemModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public string Artist { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public Guid CategoryId { get; set; }
    }
}
