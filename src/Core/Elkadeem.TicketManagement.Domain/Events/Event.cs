using Elkadeem.TicketManagement.Domain.Common;

namespace Elkadeem.TicketManagement.Domain.Events
{
    public partial class Event : AuditableEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? Artist { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = default!;
    }
}
