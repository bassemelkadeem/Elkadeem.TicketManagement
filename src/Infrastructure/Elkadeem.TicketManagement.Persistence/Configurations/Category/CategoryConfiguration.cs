using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elkadeem.TicketManagement.Persistence.Configurations.Category
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Events.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Events.Category> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
