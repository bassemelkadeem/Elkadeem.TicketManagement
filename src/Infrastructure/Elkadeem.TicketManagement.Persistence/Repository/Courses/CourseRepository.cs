using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using Elkadeem.TicketManagement.Domain.Courses;
using Elkadeem.TicketManagement.Persistence.DbContexts.Courses;

namespace Elkadeem.TicketManagement.Persistence.Repository.Courses
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ICourseLibraryDbContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
