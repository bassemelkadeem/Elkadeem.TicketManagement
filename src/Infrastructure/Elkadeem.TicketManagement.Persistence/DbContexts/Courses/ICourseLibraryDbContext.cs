using Elkadeem.TicketManagement.Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts.Courses
{
    public partial interface ICourseLibraryDbContext : IBaseDbContext
    {
        DbSet<Course> Courses { get; set; }

        DbSet<Author> Authors { get; set; }
    }
}
