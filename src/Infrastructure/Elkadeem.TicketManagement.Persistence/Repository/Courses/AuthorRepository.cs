using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using Elkadeem.TicketManagement.Domain.Courses;
using Elkadeem.TicketManagement.Persistence.DbContexts;

namespace Elkadeem.TicketManagement.Persistence.Repository.Courses
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(IBaseDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
