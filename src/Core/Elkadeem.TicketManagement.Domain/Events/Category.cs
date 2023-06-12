using Elkadeem.TicketManagement.Domain.Common;

namespace Elkadeem.TicketManagement.Domain.Events
{
    public partial class Category : AuditableEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = default!;
    }
}
