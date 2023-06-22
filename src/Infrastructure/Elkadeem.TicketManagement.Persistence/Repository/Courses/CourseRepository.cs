using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using Elkadeem.TicketManagement.Domain.Courses;
using Elkadeem.TicketManagement.Persistence.DbContexts.Courses;

namespace Elkadeem.TicketManagement.Persistence.Repository.Courses
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ICourseLibraryDbContext _dbContext;

        public CourseRepository(ICourseLibraryDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
