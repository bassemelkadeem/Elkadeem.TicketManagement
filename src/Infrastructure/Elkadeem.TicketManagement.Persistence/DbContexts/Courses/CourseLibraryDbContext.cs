using Elkadeem.TicketManagement.Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts.Courses
{
    public class CourseLibraryDbContext : BaseDbContext, ICourseLibraryDbContext
    {
        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<Author> Authors { get; set; } = default!;
    }
}
