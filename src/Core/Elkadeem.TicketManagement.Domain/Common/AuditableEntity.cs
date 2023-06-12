namespace Elkadeem.TicketManagement.Domain.Common
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}
