using Elkadeem.TicketManagement.Domain.Common;

namespace Elkadeem.TicketManagement.Domain.Orders
{
    public partial class Order : AuditableEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public bool OrderPaid { get; set; }
    }
}
