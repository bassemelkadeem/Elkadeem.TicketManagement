using Elkadeem.TicketManagement.Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace Elkadeem.TicketManagement.Persistence.DbContexts
{
    public partial interface ICourseLibraryDbContext : IBaseDbContext
    {
        DbSet<Course> Courses { get; set; }

        DbSet<Author> Authors { get; set; }
    }
}
