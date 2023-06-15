using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elkadeem.TicketManagement.Persistence.Configurations.Event
{
    public class EventConfiguration : IEntityTypeConfiguration<Domain.Events.Event>
    {
        public void Configure(EntityTypeBuilder<Domain.Events.Event> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
