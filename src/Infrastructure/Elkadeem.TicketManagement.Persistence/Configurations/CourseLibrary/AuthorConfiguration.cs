using Elkadeem.TicketManagement.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elkadeem.TicketManagement.Persistence.Configurations.CourseLibrary
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.MainCategory)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.DateOfBirth)
                .IsRequired();

            builder.HasMany(x => x.Courses)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId);
        }
    }
}
