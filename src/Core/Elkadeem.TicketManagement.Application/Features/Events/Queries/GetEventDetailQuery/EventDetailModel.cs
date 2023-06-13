namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventDetailQuery
{
    public class EventDetailModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public string Artist { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }

        public CategoryItemModel Category { get; set; } = default!;
    }
}
